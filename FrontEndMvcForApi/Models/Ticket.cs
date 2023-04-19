using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FrontEndMvcForApi.Models
{
    public class Ticket
    {
        public int id { get; set; }
        public string description { get; set; }
        public string title { get; set; }
        public int Departmentid { get; set; }
        public Department Department { get; set; }
        public ICollection<Developer> Developers { get; set; } = new HashSet<Developer>();
        public ICollection<Department> Departments { get; set; } = new HashSet<Department>();

    }
}
