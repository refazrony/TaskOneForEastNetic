using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskOne.Shared
{
    public class SubElement
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int? SubElementID { get; set; }
        public int? winId { get; set; }
        public string? Type { get; set; }
        public int? Width { get; set; }
        public int? Height { get; set; }

        //public virtual windows Windows { get; set; }
    }
}
