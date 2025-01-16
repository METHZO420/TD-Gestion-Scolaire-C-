using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MDIGestionScolaire
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void classeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formClasse formclasse = new formClasse();
            formclasse.Show();
        }

        private void etudiantToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormEtudiant formetudiant = new FormEtudiant();
            formetudiant.Show();
        }
    }
}
