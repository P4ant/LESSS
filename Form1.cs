using System;
using System.Drawing;
using System.Windows.Forms;

namespace skhnh1
{
    public partial class Form1 : Form
    {
        // Δημιουργία PictureBox για τον χάρτη
       

        public Form1()
        {
            InitializeComponent();
            this.KeyPreview = true; // Ενεργοποίηση KeyPreview για να αναγνωρίζονται τα πλήκτρα

            
        }
        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            // Λήψη των συντεταγμένων του σημείου που επιλέγει ο χρήστης
            Point clickPoint = pictureBox1.PointToClient(MousePosition);

            // Εμφάνιση δεδομένων για το σημείο που επιλέχθηκε
            string data = GetPointData(clickPoint);
            MessageBox.Show(data, "Πληροφορίες Σημείου", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
       
        // Προσομοίωση δεδομένων για το σημείο (υγρασία, σταθερότητα, ήλιος)
        private string GetPointData(Point point)
        {
            Random rand = new Random();

            // Προσομοιωμένα δεδομένα για υγρασία, σταθερότητα, και ήλιο
            int humidity = rand.Next(0, 101);  // Υγρασία 0-100%
            int stability = rand.Next(0, 101); // Σταθερότητα εδάφους 0-100%
            int sunlight = rand.Next(0, 101);  // Έκθεση στον ήλιο 0-100%

            // Επιστροφή των δεδομένων για την περιοχή
            return $"Σημείο: ({point.X}, {point.Y})\nΥγρασία: {humidity}%\nΣταθερότητα εδάφους: {stability}%\nΈκθεση στον ήλιο: {sunlight}%";
        }

        // Λειτουργία για να δημιουργήσουμε νέες φόρμες όταν πατηθεί το πλήκτρο M
        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);

            // Έλεγχος αν το πλήκτρο είναι το 'M'
            if (e.KeyCode == Keys.M)
            {
                // Παίρνουμε την ανάλυση της οθόνης
                Rectangle screenBounds = Screen.PrimaryScreen.Bounds;

                // Υπολογίζουμε τις διαστάσεις για τις δύο φόρμες (ίδιο μέγεθος, δίπλα-δίπλα)
                int halfWidth = screenBounds.Width / 2;
                int height = screenBounds.Height;

                // Δημιουργία και ρύθμιση πρώτης φόρμας (αριστερή πλευρά)
                Form form2 = new Form
                {
                    Text = "Form 2",
                        Size = new Size(halfWidth, height),
                        StartPosition = FormStartPosition.Manual,
                    Location = new Point(0, 0) // Αριστερή πλευρά
                };

                // Δημιουργία και ρύθμιση δεύτερης φόρμας (δεξιά πλευρά)
                Form form3 = new Form
                {
                    Text = "Form 3",
                    Size = new Size(halfWidth, height),
                    StartPosition = FormStartPosition.Manual,
                    Location = new Point(halfWidth, 0) // Δεξιά πλευρά
                };

                // Εμφάνιση των φορμών
                form2.Show();
                form3.Show();
            }
        }

      

        
    }
}
