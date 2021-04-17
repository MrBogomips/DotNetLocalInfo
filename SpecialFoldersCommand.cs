using System;
using System.Text.RegularExpressions;
using McMaster.Extensions.CommandLineUtils;

namespace MrBogomips.Utils.DotNetLocalInfo
{
    [Command(
        Description="Show .NET Special Folders Path",
        ExtendedHelpText="Enumerates the actual values of the Environment.SpecialFolder Enum")]
    public class SpecialFoldersCommand
    {
        [Option("-f|--filter <REGEX>", Description = "Filter special folder names")]
        public string Filter {get;}
        [Option("--all", Description="Show all special folders including those without a value")]
        public bool All {get;}
        public void OnExecute(IConsole console) {
            Regex reFilter = null;
            if (!string.IsNullOrEmpty(Filter)) {
                reFilter = new Regex(Filter);
            }
            foreach (var i in Enum.GetValues<Environment.SpecialFolder>())
            {
                var name = Enum.GetName<Environment.SpecialFolder>(i);
                if (reFilter != null && !reFilter.IsMatch(name)) continue;
                var value = Environment.GetFolderPath(i);
                if (All || !string.IsNullOrEmpty(value)) console.WriteLine($"{name}: {value}");
            }
       }
    }
}