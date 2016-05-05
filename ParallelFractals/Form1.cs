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

namespace ParallelFractals
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string[] args = new string['a'];

            using (new MPI.Environment(ref args))
            {
                Console.WriteLine("HelloWorld from rank" + Communicator.world.Rank + "running on " + MPI.Environment.ProcessorName);
            }
        }
    }
}
