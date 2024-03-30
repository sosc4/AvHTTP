using System;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Avalonia.Media;

namespace AvHTTP
{
    public partial class MainWindow : Window
    {

        private string _currentMethod = "GET";

        public MainWindow()
        {
            InitializeComponent();
            this.Opened += MainWindow_Opened;
            HighlightMethodButton("GET");
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
            if (sender is Button button)
            {
                _currentMethod = button.Content?.ToString() ?? "GET";
                HighlightMethodButton(_currentMethod);
            }
        }

        private async void OnSendClick(object? sender, RoutedEventArgs e)
        {

        }

        private void HighlightMethodButton(string method)
        {
            var methodName = method.ToLowerInvariant();
            if (methodName.Length > 0)
            {
                methodName = char.ToUpperInvariant(methodName[0]) + methodName.Substring(1);
            }

            this.FindControl<Button>("GetButton").Background = Brushes.Gray;
            this.FindControl<Button>("PostButton").Background = Brushes.Gray;
            this.FindControl<Button>("PutButton").Background = Brushes.Gray;
            this.FindControl<Button>("DeleteButton").Background = Brushes.Gray;

            var button = this.FindControl<Button>($"{methodName}Button");
            if (button != null)
            {
                button.Background = Brushes.HotPink;
            }
        }

    }
}
