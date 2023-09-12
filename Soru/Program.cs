namespace Soru
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Adım boyu, dakikadaki adım sayısı ve koşu süresi girildiğinde koşu mesafesini hesaplayan uygulama.

            try
            {
                Giriş();
                bool devamMı;
                do
                {
                    int adımBoyuSantimetre = AdımBoyuAl();
                    float adımBoyuMetre = SantimetreyiMetreyeÇevir(adımBoyuSantimetre);
                    int adımSayısı = DakikadakiAdımSayısı();
                    int koşuSüresiSaat = KoşuSüresiSaat();
                    int koşuSüresi = SaatiDakikayaÇevir(koşuSüresiSaat);
                    int koşuSüresiDakika = KoşuSüresiDakika();
                    float koşuMesafesi = KoşuMesafesiHesapla(adımBoyuMetre, adımSayısı, koşuSüresi, koşuSüresiDakika);
                    Console.WriteLine($"Koşu mesafeniz = {koşuMesafesi} metredir.");
                    string soru = "Yeni bir koşu mesafesi hesaplamak ister misiniz? Yeni veri girişi için 'Evet' yazınız.";
                    devamMı = EvetHayırSorusuSor(soru);
                } while(devamMı);
                Console.ReadLine();
            }
            catch (Exception u)
            {
                Console.WriteLine(u.Message);
            }
        }

        /// <summary>
        /// Uygulama hakkında bilgi veren metot.
        /// </summary>
        private static void Giriş()
        {
            string mesaj = "Bu uygulama günlük koşu mesafenizi ölçmek için tasarlanmıştır. Adım boyunuzu, dakikadaki adım sayınızı ve koşu sürenizi girdiğiniz takdirde koşu mesafeniz hesaplanacaktır.";
            Console.WriteLine(mesaj);
        }

        /// <summary>
        /// Kullanıcıdan adım boyunu alan ve kontrolleri yapan metot.
        /// </summary>
        /// <returns></returns>
        private static int AdımBoyuAl()
        {
            int intCevap;
            Console.WriteLine();
            Console.Write("Lütfen adım boyunuzu santimetre cinsinden giriniz: ");
            string cevap = Console.ReadLine().Trim();
            bool sayıMı = BuBirSayıMı(cevap, out intCevap);
            return sayıMı ? intCevap : AdımBoyuAl();
        }

        /// <summary>
        /// Kullanıcının girdiği değerin sayı olup olmadığını kontrol eden, sayı ise o sayıyı döndüren metot.
        /// </summary>
        /// <param name="strCevap"></param>
        /// <param name="intCevap"></param>
        /// <returns></returns>
        private static bool BuBirSayıMı(string strCevap, out int intCevap)
        {
            bool geçersizDeğer;
            if (geçersizDeğer = !int.TryParse(strCevap, out intCevap))
            {
                Console.WriteLine("Hatalı giriş yaptınız! Lütfen sadece sayısal veri giriniz.");
                return false;
            }
            else
                return int.TryParse(strCevap, out intCevap);
        }

        /// <summary>
        /// Santimetreyi metreye çeviren metot.
        /// </summary>
        /// <param name="sayı"></param>
        /// <returns></returns>
        private static float SantimetreyiMetreyeÇevir(int sayı) 
        {
            float metre = (float)sayı/100;
            return metre;
        }

        /// <summary>
        /// Kullanıcıdan dakikadaki adım sayısını alan ve kontrolleri yapan metot.
        /// </summary>
        /// <returns></returns>
        private static int DakikadakiAdımSayısı()
        {
            int intCevap;
            Console.WriteLine();
            Console.Write("Lütfen bir dakikada kaç adım attığınızı giriniz: ");
            string cevap = Console.ReadLine().Trim();
            bool sayıMı = BuBirSayıMı(cevap, out intCevap);
            return sayıMı ? intCevap : DakikadakiAdımSayısı();
        }

        /// <summary>
        /// Kullanıcıdan koşu süresinin tam saat kısmını alan ve kontrolleri yapan metot.
        /// </summary>
        /// <returns></returns>
        private static int KoşuSüresiSaat()
        {
            int intCevap;
            Console.WriteLine();
            Console.Write("Lütfen koşu sürenizin tam saat kısmını giriniz: ");
            string cevap = Console.ReadLine().Trim();
            bool sayıMı = BuBirSayıMı(cevap, out intCevap);
            return sayıMı ? intCevap : KoşuSüresiSaat();
        }

        /// <summary>
        /// Saati dakikaya çeviren metot.
        /// </summary>
        /// <param name="sayı"></param>
        /// <returns></returns>
        private static int SaatiDakikayaÇevir(int sayı) 
        {
            int dakika = sayı * 60;
            return dakika;
        }

        /// <summary>
        /// Kullanıcıdan koşu süresinin tam saat kısmından arta kalan dakikasını alan ve kontrolleri yapan metot.
        /// </summary>
        /// <returns></returns>
        private static int KoşuSüresiDakika()
        {
            int intCevap;
            Console.WriteLine();
            Console.Write("Lütfen koşu sürenizin tam saat kısmından arta kalan dakika kısmını giriniz: ");
            string cevap = Console.ReadLine().Trim();
            bool sayıMı = BuBirSayıMı(cevap, out intCevap);
            return sayıMı ? intCevap : KoşuSüresiDakika();
        }

        /// <summary>
        /// Koşu mesafesini hesaplayan metot.
        /// </summary>
        /// <param name="adımBoyu"></param>
        /// <param name="adımSayısı"></param>
        /// <param name="saat"></param>
        /// <param name="dakika"></param>
        /// <returns></returns>
        private static float KoşuMesafesiHesapla(float adımBoyu, int adımSayısı, int saat, int dakika) 
        {
            float koşuMesafesi = adımBoyu * adımSayısı * (saat + dakika);
            return koşuMesafesi;
        }

        /// <summary>
        /// Kullanıcıya evet ya da hayır cevabı verebileceği bir soru soran metot.
        /// </summary>
        /// <param name="soru"></param>
        /// <returns></returns>
        private static bool EvetHayırSorusuSor(string soru)
        {
            Console.WriteLine();
            Console.Write($"{soru} ");
            string cevap = Console.ReadLine().Trim().ToLower();
            cevap = cevap.Substring(0, 1);
            return cevap == "e";
        }
    }
}