using System;
using System.Drawing;
using System.Windows.Forms;
using FootballManager.Core.Decorators;
using FootballManager.Core.Factories;
using FootballManager.Core.Interfaces;
using FootballManager.Core.Interfaces.Base;
using FootballManager.UI.Adapters;
using FootballManager.UI.Controls;
using FootballManager.UI.Factories;

namespace FootballManager.UI
{
    /// <summary>
    /// Main form for the Football Manager application with vertical tabs and modern UI.
    /// </summary>
    public partial class MainForm : Form
    {
        private readonly string _username;
        private ProgressBar prgShooting;

        // UI Adapters
        private LiveMatchAdapter _liveMatchAdapter;
        private FixturesAdapter _fixturesAdapter;
        private TeamAdapter _teamAdapter;
        private PlayerAdapter _playerAdapter;
        private LeagueAdapter _leagueAdapter;
        private SearchAdapter _searchAdapter;

        // Services
        private ILiveMatchService _liveMatchService;
        private IFixturesService _fixturesService;
        private ITeamService _teamService;
        private IPlayerService _playerService;
        private ILeagueService _leagueService;
        private ISearchService _searchService;

        // Variables
        private DataGridView dgvLiveMatches;
        private DataGridView dgvFixtures;
        private DataGridView dgvResults;
        private Label lblFullName;
        private Label lblStadium;
        private DataGridView dgvPlayers;
        private Label lblCoach;
        private Label lblFoundingYear;
        private Label lblPlayerName;
        private Label lblNumber;
        private Label lblAge;
        private Label lblHeight;
        private Label lblNationality;
        private Label lblPosition;
        private Label lblClub;
        private ProgressBar prgPace;
        private ProgressBar prgDribbling;
        private ProgressBar prgPassing;
        private ProgressBar prgDefense;
        private Label lblPaceValue;
        private Label lblShootingValue;
        private Label lblDribblingValue;
        private Label lblPassingValue;
        private Label lblDefenseValue;
        private DataGridView dgvTeams;

        public object lvTeamResults { get; private set; }
        public object lvPlayerResults { get; private set; }
        public object lvMatchResults { get; private set; }

        /// <summary>
        /// Initializes a new instance of the MainForm class.
        /// </summary>
        /// <param name="username">The username of the logged-in user.</param>
        public MainForm(string username)
        {
            InitializeComponent();

            _username = username;
            lblTabsHeader.Text = $"WELCOME, {_username.ToUpper()}";

            InitializeContentPanels();
            InitializeTabButtons();
            InitializeDataGridViews();
            InitializeServices();
            InitializeAdapters();
            InitializeUIComponents();

            // Set Live Matches as the default active tab
            SetActiveTab(btnLiveMatches);
        }

        /// <summary>
        /// Initializes all content panels and adds them to the content panel.
        /// </summary>
        private void InitializeContentPanels()
        {
            pnlContent.Controls.Add(pnlLiveMatches);
            pnlContent.Controls.Add(pnlFixtures);
            pnlContent.Controls.Add(pnlTeams);
            pnlContent.Controls.Add(pnlPlayers);
            pnlContent.Controls.Add(pnlLeague);
            pnlContent.Controls.Add(pnlNews);
            pnlContent.Controls.Add(pnlFanInteraction);
            pnlContent.Controls.Add(pnlVideo);
            pnlContent.Controls.Add(pnlSearch);
        }

        /// <summary>
        /// Initializes tab buttons and adds them to the tabs panel.
        /// </summary>
        private void InitializeTabButtons()
        {
            pnlTabs.Controls.Add(pnlTabsHeader);
            pnlTabs.Controls.Add(btnLiveMatches);
            pnlTabs.Controls.Add(btnFixtures);
            pnlTabs.Controls.Add(btnTeams);
            pnlTabs.Controls.Add(btnPlayers);
            pnlTabs.Controls.Add(btnLeague);
            pnlTabs.Controls.Add(btnNews);
            pnlTabs.Controls.Add(btnFanInteraction);
            pnlTabs.Controls.Add(btnVideo);
            pnlTabs.Controls.Add(btnSearchTab);
        }

        /// <summary>
        /// Initializes all service dependencies using the service factory.
        /// </summary>
        /// 
        private void InitializeDataGridViews()
        {
            /// LIVE MATCH SERVICE ///
            Panel buttonPanel = new Panel();
            buttonPanel.Dock = DockStyle.Top;
            buttonPanel.Height = 50;
            buttonPanel.Padding = new Padding(10);

            // Move existing button to this panel
            btnGetMatchUpdates.Dock = DockStyle.None;
            btnGetMatchUpdates.Location = new Point(10, 10);
            buttonPanel.Controls.Add(btnGetMatchUpdates);

            // Configure text box to be below elements
            txtLiveMatches.Dock = DockStyle.Fill;

            // Initialize DataGridViews for Live Matches
            dgvLiveMatches = new DataGridView();
            dgvLiveMatches.Dock = DockStyle.Bottom;
            dgvLiveMatches.Height = 200;
            dgvLiveMatches.ReadOnly = true;
            dgvLiveMatches.AllowUserToAddRows = false;
            dgvLiveMatches.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            pnlLiveMatches.Controls.Add(dgvLiveMatches);

            // Add columns for live matches
            dgvLiveMatches.Columns.Add("HomeTeam", "Home Team");
            dgvLiveMatches.Columns.Add("Score", "Score");
            dgvLiveMatches.Columns.Add("AwayTeam", "Away Team");
            dgvLiveMatches.Columns.Add("Time", "Time");
            dgvLiveMatches.Columns.Add("Competition", "Competition");
            dgvLiveMatches.Columns.Add("Status", "Status");

            pnlLiveMatches.Controls.Clear();
            pnlLiveMatches.Controls.Add(buttonPanel);      // Top
            pnlLiveMatches.Controls.Add(txtLiveMatches);   // Middle
            pnlLiveMatches.Controls.Add(dgvLiveMatches);   // Bottom

            // FIXTURES SERVICE //
            pnlFixtures.Controls.Clear();

            // Ensure the panel is properly docked
            pnlFixtures.Dock = DockStyle.Fill;

            // 1. Add buttons at the top
            btnGetFixtures.Location = new Point(20, 20);
            btnGetFixtures.Size = new Size(120, 30);
            btnGetFixtures.BackColor = Color.FromArgb(14, 99, 156);
            btnGetFixtures.ForeColor = Color.White;
            btnGetFixtures.FlatStyle = FlatStyle.Flat;
            btnGetFixtures.FlatAppearance.BorderSize = 0;
            btnGetFixtures.Text = "Get Fixtures";
            btnGetFixtures.Click += new System.EventHandler(this.btnGetFixtures_Click);

            btnGetResults.Location = new Point(150, 20);
            btnGetResults.Size = new Size(120, 30);
            btnGetResults.BackColor = Color.FromArgb(14, 99, 156);
            btnGetResults.ForeColor = Color.White;
            btnGetResults.FlatStyle = FlatStyle.Flat;
            btnGetResults.FlatAppearance.BorderSize = 0;
            btnGetResults.Text = "Get Results";
            btnGetResults.Click += new System.EventHandler(this.btnGetResults_Click);

            pnlFixtures.Controls.Add(btnGetFixtures);
            pnlFixtures.Controls.Add(btnGetResults);

            // 2. Add text box in the middle
            txtFixtures.Location = new Point(20, 60);
            txtFixtures.Size = new Size(pnlFixtures.Width - 40, 150);
            txtFixtures.Multiline = true;
            txtFixtures.BorderStyle = BorderStyle.FixedSingle;
            txtFixtures.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;
            pnlFixtures.Controls.Add(txtFixtures);

            // 3. Add Fixtures DataGridView with label
            Label lblFixtures = new Label();
            lblFixtures.Text = "Upcoming Fixtures";
            lblFixtures.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            lblFixtures.Location = new Point(20, 230);
            lblFixtures.AutoSize = true;
            pnlFixtures.Controls.Add(lblFixtures);

            dgvFixtures = new DataGridView();
            dgvFixtures.Location = new Point(20, 260);
            dgvFixtures.Size = new Size(pnlFixtures.Width - 40, 150);
            dgvFixtures.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;
            dgvFixtures.ReadOnly = true;
            dgvFixtures.AllowUserToAddRows = false;
            dgvFixtures.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvFixtures.Columns.Add("HomeTeam", "Home Team");
            dgvFixtures.Columns.Add("AwayTeam", "Away Team");
            dgvFixtures.Columns.Add("DateTime", "Date & Time");
            dgvFixtures.Columns.Add("Competition", "Competition");
            pnlFixtures.Controls.Add(dgvFixtures);

            // 4. Add Results DataGridView with label
            Label lblResults = new Label();
            lblResults.Text = "Recent Results";
            lblResults.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            lblResults.Location = new Point(20, 430);
            lblResults.AutoSize = true;
            pnlFixtures.Controls.Add(lblResults);

            dgvResults = new DataGridView();
            dgvResults.Location = new Point(20, 460);
            dgvResults.Size = new Size(pnlFixtures.Width - 40, 150);
            dgvResults.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;
            dgvResults.ReadOnly = true;
            dgvResults.AllowUserToAddRows = false;
            dgvResults.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvResults.Columns.Add("HomeTeam", "Home Team");
            dgvResults.Columns.Add("Score", "Score");
            dgvResults.Columns.Add("AwayTeam", "Away Team");
            dgvResults.Columns.Add("Competition", "Competition");
            dgvResults.Columns.Add("Date", "Date");
            pnlFixtures.Controls.Add(dgvResults);

            // TEAM SERVICE //
            // 1. Clear existing controls
            pnlTeams.Controls.Clear();

            // 2. Configure the main panel
            pnlTeams.BackColor = Color.White;
            pnlTeams.Dock = DockStyle.Fill;

            // 3. Create controls
            // Label for team name
            Label lblTeamName = new Label();
            lblTeamName.Text = "Team Name:";
            lblTeamName.Location = new Point(8, 11);
            lblTeamName.AutoSize = true;

            // Text box for team name
            txtTeamName = new TextBox();
            txtTeamName.Location = new Point(88, 8);
            txtTeamName.Size = new Size(168, 23);
            txtTeamName.Text = "Manchester United";

            // Button to get team profile
            btnGetTeamProfile = new Button();
            btnGetTeamProfile.Location = new Point(262, 8);
            btnGetTeamProfile.Size = new Size(100, 23);
            btnGetTeamProfile.Text = "Get Profile";
            btnGetTeamProfile.UseVisualStyleBackColor = true;
            btnGetTeamProfile.Click += new System.EventHandler(btnGetTeamProfile_Click);

            // Button to get team details
            Button btnGetTeamDetails = new Button();
            btnGetTeamDetails.Name = "btnGetTeamDetails";
            btnGetTeamDetails.Location = new Point(367, 8);
            btnGetTeamDetails.Size = new Size(100, 23);
            btnGetTeamDetails.Text = "Get Details";
            btnGetTeamDetails.BackColor = Color.DarkBlue;
            btnGetTeamDetails.ForeColor = Color.White;
            btnGetTeamDetails.Click += new System.EventHandler(btnGetTeamDetails_Click);

            // Text box for team profile information
            txtTeamProfile = new TextBox();
            txtTeamProfile.Multiline = true;
            txtTeamProfile.ReadOnly = true;
            txtTeamProfile.Location = new Point(8, 40);
            txtTeamProfile.Size = new Size(pnlTeams.Width - 16, 120);
            txtTeamProfile.Text = "Manchester United\r\nStadium: Old Trafford\r\nFounded: 1878\r\nCoach: Erik ten Hag";
            txtTeamProfile.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;

            // DataGridView for player listing
            // Create DataGridView for players
            dgvPlayers = new DataGridView();
            dgvPlayers.Location = new Point(8, 170);
            dgvPlayers.Size = new Size(pnlTeams.Width - 16, 180); // Fixed height for players grid
            dgvPlayers.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            dgvPlayers.ReadOnly = true;
            dgvPlayers.AllowUserToAddRows = false;
            dgvPlayers.BackgroundColor = Color.White;
            dgvPlayers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Add columns to players grid
            dgvPlayers.Columns.Add("Number", "No.");
            dgvPlayers.Columns.Add("Name", "Player Name");
            dgvPlayers.Columns.Add("Position", "Position");
            dgvPlayers.Columns.Add("Nationality", "Nationality");

            // Add sample data to players grid
            dgvPlayers.Rows.Add("10", "Marcus Rashford", "Forward", "England");
            dgvPlayers.Rows.Add("8", "Bruno Fernandes", "Midfielder", "Portugal");
            dgvPlayers.Rows.Add("5", "Harry Maguire", "Defender", "England");
            dgvPlayers.Rows.Add("1", "David de Gea", "Goalkeeper", "Spain");

            // Create label for teams section
            Label lblTeams = new Label();
            lblTeams.Text = "Team Players";
            lblTeams.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            lblTeams.Location = new Point(8, 360);
            lblTeams.AutoSize = true;

            // Create DataGridView for teams
            dgvTeams = new DataGridView();
            dgvTeams.Location = new Point(8, 400);
            dgvTeams.Size = new Size(pnlTeams.Width - 16, pnlTeams.Height - 395);
            dgvTeams.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvTeams.ReadOnly = true;
            dgvTeams.AllowUserToAddRows = false;
            dgvTeams.BackgroundColor = Color.White;
            dgvTeams.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Add columns to teams grid
            dgvTeams.Columns.Add("Number", "Number");
            dgvTeams.Columns.Add("Name", "name");
            dgvTeams.Columns.Add("Position", "position");
            dgvTeams.Columns.Add("Nationality", "Nationality");
            dgvTeams.Columns.Add("Age", "Age");

            // Add controls to panel
            pnlTeams.Controls.Add(dgvTeams);
            pnlTeams.Controls.Add(lblTeams);
            pnlTeams.Controls.Add(dgvPlayers);


            // 4. Add controls to panel in correct order (from background to foreground)
            pnlTeams.Controls.Add(dgvPlayers);
            pnlTeams.Controls.Add(dgvTeams);
            pnlTeams.Controls.Add(txtTeamProfile);
            pnlTeams.Controls.Add(btnGetTeamDetails);
            pnlTeams.Controls.Add(btnGetTeamProfile);
            pnlTeams.Controls.Add(txtTeamName);
            pnlTeams.Controls.Add(lblTeamName);

            // 5. Force layout update
            pnlTeams.PerformLayout();

        }
        private void InitializeServices()
        {
            _liveMatchService = ServiceFactory.CreateLiveMatchService();
            _fixturesService = ServiceFactory.CreateFixturesService();
            _teamService = ServiceFactory.CreateTeamService();
            _playerService = ServiceFactory.CreatePlayerService();
            _leagueService = ServiceFactory.CreateLeagueService();
            _searchService = ServiceFactory.CreateSearchService();
        }

        /// <summary>
        /// Initializes all UI adapter dependencies using the adapter factory.
        /// </summary>
        private void InitializeAdapters()
        {
            _liveMatchAdapter = AdapterFactory.CreateLiveMatchAdapter();
            _fixturesAdapter = AdapterFactory.CreateFixturesAdapter();
            _teamAdapter = AdapterFactory.CreateTeamAdapter();
            _playerAdapter = AdapterFactory.CreatePlayerAdapter();
            _leagueAdapter = AdapterFactory.CreateLeagueAdapter();
            _searchAdapter = AdapterFactory.CreateSearchAdapter();
        }

        /// <summary>
        /// Initializes UI components and sets default values.
        /// </summary>
        private void InitializeUIComponents()
        {
            // Initialize dropdown selections with null checks and item verification
            if (cmbNewsType != null && cmbNewsType.Items.Count > 0)
                cmbNewsType.SelectedIndex = 0;
            else if (cmbNewsType != null)
            {
                cmbNewsType.Items.Add("Trending");
                cmbNewsType.Items.Add("Personalized");
                cmbNewsType.SelectedIndex = 0;
            }

            if (cmbInteractionType != null && cmbInteractionType.Items.Count > 0)
                cmbInteractionType.SelectedIndex = 0;
            else if (cmbInteractionType != null)
            {
                cmbInteractionType.Items.Add("Poll");
                cmbInteractionType.Items.Add("Trivia");
                cmbInteractionType.SelectedIndex = 0;
            }

            if (cmbVideoService != null && cmbVideoService.Items.Count > 0)
                cmbVideoService.SelectedIndex = 0;
            else if (cmbVideoService != null)
            {
                cmbVideoService.Items.Add("Highlight");
                cmbVideoService.Items.Add("Replay");
                cmbVideoService.SelectedIndex = 0;
            }

            // Set status message
            statusLabel.Text = $"Ready - Logged in as {_username}";
        }

        /// <summary>
        /// Handles the form load event.
        /// </summary>
        private void MainForm_Load(object sender, EventArgs e)
        {
            // Additional form load operations can go here
        }

        #region Tab Navigation

        /// <summary>
        /// Sets the active tab and handles the UI changes.
        /// </summary>
        /// <param name="activeButton">The button corresponding to the active tab.</param>
        private void SetActiveTab(Button activeButton)
        {
            // Reset all buttons to default style
            foreach (Control control in pnlTabs.Controls)
            {
                if (control is Button button)
                {
                    button.BackColor = Color.FromArgb(45, 45, 48);
                    button.ForeColor = Color.White;
                }
            }

            // Set active button style
            activeButton.BackColor = Color.FromArgb(0, 122, 204);
            activeButton.ForeColor = Color.White;

            // Hide all panels
            foreach (Control control in pnlContent.Controls)
            {
                control.Visible = false;
            }

            // Show the panel corresponding to the active button
            if (activeButton == btnLiveMatches)
                pnlLiveMatches.Visible = true;
            else if (activeButton == btnFixtures)
                pnlFixtures.Visible = true;
            else if (activeButton == btnTeams)
                pnlTeams.Visible = true;
            else if (activeButton == btnPlayers)
                pnlPlayers.Visible = true;
            else if (activeButton == btnLeague)
                pnlLeague.Visible = true;
            else if (activeButton == btnNews)
                pnlNews.Visible = true;
            else if (activeButton == btnFanInteraction)
                pnlFanInteraction.Visible = true;
            else if (activeButton == btnVideo)
                pnlVideo.Visible = true;
            else if (activeButton == btnSearchTab)
                pnlSearch.Visible = true;

            // Update status bar
            statusLabel.Text = $"Ready - {activeButton.Text.Trim()} section";
        }

        private void btnLiveMatches_Click(object sender, EventArgs e) => SetActiveTab(btnLiveMatches);
        private void btnFixtures_Click(object sender, EventArgs e) => SetActiveTab(btnFixtures);
        private void btnTeams_Click(object sender, EventArgs e) => SetActiveTab(btnTeams);
        private void btnPlayers_Click(object sender, EventArgs e) => SetActiveTab(btnPlayers);
        private void btnLeague_Click(object sender, EventArgs e) => SetActiveTab(btnLeague);
        private void btnNews_Click(object sender, EventArgs e) => SetActiveTab(btnNews);
        private void btnFanInteraction_Click(object sender, EventArgs e) => SetActiveTab(btnFanInteraction);
        private void btnVideo_Click(object sender, EventArgs e) => SetActiveTab(btnVideo);
        // Tab button click handler
        private void btnSearchTab_Click(object sender, EventArgs e) => SetActiveTab(btnSearchTab);

        #endregion

        #region Service Actions

        /// <summary>
        /// Gets live match updates and displays them in the UI.
        /// </summary>
        private void btnGetMatchUpdates_Click(object sender, EventArgs e)
        {
            try
            {
                statusLabel.Text = "Fetching live match updates...";

                // Apply a decorator for logging
                IService decoratedService = DecoratorFactory.AddLogging(_liveMatchService);
                txtLiveMatches.Text = decoratedService.Execute();

                if (dgvLiveMatches != null)
                {
                    dgvLiveMatches.DataSource = null;
                    _liveMatchAdapter.PopulateMatchDataGrid(dgvLiveMatches);
                }

                statusLabel.Text = "Live match updates loaded successfully";
            }
            catch (Exception ex)
            {
                ShowError("Error getting match updates", ex);
            }
        }

        /// <summary>
        /// Gets fixtures and displays them in the UI.
        /// </summary>
        private void btnGetFixtures_Click(object sender, EventArgs e)
        {
            try
            {
                statusLabel.Text = "Fetching fixtures...";

                // Apply caching decorator to fixtures service
                IService cachedService = DecoratorFactory.AddCaching(_fixturesService, "fixtures");
                txtFixtures.Text = cachedService.Execute();

                if (dgvFixtures != null)
                {
                    dgvFixtures.DataSource = null;
                    _fixturesAdapter.PopulateFixturesDataGrid(dgvFixtures);
                }

                statusLabel.Text = "Fixtures loaded successfully";
            }
            catch (Exception ex)
            {
                ShowError("Error getting fixtures", ex);
            }
        }

        /// <summary>
        /// Gets results and displays them in the UI.
        /// </summary>
        private void btnGetResults_Click(object sender, EventArgs e)
        {
            try
            {
                statusLabel.Text = "Fetching results...";

                // Apply retry decorator to fixtures service
                IService reliableService = DecoratorFactory.AddReliabilityDecorators(_fixturesService);
                txtFixtures.Text = _fixturesService.GetResults();

                if (dgvResults != null)
                {
                    dgvResults.DataSource = null;
                    _fixturesAdapter.PopulateResultsDataGrid(dgvResults);
                }

                statusLabel.Text = "Results loaded successfully";
            }
            catch (Exception ex)
            {
                ShowError("Error getting results", ex);
            }
        }

        /// <summary>
        /// Gets team profile and displays it in the UI.
        /// </summary>
        private void btnGetTeamProfile_Click(object sender, EventArgs e)
        {
            try
            {
                string teamName = txtTeamName.Text;
                if (string.IsNullOrWhiteSpace(teamName))
                {
                    MessageBox.Show("Please enter a team name", "Input Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                statusLabel.Text = $"Fetching profile for {teamName}...";

                // Use a combination of caching and logging decorators
                var cachedTeamService = DecoratorFactory.AddCaching(
                    DecoratorFactory.AddLogging(_teamService),
                    $"team-{teamName}",
                    TimeSpan.FromMinutes(10)
                );

                txtTeamProfile.Text = _teamService.GetTeamProfile(teamName);

                if (lblFullName != null && lblStadium != null && lblFoundingYear != null &&
                    lblCoach != null && dgvPlayers != null)
                {
                    dgvPlayers.DataSource = null;
                    _teamAdapter.PopulateTeamProfile(teamName, lblFullName, lblStadium,
                        lblFoundingYear, lblCoach, dgvPlayers);
                }

                statusLabel.Text = $"Team profile for {teamName} loaded successfully";
            }
            catch (Exception ex)
            {
                ShowError("Error getting team profile", ex);
            }
        }

        // Add this event handler for the new button
        private void btnGetTeamDetails_Click(object sender, EventArgs e)
        {
            try
            {
                string teamName = txtTeamName.Text;
                if (string.IsNullOrWhiteSpace(teamName))
                {
                    MessageBox.Show("Please enter a team name", "Input Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Set status message (if you have a status bar)
                if (statusLabel != null)
                    statusLabel.Text = $"Fetching detailed stats for {teamName}...";

                // First clear any existing data
                dgvPlayers.Rows.Clear();
                dgvTeams.DataSource = null;

                // Use the adapter to populate the UI elements
                _teamAdapter.PopulateTeamProfile(
                    teamName,
                    lblFullName,
                    lblStadium,
                    lblFoundingYear,
                    lblCoach,
                    dgvPlayers
                );

                // Update status message
                if (statusLabel != null)
                    statusLabel.Text = $"Detailed stats for {teamName} loaded successfully";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error getting team details: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (statusLabel != null)
                    statusLabel.Text = "Error retrieving team details";
            }
        }

        /// <summary>
        /// Gets player profile and displays it in the UI.
        /// </summary>
        private void btnGetPlayerProfile_Click(object sender, EventArgs e)
        {
            try
            {
                string playerName = txtPlayerName.Text;
                if (string.IsNullOrWhiteSpace(playerName))
                {
                    MessageBox.Show("Please enter a player name", "Input Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                statusLabel.Text = $"Fetching profile for {playerName}...";


                // Use retry with performance monitoring
                var reliablePlayerService = DecoratorFactory.AddRetry(
                    DecoratorFactory.AddPerformanceMonitoring(_playerService),
                    3,
                    TimeSpan.FromSeconds(1)
                );

                txtPlayerProfile.Text = _playerService.GetPlayerProfile(playerName);

                // Note: UI population is commented out until controls are added to form
                _playerAdapter.PopulatePlayerProfile(playerName, lblPlayerName, lblNumber,
                    lblAge, lblHeight, lblNationality, lblPosition, lblClub,
                    prgPace, prgShooting, prgDribbling, prgPassing, prgDefense,
                    lblPaceValue, lblShootingValue, lblDribblingValue, lblPassingValue, lblDefenseValue);

                statusLabel.Text = $"Player profile for {playerName} loaded successfully";
            }
            catch (Exception ex)
            {
                ShowError("Error getting player profile", ex);
            }
        }

        /// <summary>
        /// Gets league standings and displays them in the UI.
        /// </summary>
        private void btnGetLeagueStandings_Click(object sender, EventArgs e)
        {
            try
            {
                // Default to Premier League if no combo box exists
                string leagueName = "Premier League";

                statusLabel.Text = $"Fetching {leagueName} standings...";

                // Apply performance monitoring decorator
                IService decoratedService = DecoratorFactory.AddPerformanceMonitoring(_leagueService);
                txtLeagueStandings.Text = decoratedService.Execute();

                // Note: UI population is commented out until controls are added to form
                //_leagueAdapter.PopulateLeagueStandings(leagueName, dgvLeagueTable);

                statusLabel.Text = $"{leagueName} standings loaded successfully";
            }
            catch (Exception ex)
            {
                ShowError("Error getting league standings", ex);
            }
        }

        /// <summary>
        /// Gets news and displays them in the UI.
        /// </summary>
        private void btnGetNews_Click(object sender, EventArgs e)
        {
            try
            {
                string newsType = cmbNewsType.SelectedItem.ToString();
                string preference = txtNewsPreference.Text;

                statusLabel.Text = $"Fetching {newsType} news for {preference}...";

                INewsService newsService = ServiceFactory.CreateNewsService(newsType, preference);
                txtNews.Text = newsService.GetNewsByPreference(preference);

                statusLabel.Text = $"News loaded successfully";
            }
            catch (Exception ex)
            {
                ShowError("Error getting news", ex);
            }
        }

        /// <summary>
        /// Submits fan interaction and displays the result in the UI.
        /// </summary>
        private void btnSubmitInteraction_Click(object sender, EventArgs e)
        {
            try
            {
                string interactionType = cmbInteractionType.SelectedItem.ToString();
                string type = txtInteractionType.Text;
                string input = txtInteractionInput.Text;

                statusLabel.Text = $"Processing {interactionType} interaction...";

                IFanInteractionService interactionService = ServiceFactory.CreateFanInteractionService(interactionType, type, input);
                txtFanInteraction.Text = interactionService.Interact(type, input);

                statusLabel.Text = $"Fan interaction submitted successfully";
            }
            catch (Exception ex)
            {
                ShowError("Error with fan interaction", ex);
            }
        }

        /// <summary>
        /// Fetches video and displays it in the UI.
        /// </summary>
        private void btnFetchVideo_Click(object sender, EventArgs e)
        {
            try
            {
                string videoServiceType = cmbVideoService.SelectedItem.ToString();
                string videoType = txtVideoType.Text;

                statusLabel.Text = $"Fetching {videoType} video...";

                IVideoService videoService = ServiceFactory.CreateVideoService(videoServiceType, videoType);
                txtVideo.Text = videoService.FetchVideo(videoType);

                statusLabel.Text = $"Video loaded successfully";
            }
            catch (Exception ex)
            {
                ShowError("Error fetching video", ex);
            }
        }

        /// <summary>
        /// Executes a search and displays the results in the UI.
        /// </summary>
        private void btnExecuteSearch_Click(object sender, EventArgs e)
        {
            try
            {
                string query = txtSearchQuery.Text;
                if (string.IsNullOrWhiteSpace(query))
                {
                    MessageBox.Show("Please enter a search query", "Input Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                statusLabel.Text = $"Searching for '{query}'...";

                // Apply multiple decorators for demonstration
                ISearchService searchService = ServiceFactory.CreateSearchService(query);
                IService decoratedService = DecoratorFactory.AddAllDecorators(searchService);
                txtSearchResults.Text = searchService.Search(query);

                // Check if UI controls are available before accessing them
                bool controlsAvailable = lvTeamResults != null &&
                                        lvPlayerResults != null &&
                                        lvMatchResults != null;

                if (controlsAvailable)
                {
                    // Use adapter to populate search results
                    _searchAdapter.PopulateSearchResults(query, (ListView)lvTeamResults, (ListView)lvPlayerResults, (ListView)lvMatchResults);
                }

                statusLabel.Text = $"Search results for '{query}' loaded successfully";
            }
            catch (Exception ex)
            {
                ShowError("Error performing search", ex);
            }
        }

        #endregion

        #region Menu Items

        /// <summary>
        /// Handles the exit menu item click event.
        /// </summary>
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        /// <summary>
        /// Handles the about menu item click event.
        /// </summary>
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                "Football Manager Application\n" +
                "Version 1.0\n\n" +
                "A comprehensive platform for football enthusiasts to access live updates, " +
                "team profiles, league standings, and more.",
                "About",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }

        #endregion

        /// <summary>
        /// Displays an error message box with details about the exception.
        /// </summary>
        /// <param name="message">The error message.</param>
        /// <param name="ex">The exception that occurred.</param>
        private void ShowError(string message, Exception ex)
        {
            MessageBox.Show($"{message}: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            statusLabel.Text = $"Error: {message}";

            // Log the exception (could be expanded to use a proper logging framework)
            Console.WriteLine($"[ERROR] {DateTime.Now}: {message} - {ex}");
        }
    }
}