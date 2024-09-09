using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataShelfMaster.Entities
{
    public class Student
    {
        [Key]
        public string Matric { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Turn { get; set; }
        public string Career { get; set; }
        public int Semester { get; set; }
}
}
