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
            Popupedit popupedit = new Popupedit();
            popupedit.ShowDialog();

        }

        public void DeleteClient()
        {
            popupsupp popup = new popupsupp();
            popup.ShowDialog();
        }

        public void RecupererClient()
        {

           popuprecuperclient popup = new popuprecuperclient();
            popup.ShowDialog();
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
