using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectReleaseManager.ViewModel.Models
{
    public enum ChangeType
    {
        Feature = 0,
        BugFix = 1,
        MajorUpgrade = 2,
        Enhancement = 3,
    }
    public class NoteItem
    {
        public string Title { get; set; }
        public ChangeType Change { get; set; }
        public string Description { get; set; }
    }
}
