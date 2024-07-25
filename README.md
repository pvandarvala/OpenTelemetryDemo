# OpenTelemetryDemo
OpenTelemetry Logging demo

1. Open a terminal or command prompt: This can be Command Prompt, PowerShell, Terminal, or any other command-line interface you use.

2. Navigate to your project directory: Use the cd command to navigate to the directory where your ASP.NET Core project is located.
   cd OpenTelementryDemo

3. Run the application: Execute the dotnet run command to start your application.
    dotnet run

4. Observe the console output: The console where you ran the dotnet run command will display the trace information from OpenTelemetry.

After running the application, you should see output similar to the following in your console:

info: OpenTelemetry.Extensions.Hosting.Implementation.TracingHostedService[0]
      Starting OpenTelemetry Tracer.
info: OpenTelemetry.Instrumentation.AspNetCore.Implementation.AspNetCoreDiagnosticListener[0]
      Activity started
info: OpenTelemetry.Instrumentation.AspNetCore.Implementation.AspNetCoreDiagnosticListener[0]
      Activity stopped

When you navigate to https://localhost:5001/weatherforecast in your browser, you should see additional trace information being logged to the console.


   
