using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Businnes.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException():base("not found exception"){}
        public NotFoundException(string message):base(message){}
    }
}
