using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Data.SQLite;
using System.Drawing.Text;

namespace Match_picture
{
    public partial class Menu : Form
    {
        private List<string> selectedImages = new List<string>();
        DatabaseManager db = new DatabaseManager();
        public Menu()
        {
            InitializeComponent();

            this.BackgroundImage = Properties.Resources.background1;
            this.BackgroundImageLayout = ImageLayout.Stretch;

            // Ότι δεν χρειάζεται να φαίνεται στην αρχή του μενού
            player_btn.Visible = false;
            Sport_btn.Visible = false;
            programm_btn.Visible = false;
            back_btn.Visible = false;
            name_lbl.Visible = false;
            name_txt.Visible = false;
            richTextBox1.Visible = false;
            richTextBox1.Enabled = false;
        }

        // Λογική μεταβλητή για το αν έχει συμπληρώση τα settings ο παίχτης
        private bool gamesettings = false;

        // το mode που έχει επιλέξει είναι ορατό σε όλες τις κλάσεις
        public string mode;

        // Η μέθοδος που εμφανίζει τον πίνακα των ΤΟΠ 10 παικτών
        public void DisplayLeaderBoard()
        {
            try
            {
                DataTable dt = db.GetLeaderboard();

                richTextBox1.Clear();

                
                richTextBox1.AppendText("ΚΑΤΑΤΑΞΗ - TOP 10 PLAYERS\n");
                richTextBox1.SelectionFont = new Font(richTextBox1.Font, FontStyle.Regular);

                int rank = 1;
                foreach (DataRow row in dt.Rows)
                {
                    string name = row["PlayerName"].ToString();
                    int attempts = Convert.ToInt32(row["Attempts"]);
                    int totalSeconds = Convert.ToInt32(row["FullTime"]);

                    // Μετατροπή δευτερολέπτων σε λεπτά:δευτερόλεπτα
                    TimeSpan t = TimeSpan.FromSeconds(totalSeconds);
                    string timeFormatted = string.Format("{0:D2}:{1:D2}", t.Minutes, t.Seconds);

                    // Χρησιμοποιούμε PadRight για να μένουν οι στήλες ευθυγραμμισμένες
                    string line = $"{rank}. {name.PadRight(15)} | Προσπάθειες: {attempts} | Χρόνος: {timeFormatted}\n";
                    richTextBox1.AppendText(line);
                    rank++;
                }
            }
            // Η περίπτωση που υπάρχει κάποιο σφάλμα κατα την φόρτωση εμφανίζει το αντίστοιχο μήνυμα
            catch (Exception ex)
            {
                MessageBox.Show("Σφάλμα κατά τη φόρτωση του leaderboard: " + ex.Message);
            }
        }

        // Πατήσει ο χρήστης το κουμπί play ελέγχεται αν πληρεί τις απαιτούμενες προδιογραφές που έχουν οριστεί στα settings
        private async void Play_btn_Click(object sender, EventArgs e)
        {
            Check_Settings();

        }

        // Μέθοδος για να αποφεχθούν πολλές επαναλήψεις για την ορατότητα των 3ιων αρχικών κουμπιών
        private void Disappear_btn(object sender, EventArgs e)
        {
            Play_btn.Visible = false;
            Settings_btn.Visible = false;
            leaderboard_btn.Visible = false;
        }

        // To οποίο εμφανίζει τα settings του μενού και εξαφανίζει τα υπόλοιπα κουμπιά
        private void Settings_btn_Click(object sender, EventArgs e)
        {
            Disappear_btn(sender, e);
            player_btn.Visible = true;
            Sport_btn.Visible = true;
            programm_btn.Visible = true;
            back_btn.Visible = true;
            name_lbl.Visible = true;
            name_txt.Visible = true;
        }

        // Το κουμπί επιστροφής
        private void back_btn_Click(object sender, EventArgs e)
        {
            player_btn.Visible = false;
            Sport_btn.Visible = false;
            programm_btn.Visible = false;
            Play_btn.Visible = true;
            Settings_btn.Visible = true;
            leaderboard_btn.Visible = true;
            back_btn.Visible = false;
            name_lbl.Visible = false;
            name_txt.Visible = false;
            richTextBox1.Visible = false;
        }

        //Προβολή του leaderboard
        private void leaderboard_btn_Click(object sender, EventArgs e)
        {
            Disappear_btn(sender, e);
            richTextBox1.Visible = true;
            back_btn.Visible = true;

            DisplayLeaderBoard();
        }

        // Ο χρήστης επιλέγει το mode του Sport
        private void Sport_btn_Click(object sender, EventArgs e)
        {
            mode = "Sport";
            gamesettings = true;
        }

        // Ο χρήστης επιλέγει το mode του Programming Languages
        private void programm_btn_Click(object sender, EventArgs e)
        {
            mode = "Programming_languages";
            gamesettings = true;
        }

        // Ο χρήστης επιλέγει δικό του mode
        private void player_btn_Click(object sender, EventArgs e)
        {
            gamesettings = true;
            mode = "Custom";

            // Ανοίγει του φακέλους του υπολογιστ΄γ
            using (FolderBrowserDialog fbd = new FolderBrowserDialog())
            {
                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    // Φιλτράρουμε μόνο αρχεία εικόνων
                    string[] extensions = { "*.png", "*.jpg", "*.jpeg" };
                    selectedImages.Clear();

                    // Διαβάζει όλα τα αρχεία του φακέλου
                    foreach (var ext in extensions)
                    {
                        selectedImages.AddRange(Directory.GetFiles(fbd.SelectedPath, ext));
                    }

                    // Έλεγχος για τον αριθμό των εικόνων αν είναι τουλάχιστον 8 αφού πρέπει να είναι σταθερός
                    if (selectedImages.Count >= 8)
                    {
                        MessageBox.Show("The file has uploaded!");
                    }
                    else
                    {
                        MessageBox.Show("The file should have at least 8 images.");
                    }
                }
            }
        }

        // Τσεκάρει αν πληρεί όλες τις προυποθέσεις
        private void Check_Settings()
        {
            if (string.IsNullOrEmpty(name_txt.Text) || gamesettings == false)
            {
                MessageBox.Show("Settings Error be sure you have chosen Mode and fill the name");
                return;
            }

            else
            {
                Form1 form = new Form1(name_txt.Text, mode, selectedImages);
                form.Show();
                this.Hide();
                return;
            }
        }
    }
}
