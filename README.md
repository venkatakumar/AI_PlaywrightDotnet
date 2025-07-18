# PlayDotnet: Playwright C# Page Object Model Test Framework

This project demonstrates a basic Page Object Model (POM) test framework using Playwright, C#, and NUnit. It includes a sample test that searches for the keyword `bt1` on the [NI Planning Register Simple Search](https://planningregister.planningsystemni.gov.uk/simple-search) page and verifies the results.

## Structure
- `Pages/`: Page Object Model classes
- `Tests/`: Test classes using NUnit

## Prerequisites
- .NET 8 SDK
- Playwright CLI (installed via NuGet and dotnet tool)

## Setup
1. Restore dependencies:
   ```pwsh
   dotnet restore
   ```
2. Build the project:
   ```pwsh
   dotnet build
   ```
3. Install Playwright browsers:
   ```pwsh
   playwright install
   ```

## Running Tests
Run the following command from the `PlayDotnet` directory:
```pwsh
cd PlayDotnet
 dotnet test
```

## Notes
- The test uses headless Chromium by default.
- The POM pattern is used for maintainability and scalability.
