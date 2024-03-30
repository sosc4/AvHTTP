using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Avalonia.Media;

namespace AvHTTP
{
    public partial class MainWindow : Window
    {

        private HttpClient _httpClient = new HttpClient();
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
            var urlTextBox = this.FindControl<TextBox>("UrlTextBox");
            var dataTextBox = this.FindControl<TextBox>("DataTextBox");
            var responseTextBox = this.FindControl<TextBox>("ResponseTextBox");
            var url = urlTextBox?.Text ?? string.Empty;
            var data = dataTextBox?.Text ?? string.Empty;
            var headers = ParseObject(this.FindControl<TextBox>("HeadersTextBox")?.Text);

            if (string.IsNullOrEmpty(url))
            {
                responseTextBox.Text = "URL is required.";
                return;
            }

            if (!Uri.IsWellFormedUriString(url, UriKind.Absolute))
            {
                responseTextBox.Text = "The entered URL is not valid.";
                return;
            }

            var content = new StringContent(data, Encoding.UTF8, "application/json");

            using var request = new HttpRequestMessage
            {
                RequestUri = new Uri(url),
                Method = new HttpMethod(_currentMethod),
                Content = _currentMethod == "POST" || _currentMethod == "PUT" ? content : null
            };

            foreach (var header in headers)
            {
                request.Headers.TryAddWithoutValidation(header.Key, header.Value);
            }

            try
            {
                using var response = await _httpClient.SendAsync(request);
                var responseContent = await response.Content.ReadAsStringAsync();
                responseTextBox.Text = responseContent;
            }
            catch (HttpRequestException ex)
            {
                responseTextBox.Text = $"HTTP Request Error: {ex.Message}";
            }
            catch (Exception ex)
            {
                responseTextBox.Text = $"Error: {ex.Message}";
            }
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
        private Dictionary<string, string> ParseObject(string? jsonText)
        {
            if (string.IsNullOrWhiteSpace(jsonText)) return new Dictionary<string, string>();

            try
            {
                var obj = JsonSerializer.Deserialize<Dictionary<string, string>>(jsonText);
                return obj ?? new Dictionary<string, string>();
            }
            catch (JsonException ex)
            {
                this.FindControl<TextBox>("ResponseTextBox").Text = $"JSON Parse Error: {ex.Message}";
                return new Dictionary<string, string>();
            }
        }
    }
}
