using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projekt
{
    class Program
    {
        private static int wybor;
        private static string wybor_str;
        public abstract class Pojazd
        {
            public int identyfikator;
            public int predkosc;
            public string model;
            public Pojazd(int Id, int Prd, string Mdl)
            {
                identyfikator = Id;
                predkosc = Prd;
                model = Mdl;
            }
            public virtual string Info()
            {
                string txt = "";
                return txt = "\nID: "+identyfikator+"\nModel: " + model + "\nPredkosc: " + predkosc;
            }
        }
        public class Samochod : Pojazd
        {
            int liczbaDrzwi;
            public Samochod(int Id, int Prd, string Mdl, int Ldrz) : base(Id, Prd, Mdl)
            {
                identyfikator = Id;
                predkosc = Prd;
                model = Mdl;
                liczbaDrzwi = Ldrz;
            }
            public override string Info()
            {
                string txt = "";
                return txt = base.Info() + "\nLiczba drzwi: " + liczbaDrzwi;
            }
        }

        public class Samolot : Pojazd
        {
            int liczbaMiejsc;

            public Samolot(int Id, int Prd, string Mdl, int Lmsc) : base(Id, Prd, Mdl)
            {
                identyfikator = Id;
                predkosc = Prd;
                model = Mdl;
                liczbaMiejsc = Lmsc;
            }
            public override string Info()
            {
                string txt = "";
                return txt = base.Info() + "\nLiczba miejsc: " + liczbaMiejsc;
            }
        }

        public class Statek : Pojazd
        {
            int liczbaZagli;

            public Statek(int Id, int Prd, string Mdl, int Lz) : base(Id, Prd, Mdl)
            {
                identyfikator = Id;
                predkosc = Prd;
                model = Mdl;
                liczbaZagli = Lz;
            }
            public override string Info()
            {
                string txt = "";
                return txt = base.Info() + "\nLiczba żagli: " + liczbaZagli;
            }
        }

        public class Autobus : Pojazd
        {
            int liczbaPieter;

            public Autobus(int Id, int Prd, string Mdl, int Lp) : base(Id, Prd, Mdl)
            {
                identyfikator = Id;
                predkosc = Prd;
                model = Mdl;
                liczbaPieter = Lp;
            }
            public override string Info()
            {
                string txt = "";
                return txt = base.Info() + "\nLiczba pięter: " + liczbaPieter;
            }
        }

        public class Pociag : Pojazd
        {
            int liczbaWagonow;

            public Pociag(int Id, int Prd, string Mdl, int Lw) : base(Id, Prd, Mdl)
            {
                identyfikator = Id;
                predkosc = Prd;
                model = Mdl;
                liczbaWagonow = Lw;
            }
            public override string Info()
            {
                string txt = "";
                return txt = base.Info() + "\nLiczba wagonów: " + liczbaWagonow;
            }
        }

        static void Main(string[] args)
        {
            List<Pojazd> pojazdy = new List<Pojazd>();
            do
            {
                wybor = 0;
                wybor_str = "0";
                Console.Clear();
                Console.WriteLine("Wybierz dzialanie: \n1. Dodaj nowy obiekt\n2. Usuń istniejący obiekt\n3. Wyświetl wszystkie obiekty\n4. Wyświetl obiekty podanego typu\n5. Wyświetl obiekty o podanej nazwie\n6. Wyjście z programu\n");
                wybor_str=Console.ReadLine();
                int.TryParse(wybor_str,out wybor);
                switch(wybor)
                {
                    case 1:
                        int wybor_typ=0;
                        string wybor_typ_str="0";
                        do
                        {
                            Console.Clear();
                            Console.WriteLine("Podaj typ nowego pojazdu:\n1. Samochod\n2. Samolot\n3. Statek\n4. Autobus\n5. Pociąg");
                            wybor_typ_str = Console.ReadLine();
                            int.TryParse(wybor_typ_str, out wybor_typ);
                        }
                        while (wybor_typ<1 || wybor_typ>5);

                        Console.WriteLine("Podaj nazwę pojazdu: ");
                        string poj_nazwa = Console.ReadLine();

                        Console.WriteLine("Podaj prędkość maksymalną: ");
                        int poj_spd = int.Parse(Console.ReadLine());

                        switch(wybor_typ)
                        {
                            case 1:
                                Console.WriteLine("Podaj ilość drzwi w samochodzie: ");
                                int poj_drz = int.Parse(Console.ReadLine());
                                pojazdy.Add(new Samochod(pojazdy.Count,poj_spd,poj_nazwa,poj_drz));
                                break;
                            case 2:
                                Console.WriteLine("Podaj liczbę miejsc w samolocie: ");
                                int poj_mie = int.Parse(Console.ReadLine());
                                pojazdy.Add(new Samolot(pojazdy.Count, poj_spd, poj_nazwa, poj_mie));
                                break;
                            case 3:
                                Console.WriteLine("Podaj liczbę żagli na statku: ");
                                int poj_zag = int.Parse(Console.ReadLine());
                                pojazdy.Add(new Statek(pojazdy.Count, poj_spd, poj_nazwa, poj_zag));
                                break;
                            case 4:
                                Console.WriteLine("Podaj liczbę pięter w autobusie: ");
                                int poj_pie = int.Parse(Console.ReadLine());
                                pojazdy.Add(new Autobus(pojazdy.Count, poj_spd, poj_nazwa, poj_pie));
                                break;
                            case 5:
                                Console.WriteLine("Podaj liczbę wagonów pociągu: ");
                                int poj_wag = int.Parse(Console.ReadLine());
                                pojazdy.Add(new Pociag(pojazdy.Count, poj_spd, poj_nazwa, poj_wag));
                                break;
                        }
                        break;
                    case 2:
                        Console.WriteLine("Podaj ID pojazdu, który chcesz usunąć z listy: ");
                        int usun_id = int.Parse(Console.ReadLine());
                        pojazdy.RemoveAt(usun_id);
                        break;
                    case 3:
                        Console.Clear();
                        foreach (Pojazd i in pojazdy)
                        {
                            Console.WriteLine(i.Info());
                        }
                        Console.WriteLine("\nWciśnij dowolny klawisz, aby kontynuować");
                        Console.ReadKey();
                        break;
                    case 4:
                        do
                        {
                            Console.Clear();
                            Console.WriteLine("Podaj typ szukanych pojazdów:\n1. Samochod\n2. Samolot\n3. Statek\n4. Autobus\n5. Pociąg");
                            wybor_typ_str = Console.ReadLine();
                            int.TryParse(wybor_typ_str, out wybor_typ);
                        }
                        while (wybor_typ < 1 || wybor_typ > 5);
                        switch(wybor_typ)
                        {
                            case 1:
                                foreach(Pojazd i in pojazdy)
                                {
                                    if (i.GetType() == typeof(Samochod))
                                    {
                                        Console.WriteLine(i.Info());
                                    }
                                }
                                break;
                            case 2:
                                foreach (Pojazd i in pojazdy)
                                {
                                    if (i.GetType() == typeof(Samolot))
                                    {
                                        Console.WriteLine(i.Info());
                                    }
                                }
                                break;
                            case 3:
                                foreach (Pojazd i in pojazdy)
                                {
                                    if (i.GetType() == typeof(Statek))
                                    {
                                        Console.WriteLine(i.Info());
                                    }
                                }
                                break;
                            case 4:
                                foreach (Pojazd i in pojazdy)
                                {
                                    if (i.GetType() == typeof(Autobus))
                                    {
                                        Console.WriteLine(i.Info());
                                    }
                                }
                                break;
                            case 5:
                                foreach (Pojazd i in pojazdy)
                                {
                                    if (i.GetType() == typeof(Pociag))
                                    {
                                        Console.WriteLine(i.Info());
                                    }
                                }
                                break;
                        }
                        Console.WriteLine("\nWciśnij dowolny klawisz, aby kontynuować");
                        Console.ReadKey();
                        break;
                    case 5:
                        Console.WriteLine("Podaj nazwę szukanego pojazdu: ");
                        wybor_typ_str = Console.ReadLine();
                        foreach(Pojazd i in pojazdy)
                        {
                            if(i.model.Contains(wybor_typ_str))
                            {
                                Console.WriteLine(i.Info());
                            }
                        }
                        Console.WriteLine("\nWciśnij dowolny klawisz, aby kontynuować");
                        Console.ReadKey();
                        break;
                }
            }
            while (wybor != 6);
        }
    }
}


