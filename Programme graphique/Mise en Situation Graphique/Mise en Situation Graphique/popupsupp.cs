using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace Mise_en_Situation_Graphique
{
    public partial class popupsupp : Form
    {
        public popupsupp()
        {
            InitializeComponent();
            lbrecuperer.Visible = false;
            btyes.Visible = false;  
        }

        private void btok_Click(object sender, EventArgs e)
        {
            Client c = new Client();
            string repertoireprojet = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..", "..", ".."));
            string chemindufichier = Path.Combine(repertoireprojet, "clients.dat");
            string chemindufichiertemporaire = Path.Combine(repertoireprojet, "clientstempo.dat");
            FileInfo fi = new FileInfo(chemindufichier);
            if (fi.Length == 0)
            {
                lbresult.Text = "Le fichier est vide, impossible de supprimer un client.";
                return;
            }


            string cible = tbsearch.Text.ToUpper();

            bool found = false;


            using (FileStream fs = new FileStream(chemindufichier, FileMode.Open, FileAccess.Read, FileShare.Read))
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
                        if (cible == c.nom)
                        {
                            lbresult.Text = "Le client que vous allez supprimer est : " + c.Id + " " + c.nom + " " + c.prenom;
                             found = true;
                            lbrecuperer.Visible = true;
                            btyes.Visible = true;

                        }

                    }
                }
                if (!found)
                {
                    lbresult.Text = "Aucun client trouvé avec ce numero.";
                }



            }
        }




        private void btexit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btyes_Click(object sender, EventArgs e)
        {
            Client c = new Client();
            string repertoireprojet = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..", "..", ".."));
            string chemindufichier = Path.Combine(repertoireprojet, "clients.dat");
            string chemindufichiertemporaire = Path.Combine(repertoireprojet, "clientstempo.dat");


            string cible = tbsearch.Text;

            bool found = false;


            using (FileStream fs = new FileStream(chemindufichier, FileMode.Open, FileAccess.Read, FileShare.Read))
            using (FileStream fsmodifier = new FileStream(chemindufichiertemporaire, FileMode.Create, FileAccess.Write, FileShare.None))
            using (BinaryReader reader = new BinaryReader(fs))
            using (BinaryWriter WriterBin = new BinaryWriter(fsmodifier))
            {
                while (fs.Position < fs.Length)
                {
                    c.Id = reader.ReadInt32();
                    c.nom = reader.ReadString();
                    c.prenom = reader.ReadString();
                    c.num = reader.ReadString();
                    if (!c.nom.StartsWith("*"))
                    {
                        if (cible == c.nom)
                        {
                            c.nom = "*" + c.nom;
                            found = true;


                        }

                    }
                    WriterBin.Write(c.Id);
                    c.Majuscule();
                    WriterBin.Write(c.nom);
                    c.FirstMajuscule();
                    WriterBin.Write(c.prenom);
                    WriterBin.Write(c.num);

                }

            }

            if (found = true)
            {
                using (var fs2 = new FileStream(chemindufichier, FileMode.Open, FileAccess.Write, FileShare.None))
                using (var fsmodifier2 = new FileStream(chemindufichiertemporaire, FileMode.Open, FileAccess.Read, FileShare.Read))

                {
                    fs2.SetLength(0);
                    fsmodifier2.CopyTo(fs2);
                }
            }
            this.Close();
        }
    }
}
    
