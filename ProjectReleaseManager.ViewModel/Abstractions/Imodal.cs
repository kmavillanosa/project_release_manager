using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectReleaseManager.ViewModel
{
    public enum DialogMode
    {
        View, 
        Add,
        Edit,
        Delete
    }
    public interface IModal
    {
        string Title { get; set; }
        bool Locked { get; set; }
        DialogMode Mode { get; set; }

        void ResetView();
    }
}
