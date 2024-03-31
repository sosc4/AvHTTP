# AvHTTP - Basic HTTP Client

AvHTTP is a minimalist HTTP client built with AvaloniaUI, designed to serve as an educational tool for understanding HTTP request/response mechanics. This project is a university-level demonstration, showcasing the fundamental capabilities of constructing and sending HTTP requests, as well as handling responses within a simple, cross-platform desktop application. 

## Features

- **Simple Interface**: A user-friendly GUI for inputting request details and viewing server responses.
- **HTTP Methods**: Supports basic HTTP methods including GET, POST, PUT, and DELETE.
- **Custom Headers**: Allows users to specify custom request headers in a JSON format.
- **JSON Body**: Permits sending a request body in JSON format, suitable for REST API testing.
- **Response Display**: Responses, including headers and body, are displayed in a read-only format for analysis.
- **Error Handling**: Basic error handling to illustrate common HTTP issues and connectivity problems.

## Built With

- [.NET 7](https://dotnet.microsoft.com/en-us/download/dotnet/7.0)
- [AvaloniaUI](https://avaloniaui.net/) - A cross-platform XAML Framework for .NET Framework, .NET Core and Mono

## Getting Started

To get a local copy up and running, follow these simple steps:

1. Clone the repo
   ```sh
   git clone https://github.com/sosc4/AvHTTP.git
   ```
2. Open the project in your favorite .NET-compatible IDE (such as Visual Studio or JetBrains Rider).
3. Restore the dependencies.
   ```sh
   dotnet restore
   ```
4. Build and run the application.
   ```sh
   dotnet run
   ```
   
## Acknowledgements

- [AvaloniaUI Documentation](https://docs.avaloniaui.net/)
- [HTTP Status Codes](https://developer.mozilla.org/docs/Web/HTTP/Status)
- [JSON Serialization with System.Text.Json](https://docs.microsoft.com/en-us/dotnet/standard/serialization/system-text-json-overview)
