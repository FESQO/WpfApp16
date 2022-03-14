using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp15.DTO;
using WpfApp15.Model;

namespace WpfApp15.ViewModels
{
    class ViewPrepodVM : BaseVM
    {
        public List<Prepods> prepods { get; set; }

        public ViewPrepodVM()
        {
            SqlModel sqlModel = SqlModel.GetInstance();
            prepods = sqlModel.SelectPrepod();
        }
    }
}
