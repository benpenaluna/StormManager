using System.Collections.Generic;
using System.Linq;

namespace StormManager.UWP.Services.NavigationService
{
    // Source: https://github.com/Windows-XAML/Template10/blob/version_1.1.12/Template10%20(Library)/Services/NavigationService/NavigationServiceList.cs

    public class NavigationServiceList : List<INavigationService>
    {
        public INavigationService GetByFrameId(string frameId) => this.FirstOrDefault(x => x.FrameFacade.FrameId == frameId);
    }
}
