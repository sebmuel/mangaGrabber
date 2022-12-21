using mangaGrabber.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mangaGrabber.MangaProviders
{
    internal class BlueLock : IMangaProvider
    {
        public Provider Provider { get; }

        public BlueLock(Provider provider)
        {
            Provider = provider;
        }

        public bool Sync()
        {
            return true;
        }
    }
}
