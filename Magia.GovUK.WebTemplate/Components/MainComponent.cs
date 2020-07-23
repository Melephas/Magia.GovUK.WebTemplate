using System.Collections.Generic;
using System.Text;

namespace Magia.GovUK.WebTemplate.Components
{
    public class MainComponent : IPageComponent
    {
        private List<IPageComponent> _components;

        public MainComponent(List<IPageComponent> subComponents)
        {
            _components = subComponents;
        }
        
        public string GetHtml()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<main class=\"govuk-main-wrapper govuk-main-wrapper--auto-spacing\" id=\"main-content\" role=\"main\">");

            foreach (IPageComponent pageComponent in _components)
            {
                sb.AppendLine(pageComponent.GetHtml());
            }
            
            sb.AppendLine("</main>");

            return sb.ToString();
        }
    }
}
