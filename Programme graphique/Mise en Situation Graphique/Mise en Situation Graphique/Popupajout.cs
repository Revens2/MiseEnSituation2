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
    public partial class Popupajout : Form
    {
        public Popupajout()
        {
            InitializeComponent();
        }

        private void btsave_Click(object sender, EventArgs e)
        {

            Client c = new Client();
            int id = 0;
            int idsupp = 0;

            bool clientsupp = false;
            string repertoireprojet = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..", "..", ".."));
            string chemindufichier = Path.Combine(repertoireprojet, "clients.dat");
            FileInfo fi = new FileInfo(chemindufichier);
            if (fi.Length > 2)
            {
                using (FileStream fs = new FileStream(chemindufichier, FileMode.Open, FileAccess.Read))
                using (BinaryReader reader = new BinaryReader(fs))
                {

                    while (fs.Position < fs.Length)
                    {
                        c.Id = reader.ReadInt32();
                        c.nom = reader.ReadString();
                        c.prenom = reader.ReadString();
                        c.num = reader.ReadString();
                        id++;
                        if (c.nom.StartsWith("*"))
                        {
                            clientsupp = true;
                            idsupp = c.Id;

                        }

                    }
                }
            }
            if (clientsupp)
            {
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
                        if (c.nom.StartsWith("*"))
                        {
                            if (idsupp == c.Id)
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

                {
                    using (var fs2 = new FileStream(chemindufichier, FileMode.Open, FileAccess.Write, FileShare.None))
                    using (var fsmodifier2 = new FileStream(chemindufichiertemporaire, FileMode.Open, FileAccess.Read, FileShare.Read))

                    {
                        fs2.SetLength(0);
                        fsmodifier2.CopyTo(fs2);
                    }
                }



            }
            else
            {


                using (FileStream fs2 = new FileStream(chemindufichier, FileMode.Append, FileAccess.Write))
                using (BinaryWriter WriterBin = new BinaryWriter(fs2))
                {

                    {
                        {
                            WriterBin.Write(id + 1);
                            c.nom = tbnom.Text;

                            c.Majuscule();
                            WriterBin.Write(c.nom);
                            c.prenom = tbprenom.Text;
                            c.FirstMajuscule();
                            WriterBin.Write(c.prenom);
                            c.num = tbnum.Text;
                            WriterBin.Write(c.num);
                        }
                    }
                }
            }
            this.Close();
        }

        private void btreturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
