using System;
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
    public partial class popuprecherchedelete : Form
    {
        public popuprecherchedelete()
        {
            InitializeComponent();
        }

        private void btok_Click(object sender, EventArgs e)
        {
            Client c = new Client();
            bool found = false;
            string repertoireprojet = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..", "..", ".."));
            string chemindufichier = Path.Combine(repertoireprojet, "clients.dat");
            FileInfo fi = new FileInfo(chemindufichier);
            if (fi.Length == 0)
            {
                lbresult.Text = "Le fichier est vide, impossible de rechercher un client supprimé.";
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
                        lbresult.Text = $"{c.Id} {c.nom} {c.prenom} {c.num}";
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
