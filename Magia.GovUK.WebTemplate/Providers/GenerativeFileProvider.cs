using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Magia.GovUK.WebTemplate.Pages;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Primitives;

namespace Magia.GovUK.WebTemplate.Providers
{
    public class GenerativeFileProvider : IFileProvider
    {
        public IDirectoryContents GetDirectoryContents(string subpath)
        {
            Console.WriteLine($"=== GetDirectoryContents === Got path: {subpath} ===");
            Assembly[] asms  = AppDomain.CurrentDomain.GetAssemblies();
            List<Type> types = new List<Type>();

            foreach (Assembly assembly in asms) types.AddRange(assembly.GetTypes());

            IEnumerable<Type> filteredTypes =
                types.Where(type => string.Equals(type.Namespace, subpath, StringComparison.Ordinal))
                     .Where(type => type.GetInterfaces().Contains(typeof(IPage)));

            List<IFileInfo> pages = filteredTypes.Select(filteredType =>
                                                             new GenerativeFileInfo(
                                                                 (IPage) filteredType
                                                                        .GetConstructor(Type.EmptyTypes)
                                                                       ?.Invoke(null)
                                                             ) as IFileInfo
                                                        ).ToList();


            IDirectoryContents directoryContents = new GenerativeDirectoryContents(pages);

            return directoryContents.Exists ? directoryContents : new NotFoundDirectoryContents();
        }

        public IFileInfo GetFileInfo(string subpath)
        {
            Console.WriteLine($"=== GetFileInfo === Got path: {subpath} ===");

            if (subpath.StartsWith("/Views/Start/"))
            {
                int len = subpath.Length - 20;
                subpath = subpath.Substring(13, len);
                
                Console.WriteLine($"=== GetFileInfo === Trimmed path to: {subpath} ===");
            }

            if (Type.GetType(subpath) is null) return new GenerativeFileInfo(null);
            IPage page = (IPage) Type.GetType(subpath)?.GetConstructor(Type.EmptyTypes)?.Invoke(null);
            return new GenerativeFileInfo(page);
        }

        public IChangeToken Watch(string filter)
        {
            Console.WriteLine($"=== Got filter: {filter} ===");
            return NullChangeToken.Singleton;
        }
    }
}
