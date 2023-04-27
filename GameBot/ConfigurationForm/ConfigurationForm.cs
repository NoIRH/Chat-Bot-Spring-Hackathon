using BotClient.Services;

namespace ConfigurationForm
{
    public partial class ConfigurationForm : Form
    {
        private BotManager _teleBot;
        public static string StringConnection { get; set; } = "Host=localhost;Port=5432;Database=testdb;Username=postgres;Password=31428";
        public ConfigurationForm()
        {
            InitializeComponent();

        }

        private void buttonBotStart_Click(object sender, EventArgs e)
        {
            _teleBot = new BotManager();
            _teleBot.Start(StringConnection);
        }

        private void buttonBotStop_Click(object sender, EventArgs e)
        {
            _teleBot.Stop();
        }

        private void buttonChangeStringConnection_Click(object sender, EventArgs e)
        {
            StringConnection = $"Host={fieldHost.Text};Port={fieldPort.Text};Database={fieldDatabase.Text};Username={fieldUsername};Password={fieldPassword}";
        }

        private void ConfigurationForm_Load(object sender, EventArgs e)
        {

        }
    }
}