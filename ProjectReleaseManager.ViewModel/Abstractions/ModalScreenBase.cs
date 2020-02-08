using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;

namespace ProjectReleaseManager.ViewModel.Abstractions
{
    public abstract class ModalScreenBase : ScreenBase
    {
        public ModalScreenBase(IEventAggregator eventAggregator) 
            : base(eventAggregator)
        {
        }
    }
}
