using System;
using GinieLive.Notify; // Ensure this matches the namespace of your web reference

namespace GinieLive.GinieLive
{
    public partial class SendEmail : System.Web.UI.Page
    {
        protected void btnSend_Click(object sender, EventArgs e)
        {
            // Get the email details from the form
            string emailAddress = TxtEmail.Text.Trim();
            string subject = txtSubj.Text.Trim();
            string message = txtMsg.Text.Trim();
            string senderEmail = "sender@example.com"; // Replace with the actual sender email address
            string appKey = "YourAppKey"; // Replace with your actual AppKey

            // Create an instance of the web service client
            var notifyService = new Notify.Msg();
            try
            {
                // Call the Email method with Sender and AppKey parameters
                string result = notifyService.Email(emailAddress, subject, message, senderEmail, appKey);

                // Sanitize result
                result = result.Replace("localhost", "").Trim(); // Remove "localhost" if present

                // Use JavaMsg to handle the result
                if (result == "Pass")
                {
                    JavaMsg("Email sent successfully.");
                }
                else if (result == "Fail")
                {
                    JavaMsg("Failed to send email.");
                }
                else
                {
                    JavaMsg($"Unexpected response: {result}");
                }
            }
            catch (System.Net.WebException webEx)
            {
                // Detailed error handling for web exceptions
                JavaMsg($"Web error occurred: {webEx.Message}. Status: {webEx.Status}");
            }
            catch (Exception ex)
            {
                // Handle any other exceptions
                JavaMsg($"An error occurred: {ex.Message}");
            }
        }

        private void JavaMsg(string message)
        {
            // Register a JavaScript alert message
            ClientScript.RegisterStartupScript(this.GetType(), "alert", $"alert('{message}');", true);
        }

        protected void btnHello_Click(object sender, EventArgs e)
        {
            try
            {
                // Create an instance of the web service client
                var notifyService = new Notify.Msg(); // Replace EmailService with the correct class name

                // Call the AskHelloWorld method
                string result = notifyService.AskHelloWorld();

                // Display the result
                JavaMsg(result); // Assuming JavaMsg is a method to display a message
            }
            catch (Exception ex)
            {
                // Handle any exceptions
                JavaMsg($"An error occurred: {ex.Message}");
            }
        }
    }
}