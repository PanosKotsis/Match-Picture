namespace Match_picture
{
    partial class Form1
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
            components = new System.ComponentModel.Container();
            label1 = new Label();
            label2 = new Label();
            timer1 = new System.Windows.Forms.Timer(components);
            button_back = new Button();
            button_restart = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Cambria", 14.25F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 161);
            label1.Location = new Point(640, 9);
            label1.Name = "label1";
            label1.Size = new Size(96, 22);
            label1.TabIndex = 0;
            label1.Text = "Attempts :";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Cambria", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 161);
            label2.Location = new Point(12, 9);
            label2.Name = "label2";
            label2.Size = new Size(64, 22);
            label2.TabIndex = 1;
            label2.Text = "Timer";
            // 
            // timer1
            // 
            timer1.Interval = 1000;
            timer1.Tick += TimerEvent;
            // 
            // button_back
            // 
            button_back.Font = new Font("Franklin Gothic Medium", 11.25F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            button_back.Location = new Point(661, 401);
            button_back.Name = "button_back";
            button_back.Size = new Size(127, 37);
            button_back.TabIndex = 2;
            button_back.Text = "Back To Menu";
            button_back.UseVisualStyleBackColor = true;
            button_back.Click += button_back_Click_1;
            // 
            // button_restart
            // 
            button_restart.Font = new Font("Franklin Gothic Medium", 11.25F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            button_restart.Location = new Point(12, 401);
            button_restart.Name = "button_restart";
            button_restart.Size = new Size(127, 37);
            button_restart.TabIndex = 3;
            button_restart.Text = "Restart Game";
            button_restart.UseVisualStyleBackColor = true;
            button_restart.Click += button_restart_Click_1;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Chocolate;
            ClientSize = new Size(800, 450);
            Controls.Add(button_restart);
            Controls.Add(button_back);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private System.Windows.Forms.Timer timer1;
        private Button button_back;
        private Button button_restart;
    }
}
