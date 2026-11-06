using KeyEventLogger.Models;

namespace KeyEventLogger.Services
{
    // Kayıtları yalnızca kullanıcının seçtiği yerel metin dosyasına yazar
    public static class DosyaKaydedici
    {
        public static void Kaydet(string dosyaYolu, IEnumerable<TusKaydi> kayitlar)
        {
            using (StreamWriter yazici = new StreamWriter(dosyaYolu, false, System.Text.Encoding.UTF8))
            {
                foreach (TusKaydi kayit in kayitlar)
                    yazici.WriteLine(kayit);
            }
        }
    }
}
