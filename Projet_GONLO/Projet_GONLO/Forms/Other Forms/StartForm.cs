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
    public partial class StartForm : Form
    {
        public StartForm()
        {
            InitializeComponent();
        }

        private void BtnEllStart_Click(object sender, EventArgs e)
        {
            this.Hide();
            CreationPerso creationPerso = new CreationPerso();
            creationPerso.ShowDialog();
            this.Close();
        }

        private void BtnEllExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnEllLoad_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoadForm load = new LoadForm();
            load.ShowDialog();
            this.Close();
        }
    }
}
