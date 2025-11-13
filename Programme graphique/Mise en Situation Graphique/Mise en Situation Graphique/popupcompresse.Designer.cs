namespace Mise_en_Situation_Graphique
{
    partial class popupcompresse
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
            btno = new Button();
            btyes = new Button();
            lbcompresse = new Label();
            SuspendLayout();
            // 
            // btno
            // 
            btno.Font = new Font("Segoe UI", 11F);
            btno.Location = new Point(156, 187);
            btno.Margin = new Padding(3, 2, 3, 2);
            btno.Name = "btno";
            btno.Size = new Size(116, 35);
            btno.TabIndex = 6;
            btno.Text = "annuler";
            btno.UseVisualStyleBackColor = true;
            btno.Click += btno_Click;
            // 
            // btyes
            // 
            btyes.Font = new Font("Segoe UI", 11F);
            btyes.Location = new Point(397, 187);
            btyes.Margin = new Padding(3, 2, 3, 2);
            btyes.Name = "btyes";
            btyes.Size = new Size(116, 35);
            btyes.TabIndex = 5;
            btyes.Text = "confirmer";
            btyes.UseVisualStyleBackColor = true;
            btyes.Click += btyes_Click;
            // 
            // lbcompresse
            // 
            lbcompresse.AutoSize = true;
            lbcompresse.Font = new Font("Segoe UI", 15F);
            lbcompresse.Location = new Point(58, 104);
            lbcompresse.Name = "lbcompresse";
            lbcompresse.Size = new Size(582, 28);
            lbcompresse.TabIndex = 4;
            lbcompresse.Text = "Vous allez compresser le fichier (cette action n'est pas revercible !)";
            // 
            // popupcompresse
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(682, 354);
            Controls.Add(btno);
            Controls.Add(btyes);
            Controls.Add(lbcompresse);
            Name = "popupcompresse";
            Text = "popupcompresse";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btno;
        private Button btyes;
        private Label lbcompresse;
    }
}