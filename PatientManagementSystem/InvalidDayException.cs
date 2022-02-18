using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientManagementSystem
{
    class InvalidDayException: Exception
    {
        public InvalidDayException(String msg)
            : base(msg)
        {

        }
    }
}
