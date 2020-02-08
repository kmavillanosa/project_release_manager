using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Caliburn.Micro;
using ProjectReleaseManager.ViewModel.Models;

namespace ProjectReleaseManager.ViewModel.Members.Dialogs
{
    public interface IManageProjectReleaseViewModel : IModal
    {
        event EventHandler<Release> OnReleaseCreated;
        Release SelectedRelease { get; set; }

        void AddNote();
        void RemoveNote(NoteItem noteItem);
        void Save();
        void FileDropped(DragEventArgs eventArgs);
        void FilePreviewDragEnter(DragEventArgs eventArgs);

    }
    public class ManageProjectReleaseViewModel : ScreenBase,
        IManageProjectReleaseViewModel
    {


        public event EventHandler<Release> OnReleaseCreated;
        public string Title { get; set; }
        public bool Locked { get; set; }
        public DialogMode Mode { get; set; }
        public Release SelectedRelease { get; set; }
        public ManageProjectReleaseViewModel(IEventAggregator eventAggregator) 
            : base(eventAggregator)
        {

        }

        public void ResetView()
        {
            SelectedRelease = new Release();
            SelectedRelease.ReleaseNotes = new ObservableCollection<NoteItem>();
            SelectedRelease.Files = new ObservableCollection<FileItem>();
        }

        public void AddNote()
        {
            SelectedRelease.ReleaseNotes.Add(new NoteItem() {Title ="asd" });
        }

        public void RemoveNote(NoteItem noteItem)
        {
           
        }

        public void Save()
        {

        }

        public void FilePreviewDragEnter(DragEventArgs e)
        {
            try
            {
                e.Handled = true;

            }
            catch
            {

            }
        }

        public void FileDropped(DragEventArgs e)
        {
            string[] fileList = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            SelectedRelease.Files = new ObservableCollection<FileItem>
                (fileList.Select(x => { return new FileItem() { Path = x }; }));
        }
    }
}
