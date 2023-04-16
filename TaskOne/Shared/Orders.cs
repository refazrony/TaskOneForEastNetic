using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskOne.Shared
{
    public class Orders
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Int64 orderid { get; set; }
        [Required]
        public string OrderName { get; set;}
        [Required]
        public string State { get; set;}


        [ForeignKey("orderid")]
        public virtual ICollection<windows>? liwindows { get; set; }

       
    }
}
