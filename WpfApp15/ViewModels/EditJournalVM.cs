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
    public class EditJournalVM : BaseVM
    {
        public Journal EditJournal { get; }
        public CommandVM SaveJournal { get; set; }
        public Discipline JournalDiscipline
        {
            get => journalDiscipline;
            set
            {
                journalDiscipline = value;
                Signal();
            }
        }
        public Student JournalStudent
        {
            get => journalStudent;
            set
            {
                journalStudent = value;
                Signal();
            }
        }

        public List<Discipline> Discipline { get; set; }
        public List<Student> Student { get; set; }

        private CurrentPageControl currentPageControl;
        private Discipline journalDiscipline;
        private Student journalStudent;

        public EditJournalVM(CurrentPageControl currentPageControl)
        {
            this.currentPageControl = currentPageControl;
            EditJournal = new Journal();
            Init();
        }

        public EditJournalVM(Journal editJournal, CurrentPageControl currentPageControl)
        {
            EditJournal = editJournal;
            this.currentPageControl = currentPageControl;
            Init();
            JournalDiscipline = Discipline.FirstOrDefault(s => s.ID == editJournal.DisciplineId);
            JournalStudent = Student.FirstOrDefault(s => s.ID == editJournal.StudentId);
        }

        private void Init()
        {
            Discipline = SqlModel.GetInstance().SelectDiscipline();
            Student = SqlModel.GetInstance().SelectStudent();
            SaveJournal = new CommandVM(() => {
                if (JournalDiscipline == null || JournalStudent == null)
                {
                    System.Windows.MessageBox.Show("Нужно выбрать дисциплину/студента для продолжения");
                    return;
                }
                EditJournal.DisciplineId = JournalDiscipline.ID;
                EditJournal.StudentId = JournalStudent.ID;
                var model = SqlModel.GetInstance();
                if (EditJournal.ID == 0)
                    model.Insert(EditJournal);
                else
                    model.Update(EditJournal);
                currentPageControl.SetPage(new ViewJournalPage(JournalDiscipline));
            });
        }
    }
}
