using MPI;
using MPI.Remoting;
using System;
using System.Drawing;
using System.Runtime.Remoting;

namespace ParallelFractals
{
    public class MandelBrot
    {
        private int iterationsNumber;
        private int width;
        private int height;
        private ComplexNumber minNumber;
        private ComplexNumber maxNumber;
        private string theme;
        private string[] colorSet;

        public int IterationsNumber
        {
            get
            {
                return iterationsNumber;
            }
            set
            {
                iterationsNumber = value;
            }
        }

        public int Width
        {
            get
            {
                return width;
            }
            set
            {
                width = value;
            }
        }

        public int Height
        {
            get
            {
                return height;
            }
            set
            {
                height = value;
            }
        }

        public ComplexNumber MinNumber
        {
            get
            {
                return minNumber;
            }
            set
            {
                minNumber = value;
            }
        }

        public ComplexNumber MaxNumber
        {
            get
            {
                return maxNumber;
            }
            set
            {
                maxNumber = value;
            }
        }

        public string Theme
        {
            get
            {
                return theme;
            }
            set
            {
                theme = value;

                if (System.IO.File.Exists("Lib\\" + theme))
                {
                    System.IO.StreamReader reader = new System.IO.StreamReader("Lib\\" + theme);

                    
                    colorSet = reader.ReadToEnd().Replace("\r", "").Split('\n');

                    reader.Close();
                }
            }
        }

        public Bitmap DrawMandelSet()
        {
            Bitmap bitmap = new Bitmap(width, height);
            decimal scaleX = (maxNumber.Real - minNumber.Real) / width;
            decimal scaleY = (maxNumber.Imaginary - minNumber.Imaginary) / height;

            ComplexNumber c = new ComplexNumber();

            c.Real = minNumber.Real;
            for (int w = 0; w < width; w++)
            {
                c.Imaginary = minNumber.Imaginary;
                for (int h = 0; h < height; h++)
                {
                    int count = CalculatePixel(c);

                    PointSet point = new PointSet();
                    point.W = w;
                    point.H = h;
                    point.Pixel = count;

                    bitmap.SetPixel(w, h, ColorPixel(count));

                    c.Imaginary += scaleY;
                }

                c.Real += scaleX;
            }

            return bitmap;
        }

        private int CalculatePixel(ComplexNumber c)
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
            while ((lengthSqr < width) && (count < iterationsNumber));

            return count;
        }

        public Color ColorPixel(decimal number)
        {
            if (number < 0) return Color.Black;

            try
            {
                decimal percentage = number / iterationsNumber;

                int colorValue = ((int)(percentage * 255));

                if (colorSet != null && colorSet.Length > 0)
                {
                    string[] rgb = colorSet[colorValue].Split(' ');

                    if (rgb.Length == 3)
                    {
                        var color = Color.FromArgb(int.Parse(rgb[0]), int.Parse(rgb[1]), int.Parse(rgb[2]));
                        return color;
                    }
                    else
                    {
                        return Color.Black;
                    }
                }
                else
                {
                    return Color.Black;
                }
            }
            catch
            {
                throw new Exception("Coloring Pixel failed.");
            }
        }

        public void DrawMandelSetParallel(IObserver observer)
        {
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(Points), "MandelBrot", WellKnownObjectMode.SingleCall);
            Cache.Attach(observer);
        }
    }
}
