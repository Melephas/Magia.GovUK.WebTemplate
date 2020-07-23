using System.Collections.Generic;
using System.Text;
using Magia.GovUK.WebTemplate.Components;

namespace Magia.GovUK.WebTemplate.Pages
{
    public class IndexPage : IPage
    {
        private readonly List<IPageComponent> _components = new List<IPageComponent>
        {
            new MainComponent(new List<IPageComponent>
            {
                new HeaderComponent("Example Page"),
                new ContinueButtonComponent("#")
            })
        };
        public string GetHtml()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(BasePage.Header);

            foreach (IPageComponent pageComponent in _components)
            {
                sb.AppendLine(pageComponent.GetHtml());
            }
            
            sb.AppendLine(BasePage.Footer);

            return sb.ToString();
        }
    }
}
