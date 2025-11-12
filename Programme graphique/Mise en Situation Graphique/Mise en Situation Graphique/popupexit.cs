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
    public partial class popupexit : Form
    {
        public popupexit()
        {
            InitializeComponent();
        }

        private void btyes_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btno_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
