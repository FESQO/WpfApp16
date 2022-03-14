using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp15.Tools;

namespace WpfApp15.DTO
{
    [Table("curator")]
    public class curator : BaseDTO
    {
        [Column("firstName")]
        public string FirstNameC { get; set; }
        [Column("lastName")]
        public string LastNameC { get; set; }
        [Column("birthday")]
        public DateTime BirthdayC { get; set; }
    }
}
