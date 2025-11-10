using System;
using System.IO;
using System.Net.NetworkInformation;
using System.Net.Security;
using System.Reflection.PortableExecutable;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Collections.Generic;
using System.Reflection;
public struct Client
{
    public int Id { get; set; }
    public string nom { get; set; }
    public string prenom { get; set; }
    public string num { get; set; }
}
public class Program
{
    Client c = new Client();
    public void SaisirNouveauClient()
    {
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
                            Console.WriteLine("Veuillez saisir le nom du client : ");
                            c.nom = Console.ReadLine();

                            Console.WriteLine("Veuillez saisir le prenom du client : ");
                            c.prenom = Console.ReadLine();

                            Console.WriteLine("Veuillez saisir le prenom du client : ");
                            c.num = Console.ReadLine();


                        }
                    }
                    WriterBin.Write(c.Id);
                    Majuscule();
                    WriterBin.Write(c.nom);
                    FirstMajuscule();
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
                        Console.WriteLine("Veuillez saisir le nom du client : ");
                        c.nom = Console.ReadLine();
                        Majuscule();
                        WriterBin.Write(c.nom);


                        Console.WriteLine("Veuillez saisir le prenom du client : ");
                        c.prenom = Console.ReadLine();
                        FirstMajuscule();
                        WriterBin.Write(c.prenom);

                        Console.WriteLine("Veuillez saisir le prenom du client : ");
                        c.num = Console.ReadLine();
                        WriterBin.Write(c.num);
                    }
                }
            }
        }

    }

    public void RechercheClient()
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
                        Console.WriteLine($"{c.nom} {c.prenom}");
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
    public void RecherchetousClient()
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
                c.Id = reader.ReadInt32();
                c.nom = reader.ReadString();
                c.prenom = reader.ReadString();
                c.num = reader.ReadString();
                if (!c.nom.StartsWith("*"))
                {
                    Console.WriteLine($"{c.Id} {c.nom} {c.prenom} {c.num}");
                }
            }
        }
        Console.WriteLine("Appuer sur une touche pour continuer :");
        Console.Read();

    }
    public void NombreClient()
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
        Console.WriteLine($"Le nombre de client est de : {numberclient}");
        Console.WriteLine($"Appuer sur une touche pour continuer");
        Console.Read();

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
                    Majuscule();
                    WriterBin.Write(c.nom);
                    FirstMajuscule();
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
                    Majuscule();
                    WriterBin.Write(c.nom);
                    FirstMajuscule();
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
                Majuscule();
                WriterBin.Write(c.nom);
                FirstMajuscule();
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
                c.Id = reader.ReadInt32();
                c.nom = reader.ReadString();
                c.prenom = reader.ReadString();
                c.num = reader.ReadString();
                if (c.nom.StartsWith("*"))
                {
                    Console.WriteLine($"{c.Id} {c.nom} {c.prenom} {c.num}");
                }
            }
        }
        Console.WriteLine("Appuer sur une touche pour continuer :");
        Console.Read();

    }

    public void CompresseFile()
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
                c.Id = reader.ReadInt32();
                c.nom = reader.ReadString();
                c.prenom = reader.ReadString();
                c.num = reader.ReadString();
                if (!c.nom.StartsWith("*"))
                {
                    WriterBin.Write(c.Id);
                    Majuscule();
                    WriterBin.Write(c.nom);
                    FirstMajuscule();
                    WriterBin.Write(c.prenom);
                    WriterBin.Write(c.num);


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

    public void Majuscule()
    {
        c.nom = c.nom.ToUpper();

    }
    public void FirstMajuscule()
    {

        c.prenom = c.prenom.ToLower();
        c.prenom = char.ToUpper(c.prenom[0]) + c.prenom.Substring(1);
    }

    public static void Main()
    {
        bool quitter = false;
        List<string> LesMethodes = new List<string> { "SaisirNouveauClient", "RechercheClient", "RecherchetousClient", "NombreClient", "EditClient", "DeleteClient", "RecupererClient", "RechercheClientSupprimé", "CompresseFile", "QUITTER_ACTION" };
        Program monprog = new Program();
        while (!quitter)
        {
            int num = 0;
            foreach (string name in LesMethodes)
            {
                Console.WriteLine($"{num + 1}. {name}");
                num++;
            }
            Console.WriteLine("Veuillez saisir un nombre pour naviguer : ");
            int Num;
            if (int.TryParse(Console.ReadLine(), out Num))
            {
                Console.Clear();
                MethodInfo methodInfo = monprog.GetType().GetMethod(LesMethodes[Num - 1]);
                if (Num == 10)
                {
                    quitter = true;
                    return;
                }
                methodInfo.Invoke(monprog, null);
            }
            Console.Clear();
        }
    }

}





