namespace KeyEventLogger.Models
{
    // Kayıt durumunu ve toplanan kayıtları yönetir. Arayüzden bağımsızdır.
    public class KayitOturumu
    {
        private readonly List<TusKaydi> kayitlar = new List<TusKaydi>();

        public bool KayitAktif { get; private set; }

        public IReadOnlyList<TusKaydi> Kayitlar
        {
            get { return kayitlar; }
        }

        public void Baslat()
        {
            KayitAktif = true;
        }

        public void Durdur()
        {
            KayitAktif = false;
        }

        // Kayıt kapalıyken gelen olaylar eklenmez; sonuç bu durumu çağırana bildirir
        public bool Ekle(TusKaydi kayit)
        {
            if (!KayitAktif)
                return false;

            kayitlar.Add(kayit);
            return true;
        }

        public void Temizle()
        {
            kayitlar.Clear();
        }

        // İstatistiklerde yalnızca basma olayları sayılır (KeyUp aynı tuşu iki kez saydırmasın)
        public int ToplamBasma()
        {
            int sayac = 0;
            foreach (TusKaydi kayit in kayitlar)
                if (kayit.OlayTuru == "KeyDown")
                    sayac++;
            return sayac;
        }

        // En sık basılan tuşları, çoktan aza sıralı olarak döndürür
        public List<KeyValuePair<string, int>> EnSikTuslar(int adet)
        {
            Dictionary<string, int> sayilar = new Dictionary<string, int>();
            foreach (TusKaydi kayit in kayitlar)
            {
                if (kayit.OlayTuru != "KeyDown")
                    continue;
                sayilar.TryGetValue(kayit.TusAdi, out int mevcut);
                sayilar[kayit.TusAdi] = mevcut + 1;
            }

            List<KeyValuePair<string, int>> sirali = new List<KeyValuePair<string, int>>(sayilar);
            sirali.Sort((a, b) => b.Value.CompareTo(a.Value));
            return sirali.GetRange(0, Math.Min(adet, sirali.Count));
        }
    }
}
