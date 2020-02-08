using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using ProjectReleaseManager.ViewModel.Members.Dialogs;
using ProjectReleaseManager.ViewModel.Models;

namespace ProjectReleaseManager.ViewModel.Members.Modules
{
    public interface IProjectsViewModel : IModule
    {
        void NewProject();
        void EditProject(Project project);
        ObservableCollection<Project> Projects { get; set; }
    }
    public class ProjectsViewModel : ScreenBase, IProjectsViewModel
    {
        public ObservableCollection<Project> Projects { get; set; }
        public IManageProjectViewModel ManageProjectViewModel { get; }

        public ProjectsViewModel(IEventAggregator eventAggregator,
            IManageProjectViewModel manageProjectViewModel)
            : base(eventAggregator)
        {
            Projects = new ObservableCollection<Project>();
            ManageProjectViewModel = manageProjectViewModel;
            ManageProjectViewModel.OnProjectCreated += ManageProjectViewModel_OnProjectCreated;
        }

        private void ManageProjectViewModel_OnProjectCreated(object sender, Project e)
        {
            Projects.Add(e);
        }

        public void NewProject()
        {
            ManageProjectViewModel.Title = "Add Project";
            ManageProjectViewModel.ResetView();
            ManageProjectViewModel.Mode = DialogMode.Add;
            EventAggregator
                .PublishOnBackgroundThread(new ModalNavigatorDTO(ManageProjectViewModel as IModal));
        }

        public void EditProject(Project project)
        {
            ManageProjectViewModel.Title = "Edit Project";
            ManageProjectViewModel.SelectedProject = project;
            ManageProjectViewModel.Mode = DialogMode.Edit;
            EventAggregator
                .PublishOnBackgroundThread(new ModalNavigatorDTO(ManageProjectViewModel as IModal));
        }
    }
}
