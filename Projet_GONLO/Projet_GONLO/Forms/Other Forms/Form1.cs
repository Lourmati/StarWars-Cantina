using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projet_GONLO
{
    public partial class MenuAccueil : Form
    {
        Player player1 = new Player();
        SoundPlayer sound = new SoundPlayer(Properties.Resources.Cantina_Band);
        //public MenuAccueil()
        //{
        //    this.DoubleBuffered = true;
        //    InitializeComponent();

        //}

        public MenuAccueil()
        {
            this.DoubleBuffered = true;
            InitializeComponent();
            
            sound.PlayLooping();
            // player1 = player;
        }

        bool etatWelcome = true;
        bool etatGonlo = true;
        int len1;
        int len2;
        string txt1;
        string txt2;

        internal Player Player1 { get => player1; set => player1 = value; }

        private void MenuAccueil_Load(object sender, EventArgs e)
        {
            txt1 = LblWelcome.Text;
            txt2 = LblGonlo.Text;
            len1 = txt1.Length;
            len2 = txt2.Length;
            LblPlayerName.Text = player1.Name;
            LblPlayerSpecies.Text = player1.Species;
            LblPlayerCredits.Text = player1.Credits.ToString();
            LblNbPGW.Text = player1.PazaakGamesWon.ToString();
            LblNbPGL.Text = player1.PazaakGamesLost.ToString();
            LblNbDGW.Text = player1.DejarikGamesWon.ToString();
            LblNbDGL.Text = player1.DejarikGamesLost.ToString();
            RPnlPazaak.Hide();
            RPnlDejarik.Hide();
            RPnlSBR.Hide();
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
        }

        private void BtnEllPazaak_Click(object sender, EventArgs e)
        {
            RPnlDejarik.Hide();
            RPnlSBR.Hide();
            RPnlPazaak.Show();
            this.Refresh();
        }

        private void BtnEllDejarik_Click(object sender, EventArgs e)
        {
            RPnlPazaak.Hide();
            RPnlSBR.Hide();
            RPnlDejarik.Show();
            this.Refresh();
        }

        private void BtnEllSB_Click(object sender, EventArgs e)
        {
            RPnlPazaak.Hide();
            RPnlDejarik.Hide();
            RPnlSBR.Show();
            this.Refresh();
        }

        private void BtnEllSettings_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TimerSlide1_Tick(object sender, EventArgs e)
        {

            //label1
            if (LblWelcome.Left < this.Width)
            {
                LblWelcome.Left += 5;
            }
            else
            {
                if (etatWelcome == true)
                {
                    LblWelcome.Font = new Font("Aurek-Besh", 14);
                    LblWelcome.Left = -1300;
                    etatWelcome = false;
                }
                else
                {
                    LblWelcome.Left = -1200;
                    LblWelcome.Font = new Font("SF Distant Galaxy Alternate", 25);
                    etatWelcome = true;
                } 
            }

            //label2
            if (LblGonlo.Left < this.Width)
            {
                LblGonlo.Left += 5;
            }
            else
            {
                if (etatGonlo == true)
                {
                    LblGonlo.Font = new Font("Aurek-Besh", 14);
                    LblGonlo.Left = -1300;
                    etatGonlo = false;
                }
                else
                {
                    LblGonlo.Left = -1200;
                    LblGonlo.Font = new Font("SF Distant Galaxy Alternate", 25);
                    etatGonlo = true;
                }
            }
        }

        private void BtnEllPlayPazaak_Click(object sender, EventArgs e)
        {
            sound.Stop();
            Hide();
            MessageBox.Show("You must now select 10 cards for your deck. You will only have access to 4 of them and they will be chosen randomly. \n" +
                " During the Pazaak best of 5 duel. You may only use each card once during the duel. Choose wisely. \n\n\n"
                +
                "For more information:\n" +
                "+ Cards: When selected during Pazaak Duel will increase your score of the number written on the card.\n\n" +
                "- Cards: When selected during Pazaak Duel will decrease your score of the number written on the card.\n\n" +
                "+-Cards: When selected during Pazaak Duel will increase or decrease your score of the number written on the card. \n" +
                "When you will click on the “flip card” text you will see a “+” or “-” (+by default)." +
                "This symbol will decide which what the card will do.",
                "Pazzak Card Selector Infomation");





            PazaakCardsSelector pazaakCards = new PazaakCardsSelector();
            pazaakCards.Player1 = player1;
            pazaakCards.ShowDialog();
            this.Close();
            //Hide();
            //Pazaak newPazaakGame = new Pazaak();
            //newPazaakGame.ShowDialog();
            //this.Close();

        }

        private void BtnEllPlayDejarik_Click(object sender, EventArgs e)
        {
            sound.Stop();
            Hide();
            MenuDejarik menuDejarik = new MenuDejarik();
            menuDejarik.Player1 = player1;
            menuDejarik.ShowDialog();
            this.Close();
        }

        private void BtnGBoxPI_Click(object sender, EventArgs e)
        {
            if (GBoxPlayerInfo.Height == 460)
            {
                GBoxPlayerInfo.Height = 280;
                BtnGBoxPI.BackgroundImage = Properties.Resources.arrows;
            }
            else if (GBoxPlayerInfo.Height == 280)
            {
                GBoxPlayerInfo.Height = 460;
                BtnGBoxPI.BackgroundImage = Properties.Resources.arrowsUp;
            }
        }
    }
}
