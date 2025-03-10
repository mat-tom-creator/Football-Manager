namespace FootballManager.UI
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();

            // Create the main splitContainer that divides the form into left (tabs) and right (content)
            this.splitContainer = new System.Windows.Forms.SplitContainer();

            // Create the left panel for tabs
            this.pnlTabs = new System.Windows.Forms.Panel();
            this.pnlTabsHeader = new System.Windows.Forms.Panel();
            this.lblTabsHeader = new System.Windows.Forms.Label();

            // Create the tab buttons for the left panel
            this.btnLiveMatches = new System.Windows.Forms.Button();
            this.btnFixtures = new System.Windows.Forms.Button();
            this.btnTeams = new System.Windows.Forms.Button();
            this.btnPlayers = new System.Windows.Forms.Button();
            this.btnLeague = new System.Windows.Forms.Button();
            this.btnNews = new System.Windows.Forms.Button();
            this.btnFanInteraction = new System.Windows.Forms.Button();
            this.btnVideo = new System.Windows.Forms.Button();
            this.btnSearchTab = new System.Windows.Forms.Button();

            // Create content panels for each tab
            this.pnlContent = new System.Windows.Forms.Panel();
            this.pnlLiveMatches = new System.Windows.Forms.Panel();
            this.pnlFixtures = new System.Windows.Forms.Panel();
            this.pnlFixtures.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlFixtures.Location = new System.Drawing.Point(0, 0);
            this.pnlFixtures.Name = "pnlFixtures";
            this.pnlFixtures.Size = new System.Drawing.Size(820, 704);
            this.pnlFixtures.TabIndex = 1;
            this.pnlFixtures.Padding = new System.Windows.Forms.Padding(20);
            this.pnlTeams = new System.Windows.Forms.Panel();
            this.pnlPlayers = new System.Windows.Forms.Panel();
            this.pnlLeague = new System.Windows.Forms.Panel();
            this.pnlNews = new System.Windows.Forms.Panel();
            this.pnlFanInteraction = new System.Windows.Forms.Panel();
            this.pnlVideo = new System.Windows.Forms.Panel();
            this.pnlSearch = new System.Windows.Forms.Panel();

            // Create controls for the Live Matches panel
            this.btnGetMatchUpdates = new System.Windows.Forms.Button();
            this.txtLiveMatches = new System.Windows.Forms.TextBox();

            // Create controls for the Fixtures panel
            this.btnGetResults = new System.Windows.Forms.Button();
            this.btnGetFixtures = new System.Windows.Forms.Button();
            this.txtFixtures = new System.Windows.Forms.TextBox();

            // Create controls for the Teams panel
            this.txtTeamName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnGetTeamProfile = new System.Windows.Forms.Button();
            this.txtTeamProfile = new System.Windows.Forms.TextBox();

            // Create controls for the Players panel
            this.txtPlayerName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnGetPlayerProfile = new System.Windows.Forms.Button();
            this.txtPlayerProfile = new System.Windows.Forms.TextBox();

            // Create controls for the League panel
            this.btnGetLeagueStandings = new System.Windows.Forms.Button();
            this.txtLeagueStandings = new System.Windows.Forms.TextBox();

            // Create controls for the News panel
            this.label5 = new System.Windows.Forms.Label();
            this.cmbNewsType = new System.Windows.Forms.ComboBox();
            this.txtNewsPreference = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnGetNews = new System.Windows.Forms.Button();
            this.txtNews = new System.Windows.Forms.TextBox();

            // Create controls for the Fan Interaction panel
            this.label7 = new System.Windows.Forms.Label();
            this.cmbInteractionType = new System.Windows.Forms.ComboBox();
            this.txtInteractionInput = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtInteractionType = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnSubmitInteraction = new System.Windows.Forms.Button();
            this.txtFanInteraction = new System.Windows.Forms.TextBox();

            // Create controls for the Video panel
            this.label9 = new System.Windows.Forms.Label();
            this.cmbVideoService = new System.Windows.Forms.ComboBox();
            this.txtVideoType = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.btnFetchVideo = new System.Windows.Forms.Button();
            this.txtVideo = new System.Windows.Forms.TextBox();

            // Create controls for the Search panel
            this.txtSearchQuery = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.btnSearchTab = new System.Windows.Forms.Button();
            this.txtSearchResults = new System.Windows.Forms.TextBox();

            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.statusLabel = new System.Windows.Forms.ToolStripStatusLabel();

            // Initialize component properties and layout
            this.menuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.pnlTabs.SuspendLayout();
            this.pnlTabsHeader.SuspendLayout();
            this.pnlContent.SuspendLayout();
            this.pnlLiveMatches.SuspendLayout();
            this.pnlFixtures.SuspendLayout();
            this.pnlTeams.SuspendLayout();
            this.pnlPlayers.SuspendLayout();
            this.pnlLeague.SuspendLayout();
            this.pnlNews.SuspendLayout();
            this.pnlFanInteraction.SuspendLayout();
            this.pnlVideo.SuspendLayout();
            this.pnlSearch.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();

            // menuStrip
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(1024, 24);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "menuStrip1";

            // fileToolStripMenuItem
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";

            // exitToolStripMenuItem
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(93, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);

            // helpToolStripMenuItem
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";

            // aboutToolStripMenuItem
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);

            // splitContainer
            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer.Location = new System.Drawing.Point(0, 24);
            this.splitContainer.Name = "splitContainer";
            this.splitContainer.Size = new System.Drawing.Size(1024, 704);
            this.splitContainer.SplitterDistance = 200;
            this.splitContainer.TabIndex = 1;

            // splitContainer.Panel1 (Left panel for tabs)
            this.splitContainer.Panel1.Controls.Add(this.pnlTabs);

            // splitContainer.Panel2 (Right panel for content)
            this.splitContainer.Panel2.Controls.Add(this.pnlContent);

            // pnlTabs (Left panel container)
            this.pnlTabs.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.pnlTabs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlTabs.Location = new System.Drawing.Point(0, 0);
            this.pnlTabs.Name = "pnlTabs";
            this.pnlTabs.Size = new System.Drawing.Size(200, 704);
            this.pnlTabs.TabIndex = 0;

            // pnlTabsHeader
            this.pnlTabsHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(99)))), ((int)(((byte)(156)))));
            this.pnlTabsHeader.Controls.Add(this.lblTabsHeader);
            this.pnlTabsHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTabsHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlTabsHeader.Name = "pnlTabsHeader";
            this.pnlTabsHeader.Size = new System.Drawing.Size(200, 40);
            this.pnlTabsHeader.TabIndex = 0;

            // lblTabsHeader
            this.lblTabsHeader.AutoSize = false;
            this.lblTabsHeader.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTabsHeader.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.lblTabsHeader.ForeColor = System.Drawing.Color.White;
            this.lblTabsHeader.Location = new System.Drawing.Point(0, 0);
            this.lblTabsHeader.Name = "lblTabsHeader";
            this.lblTabsHeader.Size = new System.Drawing.Size(200, 40);
            this.lblTabsHeader.TabIndex = 0;
            this.lblTabsHeader.Text = "FOOTBALL MANAGER";
            this.lblTabsHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // Tab buttons
            // btnLiveMatches
            this.btnLiveMatches.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.btnLiveMatches.FlatAppearance.BorderSize = 0;
            this.btnLiveMatches.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLiveMatches.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.btnLiveMatches.ForeColor = System.Drawing.Color.White;
            this.btnLiveMatches.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLiveMatches.Location = new System.Drawing.Point(0, 40);
            this.btnLiveMatches.Name = "btnLiveMatches";
            this.btnLiveMatches.Size = new System.Drawing.Size(200, 40);
            this.btnLiveMatches.TabIndex = 1;
            this.btnLiveMatches.Text = "  Live Matches";
            this.btnLiveMatches.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLiveMatches.UseVisualStyleBackColor = false;
            this.btnLiveMatches.Click += new System.EventHandler(this.btnLiveMatches_Click);

            // btnFixtures
            this.btnFixtures.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnFixtures.FlatAppearance.BorderSize = 0;
            this.btnFixtures.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFixtures.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.btnFixtures.ForeColor = System.Drawing.Color.White;
            this.btnFixtures.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFixtures.Location = new System.Drawing.Point(0, 80);
            this.btnFixtures.Name = "btnFixtures";
            this.btnFixtures.Size = new System.Drawing.Size(200, 40);
            this.btnFixtures.TabIndex = 2;
            this.btnFixtures.Text = "  Fixtures & Results";
            this.btnFixtures.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFixtures.UseVisualStyleBackColor = false;
            this.btnFixtures.Click += new System.EventHandler(this.btnFixtures_Click);

            // btnTeams
            this.btnTeams.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.btnTeams.FlatAppearance.BorderSize = 0;
            this.btnTeams.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTeams.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.btnTeams.ForeColor = System.Drawing.Color.White;
            this.btnTeams.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTeams.Location = new System.Drawing.Point(0, 120);
            this.btnTeams.Name = "btnTeams";
            this.btnTeams.Size = new System.Drawing.Size(200, 40);
            this.btnTeams.TabIndex = 3;
            this.btnTeams.Text = "  Teams";
            this.btnTeams.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTeams.UseVisualStyleBackColor = false;
            this.btnTeams.Click += new System.EventHandler(this.btnTeams_Click);

            // btnPlayers
            this.btnPlayers.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.btnPlayers.FlatAppearance.BorderSize = 0;
            this.btnPlayers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPlayers.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.btnPlayers.ForeColor = System.Drawing.Color.White;
            this.btnPlayers.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPlayers.Location = new System.Drawing.Point(0, 160);
            this.btnPlayers.Name = "btnPlayers";
            this.btnPlayers.Size = new System.Drawing.Size(200, 40);
            this.btnPlayers.TabIndex = 4;
            this.btnPlayers.Text = "  Players";
            this.btnPlayers.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPlayers.UseVisualStyleBackColor = false;
            this.btnPlayers.Click += new System.EventHandler(this.btnPlayers_Click);

            // btnLeague
            this.btnLeague.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.btnLeague.FlatAppearance.BorderSize = 0;
            this.btnLeague.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLeague.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.btnLeague.ForeColor = System.Drawing.Color.White;
            this.btnLeague.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLeague.Location = new System.Drawing.Point(0, 200);
            this.btnLeague.Name = "btnLeague";
            this.btnLeague.Size = new System.Drawing.Size(200, 40);
            this.btnLeague.TabIndex = 5;
            this.btnLeague.Text = "  League Standings";
            this.btnLeague.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLeague.UseVisualStyleBackColor = false;
            this.btnLeague.Click += new System.EventHandler(this.btnLeague_Click);

            // btnNews
            this.btnNews.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.btnNews.FlatAppearance.BorderSize = 0;
            this.btnNews.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNews.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.btnNews.ForeColor = System.Drawing.Color.White;
            this.btnNews.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNews.Location = new System.Drawing.Point(0, 240);
            this.btnNews.Name = "btnNews";
            this.btnNews.Size = new System.Drawing.Size(200, 40);
            this.btnNews.TabIndex = 6;
            this.btnNews.Text = "  News";
            this.btnNews.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNews.UseVisualStyleBackColor = false;
            this.btnNews.Click += new System.EventHandler(this.btnNews_Click);

            // btnFanInteraction
            this.btnFanInteraction.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.btnFanInteraction.FlatAppearance.BorderSize = 0;
            this.btnFanInteraction.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFanInteraction.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.btnFanInteraction.ForeColor = System.Drawing.Color.White;
            this.btnFanInteraction.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFanInteraction.Location = new System.Drawing.Point(0, 280);
            this.btnFanInteraction.Name = "btnFanInteraction";
            this.btnFanInteraction.Size = new System.Drawing.Size(200, 40);
            this.btnFanInteraction.TabIndex = 7;
            this.btnFanInteraction.Text = "  Fan Interaction";
            this.btnFanInteraction.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFanInteraction.UseVisualStyleBackColor = false;
            this.btnFanInteraction.Click += new System.EventHandler(this.btnFanInteraction_Click);

            // btnVideo
            this.btnVideo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.btnVideo.FlatAppearance.BorderSize = 0;
            this.btnVideo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVideo.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.btnVideo.ForeColor = System.Drawing.Color.White;
            this.btnVideo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnVideo.Location = new System.Drawing.Point(0, 320);
            this.btnVideo.Name = "btnVideo";
            this.btnVideo.Size = new System.Drawing.Size(200, 40);
            this.btnVideo.TabIndex = 8;
            this.btnVideo.Text = "  Videos";
            this.btnVideo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnVideo.UseVisualStyleBackColor = false;
            this.btnVideo.Click += new System.EventHandler(this.btnVideo_Click);


            this.btnExecuteSearch = new System.Windows.Forms.Button();
            this.btnExecuteSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(99)))), ((int)(((byte)(156)))));
            this.btnExecuteSearch.FlatAppearance.BorderSize = 0;
            this.btnExecuteSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExecuteSearch.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnExecuteSearch.ForeColor = System.Drawing.Color.White;
            this.btnExecuteSearch.Location = new System.Drawing.Point(410, 24);
            this.btnExecuteSearch.Name = "btnExecuteSearch";
            this.btnExecuteSearch.Size = new System.Drawing.Size(150, 30);
            this.btnExecuteSearch.TabIndex = 3;
            this.btnExecuteSearch.Text = "Search";
            this.btnExecuteSearch.UseVisualStyleBackColor = false;
            this.btnExecuteSearch.Click += new System.EventHandler(this.btnExecuteSearch_Click);

            // Content panels
            // pnlContent
            this.pnlContent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Location = new System.Drawing.Point(0, 0);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(820, 704);
            this.pnlContent.TabIndex = 0;
            this.pnlSearch.Controls.Add(this.btnExecuteSearch);

            // The content panels
            // pnlLiveMatches
            this.pnlLiveMatches.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlLiveMatches.Location = new System.Drawing.Point(0, 0);
            this.pnlLiveMatches.Name = "pnlLiveMatches";
            this.pnlLiveMatches.Size = new System.Drawing.Size(820, 704);
            this.pnlLiveMatches.TabIndex = 0;

            // Controls for Live Matches panel
            this.pnlLiveMatches.Controls.Add(this.btnGetMatchUpdates);
            this.pnlLiveMatches.Controls.Add(this.txtLiveMatches);

            // btnGetMatchUpdates
            this.btnGetMatchUpdates.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(99)))), ((int)(((byte)(156)))));
            this.btnGetMatchUpdates.FlatAppearance.BorderSize = 0;
            this.btnGetMatchUpdates.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGetMatchUpdates.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnGetMatchUpdates.ForeColor = System.Drawing.Color.White;
            this.btnGetMatchUpdates.Location = new System.Drawing.Point(20, 20);
            this.btnGetMatchUpdates.Name = "btnGetMatchUpdates";
            this.btnGetMatchUpdates.Size = new System.Drawing.Size(150, 30);
            this.btnGetMatchUpdates.TabIndex = 1;
            this.btnGetMatchUpdates.Text = "Get Match Updates";
            this.btnGetMatchUpdates.UseVisualStyleBackColor = false;
            this.btnGetMatchUpdates.Click += new System.EventHandler(this.btnGetMatchUpdates_Click);

            // txtLiveMatches
            this.txtLiveMatches.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLiveMatches.Location = new System.Drawing.Point(20, 60);
            this.txtLiveMatches.Multiline = true;
            this.txtLiveMatches.Name = "txtLiveMatches";
            this.txtLiveMatches.ReadOnly = true;
            this.txtLiveMatches.Size = new System.Drawing.Size(780, 624);
            this.txtLiveMatches.TabIndex = 0;

            // Similar definitions for other panels would go here
            // For brevity, they've been omitted but would follow the same pattern

            // statusStrip
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 728);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(1024, 22);
            this.statusStrip.TabIndex = 2;
            this.statusStrip.Text = "statusStrip1";

            // statusLabel
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(42, 17);
            this.statusLabel.Text = "Ready";

            // MainForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1024, 750);
            this.Controls.Add(this.splitContainer);
            this.Controls.Add(this.menuStrip);
            this.Controls.Add(this.statusStrip);
            this.MainMenuStrip = this.menuStrip;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Football Manager";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            this.pnlTabs.ResumeLayout(false);
            this.pnlTabsHeader.ResumeLayout(false);
            this.pnlContent.ResumeLayout(false);
            this.pnlLiveMatches.ResumeLayout(false);
            this.pnlLiveMatches.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;

        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.Panel pnlTabs;
        private System.Windows.Forms.Panel pnlTabsHeader;
        private System.Windows.Forms.Label lblTabsHeader;

        private System.Windows.Forms.Button btnLiveMatches;
        private System.Windows.Forms.Button btnFixtures;
        private System.Windows.Forms.Button btnTeams;
        private System.Windows.Forms.Button btnPlayers;
        private System.Windows.Forms.Button btnLeague;
        private System.Windows.Forms.Button btnNews;
        private System.Windows.Forms.Button btnFanInteraction;
        private System.Windows.Forms.Button btnVideo;
        private System.Windows.Forms.Button btnSearchTabTab;

        private System.Windows.Forms.Panel pnlContent;

        private System.Windows.Forms.Panel pnlLiveMatches;
        private System.Windows.Forms.Button btnGetMatchUpdates;
        private System.Windows.Forms.TextBox txtLiveMatches;

        private System.Windows.Forms.Panel pnlFixtures;
        private System.Windows.Forms.Button btnGetResults;
        private System.Windows.Forms.Button btnGetFixtures;
        private System.Windows.Forms.TextBox txtFixtures;

        private System.Windows.Forms.Panel pnlTeams;
        private System.Windows.Forms.TextBox txtTeamName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnGetTeamProfile;
        private System.Windows.Forms.TextBox txtTeamProfile;

        private System.Windows.Forms.Panel pnlPlayers;
        private System.Windows.Forms.TextBox txtPlayerName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnGetPlayerProfile;
        private System.Windows.Forms.TextBox txtPlayerProfile;

        private System.Windows.Forms.Panel pnlLeague;
        private System.Windows.Forms.Button btnGetLeagueStandings;
        private System.Windows.Forms.TextBox txtLeagueStandings;

        private System.Windows.Forms.Panel pnlNews;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbNewsType;
        private System.Windows.Forms.TextBox txtNewsPreference;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnGetNews;
        private System.Windows.Forms.TextBox txtNews;

        private System.Windows.Forms.Panel pnlFanInteraction;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cmbInteractionType;
        private System.Windows.Forms.TextBox txtInteractionInput;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtInteractionType;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnSubmitInteraction;
        private System.Windows.Forms.TextBox txtFanInteraction;

        private System.Windows.Forms.Panel pnlVideo;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cmbVideoService;
        private System.Windows.Forms.TextBox txtVideoType;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnFetchVideo;
        private System.Windows.Forms.TextBox txtVideo;

        private System.Windows.Forms.Panel pnlSearch;
        private System.Windows.Forms.TextBox txtSearchQuery;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnSearchTab;
        private System.Windows.Forms.TextBox txtSearchResults;
        private System.Windows.Forms.Button btnExecuteSearch;

        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel statusLabel;
    }
}