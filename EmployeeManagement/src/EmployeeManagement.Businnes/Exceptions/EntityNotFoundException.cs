using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Businnes.Exceptions
{
    public class EntityNotFoundException : NotFoundException
    {
        public EntityNotFoundException() : base("Entity not found") { }
        public EntityNotFoundException(string message) : base(message) { }
    }
}
