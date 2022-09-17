
namespace Dosya_Duzenleme.Presentation
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.dosyaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kaydetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.çıkışToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dosyaAçToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.düzenleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.uzantılaraGöreKlasörleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.çöpKutusunaTaşıToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.dosyaDüzenleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.açıklamaEkleToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.geçerlilikSüresiEkleToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.anaKlasöreGitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.flpDosyaListesi = new System.Windows.Forms.FlowLayoutPanel();
            this.çöpKutusunaTaşıToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.White;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dosyaToolStripMenuItem,
            this.düzenleToolStripMenuItem,
            this.dosyaDüzenleToolStripMenuItem,
            this.anaKlasöreGitToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(844, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // dosyaToolStripMenuItem
            // 
            this.dosyaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.kaydetToolStripMenuItem,
            this.çıkışToolStripMenuItem,
            this.dosyaAçToolStripMenuItem});
            this.dosyaToolStripMenuItem.Name = "dosyaToolStripMenuItem";
            this.dosyaToolStripMenuItem.Size = new System.Drawing.Size(51, 20);
            this.dosyaToolStripMenuItem.Text = "Dosya";
            // 
            // kaydetToolStripMenuItem
            // 
            this.kaydetToolStripMenuItem.Image = global::Dosya_Duzenleme.Presentation.Properties.Resources.icons8_save_64;
            this.kaydetToolStripMenuItem.Name = "kaydetToolStripMenuItem";
            this.kaydetToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.kaydetToolStripMenuItem.Text = "Kaydet";
            this.kaydetToolStripMenuItem.Click += new System.EventHandler(this.BtnKaydet_Click);
            // 
            // çıkışToolStripMenuItem
            // 
            this.çıkışToolStripMenuItem.Image = global::Dosya_Duzenleme.Presentation.Properties.Resources.icons8_opened_folder_64;
            this.çıkışToolStripMenuItem.Name = "çıkışToolStripMenuItem";
            this.çıkışToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.çıkışToolStripMenuItem.Text = "Çıkış";
            this.çıkışToolStripMenuItem.Click += new System.EventHandler(this.BtnÇıkış_Click);
            // 
            // dosyaAçToolStripMenuItem
            // 
            this.dosyaAçToolStripMenuItem.Image = global::Dosya_Duzenleme.Presentation.Properties.Resources.icons8_add_folder_64;
            this.dosyaAçToolStripMenuItem.Name = "dosyaAçToolStripMenuItem";
            this.dosyaAçToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.dosyaAçToolStripMenuItem.Text = "Dosya Aç";
            // 
            // düzenleToolStripMenuItem
            // 
            this.düzenleToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.uzantılaraGöreKlasörleToolStripMenuItem,
            this.çöpKutusunaTaşıToolStripMenuItem1});
            this.düzenleToolStripMenuItem.Name = "düzenleToolStripMenuItem";
            this.düzenleToolStripMenuItem.Size = new System.Drawing.Size(96, 20);
            this.düzenleToolStripMenuItem.Text = "Klasör Düzenle";
            // 
            // uzantılaraGöreKlasörleToolStripMenuItem
            // 
            this.uzantılaraGöreKlasörleToolStripMenuItem.Image = global::Dosya_Duzenleme.Presentation.Properties.Resources.icons8_text_64;
            this.uzantılaraGöreKlasörleToolStripMenuItem.Name = "uzantılaraGöreKlasörleToolStripMenuItem";
            this.uzantılaraGöreKlasörleToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
            this.uzantılaraGöreKlasörleToolStripMenuItem.Text = "Uzantılara Göre Klasörle";
            this.uzantılaraGöreKlasörleToolStripMenuItem.Click += new System.EventHandler(this.BtnUzantılaraGöreKlasörle_Click);
            // 
            // çöpKutusunaTaşıToolStripMenuItem1
            // 
            this.çöpKutusunaTaşıToolStripMenuItem1.Image = global::Dosya_Duzenleme.Presentation.Properties.Resources.icons8_recycle_bin_64;
            this.çöpKutusunaTaşıToolStripMenuItem1.Name = "çöpKutusunaTaşıToolStripMenuItem1";
            this.çöpKutusunaTaşıToolStripMenuItem1.Size = new System.Drawing.Size(198, 22);
            this.çöpKutusunaTaşıToolStripMenuItem1.Text = "Çöp Kutusuna Taşı";
            this.çöpKutusunaTaşıToolStripMenuItem1.Click += new System.EventHandler(this.BtnÇöpKutusunaTaşı_Click);
            // 
            // dosyaDüzenleToolStripMenuItem
            // 
            this.dosyaDüzenleToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.açıklamaEkleToolStripMenuItem1,
            this.geçerlilikSüresiEkleToolStripMenuItem1});
            this.dosyaDüzenleToolStripMenuItem.Name = "dosyaDüzenleToolStripMenuItem";
            this.dosyaDüzenleToolStripMenuItem.Size = new System.Drawing.Size(96, 20);
            this.dosyaDüzenleToolStripMenuItem.Text = "Dosya Düzenle";
            // 
            // açıklamaEkleToolStripMenuItem1
            // 
            this.açıklamaEkleToolStripMenuItem1.Image = global::Dosya_Duzenleme.Presentation.Properties.Resources.icons8_text_64;
            this.açıklamaEkleToolStripMenuItem1.Name = "açıklamaEkleToolStripMenuItem1";
            this.açıklamaEkleToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.açıklamaEkleToolStripMenuItem1.Text = "Açıklama Ekle";
            this.açıklamaEkleToolStripMenuItem1.Click += new System.EventHandler(this.BtnAçıklamaEkle_Click);
            // 
            // geçerlilikSüresiEkleToolStripMenuItem1
            // 
            this.geçerlilikSüresiEkleToolStripMenuItem1.Image = global::Dosya_Duzenleme.Presentation.Properties.Resources.icons8_date_64;
            this.geçerlilikSüresiEkleToolStripMenuItem1.Name = "geçerlilikSüresiEkleToolStripMenuItem1";
            this.geçerlilikSüresiEkleToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.geçerlilikSüresiEkleToolStripMenuItem1.Text = "Geçerlilik Süresi Ekle";
            this.geçerlilikSüresiEkleToolStripMenuItem1.Click += new System.EventHandler(this.BtnGeçerlilikSüresiEkle_Click);
            // 
            // anaKlasöreGitToolStripMenuItem
            // 
            this.anaKlasöreGitToolStripMenuItem.Name = "anaKlasöreGitToolStripMenuItem";
            this.anaKlasöreGitToolStripMenuItem.Size = new System.Drawing.Size(99, 20);
            this.anaKlasöreGitToolStripMenuItem.Text = "Ana Klasöre Git";
            this.anaKlasöreGitToolStripMenuItem.Click += new System.EventHandler(this.BtnAnaKlasöreGit_Click);
            // 
            // flpDosyaListesi
            // 
            this.flpDosyaListesi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpDosyaListesi.Location = new System.Drawing.Point(0, 24);
            this.flpDosyaListesi.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.flpDosyaListesi.Name = "flpDosyaListesi";
            this.flpDosyaListesi.Size = new System.Drawing.Size(844, 456);
            this.flpDosyaListesi.TabIndex = 2;
            // 
            // çöpKutusunaTaşıToolStripMenuItem
            // 
            this.çöpKutusunaTaşıToolStripMenuItem.Image = global::Dosya_Duzenleme.Presentation.Properties.Resources.icons8_recycle_bin_64;
            this.çöpKutusunaTaşıToolStripMenuItem.Name = "çöpKutusunaTaşıToolStripMenuItem";
            this.çöpKutusunaTaşıToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
            this.çöpKutusunaTaşıToolStripMenuItem.Text = "Çöp Kutusuna Taşı";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(32, 19);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(844, 480);
            this.Controls.Add(this.flpDosyaListesi);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmMain";
            this.Text = "Dosya Düzenleme Programı";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem dosyaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem kaydetToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem çıkışToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem düzenleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem uzantılaraGöreKlasörleToolStripMenuItem;
        private System.Windows.Forms.FlowLayoutPanel flpDosyaListesi;
        private System.Windows.Forms.ToolStripMenuItem anaKlasöreGitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem çöpKutusunaTaşıToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem dosyaAçToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem çöpKutusunaTaşıToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem dosyaDüzenleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem açıklamaEkleToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem geçerlilikSüresiEkleToolStripMenuItem1;
    }
}