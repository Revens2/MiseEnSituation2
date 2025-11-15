namespace Mise_en_Situation_Graphique
{
    partial class popupsupp
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
            lbrecuperer = new Label();
            btyes = new Button();
            btexit = new Button();
            lbresult = new Label();
            btok = new Button();
            tbsearch = new TextBox();
            lbsearch = new Label();
            SuspendLayout();
            // 
            // lbrecuperer
            // 
            lbrecuperer.AutoSize = true;
            lbrecuperer.Location = new Point(61, 226);
            lbrecuperer.Name = "lbrecuperer";
            lbrecuperer.Size = new Size(198, 20);
            lbrecuperer.TabIndex = 19;
            lbrecuperer.Text = "Voulez supprimer ce client ? ";
            // 
            // btyes
            // 
            btyes.Location = new Point(182, 264);
            btyes.Margin = new Padding(3, 4, 3, 4);
            btyes.Name = "btyes";
            btyes.Size = new Size(86, 31);
            btyes.TabIndex = 18;
            btyes.Text = "Oui";
            btyes.UseVisualStyleBackColor = true;
            btyes.Click += btyes_Click;
            // 
            // btexit
            // 
            btexit.Location = new Point(61, 266);
            btexit.Name = "btexit";
            btexit.Size = new Size(94, 29);
            btexit.TabIndex = 17;
            btexit.Text = "retour";
            btexit.UseVisualStyleBackColor = true;
            btexit.Click += btexit_Click;
            // 
            // lbresult
            // 
            lbresult.AutoSize = true;
            lbresult.Location = new Point(69, 174);
            lbresult.Name = "lbresult";
            lbresult.Size = new Size(0, 20);
            lbresult.TabIndex = 16;
            // 
            // btok
            // 
            btok.Location = new Point(222, 140);
            btok.Name = "btok";
            btok.Size = new Size(94, 29);
            btok.TabIndex = 15;
            btok.Text = "Ok";
            btok.UseVisualStyleBackColor = true;
            btok.Click += btok_Click;
            // 
            // tbsearch
            // 
            tbsearch.Location = new Point(69, 140);
            tbsearch.Name = "tbsearch";
            tbsearch.Size = new Size(147, 27);
            tbsearch.TabIndex = 14;
            // 
            // lbsearch
            // 
            lbsearch.AutoSize = true;
            lbsearch.Location = new Point(69, 99);
            lbsearch.Name = "lbsearch";
            lbsearch.Size = new Size(238, 40);
            lbsearch.TabIndex = 13;
            lbsearch.Text = "Saisir le nom du client a supprimer\r\n :";
            // 
            // popupsupp
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(lbrecuperer);
            Controls.Add(btyes);
            Controls.Add(btexit);
            Controls.Add(lbresult);
            Controls.Add(btok);
            Controls.Add(tbsearch);
            Controls.Add(lbsearch);
            Name = "popupsupp";
            Text = "popupsupp";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lbrecuperer;
        private Button btyes;
        private Button btexit;
        private Label lbresult;
        private Button btok;
        private TextBox tbsearch;
        private Label lbsearch;
    }
}