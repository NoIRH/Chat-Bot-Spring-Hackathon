using BotClient.Services;

namespace ConfigurationForm
{
    public partial class ConfigurationForm : Form
    {
        private BotManager _teleBot;
        private static string StringConnectionArtem { get; set; } = "Host=localhost;Port=5432;Database=testdb;Username=postgres;Password=1463638";
        private static string StringConnectionVictor { get; set; } = "Host=localhost;Port=5432;Database=testdb;Username=postgres;Password=31428";
        private static string BotToken { get; set; } = "5921385779:AAEBFzLyOjmL2TJ1eQ4tsGu79B0Hn4d4mKA";

        public ConfigurationForm()
        {
            InitializeComponent();
        }

        private void buttonBotStop_Click(object sender, EventArgs e)
        {
            _teleBot.Stop();
        }

        private void buttonChangeStringConnection_Click(object sender, EventArgs e)
        {
            StringConnectionArtem = $"Host={fieldHost.Text};Port={fieldPort.Text};Database={fieldDatabase.Text};Username={fieldUsername};Password={fieldPassword}";
            StringConnectionVictor = $"Host={fieldHost.Text};Port={fieldPort.Text};Database={fieldDatabase.Text};Username={fieldUsername};Password={fieldPassword}";
        }

        private void ConfigurationForm_Load(object sender, EventArgs e)
        {

        }

        private void changeToken_Click(object sender, EventArgs e)
        {
            BotToken = botTokenField.Text;
        }

        private void buttonBotStartArtem_Click(object sender, EventArgs e)
        {
            _teleBot = new BotManager(BotToken);
            _teleBot.Start(StringConnectionArtem);
        }

        private void buttonBotStartVictor_Click(object sender, EventArgs e)
        {
            _teleBot = new BotManager(BotToken);
            _teleBot.Start(StringConnectionVictor);
        }
    }
}