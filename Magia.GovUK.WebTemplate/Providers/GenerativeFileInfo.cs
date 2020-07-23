using System;
using System.IO;
using System.Text;
using Magia.GovUK.WebTemplate.Pages;
using Microsoft.Extensions.FileProviders;

namespace Magia.GovUK.WebTemplate.Providers
{
    public class GenerativeFileInfo : IFileInfo
    {
        private IPage _page;
        private readonly Stream _pageStream;
        
        public bool Exists { get; }
        public bool IsDirectory { get; }
        public DateTimeOffset LastModified { get; }
        public long Length { get; }
        public string Name { get; }
        public string PhysicalPath { get; }

        public GenerativeFileInfo(IPage page)
        {
            if (page is null)
            {
                Exists       = false;
                IsDirectory  = false;
                LastModified = DateTimeOffset.MinValue;
                Length       = 0;
                Name         = string.Empty;
                PhysicalPath = string.Empty;
            }
            else
            {
                _page        = page;
                _pageStream  = new MemoryStream(Encoding.UTF8.GetBytes(_page.GetHtml()));
                Exists       = true;
                IsDirectory  = false;
                LastModified = DateTimeOffset.MinValue;
                Length       = _pageStream.Length;
                Name         = page.GetType().FullName;
                PhysicalPath = page.GetType().FullName;
            }
        }
        
        public Stream CreateReadStream()
        {
            return _pageStream;
        }
    }
}
