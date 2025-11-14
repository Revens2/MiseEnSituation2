namespace Mise_en_Situation_Graphique
{
    partial class popuprecuperclient
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
            btyes = new Button();
            lbrecuperer = new Label();
            SuspendLayout();
            // 
            // btexit
            // 
            btexit.Location = new Point(46, 182);
            btexit.Margin = new Padding(3, 2, 3, 2);
            btexit.Name = "btexit";
            btexit.Size = new Size(82, 22);
            btexit.TabIndex = 9;
            btexit.Text = "retour";
            btexit.UseVisualStyleBackColor = true;
            btexit.Click += btexit_Click;
            // 
            // lbresult
            // 
            lbresult.AutoSize = true;
            lbresult.Location = new Point(53, 113);
            lbresult.Name = "lbresult";
            lbresult.Size = new Size(0, 15);
            lbresult.TabIndex = 8;
            // 
            // btok
            // 
            btok.Location = new Point(187, 88);
            btok.Margin = new Padding(3, 2, 3, 2);
            btok.Name = "btok";
            btok.Size = new Size(82, 22);
            btok.TabIndex = 7;
            btok.Text = "Ok";
            btok.UseVisualStyleBackColor = true;
            btok.Click += btok_Click;
            // 
            // tbsearch
            // 
            tbsearch.Location = new Point(53, 88);
            tbsearch.Margin = new Padding(3, 2, 3, 2);
            tbsearch.Name = "tbsearch";
            tbsearch.Size = new Size(129, 23);
            tbsearch.TabIndex = 6;
            // 
            // lbsearch
            // 
            lbsearch.AutoSize = true;
            lbsearch.Location = new Point(53, 57);
            lbsearch.Name = "lbsearch";
            lbsearch.Size = new Size(191, 15);
            lbsearch.TabIndex = 5;
            lbsearch.Text = "Saisir le nom du client a recuperer :";
            // 
            // btyes
            // 
            btyes.Location = new Point(152, 181);
            btyes.Name = "btyes";
            btyes.Size = new Size(75, 23);
            btyes.TabIndex = 11;
            btyes.Text = "Oui";
            btyes.UseVisualStyleBackColor = true;
            btyes.Click += btyes_Click;
            // 
            // lbrecuperer
            // 
            lbrecuperer.AutoSize = true;
            lbrecuperer.Location = new Point(46, 152);
            lbrecuperer.Name = "lbrecuperer";
            lbrecuperer.Size = new Size(152, 15);
            lbrecuperer.TabIndex = 12;
            lbrecuperer.Text = "Voulez recuperer ce client ? ";
            // 
            // popuprecuperclient
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(559, 278);
            Controls.Add(lbrecuperer);
            Controls.Add(btyes);
            Controls.Add(btexit);
            Controls.Add(lbresult);
            Controls.Add(btok);
            Controls.Add(tbsearch);
            Controls.Add(lbsearch);
            Name = "popuprecuperclient";
            Text = "popuprecuperclient";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btexit;
        private Label lbresult;
        private Button btok;
        private TextBox tbsearch;
        private Label lbsearch;
        private Button btyes;
        private Label lbrecuperer;
    }
}