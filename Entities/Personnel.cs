using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataShelfMaster.Entities
{
    public class Personnel
    {
        [Key]
        public int IdPersonnel { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        [ForeignKey("Roles")]
        public int? FkRole { get; set; }
        public Role Roles { get; set; }
    }
}
