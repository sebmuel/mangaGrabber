using mangaGrabber.Config;
using MangaGrabber;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mangaGrabber.MangaProviders
{
    public class MangaProviderFactory
    {

      
        public IMangaProvider GetProvider(string providerName)
        {
            Provider providerSettings = Program.Config.GetSection(nameof(ValidMangaProviders)).Get<ValidMangaProviders>().Providers.First(p => p.Name == providerName);
            switch(providerName)
            {
                case "BlueLock":
                    return new BlueLock(providerSettings);
                default:
                    throw new NotSupportedException();
            }
        }
    }
}
