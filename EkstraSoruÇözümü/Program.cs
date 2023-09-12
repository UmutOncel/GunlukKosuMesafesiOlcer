namespace EkstraSoruÇözümü
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Koşu mesafesi, adım boyu, dakikadaki adım sayısı girildiğinde koşu süresini hesaplayan uygulama.

            try
            {
                Giriş();
                float[] arrayAdımBoyu = new float[0];
                int[] arrayAdımSayısı = new int[0];
                float parkurUzunluğu = ParkurUzunluğunuAl();
                int turSayısı = TurSayısınıAl();
                for (int i = 0; i < turSayısı; i++)
                {
                    Console.WriteLine($"Tebrikler! {i + 1}. tur bitti. Şimdi tur verilerini girme zamanı.");
                    int adımBoyuSantimetre = AdımBoyuAl();
                    float adımBoyuMetre = SantimetreyiMetreyeÇevir(adımBoyuSantimetre);
                    int adımSayısı = DakikadakiAdımSayısı();
                    FloatDiziyeElemanEkle(ref arrayAdımBoyu, adımBoyuMetre);
                    İntDiziyeElemanEkle(ref arrayAdımSayısı, adımSayısı);
                }
                float[] turSüresi = new float[turSayısı];
                for (int i = 0; i < turSayısı; i++)
                {
                    turSüresi[i] = parkurUzunluğu / (arrayAdımBoyu[i] * arrayAdımSayısı[i]);
                }
                string mesaj = $"Bravo! Parkur etrafındaki {turSayısı} turu başarıyla tamamladınız. Şimdi tur sürelerine bakalım:";
                DiziyiEkranaYazdır(mesaj, turSayısı, turSüresi);
                mesaj = "Tur sürelerinin en hızlıdan yavaşa doğru sıralaması:";
                TurSüreleriniSırala(mesaj, turSüresi);
                Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        /// <summary>
        /// Uygulama hakkında bilgi veren metot.
        /// </summary>
        private static void Giriş()
        {
            string mesaj = "Bu uygulama bir parkur etrafında koştuğunuzda tur sürelerini dakika olarak hesaplar ve en hızlıdan yavaşa doğru sıralar. Tek yapmanız gereken parkur uzunluğunu, adım boyunuzu ve dakikada attığını adım sayısını girmektir.";
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
            float metre = (float)sayı / 100;
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
        /// Kullanıcıdan parkur uzunluğunu alan ve kontrolleri yapan metot.
        /// </summary>
        /// <returns></returns>
        private static int ParkurUzunluğunuAl()
        {
            int intCevap;
            Console.WriteLine();
            Console.Write("Lütfen parkur uzunluğunu metre cinsinden giriniz: ");
            string cevap = Console.ReadLine().Trim();
            bool sayıMı = BuBirSayıMı(cevap, out intCevap);
            return sayıMı ? intCevap : ParkurUzunluğunuAl();
        }

        /// <summary>
        /// Kullanıcıdan atacağı tur sayısını alan metot.
        /// </summary>
        /// <returns></returns>
        private static int TurSayısınıAl() 
        {
            int intCevap;
            Console.WriteLine();
            Console.Write("Lütfen parkur etrafında atacağınız tur sayısını giriniz: ");
            string cevap = Console.ReadLine().Trim();
            bool sayıMı = BuBirSayıMı(cevap, out intCevap);
            return sayıMı ? intCevap : TurSayısınıAl();
        }

        /// <summary>
        /// Integer diziye eleman ataması yapan metot.
        /// </summary>
        /// <param name="intArray"></param>
        /// <param name="intSayı"></param>
        private static void İntDiziyeElemanEkle(ref int[] intArray, int intSayı)
        {
            Array.Resize(ref intArray, intArray.Length + 1);
            intArray[^1] = intSayı;
        }

        /// <summary>
        /// Float diziye eleman ataması yapan metot.
        /// </summary>
        /// <param name="floatArray"></param>
        /// <param name="sayı"></param>
        private static void FloatDiziyeElemanEkle(ref float[] floatArray, float sayı)
        {
            Array.Resize(ref floatArray, floatArray.Length + 1);
            floatArray[^1] = sayı;
        }

        /// <summary>
        /// Diziyi ekrana yazdıran metot.
        /// </summary>
        /// <param name="mesaj"></param>
        /// <param name="turSüresi"></param>
        private static void DiziyiEkranaYazdır(string mesaj, int turSayısı, float[] turSüresi)
        {
            Console.WriteLine(mesaj);
            for (int i = 0; i < turSayısı; i++)
            {
                Console.WriteLine($"{i+1}. tur süresi= {turSüresi[i]} dakika");
            }
        }

        /// <summary>
        /// Tur sürelerini en hızlıdan yavaşa doğru sıralayan metot. 
        /// </summary>
        /// <param name="mesaj"></param>
        /// <param name="turSüresi"></param>
        private static void TurSüreleriniSırala(string mesaj, float[] turSüresi) 
        {
            Console.WriteLine();
            Array.Sort(turSüresi);
            foreach (float dakika in turSüresi)
            {
                Console.Write($"{dakika} - ");
            }
        }
    }
}