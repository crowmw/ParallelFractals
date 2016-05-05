using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPI
{
    public class ComplexNumber
    {
        private decimal real;
        private decimal imaginary;

        public ComplexNumber()
        {
            real = 0;
            imaginary = 0;
        }

        public ComplexNumber(decimal real, decimal imaginary)
        {
            this.real = real;
            this.imaginary = imaginary;
        }

        public decimal Real
        {
            get
            {
                return real;
            }
            set
            {
                real = value;
            }
        }

        public decimal Imaginary
        {
            get
            {
                return imaginary;
            }
            set
            {
                imaginary = value;
            }
        }
    }
}
