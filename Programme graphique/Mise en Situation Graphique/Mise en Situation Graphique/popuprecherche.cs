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
    public partial class popuprecherche : Form
    {
        public popuprecherche()
        {
            InitializeComponent();
            btexit.Visible = false;
        }

        private void btok_Click(object sender, EventArgs e)
        {

            Client c = new Client();

            string repertoireprojet = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..", "..", ".."));
            string chemindufichier = Path.Combine(repertoireprojet, "clients.dat");
            FileInfo fi = new FileInfo(chemindufichier);
            if (fi.Length == 0)
            {
                Console.WriteLine("Le fichier est vide, impossible de rechercher un client.");
                Console.Read();
                return;
            }

            string cible = tbsearch.Text;
            cible = cible.ToUpper();

            bool found = false;
            using (FileStream fs = new FileStream(chemindufichier, FileMode.Open, FileAccess.Read))
            using (BinaryReader reader = new BinaryReader(fs))
            {
                while (fs.Position < fs.Length)
                {
                    c.Id = reader.ReadInt32();
                    c.nom = reader.ReadString();
                    c.prenom = reader.ReadString();
                    c.num = reader.ReadString();

                    if (string.Equals(c.nom, cible, StringComparison.OrdinalIgnoreCase))
                    {
                        if (!c.nom.StartsWith("*"))
                        {
                            lbresult.Text = $"{c.nom} {c.prenom} {c.num}";
                            found = true;

                        }
                    }
                }
            }
            if (!found)
            {
                lbresult.Text = "Aucun client trouvé avec ce nom.";
            }
            btexit.Visible = true;
        }

        private void btexit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
