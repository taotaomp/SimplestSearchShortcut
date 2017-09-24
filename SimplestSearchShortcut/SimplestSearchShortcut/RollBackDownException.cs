using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimplestSearchShortcut
{
    class rollBackDownException:Exception
    {
        public rollBackDownException(string message) : base(message)
        {
            
        }
    }
}
