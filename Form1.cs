using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Data.SQLite;



namespace Match_picture
{
    public partial class Form1 : Form
    {
        DatabaseManager db = new DatabaseManager();
        private Menu mainForm;

        // Δημιουργία λίστας για τις εικόνες, ο σταθερός αριθμός που ζητάει η εκφώνηση εδώ είναι 8
        List<Picture_items> gameItems = new List<Picture_items>();

        // Οι απαραίτητες μεταβλητές πρώτης επιλογής και δεύτερης επιλογής του χρήστη
        string firstchoice;
        string secondchoice;

        // Οι προσπάθειες του χρήστη
        int attempts;

        // Το όνομα που έχει εισάγει ο χρήστης καθώς και το mode που έχει επιλέξει από το μενού επιλογής
        private string playerName;
        private string gameMode;

        // Η λίστα με τις εικόνες
        private List<string> selectedImages;
        List<PictureBox> pics = new List<PictureBox>();
        PictureBox picA;
        PictureBox picB;

        // Ο χρόνος του χρήστη για να ολοκληρώσει το παιχνίδι
        int FullTime = 0;

        // Λογική μεταβλητή αν έχει τελειώσει το παιχνίδι ή όχι
        bool IsGameOver = false;

        public Form1(string name, string mode, List<string> images)
        {
            InitializeComponent();

            this.playerName = name;
            this.gameMode = mode;
            this.selectedImages = images;

            // Καλεί τη μέθοδο για να φορτώσει οι εικόνες
            LoadPictures();
        }

        //Η μέθοδος η οποία ξεκινάει να τρέχει ο timer προσθέτοντας 1 sec στο χρόνο
        private void TimerEvent(object sender, EventArgs e)
        {
            FullTime++;
            label2.Text = "Time: " + FullTime;

        }


        private void LoadPictures()
        {
            int leftPos = 250;
            int topPos = 120;
            int rows = 0;

            // Η εικόνες που θα έχουμε συνολικά θα είναι 16 αλλά τα αρχεία 8
            for (int i = 0; i < 16; i++)
            {
                // Εδώ σημειώνονται οι προδιαγραφές που θα έχουν οι εικόνες
                PictureBox picture = new PictureBox();
                picture.Height = 50;
                picture.Width = 50;
                picture.BackColor = Color.White;
                picture.SizeMode = PictureBoxSizeMode.StretchImage;
                picture.Click += picture_Click;
                pics.Add(picture);

                picture.Left = leftPos;
                picture.Top = topPos;
                this.Controls.Add(picture);
                leftPos = leftPos + 60;
                rows++;

                // Με αυτό τον ελεγχο εξασφαλίζουμαι ότι θα δημιουργηθούν 4 στήλες και 4 γραμμες δημιουργώντας ένα νοητό τετράγωνο
                if (rows == 4)
                {
                    leftPos = 250;
                    topPos += 60;
                    rows = 0;
                }
            }
            Restart_Game();
        }

        // Ή μέθοδος αυτή αναφέρεται στο κλικάρισμα του χρήστη στην εικόνα
        private async void picture_Click(object sender, EventArgs e)
        {
            if (IsGameOver || secondchoice != null) return;

            PictureBox clickedPic = sender as PictureBox;
            Picture_items currentItem = clickedPic.Tag as Picture_items;

            // Έλεγχος αν είναι ήδη ανοιχτή ή βρεμένη
            if (currentItem.IsRevealed || currentItem.IsMatched) return;

            // Εμφάνιση εικόνας
            clickedPic.Image = Image.FromFile(currentItem.ImagePath);
            currentItem.IsRevealed = true;

            if (firstchoice == null)
            {
                picA = clickedPic;
                firstchoice = currentItem.Id.ToString(); // Κρατάμε το ID για σύγκριση
            }
            else
            {
                picB = clickedPic;
                secondchoice = currentItem.Id.ToString();
                attempts++;
                label1.Text = "Attempts: " + attempts;

                await Task.Delay(500);
                CheckPicturesObjects(picA, picB);
            }
        }

        // Η μέθοδος που θα τελειώσει το παιχνίδι
        private void GameOver(string message)
        {
            timer1.Stop();
            IsGameOver = true;
            MessageBox.Show(message + " " + attempts + "σε χρόνο" + FullTime);


            db.SaveScore(playerName, attempts, FullTime);
        }

        // Μέθοδος ελέγχου των φωτογραφιών
        private void CheckPicturesObjects(PictureBox A, PictureBox B)
        {
            Picture_items itemA = A.Tag as Picture_items;
            Picture_items itemB = B.Tag as Picture_items;

            if (itemA.Id == itemB.Id)
            {
                itemA.IsMatched = true;
                itemB.IsMatched = true;
            }
            else
            {
                itemA.IsRevealed = false;
                itemB.IsRevealed = false;
                A.Image = null;
                B.Image = null;
            }

            firstchoice = null;
            secondchoice = null;
            picA = null;
            picB = null;

            // Έλεγχος νίκης
            if (gameItems.All(x => x.IsMatched))
            {
                GameOver("Συγχαρητήρια! Προσπάθειες: ");
            }
        }

        private void Restart_Game()
        {
            // Σταματάμε τον timer για να τον μηδενίσουμε σωστά
            timer1.Stop();
            gameItems.Clear();

            // Δημιουργούμε τα 16 αντικείμενα (8 ζευγάρια)
            for (int i = 1; i <= 8; i++)
            {
                string path;
                if (gameMode == "Custom")
                    path = selectedImages[i - 1];
                else
                    path = $"Pictures/{gameMode}/{i}.png";

                gameItems.Add(new Picture_items(i, path));
                gameItems.Add(new Picture_items(i, path));
            }

            // Ανακατεύουμαι τις κάρτες
            gameItems = gameItems.OrderBy(x => Guid.NewGuid()).ToList();

            for (int i = 0; i < pics.Count; i++)
            {
                pics[i].Image = null;
                pics[i].Tag = gameItems[i]; // Αποθηκεύουμε όλο το αντικείμενο στο Tag
                gameItems[i].IsMatched = false;
                gameItems[i].IsRevealed = false;
            }

            // Μηδενισμός στατιστικών
            attempts = 0;
            FullTime = 0;
            IsGameOver = false;

            // Ενημέρωση UI
            label1.Text = "Attempts: " + attempts;
            label2.Text = "Time: " + FullTime;

            // Εκκίνηση timer εκ νέου
            timer1.Start();
        }

        // Η μέθοδος αυτή κλείνει το tab και επιστρέφει στο menu
        private void button_back_Click_1(object sender, EventArgs e)
        {
            Menu form = new Menu();
            form.Show();
            this.Close();
        }

        // Η μέθοδος αυτή εκτελείται όταν πατηθεί το κουμπι restart και εμφανίζει στον χρήστη το μήνυμα αν θέλει ή όχι να κάνει restart το παιχνίδι
        private void button_restart_Click_1(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Θέλετε να ξεκινήσετε από την αρχή;", "Restart", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                Restart_Game();
            }
        }
    }
}