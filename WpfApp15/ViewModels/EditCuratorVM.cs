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
    public class EditCuratorVM
    {
        public curator EditCurator { get; set; }
        public CommandVM SaveCurator { get; set; }

        private CurrentPageControl currentPageControl;
        public EditCuratorVM(CurrentPageControl currentPageControl)
        {
            this.currentPageControl = currentPageControl;
            EditCurator = new curator();
            InitCommand();
        }
        public EditCuratorVM(curator editCurator, CurrentPageControl currentPageControl)
        {
            this.currentPageControl = currentPageControl;
            EditCurator = editCurator;
            InitCommand();
        }

        private void InitCommand()
        {
            SaveCurator = new CommandVM(() => {
                var model = SqlModel.GetInstance();
                if (EditCurator.ID == 0)
                    model.Insert(EditCurator);
                else
                    model.Update(EditCurator);
                currentPageControl.Back();
            });
        }

    }
}
