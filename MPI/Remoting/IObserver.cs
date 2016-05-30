using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPI.Remoting
{
    public interface IObserver
    {
        void Notify(ArrayList points);
    }
}
