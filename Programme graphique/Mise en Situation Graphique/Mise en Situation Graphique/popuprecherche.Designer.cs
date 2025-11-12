namespace Mise_en_Situation_Graphique
{
    partial class popuprecherche
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
            lbsearch = new Label();
            tbsearch = new TextBox();
            btok = new Button();
            lbresult = new Label();
            btexit = new Button();
            SuspendLayout();
            // 
            // lbsearch
            // 
            lbsearch.AutoSize = true;
            lbsearch.Location = new Point(25, 55);
            lbsearch.Name = "lbsearch";
            lbsearch.Size = new Size(247, 20);
            lbsearch.TabIndex = 0;
            lbsearch.Text = "Saisir le nom du client a rechercher :";
            // 
            // tbsearch
            // 
            tbsearch.Location = new Point(25, 96);
            tbsearch.Name = "tbsearch";
            tbsearch.Size = new Size(147, 27);
            tbsearch.TabIndex = 1;
            // 
            // btok
            // 
            btok.Location = new Point(178, 96);
            btok.Name = "btok";
            btok.Size = new Size(94, 29);
            btok.TabIndex = 2;
            btok.Text = "Ok";
            btok.UseVisualStyleBackColor = true;
            btok.Click += btok_Click;
            // 
            // lbresult
            // 
            lbresult.AutoSize = true;
            lbresult.Location = new Point(25, 159);
            lbresult.Name = "lbresult";
            lbresult.Size = new Size(0, 20);
            lbresult.TabIndex = 3;
            // 
            // btexit
            // 
            btexit.Location = new Point(25, 201);
            btexit.Name = "btexit";
            btexit.Size = new Size(94, 29);
            btexit.TabIndex = 4;
            btexit.Text = "retour";
            btexit.UseVisualStyleBackColor = true;
            btexit.Click += btexit_Click;
            // 
            // popuprecherche
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btexit);
            Controls.Add(lbresult);
            Controls.Add(btok);
            Controls.Add(tbsearch);
            Controls.Add(lbsearch);
            Name = "popuprecherche";
            Text = "popuprecherche";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lbsearch;
        private TextBox tbsearch;
        private Button btok;
        private Label lbresult;
        private Button btexit;
    }
}