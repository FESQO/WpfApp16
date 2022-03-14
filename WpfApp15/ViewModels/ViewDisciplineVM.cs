using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp15.DTO;
using WpfApp15.Model;

namespace WpfApp15.ViewModels
{
    public class ViewDisciplineVM : BaseVM
    {
        private Prepods selectedPrepod;
        private List<Discipline> disciplinesBySelectedPrepods;

        public List<Prepods> Prepods { get; set; }
        public Prepods SelectedPrepod
        {
            get => selectedPrepod;
            set
            {
                selectedPrepod = value;
                DisciplinesBySelectedPrepod = SqlModel.GetInstance().SelectDisciplinesByPrepod(selectedPrepod);
                Signal();
            }
        }
        public List<Discipline> DisciplinesBySelectedPrepod
        {
            get => disciplinesBySelectedPrepods;
            set
            {
                disciplinesBySelectedPrepods = value;
                Signal();
            }
        }
        public Discipline SelectedDiscipline { get; set; }

        public ViewDisciplineVM(Prepods selectedPrepod)
        {
            SqlModel sqlModel = SqlModel.GetInstance();
            Prepods = sqlModel.SelectPrepod();
            SelectedPrepod = Prepods.FirstOrDefault(s => s.ID == selectedPrepod?.ID);
        }
    }
}
