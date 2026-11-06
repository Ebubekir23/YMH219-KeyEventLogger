using System.Runtime.InteropServices;

namespace KeyEventLogger.Services
{
    // KeyEventArgs bilgisini ekranda okunabilir bir tuş adına çevirir (ör. "Ctrl+A", "Ş", "Enter")
    public static class TusAdiCozucu
    {
        private const uint VkToChar = 2; // MAPVK_VK_TO_CHAR

        // Etkin klavye düzenine göre tuşun karakterini verir (Türkçe Ş, Ğ, Ü gibi Oem tuşları için)
        [DllImport("user32.dll")]
        private static extern uint MapVirtualKey(uint kod, uint harita);

        public static string Coz(KeyEventArgs e)
        {
            string tus = TekTusAdi(e.KeyCode);

            if (DegistiriciMi(e.KeyCode))
                return tus;

            string onEk = "";
            if (e.Control) onEk += "Ctrl+";
            if (e.Alt) onEk += "Alt+";
            if (e.Shift) onEk += "Shift+";
            return onEk + tus;
        }

        private static bool DegistiriciMi(Keys tus)
        {
            return tus == Keys.ControlKey || tus == Keys.ShiftKey || tus == Keys.Menu;
        }

        private static string TekTusAdi(Keys tus)
        {
            switch (tus)
            {
                case Keys.ControlKey: return "Ctrl";
                case Keys.ShiftKey: return "Shift";
                case Keys.Menu: return "Alt";
                case Keys.Return: return "Enter";
                case Keys.Back: return "Backspace";
                case Keys.Space: return "Boşluk";
                case Keys.Escape: return "Esc";
                case Keys.Capital: return "CapsLock";
                case Keys.Next: return "PageDown";
            }

            // Sayı satırı: D0..D9 -> 0..9
            if (tus >= Keys.D0 && tus <= Keys.D9)
                return ((int)(tus - Keys.D0)).ToString();

            // Noktalama ve Türkçe harf tuşları (Oem...) için klavye düzenine bak
            if (tus.ToString().StartsWith("Oem"))
            {
                uint karakter = MapVirtualKey((uint)tus, VkToChar) & 0x7FFF;
                if (karakter != 0)
                    return ((char)karakter).ToString();
            }

            return tus.ToString();
        }
    }
}
