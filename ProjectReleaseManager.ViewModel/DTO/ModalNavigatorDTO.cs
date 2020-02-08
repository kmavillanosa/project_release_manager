using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectReleaseManager.ViewModel
{
    public class ModalNavigatorDTO
    {
        public IModal Modal { get; private set; }
        public ModalNavigatorDTO(IModal modal)
        {
            Modal = modal;
        }
    }
}
