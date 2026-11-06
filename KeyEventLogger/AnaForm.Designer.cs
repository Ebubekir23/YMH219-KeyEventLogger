namespace KeyEventLogger
{
    partial class AnaForm
    {
        private System.ComponentModel.IContainer components = null!;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            btnBaslat = new Button();
            btnDurdur = new Button();
            btnTemizle = new Button();
            btnKaydet = new Button();
            lblDurum = new Label();
            chkKeyUp = new CheckBox();
            lstKayitlar = new ListBox();
            lblBilgi = new Label();
            SuspendLayout();
            //
            // btnBaslat
            //
            btnBaslat.Location = new Point(12, 12);
            btnBaslat.Name = "btnBaslat";
            btnBaslat.Size = new Size(100, 36);
            btnBaslat.TabIndex = 0;
            btnBaslat.Text = "Başlat";
            btnBaslat.UseVisualStyleBackColor = true;
            btnBaslat.Click += btnBaslat_Click;
            //
            // btnDurdur
            //
            btnDurdur.Location = new Point(118, 12);
            btnDurdur.Name = "btnDurdur";
            btnDurdur.Size = new Size(100, 36);
            btnDurdur.TabIndex = 1;
            btnDurdur.Text = "Durdur";
            btnDurdur.UseVisualStyleBackColor = true;
            btnDurdur.Click += btnDurdur_Click;
            //
            // btnTemizle
            //
            btnTemizle.Location = new Point(224, 12);
            btnTemizle.Name = "btnTemizle";
            btnTemizle.Size = new Size(100, 36);
            btnTemizle.TabIndex = 2;
            btnTemizle.Text = "Temizle";
            btnTemizle.UseVisualStyleBackColor = true;
            btnTemizle.Click += btnTemizle_Click;
            //
            // btnKaydet
            //
            btnKaydet.Location = new Point(330, 12);
            btnKaydet.Name = "btnKaydet";
            btnKaydet.Size = new Size(120, 36);
            btnKaydet.TabIndex = 7;
            btnKaydet.Text = "Dosyaya Kaydet";
            btnKaydet.UseVisualStyleBackColor = true;
            btnKaydet.Click += btnKaydet_Click;
            //
            // lblDurum
            //
            lblDurum.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblDurum.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblDurum.ForeColor = Color.White;
            lblDurum.Location = new Point(556, 12);
            lblDurum.Name = "lblDurum";
            lblDurum.Size = new Size(212, 36);
            lblDurum.TabIndex = 3;
            lblDurum.TextAlign = ContentAlignment.MiddleCenter;
            //
            // chkKeyUp
            //
            chkKeyUp.AutoSize = true;
            chkKeyUp.Location = new Point(12, 56);
            chkKeyUp.Name = "chkKeyUp";
            chkKeyUp.TabIndex = 4;
            chkKeyUp.Text = "Tuş bırakma (KeyUp) olaylarını da göster";
            chkKeyUp.UseVisualStyleBackColor = true;
            //
            // lstKayitlar
            //
            lstKayitlar.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lstKayitlar.Font = new Font("Consolas", 10F);
            lstKayitlar.IntegralHeight = false;
            lstKayitlar.Location = new Point(12, 88);
            lstKayitlar.Name = "lstKayitlar";
            lstKayitlar.Size = new Size(756, 400);
            lstKayitlar.TabIndex = 5;
            //
            // lblBilgi
            //
            lblBilgi.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lblBilgi.ForeColor = Color.DimGray;
            lblBilgi.Location = new Point(12, 494);
            lblBilgi.Name = "lblBilgi";
            lblBilgi.Size = new Size(756, 24);
            lblBilgi.TabIndex = 6;
            lblBilgi.Text = "Yalnızca bu pencere odaktayken basılan tuşlar kaydedilir. Başka uygulamalardan veri toplanmaz.";
            //
            // AnaForm
            //
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(780, 528);
            Controls.Add(lblBilgi);
            Controls.Add(lstKayitlar);
            Controls.Add(chkKeyUp);
            Controls.Add(lblDurum);
            Controls.Add(btnKaydet);
            Controls.Add(btnTemizle);
            Controls.Add(btnDurdur);
            Controls.Add(btnBaslat);
            KeyPreview = true;
            MinimumSize = new Size(640, 400);
            Name = "AnaForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Key Event Logger (Eğitsel)";
            Deactivate += AnaForm_Deactivate;
            KeyDown += AnaForm_KeyDown;
            KeyUp += AnaForm_KeyUp;
            ResumeLayout(false);
            PerformLayout();
        }

        private Button btnBaslat = null!;
        private Button btnDurdur = null!;
        private Button btnTemizle = null!;
        private Button btnKaydet = null!;
        private Label lblDurum = null!;
        private CheckBox chkKeyUp = null!;
        private ListBox lstKayitlar = null!;
        private Label lblBilgi = null!;
    }
}
