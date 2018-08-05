using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StormManager.UWP.Services.SettingsServices
{
    public interface IPropertyMapping
    {
        IStoreConverter GetConverter(Type type);
    }
}
