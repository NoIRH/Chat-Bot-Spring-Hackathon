namespace ConfigurationForm
{
    partial class ConfigurationForm
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
            groupBox1 = new GroupBox();
            buttonChangeStringConnection = new Button();
            fieldPassword = new TextBox();
            label5 = new Label();
            fieldUsername = new TextBox();
            label4 = new Label();
            fieldDatabase = new TextBox();
            label3 = new Label();
            fieldPort = new TextBox();
            label2 = new Label();
            fieldHost = new TextBox();
            label1 = new Label();
            button1 = new Button();
            buttonBotStart = new Button();
            groupBox2 = new GroupBox();
            changeToken = new Button();
            botTokenField = new TextBox();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(buttonChangeStringConnection);
            groupBox1.Controls.Add(fieldPassword);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(fieldUsername);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(fieldDatabase);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(fieldPort);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(fieldHost);
            groupBox1.Controls.Add(label1);
            groupBox1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            groupBox1.Location = new Point(14, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(455, 295);
            groupBox1.TabIndex = 5;
            groupBox1.TabStop = false;
            groupBox1.Text = "Строка подключения  бд";
            // 
            // buttonChangeStringConnection
            // 
            buttonChangeStringConnection.Location = new Point(13, 233);
            buttonChangeStringConnection.Name = "buttonChangeStringConnection";
            buttonChangeStringConnection.Size = new Size(350, 43);
            buttonChangeStringConnection.TabIndex = 10;
            buttonChangeStringConnection.Text = "Задать  строку подключения бд";
            buttonChangeStringConnection.UseVisualStyleBackColor = true;
            buttonChangeStringConnection.Click += buttonChangeStringConnection_Click;
            // 
            // fieldPassword
            // 
            fieldPassword.Location = new Point(119, 193);
            fieldPassword.Name = "fieldPassword";
            fieldPassword.Size = new Size(318, 34);
            fieldPassword.TabIndex = 9;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(13, 196);
            label5.Name = "label5";
            label5.Size = new Size(101, 28);
            label5.TabIndex = 8;
            label5.Text = "Password";
            // 
            // fieldUsername
            // 
            fieldUsername.Location = new Point(119, 153);
            fieldUsername.Name = "fieldUsername";
            fieldUsername.Size = new Size(318, 34);
            fieldUsername.TabIndex = 7;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(13, 156);
            label4.Name = "label4";
            label4.Size = new Size(106, 28);
            label4.TabIndex = 6;
            label4.Text = "Username";
            // 
            // fieldDatabase
            // 
            fieldDatabase.Location = new Point(119, 113);
            fieldDatabase.Name = "fieldDatabase";
            fieldDatabase.Size = new Size(318, 34);
            fieldDatabase.TabIndex = 5;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(13, 116);
            label3.Name = "label3";
            label3.Size = new Size(100, 28);
            label3.TabIndex = 4;
            label3.Text = "Database";
            // 
            // fieldPort
            // 
            fieldPort.Location = new Point(118, 73);
            fieldPort.Name = "fieldPort";
            fieldPort.Size = new Size(319, 34);
            fieldPort.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(13, 76);
            label2.Name = "label2";
            label2.Size = new Size(52, 28);
            label2.TabIndex = 2;
            label2.Text = "Port";
            // 
            // fieldHost
            // 
            fieldHost.Location = new Point(118, 33);
            fieldHost.Name = "fieldHost";
            fieldHost.Size = new Size(319, 34);
            fieldHost.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(13, 36);
            label1.Name = "label1";
            label1.Size = new Size(56, 28);
            label1.TabIndex = 0;
            label1.Text = "Host";
            // 
            // button1
            // 
            button1.Location = new Point(342, 329);
            button1.Name = "button1";
            button1.Size = new Size(322, 89);
            button1.TabIndex = 4;
            button1.Text = "Остановить бота";
            button1.UseVisualStyleBackColor = true;
            button1.Click += buttonBotStop_Click;
            // 
            // buttonBotStart
            // 
            buttonBotStart.Location = new Point(14, 329);
            buttonBotStart.Name = "buttonBotStart";
            buttonBotStart.Size = new Size(322, 89);
            buttonBotStart.TabIndex = 3;
            buttonBotStart.Text = "Запустить бота";
            buttonBotStart.UseVisualStyleBackColor = true;
            buttonBotStart.Click += buttonBotStart_Click;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(changeToken);
            groupBox2.Controls.Add(botTokenField);
            groupBox2.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            groupBox2.Location = new Point(475, 12);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(455, 124);
            groupBox2.TabIndex = 11;
            groupBox2.TabStop = false;
            groupBox2.Text = "Токен бота";
            // 
            // changeToken
            // 
            changeToken.Location = new Point(6, 75);
            changeToken.Name = "changeToken";
            changeToken.Size = new Size(183, 43);
            changeToken.TabIndex = 11;
            changeToken.Text = "Задать токен";
            changeToken.UseVisualStyleBackColor = true;
            changeToken.Click += changeToken_Click;
            // 
            // botTokenField
            // 
            botTokenField.Location = new Point(6, 33);
            botTokenField.Name = "botTokenField";
            botTokenField.Size = new Size(431, 34);
            botTokenField.TabIndex = 1;
            // 
            // ConfigurationForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(943, 431);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(button1);
            Controls.Add(buttonBotStart);
            Name = "ConfigurationForm";
            Text = "Форма управления";
            Load += ConfigurationForm_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private Button buttonChangeStringConnection;
        private TextBox fieldPassword;
        private Label label5;
        private TextBox fieldUsername;
        private Label label4;
        private TextBox fieldDatabase;
        private Label label3;
        private TextBox fieldPort;
        private Label label2;
        private TextBox fieldHost;
        private Label label1;
        private Button button1;
        private Button buttonBotStart;
        private GroupBox groupBox2;
        private TextBox botTokenField;
        private Button changeToken;
    }
}