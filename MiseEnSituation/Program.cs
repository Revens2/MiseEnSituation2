// See https://aka.ms/new-console-template for more information
using System;
using System.IO;
using System.Net.NetworkInformation;
using System.Net.Security;
using System.Reflection.PortableExecutable;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Collections.Generic;
using System.Reflection;
public  struct Client
{
    public int Id { get; set; }
    public string nom { get; set; }
    public string prenom { get; set; }
    public string num { get; set; }
}
public static class Program
{

    static bool quitter = false;
    static var menuActions = new List<(string titre, string methodName)>
        {
            ("Saisir un nouveau client", "SaisirNouveauClient"),
            ("Afficher un client par nom", "RechercheClient"),
            ("Afficher tous les clients", "RecherchetousClient"),
            ("Afficher le nombre de clients", "NombreClient"),
            ("Modifier une fiche par numéro", "EditClient"),
            ("Supprimer une fiche", "DeleteClient"),
            ("Récupérer une fiche supprimée par erreur", "RecupererClient"),
            ("Lister uniquement les fiches supprimées logiquement", "RechercheClientSupprimé"),
            ("Compresser le fichier", "CompresseFile"),
            ("Quitter", "QUITTER_ACTION")
        };
    public static void Main()
    {

        while (!quitter)
        {
            Console.WriteLine("Veuillez saisir un nombre pour naviguer : ");

            for (int i = 0; i < menuActions.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {menuActions[i].titre}");

            }



            int numbernav;
            if (int.TryParse(Console.ReadLine(), out numbernav))
            {
                Console.Clear();
            }
            else
            {
                Console.WriteLine("veuillez saisir un nombre");
            }
            Console.Clear();
        }
    }
    static void SaisirNouveauClient()
    {
        int id = 0;
        int idsupp = 0;
        var c = new Client();
        bool clientsupp = false;
        string repertoireprojet = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..", "..", ".."));
        string chemindufichier = Path.Combine(repertoireprojet, "clients.dat");
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

        if (clientsupp)
        {
            string chemindufichiertemporaire = Path.Combine(repertoireprojet, "clientstempo.dat");


            int idd = 0;



            using (FileStream fs = new FileStream(chemindufichier, FileMode.Open, FileAccess.Read, FileShare.Read))
            using (FileStream fsmodifier = new FileStream(chemindufichiertemporaire, FileMode.Create, FileAccess.Write, FileShare.None))
            using (BinaryReader reader = new BinaryReader(fs))
            using (BinaryWriter WriterBin = new BinaryWriter(fsmodifier))
            {
                while (fs.Position < fs.Length)
                {
                    idd = reader.ReadInt32();
                    string nom = reader.ReadString();
                    string prenom = reader.ReadString();
                    string num = reader.ReadString();
                    if (nom.StartsWith("*"))
                    {
                        if (idsupp == idd)
                        {
                            Console.WriteLine("Veuillez saisir le nom du client : ");
                            nom = Console.ReadLine();

                            Console.WriteLine("Veuillez saisir le prenom du client : ");
                            prenom = Console.ReadLine();

                            Console.WriteLine("Veuillez saisir le prenom du client : ");
                            num = Console.ReadLine();


                        }
                    }
                    WriterBin.Write(idd);
                    WriterBin.Write(Majuscule(nom));
                    WriterBin.Write(FirstMajuscule(prenom));
                    WriterBin.Write(num);

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
                        Console.WriteLine("Veuillez saisir le nom du client : ");
                        string nom = Console.ReadLine();
                        WriterBin.Write(Majuscule(nom));

                        Console.WriteLine("Veuillez saisir le prenom du client : ");
                        string prenom = Console.ReadLine();
                        WriterBin.Write(FirstMajuscule(prenom));

                        Console.WriteLine("Veuillez saisir le prenom du client : ");
                        string num = Console.ReadLine();
                        WriterBin.Write(num);
                    }
                }
            }
        }

    }

    static void RechercheClient()
    {
        string repertoireprojet = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..", "..", ".."));
        string chemindufichier = Path.Combine(repertoireprojet, "clients.dat");
        FileInfo fi = new FileInfo(chemindufichier);
        if (fi.Length == 0)
        {
            Console.WriteLine("Le fichier est vide, impossible de rechercher un client.");
            Console.Read();
            return;
        }

        Console.Write("Nom a rechercher : ");
        string cible = Console.ReadLine();
        cible = Majuscule(cible);

        bool found = false;
        using (FileStream fs = new FileStream(chemindufichier, FileMode.Open, FileAccess.Read))
        using (BinaryReader reader = new BinaryReader(fs))
        {
            while (fs.Position < fs.Length)
            {
                int idd = reader.ReadInt32();
                string nom = reader.ReadString();
                string prenom = reader.ReadString();
                string num = reader.ReadString();

                if (string.Equals(nom, cible, StringComparison.OrdinalIgnoreCase))
                {
                    if (!nom.StartsWith("*"))
                    {
                        Console.WriteLine($"{nom} {prenom}");
                        found = true;
                    }
                }
            }
        }
        if (!found)
        {
            Console.WriteLine("Aucun client trouvé avec ce nom.");
        }
        Console.WriteLine("Appuer sur une touche pour continuer :");
        Console.Read();

    }
    static void RecherchetousClient()
    {
        string repertoireprojet = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..", "..", ".."));
        string chemindufichier = Path.Combine(repertoireprojet, "clients.dat");
        FileInfo fi = new FileInfo(chemindufichier);
        if (fi.Length == 0)
        {
            Console.WriteLine("Le fichier est vide, impossible d'afficher tout les clients.");
            Console.Read();
            return;
        }
        using (FileStream fs = new FileStream(chemindufichier, FileMode.Open, FileAccess.Read))
        using (BinaryReader reader = new BinaryReader(fs))
        {
            while (fs.Position < fs.Length)
            {
                int idd = reader.ReadInt32();
                string nom = reader.ReadString();
                string prenom = reader.ReadString();
                string num = reader.ReadString();
                if (!nom.StartsWith("*"))
                {
                    Console.WriteLine($"{idd} {nom} {prenom} {num}");
                }
            }
        }
        Console.WriteLine("Appuer sur une touche pour continuer :");
        Console.Read();

    }
    static void NombreClient()
    {
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
                int idd = reader.ReadInt32();
                string nom = reader.ReadString();
                string prenom = reader.ReadString();
                string num = reader.ReadString();
                if (!nom.StartsWith("*"))
                {
                    numberclient++;
                }


            }
        }
        Console.WriteLine($"Le nombre de client est de : {numberclient}");
        Console.WriteLine($"Appuer sur une touche pour continuer");
        Console.Read();

    }


    static void EditClient()
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
        int idd = 0;
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
                    idd = reader.ReadInt32();
                    string nom = reader.ReadString();
                    string prenom = reader.ReadString();
                    string num = reader.ReadString();
                    if (!nom.StartsWith("*"))
                    {
                        if (cible == idd)
                        {
                            Console.WriteLine($"Le client concerné est : [{idd}] {nom} {prenom} {num}");
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
                                        nom = Console.ReadLine();
                                        break;
                                    case 2:
                                        Console.WriteLine("Saisir un nouveau prenom du client client");
                                        prenom = Console.ReadLine();

                                        break;
                                    case 3:
                                        Console.WriteLine("Saisir un nouveau numero du client client");
                                        num = Console.ReadLine();
                                        break;

                                }
                            }


                        }
                    }
                    WriterBin.Write(idd);
                    WriterBin.Write(Majuscule(nom));
                    WriterBin.Write(FirstMajuscule(prenom));
                    WriterBin.Write(num);

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

    static void DeleteClient()
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
        int idd = 0;

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
                    idd = reader.ReadInt32();
                    string nom = reader.ReadString();
                    string prenom = reader.ReadString();
                    string num = reader.ReadString();
                    if (!nom.StartsWith("*"))
                    {
                        if (cible == idd)
                        {
                            Console.WriteLine($"Le client que vous allez supprimer est : [{idd}] {nom} {prenom}");

                            Console.WriteLine("Confirmez la suppresion ? 1: oui 2: Non");

                            int numberchoix;
                            if (int.TryParse(Console.ReadLine(), out numberchoix))
                            {
                                Console.Clear();
                                switch (numberchoix)
                                {
                                    case 1:
                                        nom = "*" + nom;
                                        found = true;
                                        break;
                                    case 2:
                                        return;
                                }
                            }


                        }

                    }
                    WriterBin.Write(idd);
                    WriterBin.Write(nom);
                    WriterBin.Write(prenom);
                    WriterBin.Write(num);
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

    static void RecupererClient()
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
        int idd = 0;
        bool found = false;


        using (FileStream fs = new FileStream(chemindufichier, FileMode.Open, FileAccess.Read, FileShare.Read))
        using (FileStream fsmodifier = new FileStream(chemindufichiertemporaire, FileMode.Create, FileAccess.Write, FileShare.None))
        using (BinaryReader reader = new BinaryReader(fs))
        using (BinaryWriter WriterBin = new BinaryWriter(fsmodifier))
        {
            while (fs.Position < fs.Length)
            {
                idd = reader.ReadInt32();
                string nom = reader.ReadString();
                string prenom = reader.ReadString();
                string num = reader.ReadString();
                if (nom.StartsWith("*"))
                {

                    if (cible == nom)
                    {
                        Console.WriteLine($"Le client que vous allez recuperer est : [{idd}] {nom} {prenom}");

                        Console.WriteLine("Confirmez la recuperation ? 1: oui 2: Non");

                        int numberchoix;
                        if (int.TryParse(Console.ReadLine(), out numberchoix))
                        {
                            Console.Clear();
                            switch (numberchoix)
                            {
                                case 1:
                                    nom = nom.TrimStart('*');
                                    found = true;
                                    break;
                                case 2:
                                    break;


                            }
                        }



                    }
                }
                WriterBin.Write(idd);
                WriterBin.Write(nom);
                WriterBin.Write(prenom);
                WriterBin.Write(num);
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
    static void RechercheClientSupprimé()
    {
        string repertoireprojet = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..", "..", ".."));
        string chemindufichier = Path.Combine(repertoireprojet, "clients.dat");
        FileInfo fi = new FileInfo(chemindufichier);
        if (fi.Length == 0)
        {
            Console.WriteLine("Le fichier est vide, impossible de rechercher un client supprimé.");
            Console.Read();
            return;
        }
        using (FileStream fs = new FileStream(chemindufichier, FileMode.Open, FileAccess.Read))
        using (BinaryReader reader = new BinaryReader(fs))
        {
            while (fs.Position < fs.Length)
            {
                int idd = reader.ReadInt32();
                string nom = reader.ReadString();
                string prenom = reader.ReadString();
                string num = reader.ReadString();
                if (nom.StartsWith("*"))
                {
                    Console.WriteLine($"{idd} {nom} {prenom} {num}");
                }
            }
        }
        Console.WriteLine("Appuer sur une touche pour continuer :");
        Console.Read();

    }

    static void CompresseFile()
    {
        string repertoireprojet = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..", "..", ".."));
        string chemindufichier = Path.Combine(repertoireprojet, "clients.dat");
        string chemindufichiertemporaire = Path.Combine(repertoireprojet, "clientstempo.dat");
        FileInfo fi = new FileInfo(chemindufichier);
        if (fi.Length == 0)
        {
            Console.WriteLine("Le fichier est vide, impossible de compresser le fichier.");
            Console.Read();
            return;
        }
        using (FileStream fs = new FileStream(chemindufichier, FileMode.Open, FileAccess.Read, FileShare.Read))
        using (FileStream fsmodifier = new FileStream(chemindufichiertemporaire, FileMode.Create, FileAccess.Write, FileShare.None))
        using (BinaryReader reader = new BinaryReader(fs))
        using (BinaryWriter WriterBin = new BinaryWriter(fsmodifier))
        {
            while (fs.Position < fs.Length)
            {
                int idd = reader.ReadInt32();
                string nom = reader.ReadString();
                string prenom = reader.ReadString();
                string num = reader.ReadString();
                if (!nom.StartsWith("*"))
                {
                    WriterBin.Write(idd);
                    WriterBin.Write(nom);
                    WriterBin.Write(prenom);
                    WriterBin.Write(num);

                }
            }
        }

        using (var fs2 = new FileStream(chemindufichier, FileMode.Open, FileAccess.Write, FileShare.None))
        using (var fsmodifier2 = new FileStream(chemindufichiertemporaire, FileMode.Open, FileAccess.Read, FileShare.Read))

        {
            fs2.SetLength(0);
            fsmodifier2.CopyTo(fs2);
        }
        Console.WriteLine("Fichier compressé avec succès.");
        Console.WriteLine("Appuer sur une touche pour continuer :");
        Console.Read();

    }





    static string Majuscule(string nom)
    {
        nom = nom.ToUpper();
        return nom;

    }
    static string FirstMajuscule(string prenom)
    {
        prenom = prenom.ToLower();
        prenom = char.ToUpper(prenom[0]) + prenom.Substring(1);
        return prenom;
    }
}





