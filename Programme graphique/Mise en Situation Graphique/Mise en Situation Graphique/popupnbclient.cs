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
    public partial class popupnbclient : Form
    {
        public popupnbclient()
        {
            InitializeComponent();
            Client c = new Client();
            int numberclient = 0;
            string repertoireprojet = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..", "..", ".."));
            string chemindufichier = Path.Combine(repertoireprojet, "clients.dat");
            FileInfo fi = new FileInfo(chemindufichier);
            if (fi.Length == 0)
            {
                Console.WriteLine("Le fichier est vide, impossible d'afficher le nombre de client.");
                Console.Read();
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
                    if (!c.nom.StartsWith("*"))
                    {
                        numberclient++;
                    }


                }
            }
            lbnb.Text = Convert.ToString(numberclient);
        }

        private void btretour_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
