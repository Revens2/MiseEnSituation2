namespace Mise_en_Situation_Graphique
{
    partial class Popupedit
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btexit = new Button();
            lbresult = new Label();
            btok = new Button();
            tbsearch = new TextBox();
            lbsearch = new Label();
            tbnum = new TextBox();
            lnnum = new Label();
            tbprenom = new TextBox();
            lbname = new Label();
            tbnom = new TextBox();
            lbnameclient = new Label();
            btsave = new Button();
            SuspendLayout();
            // 
            // btexit
            // 
            btexit.Location = new Point(42, 312);
            btexit.Name = "btexit";
            btexit.Size = new Size(94, 29);
            btexit.TabIndex = 24;
            btexit.Text = "retour";
            btexit.UseVisualStyleBackColor = true;
            btexit.Click += btexit_Click;
            // 
            // lbresult
            // 
            lbresult.AutoSize = true;
            lbresult.Location = new Point(42, 139);
            lbresult.Name = "lbresult";
            lbresult.Size = new Size(0, 20);
            lbresult.TabIndex = 23;
            // 
            // btok
            // 
            btok.Location = new Point(195, 105);
            btok.Name = "btok";
            btok.Size = new Size(94, 29);
            btok.TabIndex = 22;
            btok.Text = "Ok";
            btok.UseVisualStyleBackColor = true;
            btok.Click += btok_Click;
            // 
            // tbsearch
            // 
            tbsearch.Location = new Point(42, 105);
            tbsearch.Name = "tbsearch";
            tbsearch.Size = new Size(147, 27);
            tbsearch.TabIndex = 21;
            // 
            // lbsearch
            // 
            lbsearch.AutoSize = true;
            lbsearch.Location = new Point(42, 50);
            lbsearch.Name = "lbsearch";
            lbsearch.Size = new Size(235, 20);
            lbsearch.TabIndex = 20;
            lbsearch.Text = "Saisir le nom du client a modifier :";
            // 
            // tbnum
            // 
            tbnum.Location = new Point(552, 231);
            tbnum.Margin = new Padding(3, 4, 3, 4);
            tbnum.Name = "tbnum";
            tbnum.Size = new Size(194, 27);
            tbnum.TabIndex = 30;
            // 
            // lnnum
            // 
            lnnum.AutoSize = true;
            lnnum.Location = new Point(552, 192);
            lnnum.Name = "lnnum";
            lnnum.Size = new Size(135, 20);
            lnnum.TabIndex = 29;
            lnnum.Text = "Numéro du client : ";
            // 
            // tbprenom
            // 
            tbprenom.Location = new Point(291, 231);
            tbprenom.Margin = new Padding(3, 4, 3, 4);
            tbprenom.Name = "tbprenom";
            tbprenom.Size = new Size(194, 27);
            tbprenom.TabIndex = 28;
            // 
            // lbname
            // 
            lbname.AutoSize = true;
            lbname.Location = new Point(291, 192);
            lbname.Name = "lbname";
            lbname.Size = new Size(128, 20);
            lbname.TabIndex = 27;
            lbname.Text = "Prenom du client :";
            // 
            // tbnom
            // 
            tbnom.Location = new Point(42, 231);
            tbnom.Margin = new Padding(3, 4, 3, 4);
            tbnom.Name = "tbnom";
            tbnom.Size = new Size(194, 27);
            tbnom.TabIndex = 26;
            // 
            // lbnameclient
            // 
            lbnameclient.AutoSize = true;
            lbnameclient.Location = new Point(42, 192);
            lbnameclient.Name = "lbnameclient";
            lbnameclient.Size = new Size(110, 20);
            lbnameclient.TabIndex = 25;
            lbnameclient.Text = "Nom du client :";
            // 
            // btsave
            // 
            btsave.Location = new Point(168, 312);
            btsave.Margin = new Padding(3, 4, 3, 4);
            btsave.Name = "btsave";
            btsave.Size = new Size(86, 31);
            btsave.TabIndex = 31;
            btsave.Text = "Enregistrer";
            btsave.UseVisualStyleBackColor = true;
            btsave.Click += btsave_Click;
            // 
            // Popupedit
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btsave);
            Controls.Add(tbnum);
            Controls.Add(lnnum);
            Controls.Add(tbprenom);
            Controls.Add(lbname);
            Controls.Add(tbnom);
            Controls.Add(lbnameclient);
            Controls.Add(btexit);
            Controls.Add(lbresult);
            Controls.Add(btok);
            Controls.Add(tbsearch);
            Controls.Add(lbsearch);
            Name = "Popupedit";
            Text = "Popupedit";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btexit;
        private Label lbresult;
        private Button btok;
        private TextBox tbsearch;
        private Label lbsearch;
        private TextBox tbnum;
        private Label lnnum;
        private TextBox tbprenom;
        private Label lbname;
        private TextBox tbnom;
        private Label lbnameclient;
        private Button btsave;
    }
}