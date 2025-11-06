// See https://aka.ms/new-console-template for more information
using System;
using System.IO;
using System.Net.Security;
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

    Console.Clear();

    int numbernav;
    if (int.TryParse(Console.ReadLine(), out numbernav))
    {
        switch (numbernav)
        {
            case 1:
                Console.WriteLine("Saisir un nouveau client");

                break;
            case 2:
                Console.WriteLine("Afficher un client par nom");
                break;
            case 3:
                Console.WriteLine("Afficher tous les clients");
                break;
            case 4:
                Console.WriteLine("Afficher le nombre de clients");
                break;
            case 5:
                Console.WriteLine("Modifier une fiche par numéro");
                break;
            case 6:
                Console.WriteLine("Supprimer une fiche");
                break;
            case 7:
                Console.WriteLine("Récupérer une fiche supprimée par erreur");
                break;
            case 8:
                Console.WriteLine("Lister uniquement les fiches supprimées logiquement");
                break;
            case 9:
                Console.WriteLine("Compresser le fichier");
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

    static void SaisirNouveauClient()
    {
        string repertoireprojet = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..", "..", ".."));
        string chemindufichier = Path.Combine(repertoireprojet, "clients.txt");
        using (FileStream MonFichier = new FileStream(chemindufichier, FileMode.Append, FileAccess.Write))
        {

        }
    }




}

