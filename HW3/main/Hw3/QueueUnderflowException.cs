using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hw3
{
    public class QueueUnderflowException : SystemException
    {
        public QueueUnderflowException() : base()
        {
            
        }

        public QueueUnderflowException(String message) : base(message)
        {
         
        }

    }
}
