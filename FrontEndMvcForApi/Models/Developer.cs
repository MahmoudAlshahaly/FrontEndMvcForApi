﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrontEndMvcForApi.Models
{
   public class Developer
    {
        public int id { get; set; }
        public string name { get; set; }
        public ICollection<Ticket> Tickets { get; set; } = new HashSet<Ticket>();

    }
}
