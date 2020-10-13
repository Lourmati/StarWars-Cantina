using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projet_GONLO
{
    public partial class CreationPerso : Form
    {
        Player player = new Player();
        BorderStyle style3D = BorderStyle.Fixed3D;
        BorderStyle styleNone = BorderStyle.None;
        GeneratedNamesList nameList = new GeneratedNamesList();

        public CreationPerso()
        {
            this.DoubleBuffered = true;
            InitializeComponent();
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
        }

        public void groupBoxExtended(GroupBox gb, Button button)
        {
            if (gb.Height == 725)
            {
                gb.Height = 425;
                button.Location = new Point(65, 350);
                button.BackgroundImage = Properties.Resources.arrows;
            }
            else if (gb.Height == 425)
            {
                gb.Height = 725;
                button.Location = new Point(65, 685);
                button.BackgroundImage = Properties.Resources.arrowsUp;
            }
        }

        private void BtnInfoMand_Click(object sender, EventArgs e)
        {
            groupBoxExtended(GBoxMandalorian, BtnInfoMand);
        }

        private void BtnInfoZab_Click(object sender, EventArgs e)
        {
            groupBoxExtended(GBoxZabrak, BtnInfoZab);
        }

        private void BtnInfoSPB_Click(object sender, EventArgs e)
        {
            groupBoxExtended(GBoxSPB, BtnInfoSPB);
        }

        private void BtnInfoTwi_Click(object sender, EventArgs e)
        {
            groupBoxExtended(GBoxTwilek, BtnInfoTwi);
        }

        private void BtnInfoCath_Click(object sender, EventArgs e)
        {
            groupBoxExtended(GBoxCathar, BtnInfoCath);
        }

        private void BtnInfoHum_Click(object sender, EventArgs e)
        {
            groupBoxExtended(GBoxHuman, BtnInfoHum);
        }

        private void CheckPanelBorderStyle()
        {
            if (RPnlImgMando.BorderStyle == style3D)
            {
                RPnlImgMando.BorderStyle = styleNone;
            }
            else if (RPnlImgZabrak.BorderStyle == style3D)
            {
                RPnlImgZabrak.BorderStyle = styleNone;
            }
            else if (RPnlImgSPB.BorderStyle == style3D)
            {
                RPnlImgSPB.BorderStyle = styleNone;
            }
            else if (RPnlImgTwi.BorderStyle == style3D)
            {
                RPnlImgTwi.BorderStyle = styleNone;
            }
            else if (RPnlImgCath.BorderStyle == style3D)
            {
                RPnlImgCath.BorderStyle = styleNone;
            }
            else if (RPnlImgHum.BorderStyle == style3D)
            {
                RPnlImgHum.BorderStyle = styleNone;
            }
        }

        private void RPnlImgMando_Click(object sender, EventArgs e)
        {
            CheckPanelBorderStyle();
            RPnlImgMando.BorderStyle = style3D;
            
        }

        private void RPnlImgZabrak_Click(object sender, EventArgs e)
        {
            CheckPanelBorderStyle();
            RPnlImgZabrak.BorderStyle = style3D;
        }

        private void RPnlImgSPB_Click(object sender, EventArgs e)
        {
            CheckPanelBorderStyle();
            RPnlImgSPB.BorderStyle = style3D;
        }

        private void RPnlImgTwi_Click(object sender, EventArgs e)
        {
            CheckPanelBorderStyle();
            RPnlImgTwi.BorderStyle = style3D;
        }

        private void RPnlImgCath_Click(object sender, EventArgs e)
        {
            CheckPanelBorderStyle();
            RPnlImgCath.BorderStyle = style3D;
        }

        private void RPnlImgHum_Click(object sender, EventArgs e)
        {
            CheckPanelBorderStyle();
            RPnlImgHum.BorderStyle = style3D;
        }

        private void CBoxMale_CheckedChanged(object sender, EventArgs e)
        {
            if (CBoxFemale.Checked == true)
            {
                CBoxFemale.Checked = false;
            }
            else
            {
                CBoxMale.Checked = true;
            }
        }

        private void CBoxFemale_CheckedChanged(object sender, EventArgs e)
        {
            if (CBoxMale.Checked == true)
            {
                CBoxMale.Checked = false;
            }
            else
            {
                CBoxFemale.Checked = true;
            }
        }

        private void CreationPerso_Load(object sender, EventArgs e)
        {
            BtnEllNext.Enabled = false;
            CBoxMale.Checked = true;
            RPnlImgMando.BorderStyle = style3D;
        }

        private void BtnEllNext_Click(object sender, EventArgs e)
        {
            this.Hide();
            player.Species = VerificationSpecies();
            player.Name = TxtBoxNameGen.Text;
            player.Credits = 500;
            player.PazaakGamesWon = 0;
            player.PazaakGamesLost = 0;
            player.DejarikGamesLost = 0;
            player.DejarikGamesWon = 0;
            MenuAccueil menuAccueil = new MenuAccueil();
            menuAccueil.Player1 = player;
            if (CBoxFemale.Checked)
            {
                player.Gender = "Female";
            }
            else if (CBoxMale.Checked)
            {
                player.Gender = "Male";
            }
            menuAccueil.ShowDialog();
            this.Close();
        }

        private void BtnEllBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            StartForm startFrom = new StartForm();
            startFrom.ShowDialog();
            this.Close();
        }

        private void TxtBoxNameGen_TextChanged(object sender, EventArgs e)
        {
            BtnEllNext.Enabled = true;
        }

        private string VerificationSpecies()
        {
            String species = "";
            if (RPnlImgMando.BorderStyle == style3D)
            {
                species = "Mandalorian";
            }
            else if (RPnlImgZabrak.BorderStyle == style3D)
            {
                species = "Zabrak";
            }
            else if (RPnlImgSPB.BorderStyle == style3D)
            {
                species = "Sith PureBlood";
            }
            else if (RPnlImgTwi.BorderStyle == style3D)
            {
                species = "Twi'lek";
            }
            else if (RPnlImgCath.BorderStyle == style3D)
            {
                species = "Cathar";
            }
            else if (RPnlImgHum.BorderStyle == style3D)
            {
                species = "Human";
            }
            return species;
        }

        public void GenderCheckName()
        {
            string gender = "";
            if (RPnlImgMando.BorderStyle == style3D && CBoxMale.Checked)
            {
                string playerName;
                gender = "M";
                playerName = nameList.getListNameMand(gender);
                TxtBoxNameGen.Text = playerName;
            }
            else if (RPnlImgMando.BorderStyle == style3D && CBoxFemale.Checked)
            {
                string playerName;
                playerName = nameList.getListNameMand(gender);
                TxtBoxNameGen.Text = playerName;
            }
            else if (RPnlImgZabrak.BorderStyle == style3D && CBoxMale.Checked)
            {
                string playerName;
                gender = "M";
                playerName = nameList.getListNameZab(gender);
                TxtBoxNameGen.Text = playerName;
            }
            else if (RPnlImgZabrak.BorderStyle == style3D && CBoxFemale.Checked)
            {
                string playerName;
                playerName = nameList.getListNameZab(gender);
                TxtBoxNameGen.Text = playerName;
            }
            else if (RPnlImgSPB.BorderStyle == style3D && CBoxMale.Checked)
            {
                string playerName;
                gender = "M";
                playerName = nameList.getListNameSPB(gender);
                TxtBoxNameGen.Text = playerName;
            }
            else if (RPnlImgSPB.BorderStyle == style3D && CBoxFemale.Checked)
            {
                string playerName;
                playerName = nameList.getListNameSPB(gender);
                TxtBoxNameGen.Text = playerName;
            }
            else if (RPnlImgTwi.BorderStyle == style3D && CBoxMale.Checked)
            {
                string playerName;
                gender = "M";
                playerName = nameList.getListNameTwilek(gender);
                TxtBoxNameGen.Text = playerName;
            }
            else if (RPnlImgTwi.BorderStyle == style3D && CBoxFemale.Checked)
            {
                string playerName;
                playerName = nameList.getListNameTwilek(gender);
                TxtBoxNameGen.Text = playerName;
            }
            else if (RPnlImgCath.BorderStyle == style3D && CBoxMale.Checked)
            {
                string playerName;
                gender = "M";
                playerName = nameList.getListNameCathar(gender);
                TxtBoxNameGen.Text = playerName;
            }
            else if (RPnlImgCath.BorderStyle == style3D && CBoxFemale.Checked)
            {
                string playerName;
                playerName = nameList.getListNameCathar(gender);
                TxtBoxNameGen.Text = playerName;
            }
            else if (RPnlImgHum.BorderStyle == style3D && CBoxMale.Checked)
            {
                string playerName;
                gender = "M";
                playerName = nameList.getListNameHum(gender);
                TxtBoxNameGen.Text = playerName;
            }
            else if (RPnlImgHum.BorderStyle == style3D && CBoxFemale.Checked)
            {
                string playerName;
                playerName = nameList.getListNameHum(gender);
                TxtBoxNameGen.Text = playerName;
            }
        }


        private void BtnGenName_Click(object sender, EventArgs e)
        {
            GenderCheckName();
        }
    }

 }
