using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp15.DTO;
using WpfApp15.Model;


namespace WpfApp15.ViewModels
{
    class ViewSpecialVM : BaseVM
    {
        public List<Specials> specials { get; set; }

        public ViewSpecialVM()
        {
            SqlModel sqlModel = SqlModel.GetInstance();
            specials = sqlModel.SelectSpecial();
        }
    }
}
