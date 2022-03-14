using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp15.DTO;
using WpfApp15.Model;

namespace WpfApp15.ViewModels
{
    class ViewCuratorVM : BaseVM
    {
        public List<curator> curators { get; set; }

        public ViewCuratorVM()
        {
            SqlModel sqlModel = SqlModel.GetInstance();
            curators = sqlModel.SelectCurator();
        }
    }
}
