using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientManagementSystem
{
    class InvalidFormatExceptions: Exception
    {
        public InvalidFormatExceptions(string msg)
            :base(msg)
        {

        }
    }
}
