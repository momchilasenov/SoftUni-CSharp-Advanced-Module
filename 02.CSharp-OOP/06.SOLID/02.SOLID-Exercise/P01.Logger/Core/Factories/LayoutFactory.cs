using SOLID.Layouts;
using System;
using System.Collections.Generic;
using System.Text;

namespace SOLID.Core.Factories
{
    class LayoutFactory : ILayoutFactory
    {
        public ILayout CreateLayout(string template)
        {
            ILayout layout = null;

            switch (template)
            {
                case nameof(SimpleLayout):
                    layout = new SimpleLayout();
                    break;
                case nameof(XmlLayout):
                    layout = new XmlLayout();
                    break;
                case nameof(JsonLayout):
                    layout = new JsonLayout();
                    break;
            }

            return layout;
        }
    }
}
