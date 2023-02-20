using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
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
using Microsoft.Web.WebView2.WinForms;
using Microsoft.Web.WebView2.Wpf;
using Windows.UI.WebUI;

namespace EpicChatClient
{
    /// <summary>
    /// Логика взаимодействия для Page1.xaml
    /// </summary>
    public partial class Home : Page
    {
        public Home()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (BrowserWindow.CanGoBack == true)
            {
                BrowserWindow.GoBack();
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (BrowserWindow.CanGoForward== true)
            {
                BrowserWindow.GoForward();
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            BrowserWindow.CoreWebView2.Navigate("https://web2909.craft-host.ru/");
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            BrowserWindow.Reload();
        }

        private void NewWindow_Click(object sender, RoutedEventArgs e)
        {
            new MainWindow().Show();
        }

        private void Settings_Click(object sender, RoutedEventArgs e)
        {
            var mw = Application.Current.Windows.OfType<MainWindow>().FirstOrDefault();
            mw.Content = new Settings();
        }

        private void UrlInput_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                if (UrlInput.Text.Contains("web2909.craft-host.ru") == true)
                {
                    if (UrlInput.Text.Contains("https://") == false)
                    {
                        BrowserWindow.CoreWebView2.Navigate("https://" + UrlInput.Text);
                    }
                    if (UrlInput.Text.Contains("https://") == true)
                    {
                        BrowserWindow.CoreWebView2.Navigate(UrlInput.Text);
                    }
                }
                if (UrlInput.Text == "DevTools")
                {
                    BrowserWindow.CoreWebView2.OpenDevToolsWindow();
                }
                if (UrlInput.Text.Contains("web2909.craft-host.ru") == false)
                {
                    if (UrlInput.Text.Contains("DevTools") == false) {
                        MessageBox.Show("Это не ссылка приглашения");
                    }
                }
                UrlInput.Clear();
            }
        }
    }
}
