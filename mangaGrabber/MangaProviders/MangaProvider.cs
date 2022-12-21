using mangaGrabber.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mangaGrabber.MangaProviders
{
    public interface IMangaProvider
    { 
        public Provider Provider { get; }

        public bool Sync();
    }

}
