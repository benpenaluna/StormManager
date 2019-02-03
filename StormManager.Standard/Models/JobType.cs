using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using StormManager.Standard.Annotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace StormManager.Standard.Models
{
    public class JobType : INotifyPropertyChanged
    {
#region Mapped Properties
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsUsed { get; set; }
        public int NewJobArgb
        {
            get => NewJobColor.ToArgb();
            set => NewJobColor = Color.FromArgb(value);
        }
        public int AgingJobArgb
        {
            get => AgingJobColor.ToArgb();
            set => AgingJobColor = Color.FromArgb(value);
        }
#endregion

#region Not Mapped Properties
        public Color NewJobColor { get; set; }
        public Color AgingJobColor { get; set; }
#endregion 

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
