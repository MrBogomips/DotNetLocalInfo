using System;
using McMaster.Extensions.CommandLineUtils;

namespace NETTestBed
{
    [Command(ExtendedHelpText=@"
Command line utils to retrieve .NET local info")]
    [Subcommand(typeof(SpecialFoldersCommand))]
    [VersionOptionFromMember(MemberName=nameof(GetVersion), Description="Version")]
    class Program
    {
        public static int Main(string[] args) => CommandLineApplication.Execute<Program>(args);

        public void OnExecute(CommandLineApplication app) => app.ShowHelp();

        public string GetVersion() => typeof(Program).Assembly.GetName().Version.ToString();
    }
}
