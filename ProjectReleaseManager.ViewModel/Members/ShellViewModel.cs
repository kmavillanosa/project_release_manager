using Caliburn.Micro;
using ProjectReleaseManager.ViewModel.Members.Dialogs;
using ProjectReleaseManager.ViewModel.Members.Modules;
using ProjectReleaseManager.ViewModel.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectReleaseManager.ViewModel.Members
{
    public interface IShellViewModel
    {
        void ViewReleases(Project project);
        void CloseModal();
    }
    public class ShellViewModel : Conductor<IPage>,
        IShellViewModel,
        IHandle<ModuleNavigatorDTO>,
        IHandle<ModalNavigatorDTO>
    {
        public IEventAggregator EventAggregator { get; }
        public IProjectReleasesViewModel ProjectReleasesViewModel { get; }
        public IProjectsViewModel ProjectsViewModel { get; }
        public IManageProjectViewModel ManageProjectViewModel { get; }
        public IModal ActiveModalView { get; set; }
        public IModule ActiveModule { get; set; }
        public bool IsModalOpen { get; set; }


        public ShellViewModel(IEventAggregator eventAggregator,
            IProjectReleasesViewModel projectReleasesViewModel,
            IProjectsViewModel  projectsViewModel,
            IManageProjectViewModel manageProjectViewModel)
        {
            EventAggregator = eventAggregator;
            ProjectReleasesViewModel = projectReleasesViewModel;
            ProjectsViewModel = projectsViewModel;
            ManageProjectViewModel = manageProjectViewModel;


            EventAggregator.Subscribe(this);

            ActiveModule = ProjectsViewModel as IModule;
            ActiveModalView = ManageProjectViewModel as IModal;
        }

        public void ViewReleases(Project project)
        {
            ProjectReleasesViewModel.SelectedProject = project;
            ActiveModule = ProjectReleasesViewModel as IModule;
        }

        public void Handle(ModuleNavigatorDTO message)
        {
            ActiveModule = message.Module;
        }

        public void Handle(ModalNavigatorDTO message)
        {
            IsModalOpen = true;
            ActiveModalView = message.Modal;
        }

        public void CloseModal()
        {
            IsModalOpen = false;
        }
    }
}
