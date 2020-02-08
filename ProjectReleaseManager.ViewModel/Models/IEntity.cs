using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectReleaseManager.ViewModel.Models
{
    public interface IEntity
    {
        int Id { get; set; }
    }

    public abstract class ModelBase : IEntity, INotifyPropertyChanged
    {
        public int Id { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
