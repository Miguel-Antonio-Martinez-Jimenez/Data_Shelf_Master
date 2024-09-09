using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataShelfMaster.Entities
{
    public class Solicitude
    {
        [Key]
        public int IdSolicitude { get; set; }
        [ForeignKey("Students")]
        public string? FkMatric { get; set; }
        public Student Students { get; set; }
        [ForeignKey("Books")]
        public string? FkISBN { get; set; }
        public Book Books { get; set; }
        public DateTime DateSolicitude { get; set; }
        public string Observation { get; set; }
        public string Status { get; set; }
        public DateTime DateDevolution { get; set; }
    }
}
