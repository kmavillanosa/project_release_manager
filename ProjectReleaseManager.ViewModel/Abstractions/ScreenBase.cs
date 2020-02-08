using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectReleaseManager.ViewModel
{
    public abstract class ScreenBase : Screen
    {
        public IEventAggregator EventAggregator { get; }

        public ScreenBase(IEventAggregator eventAggregator)
        {
            EventAggregator = eventAggregator;
            eventAggregator.Subscribe(this);
        }
    }
}
