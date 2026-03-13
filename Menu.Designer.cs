namespace Match_picture
{
    partial class Menu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Play_btn = new Button();
            Settings_btn = new Button();
            leaderboard_btn = new Button();
            Sport_btn = new Button();
            programm_btn = new Button();
            player_btn = new Button();
            back_btn = new Button();
            name_txt = new TextBox();
            name_lbl = new Label();
            richTextBox1 = new RichTextBox();
            SuspendLayout();
            // 
            // Play_btn
            // 
            Play_btn.BackColor = Color.ForestGreen;
            Play_btn.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 161);
            Play_btn.Location = new Point(327, 78);
            Play_btn.Name = "Play_btn";
            Play_btn.Size = new Size(167, 39);
            Play_btn.TabIndex = 0;
            Play_btn.Text = "Play\r\n";
            Play_btn.UseVisualStyleBackColor = false;
            Play_btn.Click += Play_btn_Click;
            // 
            // Settings_btn
            // 
            Settings_btn.BackColor = Color.ForestGreen;
            Settings_btn.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 161);
            Settings_btn.Location = new Point(327, 213);
            Settings_btn.Name = "Settings_btn";
            Settings_btn.Size = new Size(167, 39);
            Settings_btn.TabIndex = 1;
            Settings_btn.Text = "Settings";
            Settings_btn.UseVisualStyleBackColor = false;
            Settings_btn.Click += Settings_btn_Click;
            // 
            // leaderboard_btn
            // 
            leaderboard_btn.BackColor = Color.ForestGreen;
            leaderboard_btn.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 161);
            leaderboard_btn.Location = new Point(327, 359);
            leaderboard_btn.Name = "leaderboard_btn";
            leaderboard_btn.Size = new Size(167, 39);
            leaderboard_btn.TabIndex = 2;
            leaderboard_btn.Text = "LeaderBoard";
            leaderboard_btn.UseVisualStyleBackColor = false;
            leaderboard_btn.Click += leaderboard_btn_Click;
            // 
            // Sport_btn
            // 
            Sport_btn.BackColor = Color.ForestGreen;
            Sport_btn.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 161);
            Sport_btn.Location = new Point(12, 151);
            Sport_btn.Name = "Sport_btn";
            Sport_btn.Size = new Size(167, 39);
            Sport_btn.TabIndex = 3;
            Sport_btn.Text = "Sport";
            Sport_btn.UseVisualStyleBackColor = false;
            Sport_btn.Click += Sport_btn_Click;
            // 
            // programm_btn
            // 
            programm_btn.BackColor = Color.ForestGreen;
            programm_btn.Font = new Font("Segoe UI Black", 12F, FontStyle.Bold, GraphicsUnit.Point, 161);
            programm_btn.Location = new Point(301, 151);
            programm_btn.Name = "programm_btn";
            programm_btn.Size = new Size(217, 39);
            programm_btn.TabIndex = 4;
            programm_btn.Text = "Programming Languages\r\n";
            programm_btn.UseVisualStyleBackColor = false;
            programm_btn.Click += programm_btn_Click;
            // 
            // player_btn
            // 
            player_btn.BackColor = Color.ForestGreen;
            player_btn.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 161);
            player_btn.Location = new Point(621, 151);
            player_btn.Name = "player_btn";
            player_btn.Size = new Size(167, 39);
            player_btn.TabIndex = 5;
            player_btn.Text = "Your File";
            player_btn.UseVisualStyleBackColor = false;
            player_btn.Click += player_btn_Click;
            // 
            // back_btn
            // 
            back_btn.BackColor = Color.ForestGreen;
            back_btn.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 161);
            back_btn.Location = new Point(12, 399);
            back_btn.Name = "back_btn";
            back_btn.Size = new Size(167, 39);
            back_btn.TabIndex = 6;
            back_btn.Text = "Back";
            back_btn.UseVisualStyleBackColor = false;
            back_btn.Click += back_btn_Click;
            // 
            // name_txt
            // 
            name_txt.Location = new Point(12, 49);
            name_txt.Name = "name_txt";
            name_txt.Size = new Size(208, 23);
            name_txt.TabIndex = 7;
            // 
            // name_lbl
            // 
            name_lbl.AutoSize = true;
            name_lbl.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 161);
            name_lbl.Location = new Point(12, 9);
            name_lbl.Name = "name_lbl";
            name_lbl.Size = new Size(157, 21);
            name_lbl.TabIndex = 8;
            name_lbl.Text = "Enter player name :";
            // 
            // richTextBox1
            // 
            richTextBox1.Location = new Point(248, 112);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(326, 326);
            richTextBox1.TabIndex = 9;
            richTextBox1.Text = "";
            // 
            // Menu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.SandyBrown;
            ClientSize = new Size(800, 450);
            Controls.Add(richTextBox1);
            Controls.Add(name_lbl);
            Controls.Add(name_txt);
            Controls.Add(back_btn);
            Controls.Add(player_btn);
            Controls.Add(programm_btn);
            Controls.Add(Sport_btn);
            Controls.Add(leaderboard_btn);
            Controls.Add(Settings_btn);
            Controls.Add(Play_btn);
            Name = "Menu";
            Text = "Menu";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button Play_btn;
        private Button Settings_btn;
        private Button leaderboard_btn;
        private Button Sport_btn;
        private Button programm_btn;
        private Button player_btn;
        private Button back_btn;
        private TextBox name_txt;
        private Label name_lbl;
        private RichTextBox richTextBox1;
    }
}