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
    public class EditSpecialVM
    {
        public Specials EditSpecial { get; set; }
        public CommandVM SaveSpecial { get; set; }

        private CurrentPageControl currentPageControl;
        public EditSpecialVM(CurrentPageControl currentPageControl)
        {
            this.currentPageControl = currentPageControl;
            EditSpecial = new Specials();
            InitCommand();
        }
        public EditSpecialVM(Specials editSpecial, CurrentPageControl currentPageControl)
        {
            this.currentPageControl = currentPageControl;
            EditSpecial = editSpecial;
            InitCommand();
        }

        private void InitCommand()
        {
            SaveSpecial = new CommandVM(() => {
                var model = SqlModel.GetInstance();
                if (EditSpecial.ID == 0)
                    model.Insert(EditSpecial);
                else
                    model.Update(EditSpecial);
                currentPageControl.Back();
            });
        }
    }
}
