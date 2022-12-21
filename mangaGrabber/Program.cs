using CommandLine;
using mangaGrabber.Commands;
using mangaGrabber.Config;
using mangaGrabber.MangaProviders;
using Microsoft.Extensions.Configuration;

namespace MangaGrabber
{
   public class Program
    {
        public static IConfigurationRoot Config { get; set; }
        public static MangaProviderFactory MangaProviderFactory { get; set; }


        public Program(IConfigurationRoot config, MangaProviderFactory mangaProviderFactory)
        {
            Config = config;
            MangaProviderFactory = mangaProviderFactory;
        }

        static void Main(string[] args)
        {
            Program App = new Program(new ConfigurationBuilder().SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("config.json").Build(),
                new MangaProviderFactory());

            // check if the root app folder exists and is writable
            App.Checkfolder();

            Parser.Default.ParseArguments<AddMangaCommand>(args).WithParsed(t => t.Execute(args));
        }

        private void Checkfolder()
        {
            string test = Config.GetSection(nameof(AppRoot)).Get<AppRoot>().Root;
            if (!Directory.Exists(test))
            {
               Directory.CreateDirectory(test);
            }
        }
    }
}