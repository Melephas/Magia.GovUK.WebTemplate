namespace Magia.GovUK.WebTemplate.Components
{
    public class ContinueButtonComponent : IPageComponent
    {
        private readonly string _path;
        public ContinueButtonComponent(string path)
        {
            _path = path;
        }
        public string GetHtml()
        {
            return $"<form href=\"{_path}\"><button class=\"govuk-button\" data-module=\"govuk-button\" type=\"submit\">Continue</button></form>";
        }
    }
}
