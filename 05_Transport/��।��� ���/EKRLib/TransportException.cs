using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EKRLib
{
    class TransportException : ArgumentException
    {
        public TransportException(string message) : base(message) { }
    }
}
