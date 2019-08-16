using System.Drawing;

namespace StormManager.Standard.Models
{
    public class JobType
    {
#region Mapped Properties
        public virtual int Id { get; set; }
        public virtual string Category { get; set; }
        public virtual string SubCategory { get; set; }
        public virtual bool IsUsed { get; set; }
        public virtual int NewJobArgb
        {
            get => NewJobColor.ToArgb();
            set => NewJobColor = Color.FromArgb(value);
        }
        public virtual int AgingJobArgb
        {
            get => AgingJobColor.ToArgb();
            set => AgingJobColor = Color.FromArgb(value);
        }
#endregion

#region Not Mapped Properties
        public Color NewJobColor { get; set; }
        public Color AgingJobColor { get; set; }
#endregion 
    }
}
