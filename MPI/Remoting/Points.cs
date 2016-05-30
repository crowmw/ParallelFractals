using System;
using System.Collections;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;

namespace MPI.Remoting
{
    [Serializable]
    public class Points : MarshalByRefObject
    {

        public Points()
        {
        }

        public void SetMessage(ArrayList list)
        {
            Cache.GetInstance().MessageList = list;
        }

    }
}

