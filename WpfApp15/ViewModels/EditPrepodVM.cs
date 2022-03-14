using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp15.DTO;
using WpfApp15.Model;
using WpfApp15.Tools;

namespace WpfApp15.ViewModels
{
    public class EditPrepodVM
    {
        public Prepods EditPrepod { get; set; }
        public CommandVM SavePrepod { get; set; }

        private CurrentPageControl currentPageControl;
        public EditPrepodVM(CurrentPageControl currentPageControl)
        {
            this.currentPageControl = currentPageControl;
            EditPrepod = new Prepods();
            InitCommand();
        }
        public EditPrepodVM(Prepods editPrepod, CurrentPageControl currentPageControl)
        {
            this.currentPageControl = currentPageControl;
            EditPrepod = editPrepod;
            InitCommand();
        }

        private void InitCommand()
        {
            SavePrepod = new CommandVM(() => {
                var model = SqlModel.GetInstance();
                if (EditPrepod.ID == 0)
                    model.Insert(EditPrepod);
                else
                    model.Update(EditPrepod);
                currentPageControl.Back();
            });
        }
    }
}
