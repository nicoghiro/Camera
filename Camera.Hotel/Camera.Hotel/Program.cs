namespace Camera.Hotel
{
    class Program
    {
        public static void Main(string[] args)
        {
            Camera amera = new Camera("111",32,3,false,false,false,150,1);
            Console.WriteLine(amera.ToString());    
        }
    }

}