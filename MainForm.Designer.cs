namespace MathGame
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        // UI Элементы
        private System.Windows.Forms.Label lblEquation;
        private System.Windows.Forms.TextBox txtAnswer;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Label lblScore;
        private System.Windows.Forms.Label lblTimer;
        private System.Windows.Forms.Label lblRound;
        private System.Windows.Forms.ListBox lstLeaderboard;
        private System.Windows.Forms.Label lblLeaderboardTitle;
        private System.Windows.Forms.Timer gameTimer;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lblEquation = new System.Windows.Forms.Label();
            this.txtAnswer = new System.Windows.Forms.TextBox();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.lblScore = new System.Windows.Forms.Label();
            this.lblTimer = new System.Windows.Forms.Label();
            this.lblRound = new System.Windows.Forms.Label();
            this.lstLeaderboard = new System.Windows.Forms.ListBox();
            this.lblLeaderboardTitle = new System.Windows.Forms.Label();
            this.gameTimer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();

            // lblEquation
            this.lblEquation.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
            this.lblEquation.Location = new System.Drawing.Point(20, 60);
            this.lblEquation.Name = "lblEquation";
            this.lblEquation.Size = new System.Drawing.Size(260, 50);
            this.lblEquation.TabIndex = 0;
            this.lblEquation.Text = "Нажмите Старт";
            this.lblEquation.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // txtAnswer
            this.txtAnswer.Font = new System.Drawing.Font("Segoe UI", 16F);
            this.txtAnswer.Location = new System.Drawing.Point(90, 120);
            this.txtAnswer.Name = "txtAnswer";
            this.txtAnswer.Size = new System.Drawing.Size(120, 36);
            this.txtAnswer.TabIndex = 1;
            this.txtAnswer.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtAnswer.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtAnswer_KeyDown);

            // btnSubmit
            this.btnSubmit.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnSubmit.Location = new System.Drawing.Point(90, 170);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(120, 40);
            this.btnSubmit.TabIndex = 2;
            this.btnSubmit.Text = "Ответить";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);

            // btnStart
            this.btnStart.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnStart.Location = new System.Drawing.Point(20, 12);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(260, 40);
            this.btnStart.TabIndex = 3;
            this.btnStart.Text = "Начать новую игру";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);

            // lblScore
            this.lblScore.AutoSize = true;
            this.lblScore.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblScore.Location = new System.Drawing.Point(20, 230);
            this.lblScore.Name = "lblScore";
            this.lblScore.Text = "Очки: 0";

            // lblTimer
            this.lblTimer.AutoSize = true;
            this.lblTimer.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblTimer.ForeColor = System.Drawing.Color.Red;
            this.lblTimer.Location = new System.Drawing.Point(180, 230);
            this.lblTimer.Name = "lblTimer";
            this.lblTimer.Text = "Время: 15";

            // lblRound
            this.lblRound.AutoSize = true;
            this.lblRound.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblRound.Location = new System.Drawing.Point(20, 260);
            this.lblRound.Name = "lblRound";
            this.lblRound.Text = "Раунд: 0 / 10";

            // lblLeaderboardTitle
            this.lblLeaderboardTitle.AutoSize = true;
            this.lblLeaderboardTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblLeaderboardTitle.Location = new System.Drawing.Point(310, 20);
            this.lblLeaderboardTitle.Name = "lblLeaderboardTitle";
            this.lblLeaderboardTitle.Text = "Рекорды сессии:";

            // lstLeaderboard
            this.lstLeaderboard.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lstLeaderboard.FormattingEnabled = true;
            this.lstLeaderboard.ItemHeight = 17;
            this.lstLeaderboard.Location = new System.Drawing.Point(310, 50);
            this.lstLeaderboard.Name = "lstLeaderboard";
            this.lstLeaderboard.Size = new System.Drawing.Size(160, 225);
            this.lstLeaderboard.TabIndex = 4;

            // gameTimer
            this.gameTimer.Interval = 1000;
            this.gameTimer.Tick += new System.EventHandler(this.gameTimer_Tick);

            // MainForm
            this.ClientSize = new System.Drawing.Size(490, 300);
            this.Controls.Add(this.lstLeaderboard);
            this.Controls.Add(this.lblLeaderboardTitle);
            this.Controls.Add(this.lblRound);
            this.Controls.Add(this.lblTimer);
            this.Controls.Add(this.lblScore);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.txtAnswer);
            this.Controls.Add(this.lblEquation);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Игра «Математик»";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}