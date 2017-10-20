using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StormManager.UWP.Services.ResourceLoaderService
{
    public interface IResourceLoaderService
    {
        string Value(string name);
    }
}
