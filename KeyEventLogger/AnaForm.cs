using KeyEventLogger.Models;
using KeyEventLogger.Services;

namespace KeyEventLogger
{
    public partial class AnaForm : Form
    {
        private readonly KayitOturumu oturum = new KayitOturumu();

        // Basılı tutulan tuşun tekrar eden KeyDown olaylarını tek kayıt saymak için
        private readonly HashSet<Keys> basiliTuslar = new HashSet<Keys>();

        public AnaForm()
        {
            InitializeComponent();
            TuslariFormaYonlendir(this);
            ArayuzuGuncelle();
        }

        // Kayıt sırasında Tab, Enter ve ok tuşları odaklı butonu tetiklemesin, KeyDown olayına gelsin
        private void TuslariFormaYonlendir(Control ana)
        {
            foreach (Control kontrol in ana.Controls)
            {
                kontrol.PreviewKeyDown += (gonderen, e) =>
                {
                    if (oturum.KayitAktif)
                        e.IsInputKey = true;
                };
                TuslariFormaYonlendir(kontrol);
            }
        }

        private void btnBaslat_Click(object? sender, EventArgs e)
        {
            oturum.Baslat();
            ArayuzuGuncelle();
        }

        private void btnDurdur_Click(object? sender, EventArgs e)
        {
            oturum.Durdur();
            basiliTuslar.Clear();
            ArayuzuGuncelle();
        }

        private void btnTemizle_Click(object? sender, EventArgs e)
        {
            oturum.Temizle();
            lstKayitlar.Items.Clear();
            ArayuzuGuncelle();
        }

        private void btnKaydet_Click(object? sender, EventArgs e)
        {
            using (SaveFileDialog pencere = new SaveFileDialog())
            {
                pencere.Filter = "Metin dosyası (*.txt)|*.txt";
                pencere.FileName = $"tus_kayitlari_{DateTime.Now:yyyyMMdd_HHmmss}.txt";

                if (pencere.ShowDialog(this) != DialogResult.OK)
                    return;

                try
                {
                    DosyaKaydedici.Kaydet(pencere.FileName, oturum.Kayitlar);
                    MessageBox.Show(this, $"{oturum.Kayitlar.Count} kayıt dosyaya yazıldı.", "Kaydedildi",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception hata) when (hata is IOException || hata is UnauthorizedAccessException)
                {
                    MessageBox.Show(this, $"Dosya kaydedilemedi:\n{hata.Message}", "Hata",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void AnaForm_KeyDown(object? sender, KeyEventArgs e)
        {
            if (!oturum.KayitAktif)
                return;

            // Alt+F4 ile pencere her zaman kapatılabilmeli
            if (e.Alt && e.KeyCode == Keys.F4)
                return;

            e.Handled = true;
            e.SuppressKeyPress = true;

            if (basiliTuslar.Add(e.KeyCode))
                KayitEkle(TusAdiCozucu.Coz(e), "KeyDown");
        }

        private void AnaForm_KeyUp(object? sender, KeyEventArgs e)
        {
            if (!oturum.KayitAktif)
                return;

            e.Handled = true;
            basiliTuslar.Remove(e.KeyCode);

            if (chkKeyUp.Checked)
                KayitEkle(TusAdiCozucu.Coz(e), "KeyUp");
        }

        // Pencere odağı kaybedince KeyUp gelmez; basılı tuş listesi takılı kalmasın
        private void AnaForm_Deactivate(object? sender, EventArgs e)
        {
            basiliTuslar.Clear();
        }

        private void KayitEkle(string tusAdi, string olayTuru)
        {
            TusKaydi kayit = new TusKaydi(DateTime.Now, tusAdi, olayTuru);
            if (!oturum.Ekle(kayit))
                return;

            lstKayitlar.Items.Add(kayit);
            lstKayitlar.TopIndex = lstKayitlar.Items.Count - 1; // son kaydı görünür tut
            ArayuzuGuncelle();
        }

        private void ArayuzuGuncelle()
        {
            btnBaslat.Enabled = !oturum.KayitAktif;
            btnDurdur.Enabled = oturum.KayitAktif;
            btnTemizle.Enabled = oturum.Kayitlar.Count > 0;
            btnKaydet.Enabled = oturum.Kayitlar.Count > 0;

            lblDurum.Text = oturum.KayitAktif ? "● KAYIT AKTİF" : "○ KAYIT DURDU";
            lblDurum.BackColor = oturum.KayitAktif ? Color.Firebrick : Color.DimGray;
        }
    }
}
