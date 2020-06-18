using StormManager.Standard.Annotations;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace StormManager.Standard.Models
{
    public class Location : INotifyPropertyChanged
    {
        public int Id { get; set; }
        public string Address { get; set; }
        public string CommonPlaceName { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
