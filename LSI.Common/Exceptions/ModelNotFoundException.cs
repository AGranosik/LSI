using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LSI.Common.Exceptions
{
    public class ModelNotFoundException : Exception
    {
        public ModelNotFoundException()
        {

        }

        public ModelNotFoundException(string message) : base (message + "not found.")
        {

        }
    }
}
