using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp15.DTO;
using WpfApp15.Model;

namespace WpfApp15.ViewModels
{
    public class ViewJournalVM : BaseVM
    {
        private Discipline selectedDiscipline;
        private List<Journal> journalBySelectedDiscipline;

        public List<Student> students { get; set; }

        public List<Discipline> Discipline { get; set; }
        public Discipline SelectedDiscipline
        {
            get => selectedDiscipline;
            set
            {
                selectedDiscipline = value;
                JournalBySelectedDiscipline = SqlModel.GetInstance().SelectJournalByDiscipline(selectedDiscipline);
                Signal();
            }
        }
        public List<Journal> JournalBySelectedDiscipline
        {
            get => journalBySelectedDiscipline;
            set
            {
                journalBySelectedDiscipline = value;
                Signal();
            }
        }
        public Journal SelectedJournal { get; set; }

        public ViewJournalVM(Discipline selectedDiscipline)
        {
            SqlModel sqlModel = SqlModel.GetInstance();
            Discipline = sqlModel.SelectDiscipline();
            SelectedDiscipline = Discipline.FirstOrDefault(s => s.ID == selectedDiscipline?.ID);
        }

    }
}
