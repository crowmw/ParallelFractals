using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPI.Remoting
{
    public class Cache
    {
        private static Cache myInstance;
        public static IObserver Observer;

        private Cache()
        {

        }

        public static void Attach(IObserver observer)
        {
            Observer = observer;
        }

        public static Cache GetInstance()
        {
            if (myInstance == null)
            {
                myInstance = new Cache();
            }
            return myInstance;
        }

        public ArrayList MessageList
        {
            set
            {
                Observer.Notify(value);
            }
        }
    }
}
