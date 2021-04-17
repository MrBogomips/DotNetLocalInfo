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
        private IConsole Console {get; set;}

        [Option("-f|--filter <REGEX>", Description = "Filter special folder names")]
        public string Filter {get;}
        [Option("--all", Description="Show all special folders including those without a value")]
        public bool All {get;}
        [Option("--name <SPECIAL_FOLDER_NAME>", Description="Retrieve the value of the special folder name")]
        public string Name {get;}
        public void OnExecute(IConsole console) {
            Console = console;
            if (string.IsNullOrEmpty(Name))
                EnumerateFolders();
            else
                GetSpecialFolderValue();
       }

       private void GetSpecialFolderValue() {
            try {
                var specialFolder = Enum.Parse<Environment.SpecialFolder>(Name);
                var value = Environment.GetFolderPath(specialFolder);
                Console.WriteLine(value);
            } catch (Exception) {
                Console.Error.WriteLine($"The name '{Name}' is not a valid special forlder name");
            }
       }

       private void EnumerateFolders() {
            Regex reFilter = null;
            if (!string.IsNullOrEmpty(Filter)) {
                reFilter = new Regex(Filter);
            }
            foreach (var i in Enum.GetValues<Environment.SpecialFolder>())
            {
                var name = Enum.GetName<Environment.SpecialFolder>(i);
                if (reFilter != null && !reFilter.IsMatch(name)) continue;
                var value = Environment.GetFolderPath(i);
                if (All || !string.IsNullOrEmpty(value)) Console.WriteLine($"{name}: {value}");
            }
       }
    }
}
