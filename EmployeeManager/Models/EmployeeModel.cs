using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManager.Models
{
    public class EmployeeModel
    {
        public required string Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime Dob { get; set; }
        public string Role { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Status { get; set; }
    }
}
