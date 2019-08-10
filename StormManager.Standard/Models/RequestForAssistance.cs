using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using StormManager.Standard.Annotations;

namespace StormManager.Standard.Models
{
    public class RequestForAssistance : INotifyPropertyChanged
    {
        public string JobNumber { get; set; }
        public Location Location { get; set; }
        public DateTime NotificationTime { get; set; }
        public JobType JobType { get; set; }
        public int Priority { get; set; }
        public Status Status { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
