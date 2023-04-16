using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskOne.Shared
{
    public class windows
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int winId { get; set; }
        public Int64 orderid { get; set; }
        public string WindowName { get; set; }
        public string QuantityOfWindows { get; set; }
        public string TotalSubElements { get; set; }

        //public virtual Orders Orders { get; set; }

        [ForeignKey("winId")]
        public virtual ICollection<SubElement>? liSubElement { get; set; }

    }


}
