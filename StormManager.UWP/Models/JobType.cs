using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StormManager.UWP.Models
{
    public class JobType : StormManager.Standard.Models.JobType
    {
        public Windows.UI.Color NewJobColorWindowUi
        {
            get => Windows.UI.Color.FromArgb(NewJobColor.A, NewJobColor.R, NewJobColor.G, NewJobColor.B);
            set => NewJobColor = Color.FromArgb(value.A, value.R, value.G, value.B);
        }

        public Windows.UI.Color AgingJobColorWindowUi
        {
            get => Windows.UI.Color.FromArgb(AgingJobColor.A, AgingJobColor.R, AgingJobColor.G, AgingJobColor.B);
            set => AgingJobColor = Color.FromArgb(value.A, value.R, value.G, value.B);
        }
    }
}
