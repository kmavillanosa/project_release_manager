using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectReleaseManager.ViewModel.Models
{
    public class Release : ModelBase
    {
        public string Version { get; set; }
        public string SavePath { get; set; }
        public ObservableCollection<FileItem> Files { get; set; }
        public string ReleaseDetails { get; set; }
        public ObservableCollection<NoteItem> ReleaseNotes { get; set; }
        public DateTime CompileDate { get; set; }
    }
}
