using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectReleaseManager.ViewModel
{
    public class ModuleNavigatorDTO
    {
        public IModule Module { get; private set; }

        public ModuleNavigatorDTO(IModule module)
        {
            Module = module;
        }
    }
}
