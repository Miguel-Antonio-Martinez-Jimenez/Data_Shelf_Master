using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataShelfMaster.Entities
{
    public class Role
    {
        [Key]
        public int IdRole { get; set; }
        public string NameRole { get; set; }
    }
}
