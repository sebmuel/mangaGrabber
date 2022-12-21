using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using CommandLine;
using mangaGrabber.Config;
using MangaGrabber;
using Microsoft.Extensions.Configuration;
using System.Net;
using HtmlAgilityPack;
using mangaGrabber.Helpers;
using mangaGrabber.MangaProviders;

namespace mangaGrabber.Commands
{
    
    [Verb("manga", HelpText = "Adds a Manga to Grabber")]
    public class AddMangaCommand : ICommand
    {
        private IConfigurationRoot Config { get; }
     

        public event EventHandler CanExecuteChanged;

        [Option('a', "add", Required = true, HelpText = "Url you want to add the manga from")]
        public string Manga { get; set; }

        public bool CanExecute(object parameter)
        {
            throw new NotImplementedException();
        }

        public void Execute(object parameter)
        {
            if (!Program.Config.GetSection(nameof(ValidMangaProviders)).Get<ValidMangaProviders>().Providers.Any(prov => prov.Name == Manga))
            {
                Console.WriteLine("The entered URL does not belong a valid Manga Provider");
                return;
            }

            IMangaProvider provider =  Program.MangaProviderFactory.GetProvider(Manga);
            bool success = provider.Sync();

        }

    }
}
