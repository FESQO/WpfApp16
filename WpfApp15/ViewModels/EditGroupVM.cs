using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp15.DTO;
using WpfApp15.Model;
using WpfApp15.Pages;
using WpfApp15.Tools;

namespace WpfApp15.ViewModels
{
    public class EditGroupVM : BaseVM
    {
        public Group EditGroup { get; set; }
        public CommandVM SaveGroup { get; set; }

        public List<curator> Curators { get; set; }
        public List<Specials> Specials { get; set; }

        public Specials GroupSpecials
        {
            get => groupSpecials;
            set
            {
                groupSpecials = value;
                Signal();
            }
        }
        public curator GroupCurator
        {
            get => groupCurator;
            set
            {
                groupCurator = value;
                Signal();
            }
        }

        private Specials groupSpecials;
        private curator groupCurator;

        private CurrentPageControl currentPageControl;
        public EditGroupVM(CurrentPageControl currentPageControl)
        {
            this.currentPageControl = currentPageControl;
            EditGroup = new Group();
            InitCommand();
        }
        public EditGroupVM(Group editGroup, CurrentPageControl currentPageControl)
        {
            this.currentPageControl = currentPageControl;
            EditGroup = editGroup;
            InitCommand();
        }

        private void InitCommand()
        {
            Curators = SqlModel.GetInstance().SelectCurator();
            Specials = SqlModel.GetInstance().SelectSpecial();
            if (GroupCurator == null || GroupSpecials == null)
            {
                System.Windows.MessageBox.Show("Нужно выбрать специальность/куратора для продолжения");
                return;
            }
            EditGroup.curator_id = GroupCurator.ID;
            EditGroup.special_id = GroupSpecials.ID;
            SaveGroup = new CommandVM(()=> {
                var model = SqlModel.GetInstance();
                if (EditGroup.ID == 0)
                    model.Insert(EditGroup);
                else
                    model.Update(EditGroup);
                currentPageControl.Back();
            });
        }

        

    }
}
