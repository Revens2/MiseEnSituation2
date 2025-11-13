namespace Mise_en_Situation_Graphique
{
    partial class popupnbclient
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
            btretour = new Button();
            lbcompresse = new Label();
            lbnb = new Label();
            SuspendLayout();
            // 
            // btretour
            // 
            btretour.Font = new Font("Segoe UI", 11F);
            btretour.Location = new Point(153, 159);
            btretour.Margin = new Padding(3, 2, 3, 2);
            btretour.Name = "btretour";
            btretour.Size = new Size(116, 35);
            btretour.TabIndex = 8;
            btretour.Text = "retour";
            btretour.UseVisualStyleBackColor = true;
            btretour.Click += btretour_Click;
            // 
            // lbcompresse
            // 
            lbcompresse.AutoSize = true;
            lbcompresse.Font = new Font("Segoe UI", 10F);
            lbcompresse.Location = new Point(91, 88);
            lbcompresse.Name = "lbcompresse";
            lbcompresse.Size = new Size(178, 19);
            lbcompresse.TabIndex = 7;
            lbcompresse.Text = "Le nombre de client est de :";
            // 
            // lbnb
            // 
            lbnb.AutoSize = true;
            lbnb.Font = new Font("Segoe UI", 10F);
            lbnb.Location = new Point(287, 88);
            lbnb.Name = "lbnb";
            lbnb.Size = new Size(45, 19);
            lbnb.TabIndex = 10;
            lbnb.Text = "label2";
            // 
            // popupnbclient
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(439, 291);
            Controls.Add(lbnb);
            Controls.Add(btretour);
            Controls.Add(lbcompresse);
            Name = "popupnbclient";
            Text = "popupnbclient";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btretour;
        private Label lbcompresse;
        private Label lbnb;
    }
}