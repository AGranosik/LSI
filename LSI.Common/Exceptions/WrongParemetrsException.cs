using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LSI.Common.Exceptions
{
    public class WrongParemetrsException : Exception
    {
        public WrongParemetrsException()
        {

        }
        public WrongParemetrsException(string message) : base(message)
        {

        }
    }
}
