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
    }
}
