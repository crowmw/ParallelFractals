using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MPI;
using MPI.Remoting;
using System.Collections;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;

namespace ParallelFractals
{
    public partial class Form1 : Form, IObserver
    {
        public Form1()
        {
            InitializeComponent();
        }

        MandelBrot mandelbrotSet = new MandelBrot();
        System.Diagnostics.Process mandelProcess = new System.Diagnostics.Process();
        TimeSpan duration = new TimeSpan(0);
        private void button1_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            iterationsTextBox.Enabled = false;
            processCountTextBox.Enabled = false;
            partitionTextBox.Enabled = false;
            durationCount.ForeColor = Color.Gray;
            statusLabel.Text = String.Format("Generowanie fraktala: MPI [ x: {0} / y: {1} ]", pictureBox.Width, pictureBox.Height);

            mandelbrotSet.Width = pictureBox.Width;
            mandelbrotSet.Height = pictureBox.Height;
            mandelbrotSet.MinNumber = new ComplexNumber(-2, -2);
            mandelbrotSet.MaxNumber = new ComplexNumber(2, 2);
            mandelbrotSet.IterationsNumber = Int32.Parse(iterationsTextBox.Text);
            mandelbrotSet.Theme = "colors.theme";

            var MPIPartitionSize = partitionTextBox.Text;

            mandelProcess.StartInfo.FileName = @".\Lib\mpiexec";
            mandelProcess.StartInfo.Arguments = String.Format(@"-n {0} .\MPI.exe {1} {2} {3} {4}", processCountTextBox.Text, mandelbrotSet.Width, mandelbrotSet.Height, mandelbrotSet.IterationsNumber, MPIPartitionSize);
            mandelProcess.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            mandelProcess.Start();

            mandelbrotSet.DrawMandelSetParallel(this);

            Console.WriteLine("Procesy MPI zakończyły zadanie");
            //button1.Enabled = true;
        }

        public delegate void ShowTimeDelegate();
        ShowTimeDelegate showDelegate;
        public void Notify(ArrayList points)
        {
            showDelegate = new ShowTimeDelegate(ShowTime);

            

            Bitmap bitmap = new Bitmap(pictureBox.Width, pictureBox.Height);
            foreach(PointSet result in points)
            {
                bitmap.SetPixel(result.W, result.H, mandelbrotSet.ColorPixel(result.Pixel));
            }

            Image image = bitmap;

            //pictureBox.BackColor = Color.Black;
            pictureBox.Image = image;
            this.Invoke(showDelegate);
        }

        public void ShowTime()
        {
            var startTime = mandelProcess.StartTime;
            var endTime = DateTime.Now;
            duration = endTime.Subtract(startTime);
            durationCount.Text = String.Format("{0:hh\\:mm\\:ss\\.fff}", duration);
            button1.Enabled = true;
            iterationsTextBox.Enabled = true;
            processCountTextBox.Enabled = true;
            partitionTextBox.Enabled = true;
            durationCount.ForeColor = Color.Green;
            statusLabel.Text = "Gotowy!";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            TcpChannel channel = new TcpChannel(8090);
            ChannelServices.RegisterChannel(channel, false);
        }
    }
}
