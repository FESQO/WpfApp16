using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp15.Tools;

namespace WpfApp15.DTO
{
    [Table("prepods")]
    public class Prepods : BaseDTO
    {
        [Column("firstName")]
        public string firstNameP { get; set; }
        [Column("lastName")]
        public string lastNameP { get; set; }
    }
}
