// See https://aka.ms/new-console-template for more information
using System;
using System.IO;
using System.Net.Security;
using static System.Net.Mime.MediaTypeNames;
using static System.Net.WebRequestMethods;
using static System.Runtime.InteropServices.JavaScript.JSType;


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
                break;
            case 8:
                Console.WriteLine("Lister uniquement les fiches supprimées logiquement");
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
        string repertoireprojet = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..", "..", ".."));
        string chemindufichier = Path.Combine(repertoireprojet, "clients.dat");
        using (FileStream fs = new FileStream(chemindufichier, FileMode.Append, FileAccess.Write))
        using (BinaryWriter WriterBin = new BinaryWriter(fs))
        {
            
            {
                {
                    Console.WriteLine("Veuillez saisir le nom du client : ");
                    string nom = Console.ReadLine();
                    WriterBin.Write(Majuscule(nom));

                    Console.WriteLine("Veuillez saisir le prenom du client : ");
                    string prenom = Console.ReadLine();

                    WriterBin.Write(FirstMajuscule(prenom));
                }
            }
        }

    }
    static void RechercheClient()
    {
        Console.Write("Nom a rechercher : ");
        string cible = Console.ReadLine();
        cible = Majuscule(cible);

        bool found = false;

        string repertoireprojet = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..", "..", ".."));
        string chemindufichier = Path.Combine(repertoireprojet, "clients.dat");
        using (FileStream fs = new FileStream(chemindufichier, FileMode.Open, FileAccess.Read))
        using (BinaryReader reader = new BinaryReader(fs))
        {
            while (fs.Position < fs.Length)
            {
                string nom = reader.ReadString();    
                string prenom = reader.ReadString();  

                if (string.Equals(nom, cible, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine($"{nom} {prenom}");
                    found = true;
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
        using (FileStream fs = new FileStream(chemindufichier, FileMode.Open, FileAccess.Read))
        using (BinaryReader reader = new BinaryReader(fs))
        {
            while (fs.Position < fs.Length)
            {
                string nom = reader.ReadString();
                string prenom = reader.ReadString();
                Console.WriteLine($"{nom} {prenom}");
                
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
        using (FileStream fs = new FileStream(chemindufichier, FileMode.Open, FileAccess.Read))
        using (BinaryReader reader = new BinaryReader(fs))
        {
            while (fs.Position < fs.Length)
            {
                string nom = reader.ReadString();
                string prenom = reader.ReadString();
                numberclient++;


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


        Console.Write("Numéro a rechercher : ");
        int cible = 0;
        if (int.TryParse(Console.ReadLine(), out cible))
        {
            bool found = false;
            int numclient = 0;


            using (FileStream fs = new FileStream(chemindufichier, FileMode.Open, FileAccess.ReadWrite))
            using (BinaryReader reader = new BinaryReader(fs))
            using (BinaryWriter WriterBin = new BinaryWriter(fs))
            {
                while (fs.Position < fs.Length)
                {
                    string nom = reader.ReadString();
                    string prenom = reader.ReadString();
                    numclient++;
                    if (cible == numclient)
                    {
                        Console.WriteLine($"Le client concerné est : [{numclient}] {nom} {prenom}");
                        found = true;
                        Console.WriteLine("Que souhaitez vous modifier ? 1: Le nom 2: Le prenom");

                        int numberchoix;
                        if (int.TryParse(Console.ReadLine(), out numberchoix))
                        {
                            Console.Clear();
                            switch (numberchoix)
                            {
                                case 1:
                                    Console.WriteLine("Saisir un nouveau nom du client :");
                                    string newnom = Console.ReadLine();
                                    WriterBin.Write(Majuscule(newnom));
                                    break;
                                case 2:
                                    Console.WriteLine("Saisir un nouveau prenom du client client");
                                    string newprenom = Console.ReadLine();

                                    WriterBin.Write(FirstMajuscule(newprenom));
                                    break;

                            }
                        }


                    }
                    if (!found)
                    {
                        Console.WriteLine("Aucun client trouvé avec ce numero.");
                    }
                    Console.WriteLine("Appuer sur une touche pour continuer :");
                    Console.Read();
                }
            }
        }
        else
        {

            Console.WriteLine("Veuillez saisir un nombre valide");
        }

    }


  

    static void DeleteClient()
    {
        string repertoireprojet = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..", "..", ".."));
        string chemindufichier = Path.Combine(repertoireprojet, "clients.dat");
        using (FileStream fs = new FileStream(chemindufichier, FileMode.Open, FileAccess.Read))
        using (BinaryReader reader = new BinaryReader(fs))
        {
            while (fs.Position < fs.Length)
            {
                string nom = reader.ReadString();
                string prenom = reader.ReadString();



            }
        }
        Console.WriteLine($"Appuer sur une touche pour continuer");
        Console.Read();

    }
    
    static void CompresseFile()
    {
        string repertoireprojet = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..", "..", ".."));
        string chemindufichier = Path.Combine(repertoireprojet, "clients.dat");
        using (FileStream fs = new FileStream(chemindufichier, FileMode.Open, FileAccess.Read))
        using (BinaryReader reader = new BinaryReader(fs))
        {
            while (fs.Position < fs.Length)
            {
                string nom = reader.ReadString();
                string prenom = reader.ReadString();



            }
        }
        Console.WriteLine($"Appuer sur une touche pour continuer");
        Console.Read();

    }


    static string Majuscule (string nom)
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

