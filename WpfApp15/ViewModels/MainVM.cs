using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using WpfApp15.Pages;
using WpfApp15.Tools;

namespace WpfApp15.ViewModels
{
    class MainVM : BaseVM
    {
        CurrentPageControl currentPageControl;

        public Page CurrentPage
        {
            get => currentPageControl.Page;
        }

        public CommandVM CreateGroup { get; set; }
        public CommandVM ViewGroups { get; set; }
        public CommandVM CreateStudent { get; set; }
        public CommandVM ViewStudents { get; set; }
        public CommandVM CreateCurator { get; set; }
        public CommandVM ViewCurator { get; set; }
        public CommandVM CreateSpecial { get; set; }
        public CommandVM ViewSpecial { get; set; }
        public CommandVM CreatePrepod { get; set; }
        public CommandVM ViewPrepod { get; set; }
        public CommandVM CreateDiscipline { get; set; }
        public CommandVM ViewDiscipline { get; set; }
        public CommandVM CreateJournal { get; set; }
        public CommandVM ViewJournal { get; set; }

        public MainVM()
        {
            currentPageControl = new CurrentPageControl();
            currentPageControl.PageChanged += CurrentPageControl_PageChanged;
            currentPageControl.SetPage(new OptionPage());
            CreateGroup = new CommandVM(() => {
                currentPageControl.SetPage(new EditGroupPage(new EditGroupVM(currentPageControl)));
            });
            ViewGroups = new CommandVM(() => {
                currentPageControl.SetPage(new ViewGroupsPage());
            });
            CreateStudent = new CommandVM(() => {
                currentPageControl.SetPage(new EditStudentPage(new EditStudentVM(currentPageControl)));
            });
            ViewStudents = new CommandVM(()=> {
                currentPageControl.SetPage(new ViewStudentsPage(null));
            });
            CreateCurator = new CommandVM(() => {
                currentPageControl.SetPage(new EditCuratorPage(new EditCuratorVM(currentPageControl)));
            });
            ViewCurator = new CommandVM(() => {
                currentPageControl.SetPage(new ViewCuratorPage());
            });
            CreateSpecial = new CommandVM(() => {
                currentPageControl.SetPage(new EditSpecialPage(new EditSpecialVM(currentPageControl)));
            });
            ViewSpecial = new CommandVM(() => {
                currentPageControl.SetPage(new ViewSpecialPage());
            });
            CreatePrepod = new CommandVM(() => {
                currentPageControl.SetPage(new EditPrepodPage(new EditPrepodVM(currentPageControl)));
            });
            ViewPrepod = new CommandVM(() => {
                currentPageControl.SetPage(new ViewPrepodPage());
            });
            CreateDiscipline = new CommandVM(() => {
                currentPageControl.SetPage(new EditDisciplinePage(new EditDisciplineVM(currentPageControl)));
            });
            ViewDiscipline = new CommandVM(() => {
                currentPageControl.SetPage(new ViewDisciplinePage(null));
            });
            CreateJournal = new CommandVM(() => {
                currentPageControl.SetPage(new EditJournalPage(new EditJournalVM(currentPageControl)));
            });
            ViewJournal = new CommandVM(() => {
                currentPageControl.SetPage(new ViewJournalPage(null));
            });
        }

        private void CurrentPageControl_PageChanged(object sender, EventArgs e)
        {
            Signal(nameof(CurrentPage));
        }
    }
}
