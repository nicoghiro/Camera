
namespace CassaforteMain
{
    public class UnitTest1
        
    {
    
        [Fact]
        public void Test1()
        {
            Cassaforte cassa = new Cassaforte(1234,"sorint","newx gen","12345",true);
            cassa.Apri("12345");
            //non richiama nessuna eccezzione se il codice inserito è sbagliato;
            Assert.True(cassa.Stato==true);
            //la cassa non risulta mai aperta

        }
        [Fact]
        public void Test2()
        {
            Cassaforte cassa = new Cassaforte(123, "sorint", "newx gen", "1234", true);
            cassa.Chiudi();
            Assert.True(cassa.Stato== false);

        }
        [Fact]
        public void Test3()
        {
            Cassaforte cassa = new Cassaforte(123, "sorint", "newx gen", "1234", true);
            cassa.Chiudi();
            // la cassaforte non si chiude se la inizializzo da aperta
            Assert.True(cassa.Stato == false);

        }
        [Fact]
        public void Test4()
        {
            Cassaforte cassa = new Cassaforte(1234, "sorint", "newx gen", "12345", false);
            cassa.Apri("12345");
            
            Assert.True(cassa.Stato == true);
            //la cassa non risulta mai aperta

        }
        [Fact]
        public void Test5()
        {
            Cassaforte cassa = new Cassaforte(1234, "sorint", "newx gen", "12345", false);
            cassa.Apri("1234");
            cassa.Apri("1234");
            cassa.Apri("1234");
            cassa.Apri("1234");
            cassa.Apri("1234");
            Assert.Throws<Exception>(() => cassa.Apri("1234"));
            //la cassaforte non si blocca dopo 5 tentatici 

        }
        [Fact]
        public void Test6()
        {
            Cassaforte cassa = new Cassaforte(1234, "sorint", "newx gen", "12345", false);
            Assert.Throws<Exception>(() => cassa.Apri("1234"));
            //non richiama nessuna eccezzione se il codice inserito è sbagliato;

        }
    }
}