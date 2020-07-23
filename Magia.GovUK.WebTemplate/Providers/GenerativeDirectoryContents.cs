using System.Collections;
using System.Collections.Generic;
using Microsoft.Extensions.FileProviders;

namespace Magia.GovUK.WebTemplate.Providers
{
    public class GenerativeDirectoryContents : IDirectoryContents
    {
        #region Members
        private readonly List<IFileInfo> _files;
        #endregion

        #region Properties
        public bool Exists { get; }
        #endregion
        
        #region Constructor
        public GenerativeDirectoryContents(in List<IFileInfo> files)
        {
            if (files.Count == 0)
            {
                Exists = false;
            }
            else
            {
                _files = files;
                Exists = true;
            }
        }
        #endregion
        
        #region Interface Implementation
        public IEnumerator<IFileInfo> GetEnumerator()
        {
            return _files.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        #endregion
    }
}
