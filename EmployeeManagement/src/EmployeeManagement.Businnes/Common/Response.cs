using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Businnes.Common
{
    public class Response
    {
        public object? Entity { get; set; }
        public IEnumerable<object>? Entities { get; set; }
        public string Message { get; set; } = null!;

    }
}
