// Importing necessary namespaces from the .NET Framework
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IE322_Project // Defining a namespace for organizing the code
{
    // Partial class definition for the main form (Form1), inheriting from Windows Form
    public partial class Form1 : Form
    {
        // Constructor: called when Form1 is created
        public Form1()
        {
            InitializeComponent(); // Initializes all form components (e.g., buttons, textboxes)
        }

        // Event handler for the login button click event
        private void btnLogin_Click(object sender, EventArgs e)
        {
            // Retrieve text entered in the username and password textboxes
            String username = txtUserName.Text;
            String pass = txtPassword.Text;

            // Check if the username and password match the predefined values
            if (username == "hms" && pass == "pass")
            {
                // Show a success message box
                MessageBox.Show("You have entered the correct username and password");

                // Hide the current form (login form)
                this.Hide();

                // Create a new instance of the Dashboard form
                Dashboard ds = new Dashboard();

                // Show the Dashboard form
                ds.Show();
            }
            else
            {
                // If the username or password is incorrect, show an error message
                MessageBox.Show("Wrong user ID or password");
            }
        }

        // This method is executed when the form is first loaded
        private void Form1_Load(object sender, EventArgs e)
        {
            // Currently empty - can be used to initialize values or settings when the form loads
        }
    }
}
