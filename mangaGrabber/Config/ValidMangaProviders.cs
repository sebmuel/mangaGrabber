using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mangaGrabber.Config
{
    public class ValidMangaProviders
    {
        public Provider[] Providers { get; set; }
    }

    public class Provider
    {
        public string Name { get; set; }
        public string Url { get; set; }
    }

    public class AppRoot
    {
        public string Root { get; set; }
    }
}
