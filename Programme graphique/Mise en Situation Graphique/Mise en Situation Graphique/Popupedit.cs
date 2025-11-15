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
    public partial class Popupedit : Form
    {
        int refid = 0;
        public Popupedit()
        {
            InitializeComponent();
            tbnom.Visible = false;
            tbprenom.Visible = false;
            tbnum.Visible = false;
            btsave.Visible = false;


        }

        private void btsave_Click(object sender, EventArgs e)
        {
            Client c = new Client();
            string repertoireprojet = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..", "..", ".."));
            string chemindufichier = Path.Combine(repertoireprojet, "clients.dat");
            string chemindufichiertemporaire = Path.Combine(repertoireprojet, "clientstempo.dat");
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
                        if (refid == c.Id)
                        {
                            c.nom = tbnom.Text;
                            c.prenom = tbprenom.Text;
                            c.num = tbnum.Text;


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

            using (var fs2 = new FileStream(chemindufichier, FileMode.Open, FileAccess.Write, FileShare.None))
            using (var fsmodifier2 = new FileStream(chemindufichiertemporaire, FileMode.Open, FileAccess.Read, FileShare.Read))

            {
                fs2.SetLength(0);
                fsmodifier2.CopyTo(fs2);
            }
            this.Close();
        }

        private void btok_Click(object sender, EventArgs e)
        {
            Client c = new Client();
            string repertoireprojet = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..", "..", ".."));
            string chemindufichier = Path.Combine(repertoireprojet, "clients.dat");
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
                            refid = c.Id;
                            found = true;
                            tbnom.Text = c.nom;
                            tbprenom.Text = c.prenom;
                            tbnum.Text = c.num;
                            tbnom.Visible = true;
                            tbprenom.Visible = true;
                            tbnum.Visible = true;
                            btsave.Visible = true;


                        }

                    }
                }
                if (!found)
                {
                    lbresult.Text = "Aucun client trouvé avec ce nom.";
                }



            }
        }

        private void btexit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
