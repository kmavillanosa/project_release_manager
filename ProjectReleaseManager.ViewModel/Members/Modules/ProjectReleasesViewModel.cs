using Caliburn.Micro;
using ProjectReleaseManager.ViewModel.Members.Dialogs;
using ProjectReleaseManager.ViewModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectReleaseManager.ViewModel.Members.Modules
{
    public interface IProjectReleasesViewModel : IModule
    {
        Project SelectedProject { get; set; }
        void GoHome();
        void NewRelease();
        void EditRelease(Release release);

    }
    public class ProjectReleasesViewModel : ScreenBase , IProjectReleasesViewModel
    {
        public IProjectsViewModel ProjectsViewModel { get; }
        public IManageProjectReleaseViewModel ManageProjectReleaseViewModel { get; }
        public Project SelectedProject { get; set; }

        public ProjectReleasesViewModel(
            IEventAggregator eventAggregator, 
            IProjectsViewModel projectsViewModel,
            IManageProjectReleaseViewModel manageProjectReleaseViewModel) 
            : base(eventAggregator)
        {
            ProjectsViewModel = projectsViewModel;
            ManageProjectReleaseViewModel = manageProjectReleaseViewModel;
        }


        public void GoHome()
        {
            EventAggregator
                .PublishOnBackgroundThread(new ModuleNavigatorDTO(ProjectsViewModel));
        }

        public void NewRelease()
        {
            ManageProjectReleaseViewModel.Title = "Add Project Release";
            ManageProjectReleaseViewModel.Mode = DialogMode.Add;
            ManageProjectReleaseViewModel.ResetView();
            EventAggregator
               .PublishOnBackgroundThread(new ModalNavigatorDTO(ManageProjectReleaseViewModel as IModal));
        }

        public void EditRelease(Release release)
        {
            
        }
    }
}
