using System;

namespace StormManager.UWP.Common
{
    // Source: https://github.com/Windows-XAML/Template10/blob/version_1.1.12/Template10%20(Library)/Common/TemplatePartNotFoundException.cs

    public class TemplatePartNotFoundException : Exception
    {
        public TemplatePartNotFoundException(string message) : base(message) { }
    }
}
