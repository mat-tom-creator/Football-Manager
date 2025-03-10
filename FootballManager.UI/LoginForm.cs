using System;
using System.Drawing;
using System.Windows.Forms;
using FootballManager.Core.Factories;
using FootballManager.Core.Interfaces;
using FootballManager.UI.Controls;

namespace FootballManager.UI.Forms
{
    public partial class LoginForm : Form
    {
        private readonly IUserAuthenticationService _authService;
        private readonly BorderlessFormControl _borderlessControl;

        public LoginForm()
        {
            InitializeComponent();
            
            // Apply modern borderless control
            _borderlessControl = new BorderlessFormControl(this);
            
            // Get authentication service from factory
            _authService = ServiceFactory.CreateUserAuthenticationService();
            
            // Apply modern styling to controls
            ApplyModernStyling();
        }

        private void ApplyModernStyling()
        {
            // Style background panel
            pnlBackground.BackColor = Color.FromArgb(28, 28, 28);
            
            // Style textboxes
            StyleTextBox(txtUsername);
            StyleTextBox(txtPassword);
            
            // Style buttons
            StyleButton(btnLogin, Color.FromArgb(185, 28, 28)); // ROG Red
            StyleButton(btnRegister, Color.FromArgb(45, 45, 45));
            
            // Add hover effects
            btnLogin.MouseEnter += (s, e) => btnLogin.BackColor = Color.FromArgb(210, 32, 32);
            btnLogin.MouseLeave += (s, e) => btnLogin.BackColor = Color.FromArgb(185, 28, 28);
            
            btnRegister.MouseEnter += (s, e) => btnRegister.BackColor = Color.FromArgb(60, 60, 60);
            btnRegister.MouseLeave += (s, e) => btnRegister.BackColor = Color.FromArgb(45, 45, 45);
            
            // Style labels
            lblTitle.ForeColor = Color.FromArgb(185, 28, 28);
            lblTitle.Font = new Font("Segoe UI", 16, FontStyle.Bold);
            
            lblUsername.ForeColor = Color.Silver;
            lblPassword.ForeColor = Color.Silver;
        }
        
        private void StyleTextBox(TextBox textBox)
        {
            textBox.BackColor = Color.FromArgb(38, 38, 38);
            textBox.ForeColor = Color.White;
            textBox.BorderStyle = BorderStyle.FixedSingle;
            textBox.Font = new Font("Segoe UI", 10);
        }
        
        private void StyleButton(Button button, Color backColor)
        {
            button.FlatStyle = FlatStyle.Flat;
            button.FlatAppearance.BorderSize = 0;
            button.BackColor = backColor;
            button.ForeColor = Color.White;
            button.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            button.Cursor = Cursors.Hand;
        }

        // Override WndProc to enable resizing of the borderless form
        protected override void WndProc(ref Message m)
        {
            if (!BorderlessFormControl.ProcessMessage(ref m, this))
            {
                base.WndProc(ref m);
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                ShowError("Please enter username and password");
                return;
            }

            if (_authService.Authenticate(username, password))
            {
                Hide();
                using (var mainForm = new MainForm(username))
                {
                    mainForm.ShowDialog();
                }
                Close();
            }
            else
            {
                ShowError("Invalid username or password");
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                ShowError("Please enter username and password");
                return;
            }

            if (_authService.CreateUser(username, password))
            {
                ShowSuccess("User registered successfully");
            }
            else
            {
                ShowError("Username already exists");
            }
        }
        
        private void ShowError(string message)
        {
            lblStatus.ForeColor = Color.FromArgb(232, 17, 35);
            lblStatus.Text = message;
            lblStatus.Visible = true;
        }
        
        private void ShowSuccess(string message)
        {
            lblStatus.ForeColor = Color.FromArgb(57, 173, 107);
            lblStatus.Text = message;
            lblStatus.Visible = true;
        }
    }
}