using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Web.WebView2.Core;
using Microsoft.Web.WebView2.Wpf;

namespace EpicChatClient
{
    /// <summary>
    /// Логика взаимодействия для Settings.xaml
    /// </summary>
    public partial class Settings : Page
    {
        public Settings()
        {
            InitializeComponent();
            string version = Assembly.GetExecutingAssembly().GetName().Version.ToString();
            WriteLn("Версия WebView Runtime:" + CoreWebView2Environment.GetAvailableBrowserVersionString() + " Версия приложения:" + version);
        }

        private void OK_Click(object sender, RoutedEventArgs e)
        {
            
        }
        private void WriteLn(string text)
        {
            VersionText.Dispatcher.BeginInvoke(new Action(() =>
            {
                VersionText.Text += text + Environment.NewLine;
            }));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var mw = Application.Current.Windows.OfType<MainWindow>().FirstOrDefault();
            mw.Content = new Home();
        }
    }
}
