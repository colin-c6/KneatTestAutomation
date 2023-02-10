# KneatAutomationChallenge

# General Assumptions:

- Assignment must be completed in 1hr

- I used [Playwright](https://playwright.dev/) as the Test Automation Tool.

- As we are writing a limited number of tests, I have made the following assumptions to reduce time:

  - Page Object model is not required.
  - Splitting of tests across multiple test files is not required.

- No requirements are provided for the browsers to use in test execution, so I have used the Playwright default browsers which include:
  - Chromium

# Installation

- Install a .NET IDE (VS Code with C# Plugin, Visual Studio)
- Install .NET 7 SDK
- Unzip the repository and `cd` into the 'PlaywrightTests' folder

> cd 'PlaywrightTests'

- Install the dependencies.

# How to Run Tests Locally

Run the below command. This will execute the tests in a headless manner

> dotnet test

To execute tests in a headful browser, execute the below command:

> HEADED=1 dotnet test

# Viewing Test Results

- Test Results are displayed in the terminal

# Tools & Libraries

- Playwright
