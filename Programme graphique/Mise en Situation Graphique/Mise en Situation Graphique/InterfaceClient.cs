using System;
using System.Reflection;
using System.Windows.Forms;
using System.Xml.Linq;
namespace Mise_en_Situation_Graphique
{

    public partial class InterfaceClient : Form
    {
        List<string> LesMethodes = new List<string> { "SaisirNouveauClient", "RechercheClient", "RecherchetousClient", "NombreClient", "EditClient", "DeleteClient", "RecupererClient", "RechercheClientSupprimé", "CompresseFile", "QUITTER_ACTION" };
        Programe monprog = new Programe();
        public InterfaceClient()
        {
            InitializeComponent();


        }

        private void btaddclient_Click(object sender, EventArgs e)
        {
            MethodInfo methodInfo = monprog.GetType().GetMethod(LesMethodes[0]);

            methodInfo.Invoke(monprog, null);
        }

        private void btsearchclient_Click(object sender, EventArgs e)
        {
            MethodInfo methodInfo = monprog.GetType().GetMethod(LesMethodes[1]);

            methodInfo.Invoke(monprog, null);
        }

        private void btallsearch_Click(object sender, EventArgs e)
        {
            MethodInfo methodInfo = monprog.GetType().GetMethod(LesMethodes[2]);

            methodInfo.Invoke(monprog, null);
        }

        private void btnbclient_Click(object sender, EventArgs e)
        {
            MethodInfo methodInfo = monprog.GetType().GetMethod(LesMethodes[3]);

            methodInfo.Invoke(monprog, null);
        }

        private void bteditclient_Click(object sender, EventArgs e)
        {
            MethodInfo methodInfo = monprog.GetType().GetMethod(LesMethodes[4]);

            methodInfo.Invoke(monprog, null);
        }

        private void btdeleteclient_Click(object sender, EventArgs e)
        {
            MethodInfo methodInfo = monprog.GetType().GetMethod(LesMethodes[5]);

            methodInfo.Invoke(monprog, null);
        }

        private void btdeletesupprimer_Click(object sender, EventArgs e)
        {
            MethodInfo methodInfo = monprog.GetType().GetMethod(LesMethodes[6]);

            methodInfo.Invoke(monprog, null);
        }

        private void btsearchdeleteclient_Click(object sender, EventArgs e)
        {
            MethodInfo methodInfo = monprog.GetType().GetMethod(LesMethodes[7]);

            methodInfo.Invoke(monprog, null);
        }

        private void btcompresse_Click(object sender, EventArgs e)
        {
            MethodInfo methodInfo = monprog.GetType().GetMethod(LesMethodes[8]);

            methodInfo.Invoke(monprog, null);
        }

        private void btexit_Click(object sender, EventArgs e)
        {
            MethodInfo methodInfo = monprog.GetType().GetMethod(LesMethodes[9]);

            methodInfo.Invoke(monprog, null);
        }
    }
}
