﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Dto
{
    public class DepartmentDTO
    {
        public Guid id { get; set; }
        public string name { get; set; }
        public int numOfStaff { get; set; }
    }
}
