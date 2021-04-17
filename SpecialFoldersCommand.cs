using System;
using System.Text.RegularExpressions;
using McMaster.Extensions.CommandLineUtils;

namespace NETTestBed
{
    [Command(
        Description="Show .NET Special Folders Path",
        ExtendedHelpText="Enumerates the actual values of the Environment.SpecialFolder Enum")]
    public class SpecialFoldersCommand
    {
        [Option("-f|--filter <REGEX>", Description = "Filter special folder names")]
        public string Filter {get;}
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
                console.WriteLine($"{name}: {value}");
            }
       }
    }
}