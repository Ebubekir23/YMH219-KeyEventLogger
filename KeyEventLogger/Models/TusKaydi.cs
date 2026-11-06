namespace KeyEventLogger.Models
{
    // Tek bir klavye olayını temsil eder. Oluşturulduktan sonra değiştirilemez.
    public class TusKaydi
    {
        public DateTime Zaman { get; }
        public string TusAdi { get; }
        public string OlayTuru { get; } // "KeyDown" veya "KeyUp"

        public TusKaydi(DateTime zaman, string tusAdi, string olayTuru)
        {
            Zaman = zaman;
            TusAdi = tusAdi;
            OlayTuru = olayTuru;
        }

        // Hem ekranda hem dosyada aynı kayıt biçimi kullanılır
        public override string ToString()
        {
            return $"[{Zaman:yyyy-MM-dd HH:mm:ss.fff}] {OlayTuru,-7} {TusAdi}";
        }
    }
}
