using StormManager.Standard.Annotations;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace StormManager.Standard.Models
{
    public class Status : INotifyPropertyChanged
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool InUse { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
