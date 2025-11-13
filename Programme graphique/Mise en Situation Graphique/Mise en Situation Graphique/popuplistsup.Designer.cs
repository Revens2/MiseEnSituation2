namespace Mise_en_Situation_Graphique
{
    partial class popuplistsup
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
            lbtitle = new Label();
            gvlist = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)gvlist).BeginInit();
            SuspendLayout();
            // 
            // btexit
            // 
            btexit.Location = new Point(70, 347);
            btexit.Name = "btexit";
            btexit.Size = new Size(94, 29);
            btexit.TabIndex = 8;
            btexit.Text = "retour";
            btexit.UseVisualStyleBackColor = true;
            // 
            // lbtitle
            // 
            lbtitle.AutoSize = true;
            lbtitle.Location = new Point(70, 74);
            lbtitle.Name = "lbtitle";
            lbtitle.Size = new Size(195, 20);
            lbtitle.TabIndex = 7;
            lbtitle.Text = "Liste des supprimés clients : ";
            // 
            // gvlist
            // 
            gvlist.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gvlist.Location = new Point(70, 122);
            gvlist.Name = "gvlist";
            gvlist.RowHeadersWidth = 51;
            gvlist.Size = new Size(661, 188);
            gvlist.TabIndex = 6;
            // 
            // popuplistsup
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btexit);
            Controls.Add(lbtitle);
            Controls.Add(gvlist);
            Name = "popuplistsup";
            Text = "popuplistsup";
            ((System.ComponentModel.ISupportInitialize)gvlist).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btexit;
        private Label lbtitle;
        private DataGridView gvlist;
    }
}