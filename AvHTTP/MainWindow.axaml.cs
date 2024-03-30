using System;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;

namespace AvHTTP
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void MainWindow_Opened(object? sender, EventArgs e)
        {

        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }

        private void OnMethodSet(object? sender, RoutedEventArgs e)
        {

        }

        private async void OnSendClick(object? sender, RoutedEventArgs e)
        {

        }
    }
}
