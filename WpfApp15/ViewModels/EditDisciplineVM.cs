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
    public class EditDisciplineVM : BaseVM
    {
        public Discipline EditDiscipline { get; }
        public CommandVM SaveDiscipline { get; set; }
        public Prepods DisciplinePrepod
        {
            get => disciplinePrepod;
            set
            {
                disciplinePrepod = value;
                Signal();
            }
        }

        public List<Prepods> Prepods { get; set; }

        private CurrentPageControl currentPageControl;
        private Prepods disciplinePrepod;

        public EditDisciplineVM(CurrentPageControl currentPageControl)
        {
            this.currentPageControl = currentPageControl;
            EditDiscipline = new Discipline();
            Init();
        }

        public EditDisciplineVM(Discipline editDiscipline, CurrentPageControl currentPageControl)
        {
            EditDiscipline = editDiscipline;
            this.currentPageControl = currentPageControl;
            Init();
            DisciplinePrepod = Prepods.FirstOrDefault(s => s.ID == editDiscipline.prepod_id);
        }

        private void Init()
        {
            Prepods = SqlModel.GetInstance().SelectPrepod();
            SaveDiscipline = new CommandVM(() => {
                if (DisciplinePrepod == null)
                {
                    System.Windows.MessageBox.Show("Нужно выбрать препода для продолжения");
                    return;
                }
                EditDiscipline.prepod_id = DisciplinePrepod.ID;
                var model = SqlModel.GetInstance();
                if (EditDiscipline.ID == 0)
                    model.Insert(EditDiscipline);
                else
                    model.Update(EditDiscipline);
                currentPageControl.SetPage(new ViewDisciplinePage(DisciplinePrepod));
            });
        }

    }
}
