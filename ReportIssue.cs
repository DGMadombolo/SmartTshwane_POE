using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SmartTshwane_POE
{
    public partial class ReportIssue : Form
    {
        // Stores all submitted municipal issues
        private static List<Issue> issues = new List<Issue>();

        // Stores the selected attachment
        private string selectedFilePath = "";

        public ReportIssue()
        {
            InitializeComponent();

            // Populate issue categories
            cmbCategory.Items.Add("Roads & Potholes");
            cmbCategory.Items.Add("Water & Sanitation");
            cmbCategory.Items.Add("Electricity");
            cmbCategory.Items.Add("Waste Management");
            cmbCategory.Items.Add("Street Lighting");
            cmbCategory.Items.Add("Public Facilities");
            cmbCategory.Items.Add("Traffic & Transport");
            cmbCategory.Items.Add("Other");

            // Start with no category selected
            cmbCategory.SelectedIndex = -1;

            // Set initial progress
            progressReport.Minimum = 0;
            progressReport.Maximum = 100;
            progressReport.Value = 0;

            lblEngagement.Text = "Reporting Progress: 0%";
        }

        // Updates the reporting progress as the user completes the form
        private void UpdateProgress()
        {
            int progress = 0;

            // Location completed = 25%
            if (!string.IsNullOrWhiteSpace(txtLocation.Text))
            {
                progress += 25;
            }

            // Category selected = 25%
            if (cmbCategory.SelectedIndex != -1)
            {
                progress += 25;
            }

            // Description completed = 25%
            if (!string.IsNullOrWhiteSpace(rtbDescription.Text))
            {
                progress += 25;
            }

            progressReport.Value = progress;
            lblEngagement.Text = "Reporting Progress: " + progress + "%";
        }

        // Attach an image or document
        private void btnAttach_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog fileDialog = new OpenFileDialog())
            {
                fileDialog.Title = "Select Supporting Image or Document";

                fileDialog.Filter =
                    "Images and Documents|*.jpg;*.jpeg;*.png;*.pdf;*.doc;*.docx|" +
                    "Images|*.jpg;*.jpeg;*.png|" +
                    "Documents|*.pdf;*.doc;*.docx|" +
                    "All Files|*.*";

                if (fileDialog.ShowDialog() == DialogResult.OK)
                {
                    selectedFilePath = fileDialog.FileName;

                    // Display selected file name
                    lblFileName.Text =
                        System.IO.Path.GetFileName(selectedFilePath);

                    // Inform the user that an attachment was added
                    MessageBox.Show(
                        "Attachment added successfully.",
                        "Attachment Added",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
            }
        }

        // Submit the municipal issue
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            // Validate location
            if (string.IsNullOrWhiteSpace(txtLocation.Text))
            {
                MessageBox.Show(
                    "Please enter the location of the issue.",
                    "Missing Information",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtLocation.Focus();
                return;
            }

            // Validate category
            if (cmbCategory.SelectedIndex == -1)
            {
                MessageBox.Show(
                    "Please select an issue category.",
                    "Missing Information",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                cmbCategory.Focus();
                return;
            }

            // Validate description
            if (string.IsNullOrWhiteSpace(rtbDescription.Text))
            {
                MessageBox.Show(
                    "Please describe the issue.",
                    "Missing Information",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                rtbDescription.Focus();
                return;
            }

            // Generate a unique reference number
            string referenceNumber =
                "ST-" + DateTime.Now.ToString("yyyyMMdd-HHmmss");

            // Create a new issue
            Issue newIssue = new Issue
            {
                Location = txtLocation.Text.Trim(),
                Category = cmbCategory.SelectedItem.ToString(),
                Description = rtbDescription.Text.Trim(),
                AttachmentPath = selectedFilePath,
                DateReported = DateTime.Now,
                Status = "Submitted",
                ReferenceNumber = referenceNumber
            };

            // Store the issue in the list
            issues.Add(newIssue);

            // Set progress to 100% after successful submission
            progressReport.Value = 100;
            lblEngagement.Text =
                "Reporting Progress: 100% - Report Submitted!";

            // Show successful submission message
            MessageBox.Show(
                "Report submitted successfully!\n\n" +
                "Reference Number: " + referenceNumber + "\n" +
                "Status: Submitted\n\n" +
                "Thank you for helping improve your community.",
                "Report Submitted",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            // Clear the form for another report
            txtLocation.Clear();
            rtbDescription.Clear();
            cmbCategory.SelectedIndex = -1;

            selectedFilePath = "";
            lblFileName.Text = "No file selected";

            // Reset progress
            progressReport.Value = 0;
            lblEngagement.Text = "Reporting Progress: 0%";
        }

        // Return to the Main Menu
        private void btnBackToMain_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Update progress when location changes
        private void txtLocation_TextChanged(object sender, EventArgs e)
        {
            UpdateProgress();
        }

        // Update progress when description changes
        private void rtbDescription_TextChanged(object sender, EventArgs e)
        {
            UpdateProgress();
        }

        // Update progress when category changes
        private void cmbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateProgress();
        }

        // Existing label event
        private void lblLocation_Click(object sender, EventArgs e)
        {
            // No action required.
        }
    }
}