[![BCH compliance](https://bettercodehub.com/edge/badge/devmanzur/ApplicantTrackingSystem?branch=master)](https://bettercodehub.com/)


# Applicant Tracking System
a simple applicant management system

# Running The Application
Prerequisites:
- Visual Studio or Jetbrains Rider
- [ASP.NET Core](https://dotnet.microsoft.com/download) must be downloaded and installed.

## Running the App in Visual Studio or Jetbrains Rider
- With either of them it's pretty straight forward. Just find the `Hahn.ApplicatonProcess.Application.sln` and open with `Visual Studio` or `Rider`

## Running The App using .Net CLI
- navigate to the application directory `./../Hahn.ApplicatonProcess.Application`
- execute the following commands in order using a terminal/shell
  
  ```shell
  dotnet restore
  ```
  ```shell
  dotnet build
  ```
  ```shell
  dotnet run
  ```
# Domain Decisions & Explanations
- Why I used Domain Driven Development aproach although the domain was very simple and straight forward?
  
  ```Although there was no complex business related to The`Applicant` model I took the opportunity to illustrate how I would go about implementing it in a real world     scenario with complex domain and constraints.```
  
- The Tests in this project do not follow TDD

  ```For me writing tests is a must, but I find that going completely TDD does not provide any extra benefits. Tests are must Test Driven Development is optional.```
  
- Why I did not use the usual Fluent Validation approach by injecting it in ConfigureServices method?

  ```Fluent Validation breaks my contract with the interfacing applications where I always provide a uniform model for all success/error/exceptions.```
