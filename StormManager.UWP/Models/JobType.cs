using StormManager.Standard.Annotations;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;

namespace StormManager.UWP.Models
{
    public class JobType : Standard.Models.JobType, INotifyPropertyChanged
    {
        public sealed override int Id
        {
            get => base.Id;
            set
            {
                base.Id = value;
                OnPropertyChanged(nameof(Id));
            }
        }

        public sealed override string Category
        {
            get => base.Category;
            set
            {
                base.Category = value;
                OnPropertyChanged(nameof(Category));
            }
        }

        public sealed override string SubCategory
        {
            get => base.SubCategory;
            set
            {
                base.SubCategory = value;
                OnPropertyChanged(nameof(SubCategory));
            }
        }

        public sealed override bool IsUsed
        {
            get => base.IsUsed;
            set
            {
                base.IsUsed = value;
                OnPropertyChanged(nameof(IsUsed));
            }
        }

        public sealed override int NewJobArgb
        {
            get => base.NewJobArgb;
            set
            {
                base.NewJobArgb = value;
                OnPropertyChanged(nameof(NewJobArgb));
            }
        }

        public sealed override int AgingJobArgb
        {
            get => base.AgingJobArgb;
            set
            {
                base.AgingJobArgb = value;
                OnPropertyChanged(nameof(AgingJobArgb));
            }
        }

        public Windows.UI.Color NewJobColorWindowUi
        {
            get => Windows.UI.Color.FromArgb(NewJobColor.A, NewJobColor.R, NewJobColor.G, NewJobColor.B);
            set
            {
                NewJobColor = Color.FromArgb(value.A, value.R, value.G, value.B);
                OnPropertyChanged(nameof(NewJobArgb));
            }
        }

        public Windows.UI.Color AgingJobColorWindowUi
        {
            get => Windows.UI.Color.FromArgb(AgingJobColor.A, AgingJobColor.R, AgingJobColor.G, AgingJobColor.B);
            set
            {
                AgingJobColor = Color.FromArgb(value.A, value.R, value.G, value.B);
                OnPropertyChanged(nameof(AgingJobArgb));
            }
        }

        public JobType()
        {
            IsUsed = true;

            // TODO: Consider making the default values configuarable at run--time
            NewJobColorWindowUi = Windows.UI.Color.FromArgb(255, 105, 105, 105);
            AgingJobColorWindowUi = Windows.UI.Color.FromArgb(0, 0, 0, 0);
        }

        public JobType(JobType jobType)
        {
            var jobTypeProperties = jobType.GetType().GetProperties();
            foreach (var prop in jobTypeProperties)
            {
                var jobTypePropValue = prop.GetValue(jobType);
                prop.SetValue(this, jobTypePropValue);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public override bool Equals(object obj)
        {
            return obj.GetType() == typeof(JobType) && Equals(obj as JobType);
        }

        protected bool Equals(JobType other)
        {
            return Id == other.Id &&
                   Category == other.Category &&
                   SubCategory == other.SubCategory &&
                   IsUsed == other.IsUsed &&
                   NewJobArgb == other.NewJobArgb &&
                   AgingJobArgb == other.AgingJobArgb &&
                   DateUpdated == other.DateUpdated &&
                   UpdatedBy == other.UpdatedBy;
        }

        public override int GetHashCode()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            var suggestionText = Category;
            if (!string.IsNullOrEmpty(SubCategory))
                suggestionText += ": " + SubCategory;

            return suggestionText;
        }
    }
}
