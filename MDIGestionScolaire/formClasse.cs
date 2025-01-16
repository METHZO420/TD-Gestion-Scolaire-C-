using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MDIGestionScolaire
{
    public partial class formClasse : Form
    {
        public formClasse()
        {
            InitializeComponent();
        }

        private void formClasse_Load(object sender, EventArgs e)
        {
            btnmodifier.Enabled = false;
            btnSupprimer.Enabled = false;
            refresh();
        }

        private void btnEffacer_Click(object sender, EventArgs e)
        {
            effacer();
        }

        private void btnAjout_Click(object sender, EventArgs e)
        {

            using (var db = new DBScolaire())
            {
                Classe classe = new Classe();
                classe.Libelle = txtlibelle.Text;

                db.Classes.Add(classe);
                db.SaveChanges();
                refresh();
                effacer();

            }
        }

        public void refresh()
        {
            using (var db = new DBScolaire())
            {
                dataGridView1.DataSource = db.Classes.ToList();
            }

        }
        public void effacer()
        {
            txtlibelle.Text = String.Empty;
            txtid.Text = String.Empty;
        }

        private void btnSupprimer_Click(object sender, EventArgs e)
        {
            using (var db = new DBScolaire())
            {
                if (dataGridView1.SelectedRows != null)
                {
                    int idclasse = (int)dataGridView1.SelectedRows[0].Cells["Id"].Value;
                    Classe classeSupprimer = db.Classes.Find(idclasse);
                    DialogResult choix = MessageBox.Show("Voullez vous Vraiment Supprimer la classe ?\n\r Tous les etudiants enregistrer dans cette classe seront supprimer", "Confirmer la suppression", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (choix == DialogResult.Yes)
                    {

                        db.Classes.Remove(classeSupprimer);
                        db.SaveChanges();
                        effacer();
                        refresh();

                    }
                    else
                    {
                        MessageBox.Show("Suppression Annulée", "Operation annulée", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Aucune ligne selectionner", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }

            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           

        }

        private void btnmodifier_Click(object sender, EventArgs e)
        {
            using (var db = new DBScolaire())
            {
                if (dataGridView1.SelectedRows != null)
                {
                    

                    DialogResult choix = MessageBox.Show("Voullez vous Vraiment Modifer la classe ?", "Confirmer de la Modification ", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (choix == DialogResult.Yes)
                    {
                        int idclasse2 = (int)dataGridView1.SelectedRows[0].Cells["Id"].Value;

                        
                        
                        Classe classeModifier = db.Set<Classe>().Find(idclasse2);
                        classeModifier.Libelle = txtlibelle.Text;
                        db.SaveChanges();
                        refresh();
                        effacer();

                    }
                    else
                    {
                        MessageBox.Show("Modification Annulée", "Operation annulée", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

                else
                {
                    MessageBox.Show("Aucune ligne selectionner", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            }
        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            using (var db = new DBScolaire())
            {
                int idclasse = (int)dataGridView1.SelectedRows[0].Cells["Id"].Value;
                Classe classeSelect = db.Classes.Find(idclasse);
                txtlibelle.Text = classeSelect.Libelle;
                btnSupprimer.Enabled = true;
                btnmodifier.Enabled=true;
            }
        }
    }
}
