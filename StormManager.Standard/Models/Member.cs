using System.ComponentModel;
using System.Runtime.CompilerServices;
using StormManager.Standard.Annotations;

namespace StormManager.Standard.Models
{
   public class Member : INotifyPropertyChanged
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string Position { get; set; }
        public string Status { get; set; }
        public string EmailAddress { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
