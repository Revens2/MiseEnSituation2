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

bool quitter = false;


while (!quitter)
{
    Console.WriteLine("Veuillez saisir un nombre pour naviguer : ");
    Console.WriteLine("1 : Saisir un nouveau client");
    Console.WriteLine("2 : Afficher un client par nom");
    Console.WriteLine("3 : Afficher tous les clients");
    Console.WriteLine("4 : Afficher le nombre de clients");
    Console.WriteLine("5 : Modifier une fiche par numéro");
    Console.WriteLine("6 : Supprimer une fiche");
    Console.WriteLine("7 : Récupérer une fiche supprimée par erreur");
    Console.WriteLine("8 : Lister uniquement les fiches supprimées logiquement");
    Console.WriteLine("9 : Compresser le fichier");
    Console.WriteLine("10 : Quitter");



    int numbernav;
    if (int.TryParse(Console.ReadLine(), out numbernav))
    {
        Console.Clear();
        switch (numbernav)
        {
            case 1:
                Console.WriteLine("Saisir un nouveau client");
                SaisirNouveauClient();
                break;
            case 2:
                Console.WriteLine("Afficher un client par nom");
                RechercheClient();
                break;
            case 3:
                Console.WriteLine("Afficher tous les clients");
                RecherchetousClient();
                break;
            case 4:
                Console.WriteLine("Afficher le nombre de clients");
                NombreClient();
                break;
            case 5:
                Console.WriteLine("Modifier un client");
                EditClient();
                break;
            case 6:
                Console.WriteLine("Supprimer une fiche");
                DeleteClient();
                break;
            case 7:
                Console.WriteLine("Récupérer une fiche supprimée par erreur");
                RecupererClient();
                break;
            case 8:
                Console.WriteLine("Lister uniquement les fiches supprimées logiquement");
                RechercheClientSupprimé();
                break;
            case 9:
                Console.WriteLine("Compresser le fichier");
                CompresseFile();
                break;
            case 10:
                quitter = true;
                break;
            default:
                Console.WriteLine("Choix invalide veuillez réessayer");
                Console.ReadKey();
                break;
        }
    }
    else
    {
        Console.WriteLine("veuillez saisir un nombre");
    }
    Console.Clear();

    static void SaisirNouveauClient()
    {
        int id = 0;
        int idsupp = 0;
        bool clientsupp = false;
        string repertoireprojet = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..", "..", ".."));
        string chemindufichier = Path.Combine(repertoireprojet, "clients.dat");
        using (FileStream fs = new FileStream(chemindufichier, FileMode.Open, FileAccess.Read))
        using (BinaryReader reader = new BinaryReader(fs))
        {
            while (fs.Position < fs.Length)
            {
                int idd = reader.ReadInt32();
                string nom = reader.ReadString();
                string prenom = reader.ReadString();
                string num = reader.ReadString();
                id++;
                if (nom.StartsWith("*"))
                {
                    clientsupp = true;
                    idsupp = idd;

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





