using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kart_Oyunu
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DateTime baslangicZamani= DateTime.Now;
            Dictionary<int,char> kartlar= new Dictionary<int,char>();
            List<char> list = new List<char>()
            {
                'A','A','B','B','C','C','D','D','E','E','F','F','G','G','H','H'
            };
            Random random = new Random();
            List<int> indexler = new List<int>();
            for (int i = 1; i < 17; i++)
            {
                int randomİndex=random.Next(0,list.Count);
                if(indexler.Contains(randomİndex))
                {
                    i--;
                    continue;
                }
                else
                {
                    kartlar[i] = list[randomİndex];
                    indexler.Add(randomİndex);
                }
            }
            foreach (int key in kartlar.Keys)
            {
                Console.Write("| {0,2}",(key));
                if((key)%4==0)
                {
                    Console.WriteLine("|");
                }
            }
            Console.WriteLine();
            foreach (int key in kartlar.Keys)
            {
                Console.Write("| {0,2}", kartlar[key]);
                if ((key) % 4 == 0)
                {
                    Console.WriteLine("|");
                }
            }
            Console.WriteLine("Kart Oyunu Basliyor...");
            List<int> acilanKartlar= new List<int>();
            int adimSayisi = 0;
            while (true)
            {
                int kart1 = girisKontrolu("\nLutfen 1. karti seciniz:", 1, 16,acilanKartlar);
                int kart2 = girisKontrolu("Lutfen 2. karti seciniz:", 1, 16, acilanKartlar);
                List<int> secilenKartlar=new List<int>();
                secilenKartlar.Add(kart1);
                secilenKartlar.Add(kart2);
                if (kartlar[kart1] == kartlar[kart2])
                {
                    acilanKartlar.Add(kart1);
                    acilanKartlar.Add(kart2);
                }
                Console.WriteLine("\nSeciminiz:");
                Yazdir(acilanKartlar, secilenKartlar,kartlar);
                adimSayisi++;
                if(acilanKartlar.Count==16)
                {
                    TimeSpan gecesSure = DateTime.Now - baslangicZamani;
                    int toplamSaniye=(int)gecesSure.TotalSeconds;
                    int dakika=toplamSaniye/60;
                    int saniye=toplamSaniye%60;
                    Console.WriteLine("\nOYUN BITTI");
                    Console.WriteLine("TOPLAM ADIM SAYISI:" + adimSayisi);
                    Console.WriteLine("TOPLAM SURE:" +dakika+"."+saniye+" dk");
                    return;
                }
            }

        }

        static void Yazdir(List<int> acilanKartlar, List<int> secilenKartlar,Dictionary<int,char> kartlar)
        {
            int syc = 0;
            for(int i=1;i<17;i++)
            {
                if (acilanKartlar.Contains(i))
                {
                    Console.Write("| {0,2}", kartlar[i]);
                }
                else if (secilenKartlar.Contains(i))
                {
                    Console.Write("| {0,2}", kartlar[i]);

                }
                else
                {
                    Console.Write("| {0,2}", (i));
                }
                if ((i) % 4 == 0)
                {
                    Console.WriteLine("|");
                }
                syc++;
            }
        }

        static int girisKontrolu(string mesaj, int min, int max,List<int> acilanKartlar)
        {
            int sayi;
            while (true)
            {
                Console.Write(mesaj);
                string secim = Console.ReadLine();

                if (int.TryParse(secim, out sayi))
                {
                    if (sayi >= min && sayi <= max)
                    {
                        if(acilanKartlar.Contains(sayi))
                        {
                            Console.WriteLine("Acik olan bir kart sectiniz!!!");
                        }
                        else
                        {
                            return sayi;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Lutfen gecerli bir kart seciniz!!!");
                    }
                }
                else
                {
                    Console.WriteLine("Lutfen gecerli bir kart seciniz!!!");
                }
            }
        }
    }
}
