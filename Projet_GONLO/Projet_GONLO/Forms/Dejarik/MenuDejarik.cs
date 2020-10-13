using Projet_GONLO.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Media;

namespace Projet_GONLO
{
    public partial class MenuDejarik : Form
    {
        /// <summary>
        /// Global variables
        /// </summary>
        Monster mantellianSavrip, monnok, ghhhk, houjix, kintanStrider, ngok, klorslug, grimtaash;
        Player player1 = new Player();
        Player player2 = new Player();
        SoundPlayer sound = new SoundPlayer(Properties.Resources.Dejarik_Cantina);
        private int playerTurn = 1;
        String logMonster = "";
        internal Player Player1 { get => player1; set => player1 = value; }
        internal Player Player2 { get => player2; set => player2 = value; }

        /// <summary>
        /// Default contructor
        /// </summary>
        public MenuDejarik()
        {
            this.DoubleBuffered = true;
            InitializeComponent();
            sound.PlayLooping();
            createMonsters();
            setBtnInfoExtender();
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
        }


        public void groupBoxExtended(GroupBox gb, Button button)
        {
            if (gb.Height == 635)
            {
                gb.Height = 265;
                button.Location = new Point(57, 212);
                button.BackgroundImage = Properties.Resources.arrows;
            }
            else if (gb.Height == 265)
            {
                gb.Height = 635;
                button.Location = new Point(57, 212);
                button.BackgroundImage = Properties.Resources.arrowsUp;
            }
        }

        /// <summary>
        /// Associate the click event to each arrow information buttons
        /// </summary>
        private void setBtnInfoExtender()
        {
            BtnInfoGHHHK.Click += (sender, EventArgs) => { ClickInfoMonsters(sender, EventArgs, grpGhhhk, BtnInfoGHHHK); };
            BtnInfoHoujix.Click += (sender, EventArgs) => { ClickInfoMonsters(sender, EventArgs, grpHoujix, BtnInfoHoujix); };
            BtnInfoKintanStrider.Click += (sender, EventArgs) => { ClickInfoMonsters(sender, EventArgs, grpKintanStrider, BtnInfoKintanStrider); };
            BtnInfoNgok.Click += (sender, EventArgs) => { ClickInfoMonsters(sender, EventArgs, grpNgok, BtnInfoNgok); };
            BtnInfoKlorslug.Click += (sender, EventArgs) => { ClickInfoMonsters(sender, EventArgs, grpKlorslug, BtnInfoKlorslug); };
            buBtnInfoGrimstaash.Click += (sender, EventArgs) => { ClickInfoMonsters(sender, EventArgs, grpGrimstaash, buBtnInfoGrimstaash); };
            BtnInfoMantellian.Click += (sender, EventArgs) => { ClickInfoMonsters(sender, EventArgs, grpMantellian, BtnInfoMantellian); };
            BtnInfoMonnok.Click += (sender, EventArgs) => { ClickInfoMonsters(sender, EventArgs, grpMonnok, BtnInfoMonnok); };
        }

        /// <summary>
        /// Click event of the arrow information button (show information of the monster)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <param name="gbox"></param>
        /// <param name="btnInfo"></param>
        private void ClickInfoMonsters(object sender, EventArgs e, GroupBox gbox, Button btnInfo)
        {
            groupBoxExtended(gbox, btnInfo);
        }

        /// <summary>
        /// BtnGhhhk click event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnGhhhk_Click(object sender, EventArgs e)
        {
            if (playerTurn == 1)
            {
                player1.AttMonster = ghhhk;
                player2.AttMonster = houjix;
                logMonster += "Player 1 chose the monster : Ghhhk-";
                logMonster += "Player 2 gets the monster : Houjix-";
            }
            else
            {
                player2.AttMonster = ghhhk;
                player1.AttMonster = houjix;
                logMonster += "Player 2 chose the monster : Ghhhk-";
                logMonster += "Player 1 gets the monster : Houjix-";
            }

            BtnGhhhk.BackColor = Color.FromArgb(80, Color.Gold);
            BtnHoujix.BackColor = Color.FromArgb(80, Color.Gold);
            btnClick(BtnGhhhk, BtnHoujix);
        }

        /// <summary>
        /// BtnHoujix click event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnHoujix_Click(object sender, EventArgs e)
        {
            if (playerTurn == 1)
            {
                player1.AttMonster = houjix;
                player2.AttMonster = ghhhk;
                logMonster += "Player 1 chose the monster : Houjix-";
                logMonster += "Player 2 gets the monster : Ghhhk-";
            }
            else
            {
                player2.AttMonster = houjix;
                player1.AttMonster = ghhhk;
                logMonster += "Player 2 chose the monster : Houjix-";
                logMonster += "Player 1 gets the monster : Ghhhk-";
            }
            BtnHoujix.BackColor = Color.FromArgb(80, Color.Gold);
            BtnGhhhk.BackColor = Color.FromArgb(80, Color.Gold);
            btnClick(BtnGhhhk, BtnHoujix);
        }

        /// <summary>
        /// BtnKintanStrider click event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnKintanStrider_Click(object sender, EventArgs e)
        {
            if (playerTurn == 1)
            {
                player1.DefMonster = kintanStrider;
                player2.DefMonster = ngok;
                logMonster += "Player 1 chose the monster : Kintan Strider-";
                logMonster += "Player 2 gets the monster : Ngok-";
            }
            else
            {
                player2.DefMonster = kintanStrider;
                player1.DefMonster = ngok;
                logMonster += "Player 2 chose the monster : Kintan Strider-";
                logMonster += "Player 1 gets the monster : Ngok-";
            }
            BtnKintanStrider.BackColor = Color.FromArgb(80, Color.Gold);
            BtnNgok.BackColor = Color.FromArgb(80, Color.Gold);
            btnClick(BtnKintanStrider, BtnNgok);
        }

        /// <summary>
        /// BtnNgok click event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnNgok_Click(object sender, EventArgs e)
        {
            if (playerTurn == 1)
            {
                player1.DefMonster = ngok;
                player2.DefMonster = kintanStrider;
                logMonster += "Player 1 chose the monster : Ngok-";
                logMonster += "Player 2 gets the monster : Kintan Strider-";
            }
            else
            {
                player2.DefMonster = ngok;
                player1.DefMonster = kintanStrider;
                logMonster += "Player 2 chose the monster : Ngok-";
                logMonster += "Player 1 gets the monster : Kintan Strider-";
            }
            BtnNgok.BackColor = Color.FromArgb(80, Color.Gold);
            BtnKintanStrider.BackColor = Color.FromArgb(80, Color.Gold);
            btnClick(BtnKintanStrider, BtnNgok);
        }

        /// <summary>
        /// BtnKlorslug click event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnKlorslug_Click(object sender, EventArgs e)
        {
            if (playerTurn == 1)
            {
                player1.MovMonster = klorslug;
                player2.MovMonster = grimtaash;
                logMonster += "Player 1 chose the monster : Klorslug-";
                logMonster += "Player 2 gets the monster : Grimtaash-";
            }
            else
            {
                player2.MovMonster = klorslug;
                player1.MovMonster = grimtaash;
                logMonster += "Player 2 chose the monster : Klorslug-";
                logMonster += "Player 1 gets the monster : Grimtaash-";
            }
            BtnKlorslug.BackColor = Color.FromArgb(80, Color.Gold);
            BtnGrimtaash.BackColor = Color.FromArgb(80, Color.Gold);
            btnClick(BtnKlorslug, BtnGrimtaash);
        }

        /// <summary>
        /// BtnGrimtaash click event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnGrimtaash_Click(object sender, EventArgs e)
        {
            if (playerTurn == 1)
            {
                player1.MovMonster = grimtaash;
                player2.MovMonster = klorslug;
                logMonster += "Player 1 chose the monster : Grimtaash-";
                logMonster += "Player 2 gets the monster : Klorslug-";
            }
            else
            {
                player2.MovMonster = grimtaash;
                player1.MovMonster = klorslug;
                logMonster += "Player 2 chose the monster : Grimtaash-";
                logMonster += "Player 1 gets the monster : Klorslug-";
            }
            BtnGrimtaash.BackColor = Color.FromArgb(80, Color.Gold);
            BtnKlorslug.BackColor = Color.FromArgb(80, Color.Gold);
            btnClick(BtnKlorslug, BtnGrimtaash);
        }

        /// <summary>
        /// BtnMantellian click event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnMantellian_Click(object sender, EventArgs e)
        {
            if (playerTurn == 1)
            {
                player1.PowMonster = mantellianSavrip;
                player2.PowMonster = monnok;
                logMonster += "Player 1 chose the monster : Mantellian Savrip-";
                logMonster += "Player 2 gets the monster : Monnok-";
            }
            else
            {
                player2.PowMonster = mantellianSavrip;
                player1.PowMonster = monnok;
                logMonster += "Player 2 chose the monster : Mantellian Savrip-";
                logMonster += "Player 1 gets the monster : Monnok-";
            }
            BtnMantellian.BackColor = Color.FromArgb(80, Color.Gold);
            BtnMonnok.BackColor = Color.FromArgb(80, Color.Gold);
            btnClick(BtnMantellian, BtnMonnok);
        }

        /// <summary>
        /// BtnMonnok click event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnMonnok_Click(object sender, EventArgs e)
        {
            if (playerTurn == 1)
            {
                player1.PowMonster = monnok;
                player2.PowMonster = mantellianSavrip;
                logMonster += "Player 1 chose the monster : Monnok-";
                logMonster += "Player 2 gets the monster : Mantellian Savrip-";
            }
            else
            {
                player2.PowMonster = monnok;
                player1.PowMonster = mantellianSavrip;
                logMonster += "Player 2 chose the monster : Monnok-";
                logMonster += "Player 1 gets the monster : Mantellian Savrip-";
            }
            BtnMonnok.BackColor = Color.FromArgb(80, Color.Gold);
            BtnMantellian.BackColor = Color.FromArgb(80, Color.Gold);
            btnClick(BtnMantellian, BtnMonnok);
        }


        /// <summary>
        /// method that disable the other button and check if the menu is done
        /// </summary>
        /// <param name="monster1"></param>
        /// <param name="monster2"></param>
        private void btnClick(Button monster1, Button monster2)
        {
            monster1.Enabled = false;
            monster2.Enabled = false;
            checkMonsterFinish();
            nextTurn();
        }

        /// <summary>
        /// Create the 8 monsters of the dejarik board game
        /// </summary>
        private void createMonsters()
        {
            mantellianSavrip = new Monster("The Mantellian Savrip", 2, 3, 2, (Image)Properties.Resources.ResourceManager.GetObject("Mantellian_Savrip"), typeMonster.Power, 0);
            monnok = new Monster("The Monnok", 3, 2, 2, (Image)Properties.Resources.ResourceManager.GetObject("Monnok"), typeMonster.Power, 0);
            ghhhk = new Monster("The Ghhhk", 3, 2, 1, (Image)Properties.Resources.ResourceManager.GetObject("ghhhk"), typeMonster.Offensive, 0);
            houjix = new Monster("The Houjix", 3, 1, 2, (Image)Properties.Resources.ResourceManager.GetObject("houjix"), typeMonster.Offensive, 0);
            kintanStrider = new Monster("The Kintan Strider", 1, 3, 2, (Image)Properties.Resources.ResourceManager.GetObject("Kintan_Strider"), typeMonster.Defensive, 0);
            ngok = new Monster("The Ng'ok", 2, 3, 1, (Image)Properties.Resources.ResourceManager.GetObject("Ngok"), typeMonster.Defensive, 0);
            klorslug = new Monster("The K'lor'slug", 2, 1, 3, (Image)Properties.Resources.ResourceManager.GetObject("klorslaug"), typeMonster.Mobile, 0);
            grimtaash = new Monster("Grimtaash the Molator", 1, 2, 3, (Image)Properties.Resources.ResourceManager.GetObject("grimtaash"), typeMonster.Mobile, 0);
        }

        /// <summary>
        /// Check if each monster is clicked (chosen by one player)
        /// If yes, the dejarik board game can begin
        /// </summary>
        private void checkMonsterFinish()
        {
            if (BtnGhhhk.Enabled == false && BtnHoujix.Enabled == false
                && BtnKintanStrider.Enabled == false && BtnNgok.Enabled == false
                && BtnKlorslug.Enabled == false && BtnGrimtaash.Enabled == false
                && BtnMantellian.Enabled == false && BtnMonnok.Enabled == false)
            {
                Hide();
                Dejarik newDejarikGame = new Dejarik(logMonster);
                newDejarikGame.Player2 = player2;
                newDejarikGame.Player1 = player1;
                newDejarikGame.ShowDialog();
                this.Close();
            }
        }

        /// <summary>
        /// Exit menu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            sound.Stop();
            this.Close();
        }

        /// <summary>
        /// Return to the main menu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ReturnToMainMenuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            sound.Stop();
            Hide();
            MenuAccueil menu = new MenuAccueil();
            menu.Player1 = player1;
            menu.ShowDialog();
            this.Close();
        }

        /// <summary>
        /// Change the turn of monster selection
        /// </summary>
        private void nextTurn()
        {
                changeLabel();
                checkMonsterFinish();
        }

        /// <summary>
        /// Update the labels to advertise which player chooses first
        /// </summary>
        private void changeLabel()
        {
            if (LblMenuPlayerTurn.Text.Equals("Player 1 select one monster for each category  "))
            {
                LblMenuPlayerTurn.Text = "Player 2 select one monster for each category  ";
                Refresh();
                playerTurn = 2;
            }
            else
            {
                LblMenuPlayerTurn.Text = "Player 1 select one monster for each category  ";
                Refresh();
                playerTurn = 1;
            }
        }
    }

}
