namespace Camera.Hotel
{
    class Program
    {
        public static void Main(string[] args)
        {
            Camera amera = new Camera("111",32,3,false,false,false,150,1);
            Console.WriteLine(amera.ToString());
            amera.Modifica_tv(true);
            amera.Modifica_bagno(true);
            amera.Modifica_dimensione(150);
            amera.Modifica_frigo(true);
            Console.WriteLine(amera.ToString());
            Camera era = new Camera("222", 32, 8, false, true, false, 78, 4);
            Console.WriteLine(era.ToString());
           Console.WriteLine( amera.confronta_Prezzo(era));
        }
    }

}