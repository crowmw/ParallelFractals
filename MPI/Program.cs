﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MPI;
using System.Collections;
using System.IO;
using MPI.Remoting;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;

namespace MPI
{
    class Program
    {
        static int height = 350;
        static int width = 450;

        static int partition = 1500;
        static int iterations = 100;

        static int minReal = -2;
        static int minImg = -2;
        static int maxReal = 2;
        static int maxImg = 2;

        static ComplexNumber minNumber = null;
        static ComplexNumber maxNumber = null;

        enum Tags
        {
            ROW_NUMBER = 0,
            RESULT = 1
        }

        static void Main(string[] args)
        {
            width = Int32.Parse(args[0]);
            height = Int32.Parse(args[1]);
            iterations = Int32.Parse(args[2]);
            partition = Int32.Parse(args[3]);

            minNumber = new ComplexNumber(minReal, minImg);
            maxNumber = new ComplexNumber(maxReal, maxImg);

            using (new MPI.Environment(ref args))
            {
                Mandlebrot();
            }
        }

        static void Mandlebrot()
        {
            Intracommunicator comm = Communicator.world;

            int processIncrement = (int)Math.Floor((double)height / (comm.Size - 1));

            if (comm.Rank == 0)
            {
                try
                {
                    Console.WriteLine("Proces GŁÓWNY Pracuje...");

                    int row = 0;
                    for (int i = 1; i < comm.Size; i++)
                    {
                        comm.Send(row, i, (int)Tags.ROW_NUMBER);
                        row += processIncrement;
                    }

                    ArrayList list = new ArrayList();
                    int max = (int)Math.Floor((double)width * height / partition);
                    for (int i = 0; i <= max+1; i++)
                    {
                        ArrayList partList = comm.Receive<ArrayList>(Communicator.anySource, (int)Tags.RESULT);
                        if (partList != null)
                        {
                            list.AddRange(partList);
                            Console.WriteLine("Proces GŁÓWNY dodał do listy " + i);
                        }
                    }

                    Points points;
                    TcpChannel channel = new TcpChannel();
                    ChannelServices.RegisterChannel(channel, false);

                    points = (Points)Activator.GetObject(typeof(Points), "tcp://localhost:8090/MandelBrot");

                    points.SetMessage(list);

                    Console.WriteLine("Zakończono obliczenia: " + list.Count + " punktów.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message + "\n ---------- \n" + ex.StackTrace);
                }
            }
            else
            {
                try
                {
                    Console.WriteLine("Proces " + comm.Rank + " pracuje...");

                    int row = comm.Receive<int>(0, (int)Tags.ROW_NUMBER);

                    decimal scaleX = (maxNumber.Real - minNumber.Real) / width;
                    decimal scaleY = (maxNumber.Imaginary - minNumber.Imaginary) / height;

                    ComplexNumber c = new ComplexNumber();

                    ArrayList list = new ArrayList();

                    c.Real = minNumber.Real;
                    for (int x = 0; x < width; x++)
                    {
                        c.Imaginary = minNumber.Imaginary + row * scaleY;
                        for(int y = row; y < (row + processIncrement); y++)
                        {
                            int count = CalculatePixel(c);

                            PointSet set = new PointSet();
                            set.W = x;
                            set.H = y;
                            set.Pixel = count;

                            list.Add(set);

                            c.Imaginary += scaleY;

                            if(list.Count == partition)
                            {
                                comm.Send<ArrayList>(list, 0, (int)Tags.RESULT);
                                list.Clear();
                            }
                        }
                        c.Real += scaleX;
                    }

                    if(list.Count > 0)
                    {
                        comm.Send<ArrayList>(list, 0, (int)Tags.RESULT);
                    }

                    Console.WriteLine("Proces "+comm.Rank+" zakończył liczenie");
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message + "\n--------------------\n" + ex.StackTrace);
                }
            }
        }

        private static int CalculatePixel(ComplexNumber c)
        {
            int count = 0;
            decimal temp;
            decimal lengthSqr = 0;

            ComplexNumber z = new ComplexNumber();

            do
            {
                temp = z.Real * z.Real - z.Imaginary * z.Imaginary + c.Real;
                z.Imaginary = 2 * z.Real * z.Imaginary + c.Imaginary;
                z.Real = temp;
                lengthSqr = z.Real * z.Real + z.Imaginary * z.Imaginary;
                count++;
            }
            while ((lengthSqr < width) && (count < iterations));
            return count;
        }
    }
}
