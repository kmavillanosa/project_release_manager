using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectReleaseManager.ViewModel.Models
{

    public enum ProjectType
    {
        Desktop,
        Web,
        API,
        Console,
        Mobile,
        Library,
        WorkerService,
    }

    public class Project : ModelBase
    {
        public string Name { get; set; }
        public ProjectType ProjectType { get; set; }
        public string DocumentationSource { get; set; }
        public string Description { get; set; }
        public IEnumerable<Release> Releases { get; set; }

    }
}
