using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mise_en_Situation_Graphique
{
    public struct Client
    {
        public int Id { get; set; }
        public string nom { get; set; }
        public string prenom { get; set; }
        public string num { get; set; }
        public void Majuscule()
        {
            nom = nom.ToUpper();

        }
        public void FirstMajuscule()
        {

            prenom = prenom.ToLower();
            prenom = char.ToUpper(prenom[0]) + prenom.Substring(1);
        }
    }
    public class Programe
    {
        Client c = new Client();
        public void SaisirNouveauClient()
        {
            Popupajout popup = new Popupajout();
            popup.ShowDialog();

        }

        public void RechercheClient()
        {
            popuprecherche popup = new popuprecherche();
            popup.ShowDialog();

        }
        public void RecherchetousClient()
        {

            popuplistclients popup = new popuplistclients();
            popup.ShowDialog();

        }
        public void NombreClient()
        {
            popupnbclient popup = new popupnbclient();
            popup.ShowDialog();
            

        }


        public void EditClient()
        {

            string repertoireprojet = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..", "..", ".."));
            string chemindufichier = Path.Combine(repertoireprojet, "clients.dat");
            string chemindufichiertemporaire = Path.Combine(repertoireprojet, "clientstempo.dat");
            FileInfo fi = new FileInfo(chemindufichier);
            if (fi.Length == 0)
            {
                Console.WriteLine("Le fichier est vide, impossible de modifier un client.");
                Console.Read();
                return;
            }

            Console.Write("Numéro a rechercher : ");
            int cible = 0;
            bool found = false;
            if (int.TryParse(Console.ReadLine(), out cible))
            {



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
                            if (cible == c.Id)
                            {
                                Console.WriteLine($"Le client concerné est : [{c.Id}] {c.nom} {c.prenom} {c.num}");
                                found = true;
                                Console.WriteLine("Que souhaitez vous modifier ? 1: Le nom 2: Le prenom 3: Le numero");

                                int numberchoix;
                                if (int.TryParse(Console.ReadLine(), out numberchoix))
                                {
                                    Console.Clear();
                                    switch (numberchoix)
                                    {
                                        case 1:
                                            Console.WriteLine("Saisir un nouveau nom du client :");
                                            c.nom = Console.ReadLine();
                                            break;
                                        case 2:
                                            Console.WriteLine("Saisir un nouveau prenom du client client");
                                            c.prenom = Console.ReadLine();

                                            break;
                                        case 3:
                                            Console.WriteLine("Saisir un nouveau numero du client client");
                                            c.num = Console.ReadLine();
                                            break;

                                    }
                                }


                            }
                        }
                        WriterBin.Write(c.Id);
                        c.Majuscule();
                        WriterBin.Write(c.nom);
                        c.FirstMajuscule();
                        WriterBin.Write(c.prenom);
                        WriterBin.Write(c.num);


                    }
                    if (!found)
                    {
                        Console.WriteLine("Aucun client trouvé avec ce numero.");
                    }

                    Console.WriteLine("Appuer sur une touche pour continuer :");
                    Console.Read();
                }
            }
            else
            {
                Console.WriteLine("Veuillez saisir un nombre valide");
            }

            if (found)
            {
                using (var fs2 = new FileStream(chemindufichier, FileMode.Open, FileAccess.Write, FileShare.None))
                using (var fsmodifier2 = new FileStream(chemindufichiertemporaire, FileMode.Open, FileAccess.Read, FileShare.Read))

                {
                    fs2.SetLength(0);
                    fsmodifier2.CopyTo(fs2);
                }
            }



        }

        public void DeleteClient()
        {

            string repertoireprojet = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..", "..", ".."));
            string chemindufichier = Path.Combine(repertoireprojet, "clients.dat");
            string chemindufichiertemporaire = Path.Combine(repertoireprojet, "clientstempo.dat");
            FileInfo fi = new FileInfo(chemindufichier);
            if (fi.Length == 0)
            {
                Console.WriteLine("Le fichier est vide, impossible de supprimer un client.");
                Console.Read();
                return;
            }


            Console.Write("Numéro a rechercher : ");
            int cible = 0;

            if (int.TryParse(Console.ReadLine(), out cible))
            {
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
                            if (cible == c.Id)
                            {
                                Console.WriteLine($"Le client que vous allez supprimer est : [{c.Id}] {c.nom} {c.prenom}");

                                Console.WriteLine("Confirmez la suppresion ? 1: oui 2: Non");

                                int numberchoix;
                                if (int.TryParse(Console.ReadLine(), out numberchoix))
                                {
                                    Console.Clear();
                                    switch (numberchoix)
                                    {
                                        case 1:
                                            c.nom = "*" + c.nom;
                                            found = true;
                                            break;
                                        case 2:
                                            return;
                                    }
                                }


                            }

                        }
                        WriterBin.Write(c.Id);
                        c.Majuscule();
                        WriterBin.Write(c.nom);
                        c.FirstMajuscule();
                        WriterBin.Write(c.prenom);
                        WriterBin.Write(c.num);

                    }
                    if (!found)
                    {
                        Console.WriteLine("Aucun client trouvé avec ce numero.");
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
            }
            else
            {
                Console.WriteLine("Veuillez saisir un nombre valide");
            }

        }

        public void RecupererClient()
        {

            string repertoireprojet = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..", "..", ".."));
            string chemindufichier = Path.Combine(repertoireprojet, "clients.dat");
            string chemindufichiertemporaire = Path.Combine(repertoireprojet, "clientstempo.dat");
            FileInfo fi = new FileInfo(chemindufichier);
            if (fi.Length == 0)
            {
                Console.WriteLine("Le fichier est vide, impossible de recuperer un client.");
                Console.Read();
                return;
            }


            Console.Write("nom du client a recuperer : ");
            string cible = "*" + Console.ReadLine();
            cible = cible.ToUpper();
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
                    if (c.nom.StartsWith("*"))
                    {

                        if (cible == c.nom)
                        {
                            Console.WriteLine($"Le client que vous allez recuperer est : [{c.Id}] {c.nom} {c.prenom}");

                            Console.WriteLine("Confirmez la recuperation ? 1: oui 2: Non");

                            int numberchoix;
                            if (int.TryParse(Console.ReadLine(), out numberchoix))
                            {
                                Console.Clear();
                                switch (numberchoix)
                                {
                                    case 1:
                                        c.nom = c.nom.TrimStart('*');
                                        found = true;
                                        break;
                                    case 2:
                                        break;


                                }
                            }



                        }
                    }
                    WriterBin.Write(c.Id);
                    c.Majuscule();
                    WriterBin.Write(c.nom);
                    c.FirstMajuscule();
                    WriterBin.Write(c.prenom);
                    WriterBin.Write(c.num);

                }
                if (!found)
                {
                    Console.WriteLine("Aucun client trouvé avec ce nom.");
                    Console.Read();
                }
            }
            if (found)
            {
                using (var fs2 = new FileStream(chemindufichier, FileMode.Open, FileAccess.Write, FileShare.None))
                using (var fsmodifier2 = new FileStream(chemindufichiertemporaire, FileMode.Open, FileAccess.Read, FileShare.Read))

                {
                    fs2.SetLength(0);
                    fsmodifier2.CopyTo(fs2);
                }
            }

        }
        public void RechercheClientSupprimé()
        {

            popuplistsup popup = new popuplistsup();
            popup.ShowDialog();

        }

        public void CompresseFile()
        {
            popupcompresse popup = new popupcompresse();
            popup.ShowDialog();
            
        }
        public void QUITTER_ACTION()
        {
            popupexit popup = new popupexit();
            popup.ShowDialog();
            
        }
        
    }

}
