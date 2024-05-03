using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Windows;

namespace DesktopPurchasingApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private Process? process;
        override protected void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            //StartUpApi();
        }

        override protected void OnExit(ExitEventArgs e)
        {
            //process?.Kill();
        }

        private void StartUpApi()
        {
            // Start the API
            ProcessStartInfo startInfo = new ProcessStartInfo
            {
                FileName = "dotnet",
                Arguments = @"API\DesktopAppAPI.dll",
                UseShellExecute = false
            };

            process = new Process
            {
                StartInfo = startInfo
            };

            process.Start();
        }
    }
}
