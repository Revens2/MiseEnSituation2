using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mise_en_Situation_Graphique
{
    public partial class popuplistsup : Form
    {
        public popuplistsup()
        {
            InitializeComponent();
            Client c = new Client();

            DataGridViewTextBoxColumn colid = new DataGridViewTextBoxColumn();
            colid.Name = "id";
            colid.HeaderText = "Id du client";
            gvlist.Columns.Add(colid);

            DataGridViewTextBoxColumn colnom = new DataGridViewTextBoxColumn();
            colnom.Name = "nom";
            colnom.HeaderText = "Nom du client";
            gvlist.Columns.Add(colnom);

            DataGridViewTextBoxColumn colprenom = new DataGridViewTextBoxColumn();
            colprenom.Name = "prenom";
            colprenom.HeaderText = "Prenom du client";
            gvlist.Columns.Add(colprenom);

            DataGridViewTextBoxColumn colnum = new DataGridViewTextBoxColumn();
            colnum.Name = "num";
            colnum.HeaderText = "Numero du client";
            gvlist.Columns.Add(colnum);

            string repertoireprojet = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..", "..", ".."));
            string chemindufichier = Path.Combine(repertoireprojet, "clients.dat");
            FileInfo fi = new FileInfo(chemindufichier);
            if (fi.Length == 0)
            {
                Console.WriteLine("Le fichier est vide, impossible de rechercher un client supprimé.");
                return;
            }
            using (FileStream fs = new FileStream(chemindufichier, FileMode.Open, FileAccess.Read))
            using (BinaryReader reader = new BinaryReader(fs))
            {
                while (fs.Position < fs.Length)
                {
                    c.Id = reader.ReadInt32();
                    c.nom = reader.ReadString();
                    c.prenom = reader.ReadString();
                    c.num = reader.ReadString();
                    if (c.nom.StartsWith("*"))
                    {
                        gvlist.Rows.Add(c.Id, c.nom, c.prenom, c.num);
                    }
                }
            }
        }

        private void btexit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
