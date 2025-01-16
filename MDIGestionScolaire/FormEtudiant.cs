using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace MDIGestionScolaire
{
    public partial class FormEtudiant : Form
    {
        public FormEtudiant()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void FormEtudiant_Load(object sender, EventArgs e)
        {

            using(var db=new DBScolaire())
            {
                comboBox1.DataSource= db.Classes.ToList();
                comboBox1.DisplayMember = "Libelle";
                comboBox1.ValueMember = "Id";
            }
            effacer();
            refresh();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var db = new DBScolaire())
            {
                Etudiant etd= new Etudiant();
                etd.Prenom=txtNom.Text;
                etd.Nom=txtPrenom.Text;
                etd.Classe=(Classe)comboBox1.SelectedItem;
                db.Etudiants.Add(etd);
                db.SaveChanges();
                refresh();
                effacer();
            }
        }
        public void refresh()
        {
            using (var db = new DBScolaire())
            {
                dataGridView1.DataSource = db.Etudiants.ToList();
            }

        }
        public void effacer()
        {
            txtNom.Text = String.Empty;
            txtPrenom.Text = String.Empty;
            comboBox1.Text=String.Empty;
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void btnModifier_Click(object sender, EventArgs e)
        {
            using (var db = new DBScolaire())
            {
                if (dataGridView1.SelectedRows != null)
                {


                    DialogResult choix = MessageBox.Show("Voullez vous Vraiment Modifer l'etudiant ?", "Confirmer de la Modification ", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (choix == DialogResult.Yes)
                    {
                        int idetd = (int)dataGridView1.SelectedRows[0].Cells["Id"].Value;



                        Etudiant etudiantModifier = db.Set<Etudiant>().Find(idetd);
                       etudiantModifier.Nom = txtNom.Text;
                        etudiantModifier.Prenom = txtPrenom.Text;
                        etudiantModifier.Classe = (Classe)comboBox1.SelectedItem;
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
                int idetd = (int)dataGridView1.SelectedRows[0].Cells["Id"].Value;
                Etudiant classeSelect = db.Etudiants.Find(idetd);
                txtNom.Text = classeSelect.Nom;
                txtPrenom.Text = classeSelect.Prenom;              
                btnSupprimer.Enabled = true;
                btnModifier.Enabled = true;
            }
        }

        private void btnSupprimer_Click(object sender, EventArgs e)
        {
            using (var db = new DBScolaire())
            {
                if (dataGridView1.SelectedRows != null)
                {
                    int idetd = (int)dataGridView1.SelectedRows[0].Cells["Id"].Value;
                    Etudiant etdSupprimer = db.Etudiants.Find(idetd);
                    DialogResult choix = MessageBox.Show("Voullez vous Vraiment Supprimer la classe ?", "Confirmer la suppression", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (choix == DialogResult.Yes)
                    {

                        db.Etudiants.Remove(etdSupprimer);
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
    }
}
