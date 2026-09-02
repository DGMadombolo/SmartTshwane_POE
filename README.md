# SmartTshwane - Municipal Services Application

## 1. Project Overview

SmartTshwane is a C# Windows Forms application designed to improve communication between residents and their municipality.

The application allows residents to report municipal service issues by providing the location, issue category, description, and supporting images or documents.

The application also provides feedback to residents after submitting a report, including a reference number and the current submission status.

## 2. Technologies Used

- C#
- .NET Framework
- Windows Forms
- Visual Studio
- Git/GitHub for version control

## 3. System Requirements

To run SmartTshwane, the following are required:

- Windows 10 or Windows 11
- Visual Studio with .NET Framework development tools
- .NET Framework compatible with the project
- At least 4 GB RAM
- Sufficient storage space for Visual Studio and the project

## 4. How to Compile the Application

1. Open Visual Studio.
2. Select **Open a project or solution**.
3. Open the `SmartTshwane_POE.sln` solution file.
4. Allow Visual Studio to load the project and its dependencies.
5. From the Visual Studio menu, select **Build**.
6. Select **Build Solution** or **Rebuild Solution**.
7. Confirm that the build completes successfully without errors.

## 5. How to Run the Application

1. Open the `SmartTshwane_POE.sln` file in Visual Studio.
2. Make sure the `SmartTshwane_POE` project is selected as the startup project.
3. Press **F5** or select **Start** in Visual Studio.
4. The SmartTshwane Main Menu will open.

## 6. How to Use the Application

### Main Menu

The Main Menu provides the following options:

- **Report Issues** - Allows residents to report municipal service problems.
- **Local Events & Announcements** - Reserved for a future part of the application.
- **Service Request Status** - Reserved for a future part of the application.
- **Exit** - Closes the application.

### Reporting an Issue

To submit a municipal issue:

1. Select **Report Issues** from the Main Menu.
2. Enter the **location of the issue**.
3. Select an **issue category**.
4. Enter a detailed description of the problem.
5. Select **Attach Image / Document** if supporting evidence is available.
6. Select an image or document from the file browser.
7. Confirm that the selected filename is displayed.
8. Select **Submit Report**.
9. The application validates the information provided.
10. If the report is valid, a unique reference number is generated.
11. The report is stored in the application's issue list.
12. A confirmation message displays the reference number and submission status.

### Supported Attachments

The application supports common image and document formats, including:

- JPG
- JPEG
- PNG
- GIF
- BMP
- PDF
- DOC
- DOCX
- TXT

Attachments are optional.

### Returning to the Main Menu

Select **Back to Main** to close the Report Issue form and return to the Main Menu.

### Exiting the Application

Select **Exit** from the Main Menu to close SmartTshwane.

## 7. Issue Data Structure

The application uses an `Issue` class to represent municipal service reports.

Each issue contains:

- Location
- Category
- Description
- Attachment path
- Date reported
- Status
- Reference number

Submitted issues are stored using a `List<Issue>` data structure during application execution.

## 8. User Engagement Strategy

The application implements the **Citizen Feedback and Progress Tracking** strategy.

Residents receive:

- Progress feedback while completing the report.
- Confirmation after successful submission.
- A unique reference number.
- The current status of the report.
- A message thanking them for contributing to their community.

This approach helps residents understand that their reports have been successfully received and provides a reference that can be used when following up on the issue.

## 9. Current Application Scope

The current version implements the **Report Issues** functionality required for the first stage of development.

The following features are reserved for future development:

- Local Events and Announcements
- Service Request Status tracking

## 10. Project Structure

The main project files include:

```text
SmartTshwane_POE
│
├── App.config
├── Issue.cs
├── MainMenu.cs
├── MainMenu.Designer.cs
├── Program.cs
├── ReportIssue.cs
├── ReportIssue.Designer.cs
└── README.md
