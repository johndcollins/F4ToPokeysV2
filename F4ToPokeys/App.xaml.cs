using System;
using System.IO;
using System.Windows;
using F4ToPokeys.Config;
using F4ToPokeys.FalconModule;
using Hardcodet.Wpf.TaskbarNotification;

namespace F4ToPokeys
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private TaskbarIcon notifyIcon;

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            if (!CheckUniqueInstance())
            {
                Shutdown();
                return;
            }

            try
            {
                ConfigHolder.Singleton.Load();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, Translations.Main.ConfigLoadErrorCaption, MessageBoxButton.OK, MessageBoxImage.Error);
            }

            FalconConnector.Singleton.start();

            //create the notifyicon (it's a resource declared in NotifyIconResources.xaml
            notifyIcon = (TaskbarIcon)FindResource("NotifyIcon");
        }

        protected override void OnExit(ExitEventArgs e)
        {
            notifyIcon.Dispose(); //the icon would clean up automatically, but this is cleaner
            base.OnExit(e);
        }

        #region uniqueInstanceMutex
        private System.Threading.Mutex uniqueInstanceMutex;
        private bool CheckUniqueInstance()
        {
            uniqueInstanceMutex = new System.Threading.Mutex(false, "F4ToPokeys");
            return uniqueInstanceMutex.WaitOne(TimeSpan.FromSeconds(0), false);
        }
        #endregion // uniqueInstanceMutex

        #region CrashLog

        private void Application_DispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
        {
            string crashLogFileName = Path.Combine(ConfigHolder.AppDataPath, "CrashLog.txt");

            Directory.CreateDirectory(ConfigHolder.AppDataPath);

            using (StreamWriter streamWriter = new StreamWriter(crashLogFileName, append: true))
            {
                streamWriter.WriteLine(string.Format("{0}: {1}", DateTime.Now, e.Exception));
                streamWriter.WriteLine();
            }
        }

        #endregion // CrashLog
    }
}
