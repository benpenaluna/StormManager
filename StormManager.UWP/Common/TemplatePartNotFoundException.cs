using System;

namespace StormManager.UWP.Common
{
    public class TemplatePartNotFoundException : Exception
    {
        public TemplatePartNotFoundException(string message) : base(message) { }
    }
}
