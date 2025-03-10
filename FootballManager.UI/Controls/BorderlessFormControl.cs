using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace FootballManager.UI.Controls
{
    public class BorderlessFormControl
    {
        #region Win32 API Constants and Methods
        private const int WM_NCHITTEST = 0x0084;
        private const int WM_NCLBUTTONDOWN = 0xA1;
        private const int HTCLIENT = 1;
        private const int HTCAPTION = 2;
        private const int HTBOTTOM = 15;
        private const int HTBOTTOMLEFT = 16;
        private const int HTBOTTOMRIGHT = 17;
        private const int HTLEFT = 10;
        private const int HTRIGHT = 11;
        private const int HTTOP = 12;
        private const int HTTOPLEFT = 13;
        private const int HTTOPRIGHT = 14;
        private const int WMSZ_LEFT = 1;
        private const int WMSZ_RIGHT = 2;
        private const int WMSZ_TOP = 3;
        private const int WMSZ_BOTTOM = 6;

        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(
            int nLeftRect,
            int nTopRect,
            int nRightRect,
            int nBottomRect,
            int nWidthEllipse,
            int nHeightEllipse
        );

        [DllImport("dwmapi.dll")]
        private static extern int DwmExtendFrameIntoClientArea(IntPtr hWnd, ref MARGINS pMarInset);

        [DllImport("dwmapi.dll")]
        private static extern int DwmSetWindowAttribute(IntPtr hwnd, int attr, ref int attrValue, int attrSize);

        [DllImport("dwmapi.dll")]
        private static extern int DwmIsCompositionEnabled(ref int pfEnabled);

        private struct MARGINS
        {
            public int leftWidth;
            public int rightWidth;
            public int topHeight;
            public int bottomHeight;
        }

        private const int DWMWA_USE_IMMERSIVE_DARK_MODE = 20;
        private const int DWMNCRP_ENABLED = 2;
        #endregion

        #region Private Fields
        private readonly Form _form;
        private readonly Panel _titleBar;
        private readonly Button _closeButton;
        private readonly Button _maximizeButton;
        private readonly Button _minimizeButton;
        private readonly Label _titleLabel;
        private readonly PictureBox _iconBox;
        private readonly int _borderSize = 2;
        private readonly int _titleBarHeight = 40;
        private readonly int _cornerRadius = 8;
        private bool _maximized = false;
        private Size _previousSize;
        private Point _previousLocation;
        private readonly Color _primaryColor = Color.FromArgb(18, 18, 18);      // Dark background
        private readonly Color _secondaryColor = Color.FromArgb(35, 35, 35);    // Slightly lighter
        private readonly Color _accentColor = Color.FromArgb(66, 133, 244);     // Blue accent
        private readonly Color _textColor = Color.FromArgb(240, 240, 240);      // Light text
        private readonly Color _closeButtonHoverColor = Color.FromArgb(232, 17, 35); // Red for close button
        #endregion

        #region Constructor
        public BorderlessFormControl(Form form)
        {
            _form = form ?? throw new ArgumentNullException(nameof(form));
            
            // Configure form
            _form.FormBorderStyle = FormBorderStyle.None;
            _form.BackColor = _primaryColor;
            _form.ForeColor = _textColor;
            _form.Padding = new Padding(_borderSize);
            _form.StartPosition = FormStartPosition.CenterScreen;

            // Enable rounded corners
            if (IsCompositionEnabled())
            {
                var v = 2; // Enable rounded corners
                DwmSetWindowAttribute(_form.Handle, 2, ref v, 4);
                
                // Apply dark mode (Windows 10 1809+)
                v = 1;
                DwmSetWindowAttribute(_form.Handle, DWMWA_USE_IMMERSIVE_DARK_MODE, ref v, 4);
                
                MARGINS margins = new MARGINS()
                {
                    leftWidth = 0,
                    rightWidth = 0,
                    topHeight = 1, // Allow form to extend slightly for top shadow
                    bottomHeight = 0
                };
                DwmExtendFrameIntoClientArea(_form.Handle, ref margins);
            }
            else
            {
                // Fallback for older Windows versions
                _form.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, _form.Width, _form.Height, _cornerRadius, _cornerRadius));
            }

            // Create title bar
            _titleBar = new Panel
            {
                BackColor = _primaryColor,
                Dock = DockStyle.Top,
                Height = _titleBarHeight
            };
            
            // Create buttons
            _closeButton = CreateButton("×", ContentAlignment.MiddleCenter, DockStyle.Right);
            _closeButton.FlatAppearance.MouseOverBackColor = _closeButtonHoverColor;
            _closeButton.Click += (s, e) => _form.Close();
            
            _maximizeButton = CreateButton("□", ContentAlignment.MiddleCenter, DockStyle.Right);
            _maximizeButton.Click += (s, e) => ToggleMaximize();
            
            _minimizeButton = CreateButton("—", ContentAlignment.MiddleCenter, DockStyle.Right);
            _minimizeButton.Click += (s, e) => _form.WindowState = FormWindowState.Minimized;
            
            // Create title label
            _titleLabel = new Label
            {
                Text = _form.Text,
                ForeColor = _textColor,
                Font = new Font("Segoe UI", 10F, FontStyle.Regular),
                BackColor = Color.Transparent,
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleLeft,
                Padding = new Padding(10, 0, 0, 0)
            };
            
            // Create icon box (optional)
            _iconBox = new PictureBox
            {
                BackColor = Color.Transparent,
                Width = _titleBarHeight - 10,
                Height = _titleBarHeight - 10,
                SizeMode = PictureBoxSizeMode.Zoom,
                Dock = DockStyle.Left,
                Padding = new Padding(10, 0, 0, 0)
            };
            
            if (_form.Icon != null)
            {
                _iconBox.Image = _form.Icon.ToBitmap();
            }
            
            // Add controls to title bar
            _titleBar.Controls.Add(_closeButton);
            _titleBar.Controls.Add(_maximizeButton);
            _titleBar.Controls.Add(_minimizeButton);
            _titleBar.Controls.Add(_titleLabel);
            _titleBar.Controls.Add(_iconBox);
            
            // Add title bar to form
            _form.Controls.Add(_titleBar);
            
            // Add event handlers
            _titleBar.MouseDown += TitleBar_MouseDown;
            _form.Resize += Form_Resize;
            _form.Paint += Form_Paint;
            
            // Store initial size
            _previousSize = _form.Size;
            _previousLocation = _form.Location;
            
            // Move title bar to front
            _titleBar.BringToFront();
        }
        #endregion

        #region Helper Methods
        private Button CreateButton(string text, ContentAlignment align, DockStyle dock)
        {
            return new Button
            {
                Text = text,
                FlatStyle = FlatStyle.Flat,
                FlatAppearance = { BorderSize = 0 },
                BackColor = _primaryColor,
                ForeColor = _textColor,
                Width = _titleBarHeight,
                Height = _titleBarHeight,
                Font = new Font("Segoe UI", 12F, FontStyle.Regular),
                TextAlign = align,
                Dock = dock,
                Cursor = Cursors.Hand
            };
        }
        
        private bool IsCompositionEnabled()
        {
            int enabled = 0;
            DwmIsCompositionEnabled(ref enabled);
            return enabled == 1;
        }
        
        private void ToggleMaximize()
        {
            if (_maximized)
            {
                // Restore to previous size and position
                _form.Size = _previousSize;
                _form.Location = _previousLocation;
                _maximizeButton.Text = "□";
                
                // Re-apply rounded corners
                if (IsCompositionEnabled())
                {
                    var v = 2;
                    DwmSetWindowAttribute(_form.Handle, 2, ref v, 4);
                }
                else
                {
                    _form.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, _form.Width, _form.Height, _cornerRadius, _cornerRadius));
                }
            }
            else
            {
                // Save current size and position
                _previousSize = _form.Size;
                _previousLocation = _form.Location;
                
                // Maximize
                Rectangle screen = Screen.FromControl(_form).WorkingArea;
                _form.Size = new Size(screen.Width, screen.Height);
                _form.Location = new Point(screen.X, screen.Y);
                _maximizeButton.Text = "❐";
                
                // Remove rounded corners when maximized
                if (!IsCompositionEnabled())
                {
                    _form.Region = null;
                }
            }
            
            _maximized = !_maximized;
        }
        #endregion

        #region Event Handlers
        private void TitleBar_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(_form.Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0);
                
                // Check if the window was maximized and is now moved
                if (_maximized)
                {
                    ToggleMaximize();
                    
                    // Place the window under the cursor
                    _form.Location = new Point(
                        Cursor.Position.X - (_form.Width / 2),
                        Cursor.Position.Y - _titleBarHeight / 2
                    );
                }
            }
        }
        
        private void Form_Resize(object sender, EventArgs e)
        {
            if (_form.WindowState == FormWindowState.Maximized)
            {
                _form.WindowState = FormWindowState.Normal;
                ToggleMaximize();
            }
            
            if (!IsCompositionEnabled() && !_maximized)
            {
                _form.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, _form.Width, _form.Height, _cornerRadius, _cornerRadius));
            }
        }
        
        private void Form_Paint(object sender, PaintEventArgs e)
        {
            // Draw shadow effect
            if (!_maximized)
            {
                using (GraphicsPath path = new GraphicsPath())
                {
                    path.AddRectangle(new Rectangle(0, 0, _form.Width, _form.Height));
                    using (SolidBrush brush = new SolidBrush(_primaryColor))
                    {
                        e.Graphics.FillPath(brush, path);
                    }
                }
            }
            
            // Draw border
            if (_borderSize > 0)
            {
                using (Pen pen = new Pen(_secondaryColor, _borderSize))
                {
                    e.Graphics.DrawRectangle(pen, 
                        new Rectangle(_borderSize / 2, _borderSize / 2, 
                            _form.Width - _borderSize, 
                            _form.Height - _borderSize));
                }
            }
        }
        #endregion

        #region Public Methods
        // Process window messages for resizing
        public static bool ProcessMessage(ref Message m, Form form)
        {
            const int resizeBorderThickness = 10;
            
            switch (m.Msg)
            {
                case WM_NCHITTEST:
                    Point pos = new Point(m.LParam.ToInt32() & 0xFFFF, m.LParam.ToInt32() >> 16);
                    Point clientPos = form.PointToClient(pos);
                    
                    // Check if the point is in the client area
                    if (clientPos.Y <= resizeBorderThickness)
                    {
                        if (clientPos.X <= resizeBorderThickness)
                            m.Result = (IntPtr)HTTOPLEFT;
                        else if (clientPos.X >= form.ClientSize.Width - resizeBorderThickness)
                            m.Result = (IntPtr)HTTOPRIGHT;
                        else
                            m.Result = (IntPtr)HTTOP;
                        return true;
                    }
                    else if (clientPos.Y >= form.ClientSize.Height - resizeBorderThickness)
                    {
                        if (clientPos.X <= resizeBorderThickness)
                            m.Result = (IntPtr)HTBOTTOMLEFT;
                        else if (clientPos.X >= form.ClientSize.Width - resizeBorderThickness)
                            m.Result = (IntPtr)HTBOTTOMRIGHT;
                        else
                            m.Result = (IntPtr)HTBOTTOM;
                        return true;
                    }
                    else if (clientPos.X <= resizeBorderThickness)
                    {
                        m.Result = (IntPtr)HTLEFT;
                        return true;
                    }
                    else if (clientPos.X >= form.ClientSize.Width - resizeBorderThickness)
                    {
                        m.Result = (IntPtr)HTRIGHT;
                        return true;
                    }
                    break;
            }
            
            return false;
        }
        
        // Change title text
        public void SetTitle(string title)
        {
            _titleLabel.Text = title;
            _form.Text = title;
        }
        
        // Change icon
        public void SetIcon(Icon icon)
        {
            if (icon != null)
            {
                _iconBox.Image = icon.ToBitmap();
            }
        }
        #endregion
    }
}