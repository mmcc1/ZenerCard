using System;
using System.Windows.Forms;
using System.Security.Cryptography;

namespace ZenerCard
{
    public partial class Form1 : Form
    {
        private int totalAttempts;
        private int numberCorrect;
        private int numberIncorrect;
        private double percentageAccurate;
        private RNGCryptoServiceProvider rng;

        public enum ZenerCard
        {
            Circle,
            Cross,
            Wavylines,
            Square,
            Star,
            Null
        }

        public Form1()
        {
            InitializeComponent();
            rng = new RNGCryptoServiceProvider();
        }

        #region Card Operations

        private ZenerCard GetCard()
        {
            
            byte[] r = new byte[1];
            
            rng.GetBytes(r);

            if (r[0] < 51)
                return ZenerCard.Circle;
            else if (r[0] < 102)
                return ZenerCard.Cross;
            else if (r[0] < 153)
                return ZenerCard.Wavylines;
            else if (r[0] < 204)
                return ZenerCard.Square;
            else if (r[0] < 255)
                return ZenerCard.Star;

            return ZenerCard.Null;
        }

        private bool CompareCards(ZenerCard selected, ZenerCard generated)
        {
            if (selected == generated)
                return true;
            else
                return false;
        }

        #endregion

        #region Success/Failure stats update

        private void UpdateSuccessData()
        {
            totalAttempts++;
            numberCorrect++;
            percentageAccurate = ((double)numberCorrect / (double)totalAttempts) * 100.00;
            label5.Text = numberCorrect.ToString();
            label4.Text = percentageAccurate.ToString();
        }

        private void UpdateFailureData()
        {
            totalAttempts++;
            numberIncorrect++;

            try
            {
                percentageAccurate = ((double)numberCorrect / (double)totalAttempts) * 100.00;
            }
            catch
            {

            }

            label6.Text = numberIncorrect.ToString();
            label4.Text = percentageAccurate.ToString();
        }

        #endregion

        #region Buttons

        private void button6_Click_1(object sender, EventArgs e)
        {
            if (button6.Text.Contains("Start"))
            {
                button6.Text = "Reset";
                button1.Enabled = true;
                button2.Enabled = true;
                button3.Enabled = true;
                button4.Enabled = true;
                button5.Enabled = true;
            }

            if (button6.Text.Contains("Reset"))
            {
                label4.Text = "0";
                label5.Text = "0";
                label6.Text = "0";

                totalAttempts = 0;
                numberCorrect = 0;
                numberIncorrect = 0;
                percentageAccurate = 0;
            }
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            bool result = CompareCards(ZenerCard.Star, GetCard());

            if (result)
                UpdateSuccessData();
            else
                UpdateFailureData();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            bool result = CompareCards(ZenerCard.Square, GetCard());

            if (result)
                UpdateSuccessData();
            else
                UpdateFailureData();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            bool result = CompareCards(ZenerCard.Wavylines, GetCard());

            if (result)
                UpdateSuccessData();
            else
                UpdateFailureData();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            bool result = CompareCards(ZenerCard.Cross, GetCard());

            if (result)
                UpdateSuccessData();
            else
                UpdateFailureData();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            bool result = CompareCards(ZenerCard.Circle, GetCard());

            if (result)
                UpdateSuccessData();
            else
                UpdateFailureData();
        }

        #endregion
    }
}
