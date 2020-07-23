namespace Magia.GovUK.WebTemplate.Components
{
    public class HeaderComponent : IPageComponent
    {
        private readonly string _text;
        public HeaderComponent(string text)
        {
            _text = text;
        }
        public string GetHtml()
        {
            return $"<h1 class=\"govuk-panel__title\">{_text}</h1>";
        }
    }
}
