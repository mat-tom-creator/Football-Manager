using System;
using System.Drawing;
using System.Windows.Forms;

namespace FootballManager.UI.Controls
{
    public static class ThemeManager
    {
        // Main theme colors
        public static Color PrimaryBackColor = Color.FromArgb(28, 28, 28);
        public static Color SecondaryBackColor = Color.FromArgb(38, 38, 38);
        public static Color TertiaryBackColor = Color.FromArgb(50, 50, 50);
        public static Color AccentColor = Color.FromArgb(185, 28, 28);       // ROG Red
        public static Color TextColor = Color.FromArgb(240, 240, 240);
        public static Color SecondaryTextColor = Color.Silver;
        public static Color SuccessColor = Color.FromArgb(57, 173, 107);
        public static Color ErrorColor = Color.FromArgb(232, 17, 35);
        public static Color HeaderBackColor = Color.FromArgb(20, 20, 20);
        
        // Hover colors
        public static Color ButtonHoverColor = Color.FromArgb(60, 60, 60);
        public static Color AccentHoverColor = Color.FromArgb(210, 32, 32);
        
        // Font settings
        public static Font HeaderFont = new Font("Segoe UI", 12, FontStyle.Bold);
        public static Font SubHeaderFont = new Font("Segoe UI", 10, FontStyle.Bold);
        public static Font RegularFont = new Font("Segoe UI", 9, FontStyle.Regular);
        public static Font SmallFont = new Font("Segoe UI", 8, FontStyle.Regular);
        
        /// <summary>
        /// Apply theme to a Form
        /// </summary>
        public static void ApplyTheme(Form form)
        {
            form.BackColor = PrimaryBackColor;
            form.ForeColor = TextColor;
            form.Font = RegularFont;
            
            // Apply theme to all controls recursively
            ApplyThemeToControls(form.Controls);
        }
        
        /// <summary>
        /// Apply theme to all controls in a collection
        /// </summary>
        public static void ApplyThemeToControls(Control.ControlCollection controls)
        {
            foreach (Control control in controls)
            {
                // Apply specific styling based on control type
                if (control is Panel panel)
                {
                    ApplyThemeToPanel(panel);
                }
                else if (control is Button button)
                {
                    ApplyThemeToButton(button);
                }
                else if (control is TextBox textBox)
                {
                    ApplyThemeToTextBox(textBox);
                }
                else if (control is Label label)
                {
                    ApplyThemeToLabel(label);
                }
                else if (control is DataGridView grid)
                {
                    ApplyThemeToDataGridView(grid);
                }
                else if (control is TabControl tabControl)
                {
                    ApplyThemeToTabControl(tabControl);
                }
                else if (control is ListView listView)
                {
                    ApplyThemeToListView(listView);
                }
                else if (control is ComboBox comboBox)
                {
                    ApplyThemeToComboBox(comboBox);
                }
                else if (control is CheckBox checkBox)
                {
                    ApplyThemeToCheckBox(checkBox);
                }
                else if (control is RadioButton radioButton)
                {
                    ApplyThemeToRadioButton(radioButton);
                }
                else if (control is ProgressBar progressBar)
                {
                    // Custom renderer needed for ProgressBar
                }
                else
                {
                    // Default styling for other controls
                    control.BackColor = SecondaryBackColor;
                    control.ForeColor = TextColor;
                    control.Font = RegularFont;
                }
                
                // Process child controls recursively
                if (control.Controls.Count > 0)
                {
                    ApplyThemeToControls(control.Controls);
                }
            }
        }
        
        /// <summary>
        /// Apply theme to a Panel
        /// </summary>
        public static void ApplyThemeToPanel(Panel panel)
        {
            panel.BackColor = SecondaryBackColor;
            panel.ForeColor = TextColor;
            
            // Add border if the panel needs it
            if (panel.BorderStyle == BorderStyle.FixedSingle)
            {
                panel.BorderStyle = BorderStyle.None;
                panel.Paint += (s, e) =>
                {
                    using (var pen = new Pen(TertiaryBackColor, 1))
                    {
                        e.Graphics.DrawRectangle(pen, 0, 0, panel.Width - 1, panel.Height - 1);
                    }
                };
            }
        }
        
        /// <summary>
        /// Apply theme to a Button
        /// </summary>
        public static void ApplyThemeToButton(Button button)
        {
            // Default button
            if (button.FlatStyle != FlatStyle.Flat)
            {
                button.FlatStyle = FlatStyle.Flat;
                button.FlatAppearance.BorderSize = 0;
            }
            
            button.BackColor = TertiaryBackColor;
            button.ForeColor = TextColor;
            button.Font = RegularFont;
            button.Cursor = Cursors.Hand;
            
            // Check if it's a primary button by checking for tag or name
            if (button.Tag?.ToString() == "Primary" || button.Name?.Contains("Primary") == true)
            {
                button.BackColor = AccentColor;
                
                // Add hover effect
                button.MouseEnter += (s, e) => button.BackColor = AccentHoverColor;
                button.MouseLeave += (s, e) => button.BackColor = AccentColor;
            }
            else
            {
                // Add hover effect for normal buttons
                button.MouseEnter += (s, e) => button.BackColor = ButtonHoverColor;
                button.MouseLeave += (s, e) => button.BackColor = TertiaryBackColor;
            }
        }
        
        /// <summary>
        /// Apply theme to a TextBox
        /// </summary>
        public static void ApplyThemeToTextBox(TextBox textBox)
        {
            textBox.BackColor = TertiaryBackColor;
            textBox.ForeColor = TextColor;
            textBox.BorderStyle = BorderStyle.FixedSingle;
            textBox.Font = RegularFont;
        }
        
        /// <summary>
        /// Apply theme to a Label
        /// </summary>
        public static void ApplyThemeToLabel(Label label)
        {
            label.BackColor = Color.Transparent;
            label.ForeColor = TextColor;
            
            // Check if it's a header by checking for tag or name
            if (label.Tag?.ToString() == "Header" || label.Name?.Contains("Header") == true)
            {
                label.Font = HeaderFont;
                label.ForeColor = AccentColor;
            }
            else if (label.Tag?.ToString() == "SubHeader" || label.Name?.Contains("SubHeader") == true)
            {
                label.Font = SubHeaderFont;
            }
            else
            {
                label.Font = RegularFont;
            }
        }
        
        /// <summary>
        /// Apply theme to a DataGridView
        /// </summary>
        public static void ApplyThemeToDataGridView(DataGridView grid)
        {
            grid.BackgroundColor = SecondaryBackColor;
            grid.BorderStyle = BorderStyle.None;
            grid.EnableHeadersVisualStyles = false;
            grid.GridColor = TertiaryBackColor;
            grid.DefaultCellStyle.BackColor = SecondaryBackColor;
            grid.DefaultCellStyle.ForeColor = TextColor;
            grid.DefaultCellStyle.SelectionBackColor = AccentColor;
            grid.DefaultCellStyle.SelectionForeColor = TextColor;
            grid.ColumnHeadersDefaultCellStyle.BackColor = HeaderBackColor;
            grid.ColumnHeadersDefaultCellStyle.ForeColor = TextColor;
            grid.ColumnHeadersDefaultCellStyle.SelectionBackColor = HeaderBackColor;
            grid.RowHeadersDefaultCellStyle.BackColor = HeaderBackColor;
        }
        
        /// <summary>
        /// Apply theme to a TabControl
        /// </summary>
        public static void ApplyThemeToTabControl(TabControl tabControl)
        {
            tabControl.ItemSize = new Size(80, 30);
            tabControl.DrawMode = TabDrawMode.OwnerDrawFixed;
            
            // Custom draw event for tabs
            tabControl.DrawItem += (s, e) =>
            {
                Graphics g = e.Graphics;
                Rectangle tabRect = tabControl.GetTabRect(e.Index);
                bool isSelected = e.Index == tabControl.SelectedIndex;
                
                // Draw tab background
                using (SolidBrush brush = new SolidBrush(isSelected ? AccentColor : TertiaryBackColor))
                {
                    g.FillRectangle(brush, tabRect);
                }
                
                // Draw text
                string tabText = tabControl.TabPages[e.Index].Text;
                using (SolidBrush brush = new SolidBrush(TextColor))
                {
                    StringFormat sf = new StringFormat
                    {
                        Alignment = StringAlignment.Center,
                        LineAlignment = StringAlignment.Center
                    };
                    g.DrawString(tabText, tabControl.Font, brush, tabRect, sf);
                }
            };
            
            // Apply styling to all tab pages
            foreach (TabPage tabPage in tabControl.TabPages)
            {
                tabPage.BackColor = SecondaryBackColor;
                tabPage.ForeColor = TextColor;
            }
        }
        
        /// <summary>
        /// Apply theme to a ListView
        /// </summary>
        public static void ApplyThemeToListView(ListView listView)
        {
            listView.BackColor = SecondaryBackColor;
            listView.ForeColor = TextColor;
            listView.BorderStyle = BorderStyle.None;
            
            // Owner-drawn listview requires more customization
            if (listView.OwnerDraw)
            {
                listView.DrawItem += (s, e) =>
                {
                    e.DrawBackground();
                    bool isSelected = ((e.State & ListViewItemStates.Selected) == ListViewItemStates.Selected);
                    
                    using (SolidBrush brush = new SolidBrush(isSelected ? AccentColor : SecondaryBackColor))
                    {
                        e.Graphics.FillRectangle(brush, e.Bounds);
                    }
                    
                    using (SolidBrush brush = new SolidBrush(TextColor))
                    {
                        e.Graphics.DrawString(listView.Items[e.ItemIndex].Text, listView.Font, brush, e.Bounds);
                    }
                    
                    e.DrawFocusRectangle();
                };
            }
        }
        
        /// <summary>
        /// Apply theme to a ComboBox
        /// </summary>
        public static void ApplyThemeToComboBox(ComboBox comboBox)
        {
            comboBox.BackColor = TertiaryBackColor;
            comboBox.ForeColor = TextColor;
            comboBox.FlatStyle = FlatStyle.Flat;
            comboBox.Font = RegularFont;
        }
        
        /// <summary>
        /// Apply theme to a CheckBox
        /// </summary>
        public static void ApplyThemeToCheckBox(CheckBox checkBox)
        {
            checkBox.BackColor = Color.Transparent;
            checkBox.ForeColor = TextColor;
            checkBox.FlatStyle = FlatStyle.Flat;
            checkBox.Font = RegularFont;
        }
        
        /// <summary>
        /// Apply theme to a RadioButton
        /// </summary>
        public static void ApplyThemeToRadioButton(RadioButton radioButton)
        {
            radioButton.BackColor = Color.Transparent;
            radioButton.ForeColor = TextColor;
            radioButton.FlatStyle = FlatStyle.Flat;
            radioButton.Font = RegularFont;
        }
    }
}