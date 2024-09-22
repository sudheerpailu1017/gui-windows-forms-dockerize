using System;
using System.Windows.Forms;

namespace HelloWorldWinApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            // Set the window title
            this.Text = "Hello World App";

            // Create a label to display "Hello, World!"
            Label helloLabel = new Label();
            helloLabel.Text = "Hello, World!";
            helloLabel.AutoSize = true;
            helloLabel.Location = new System.Drawing.Point(50, 50);

            // Add the label to the form
            this.Controls.Add(helloLabel);
        }
    }
}
