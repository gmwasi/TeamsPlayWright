using System.Diagnostics;

class Program
{
    static void Main(string[] args)
    {
        string testAssembly = "C:\\Work\\Repos\\TeamsPlayWright\\TeamsPlayWright\\bin\\Debug\\net6.0\\TeamsPlayWright.dll"; 
        string nunitConsolePath = @"C:\Users\brianmwasi\.nuget\packages\nunit.consolerunner\3.16.3\tools\nunit3-console.exe";

        ProcessStartInfo psi = new ProcessStartInfo();
        psi.FileName = nunitConsolePath;
        psi.Arguments = testAssembly;

        Process process = Process.Start(psi);
        process.WaitForExit();

        int result = process.ExitCode;
        Environment.ExitCode = result;
    }
}
