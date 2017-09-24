using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimplestSearchShortcut
{
    class rollBackUpException:Exception
    {
        public rollBackUpException(string message) :base(message)
        {
            
        }
    }
}
