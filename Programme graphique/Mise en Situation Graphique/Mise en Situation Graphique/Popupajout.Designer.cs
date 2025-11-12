namespace Mise_en_Situation_Graphique
{
    partial class Popupajout
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
            lbtitleaddclient = new Label();
            lbnameclient = new Label();
            tbnom = new TextBox();
            tbprenom = new TextBox();
            lbname = new Label();
            tbnum = new TextBox();
            lnnum = new Label();
            btsave = new Button();
            SuspendLayout();
            // 
            // lbtitleaddclient
            // 
            lbtitleaddclient.AutoSize = true;
            lbtitleaddclient.Font = new Font("Segoe UI", 15F);
            lbtitleaddclient.Location = new Point(276, 9);
            lbtitleaddclient.Name = "lbtitleaddclient";
            lbtitleaddclient.Size = new Size(188, 28);
            lbtitleaddclient.TabIndex = 0;
            lbtitleaddclient.Text = "Popup d'ajout client";
            // 
            // lbnameclient
            // 
            lbnameclient.AutoSize = true;
            lbnameclient.Location = new Point(-1, 70);
            lbnameclient.Name = "lbnameclient";
            lbnameclient.Size = new Size(170, 15);
            lbnameclient.TabIndex = 1;
            lbnameclient.Text = "Veuillez saisir le nom du client :";
            // 
            // tbnom
            // 
            tbnom.Location = new Point(-1, 99);
            tbnom.Name = "tbnom";
            tbnom.Size = new Size(170, 23);
            tbnom.TabIndex = 2;
            // 
            // tbprenom
            // 
            tbprenom.Location = new Point(294, 99);
            tbprenom.Name = "tbprenom";
            tbprenom.Size = new Size(170, 23);
            tbprenom.TabIndex = 4;
            // 
            // lbname
            // 
            lbname.AutoSize = true;
            lbname.Location = new Point(294, 70);
            lbname.Name = "lbname";
            lbname.Size = new Size(187, 15);
            lbname.TabIndex = 3;
            lbname.Text = "Veuillez saisir le prenom du client :";
            // 
            // tbnum
            // 
            tbnum.Location = new Point(573, 99);
            tbnum.Name = "tbnum";
            tbnum.Size = new Size(170, 23);
            tbnum.TabIndex = 6;
            // 
            // lnnum
            // 
            lnnum.AutoSize = true;
            lnnum.Location = new Point(573, 70);
            lnnum.Name = "lnnum";
            lnnum.Size = new Size(187, 15);
            lnnum.TabIndex = 5;
            lnnum.Text = "Veuillez saisir le numéro du client :";
            // 
            // btsave
            // 
            btsave.Location = new Point(349, 201);
            btsave.Name = "btsave";
            btsave.Size = new Size(75, 23);
            btsave.TabIndex = 7;
            btsave.Text = "Enregistrer";
            btsave.UseVisualStyleBackColor = true;
            btsave.Click += btsave_Click;
            // 
            // Popupajout
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btsave);
            Controls.Add(tbnum);
            Controls.Add(lnnum);
            Controls.Add(tbprenom);
            Controls.Add(lbname);
            Controls.Add(tbnom);
            Controls.Add(lbnameclient);
            Controls.Add(lbtitleaddclient);
            Name = "Popupajout";
            Text = "Popupajout";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lbtitleaddclient;
        private Label lbnameclient;
        private TextBox tbnom;
        private TextBox tbprenom;
        private Label lbname;
        private TextBox tbnum;
        private Label lnnum;
        private Button btsave;
    }
}