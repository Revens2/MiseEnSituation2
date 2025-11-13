namespace Mise_en_Situation_Graphique
{
    partial class popuplistclients
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
            gvlist = new DataGridView();
            lbtitle = new Label();
            btexit = new Button();
            ((System.ComponentModel.ISupportInitialize)gvlist).BeginInit();
            SuspendLayout();
            // 
            // gvlist
            // 
            gvlist.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gvlist.Location = new Point(71, 84);
            gvlist.Name = "gvlist";
            gvlist.RowHeadersWidth = 51;
            gvlist.Size = new Size(661, 188);
            gvlist.TabIndex = 0;
            // 
            // lbtitle
            // 
            lbtitle.AutoSize = true;
            lbtitle.Location = new Point(71, 36);
            lbtitle.Name = "lbtitle";
            lbtitle.Size = new Size(123, 20);
            lbtitle.TabIndex = 1;
            lbtitle.Text = "Liste des clients : ";
            // 
            // btexit
            // 
            btexit.Location = new Point(71, 309);
            btexit.Name = "btexit";
            btexit.Size = new Size(94, 29);
            btexit.TabIndex = 5;
            btexit.Text = "retour";
            btexit.UseVisualStyleBackColor = true;
            btexit.Click += btexit_Click;
            // 
            // popuplistclients
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btexit);
            Controls.Add(lbtitle);
            Controls.Add(gvlist);
            Name = "popuplistclients";
            Text = "popuplistclients";
            ((System.ComponentModel.ISupportInitialize)gvlist).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView gvlist;
        private Label lbtitle;
        private Button btexit;
    }
}