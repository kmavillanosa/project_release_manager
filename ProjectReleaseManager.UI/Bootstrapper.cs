using Autofac;
using Caliburn.Micro;
using Caliburn.Micro.Autofac;
using ProjectReleaseManager.ViewModel.Members;
using ProjectReleaseManager.ViewModel.Members.Dialogs;
using ProjectReleaseManager.ViewModel.Members.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ProjectReleaseManager.UI
{
    public class Bootstrapper : AutofacBootstrapper<ShellViewModel>
    {
        public Bootstrapper()
        {
            Initialize();
        }


        protected override IEnumerable<Assembly> SelectAssemblies()
        {
            var assemblies = base.SelectAssemblies().ToList();
            assemblies.Add(typeof(ShellViewModel).GetTypeInfo().Assembly);

            return assemblies;
        }


        protected override void ConfigureContainer(ContainerBuilder builder)
        {
            base.ConfigureContainer(builder);

            builder
                .RegisterType<ProjectReleasesViewModel>()
                .As<IProjectReleasesViewModel>()
                .SingleInstance();
            
            builder
                .RegisterType<ProjectsViewModel>()
                .As<IProjectsViewModel>()
                .SingleInstance();

            builder
                .RegisterType<ManageProjectViewModel>()
                .As<IManageProjectViewModel>()
                .SingleInstance();

            builder
            .RegisterType<ManageProjectReleaseViewModel>()
            .As<IManageProjectReleaseViewModel>()
            .SingleInstance();
        }

        protected override void ConfigureBootstrapper()
        {
            base.ConfigureBootstrapper();
            EnforceNamespaceConvention = false;

            var mvvmconfig = new TypeMappingConfiguration
            {
                DefaultSubNamespaceForViews = "ProjectReleaseManager.UI.Views",
                DefaultSubNamespaceForViewModels = "ProjectReleaseManager.ViewModel.Members"
            };

            

            ViewLocator.ConfigureTypeMappings(mvvmconfig);
            ViewModelLocator.ConfigureTypeMappings(mvvmconfig);


        }

        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            DisplayRootViewFor<ShellViewModel>();
        }
    }
}
