using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using ProjectReleaseManager.ViewModel.Models;

namespace ProjectReleaseManager.ViewModel.Members.Dialogs
{
    public interface IManageProjectViewModel : IModal
    {
        event EventHandler<Project> OnProjectCreated;
        Project SelectedProject { get; set; }
        void Save();
    }
    public class ManageProjectViewModel : ScreenBase, IManageProjectViewModel
    {
        public DialogMode Mode { get; set; }

        public string  Title { get; set; } = "Add Title";
        public bool Locked { get; set; } = false;
        public Project SelectedProject { get; set; }
        public event EventHandler<Project> OnProjectCreated;

        public ManageProjectViewModel(IEventAggregator eventAggregator) 
            : base(eventAggregator)
        {

        }


        public void ResetView()
        {
            SelectedProject = new Project();
        }

        public void Save()
        {
            if(Mode == DialogMode.Add)
            {
                OnProjectCreated?.Invoke(this, SelectedProject);
            }
        }
    }
}
