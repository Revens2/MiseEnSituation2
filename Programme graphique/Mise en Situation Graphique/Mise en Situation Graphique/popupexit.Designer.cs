namespace Mise_en_Situation_Graphique
{
    partial class popupexit
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
            lbexit = new Label();
            btyes = new Button();
            btno = new Button();
            SuspendLayout();
            // 
            // lbexit
            // 
            lbexit.AutoSize = true;
            lbexit.Font = new Font("Segoe UI", 15F);
            lbexit.Location = new Point(174, 50);
            lbexit.Name = "lbexit";
            lbexit.Size = new Size(454, 35);
            lbexit.TabIndex = 0;
            lbexit.Text = "Voulre vraiment quitter le programme ?";
            // 
            // btyes
            // 
            btyes.Font = new Font("Segoe UI", 11F);
            btyes.Location = new Point(478, 165);
            btyes.Name = "btyes";
            btyes.Size = new Size(132, 47);
            btyes.TabIndex = 2;
            btyes.Text = "Oui";
            btyes.UseVisualStyleBackColor = true;
            btyes.Click += btyes_Click;
            // 
            // btno
            // 
            btno.Font = new Font("Segoe UI", 11F);
            btno.Location = new Point(202, 165);
            btno.Name = "btno";
            btno.Size = new Size(132, 47);
            btno.TabIndex = 3;
            btno.Text = "Non";
            btno.UseVisualStyleBackColor = true;
            btno.Click += btno_Click;
            // 
            // popupexit
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btno);
            Controls.Add(btyes);
            Controls.Add(lbexit);
            Name = "popupexit";
            Text = "popupexit";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lbexit;
        private Button btyes;
        private Button btno;
    }
}