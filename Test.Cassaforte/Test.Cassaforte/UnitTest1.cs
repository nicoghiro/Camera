
namespace CassaforteMain
{
    public class UnitTest1
        
    {
    //correggo nel testo per rendere possibile l'apertura ,altrimenti tutti i metodi non funzionano , l'errore era a riga 58 della classe
    //non riesco a testare il metodo sblocca dato che il codice non viene mai dato 
    // il codice di sblocco non viene mai dato 
        [Fact]
        public void Test1()
        {
            Cassaforte cassa = new Cassaforte(1234,"sorint","newx gen","12345",true);
            cassa.Apri("12345");  
            //il codice di apertura non da errore anche se non di 5 lettere
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
            Assert.True(cassa.Stato == false);

        }
        [Fact]
        public void Test4()
        {
            Cassaforte cassa = new Cassaforte(1234, "sorint", "newx gen", "12345", true);
            
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
            Assert.Throws<Exception>(() => cassa.Apri("1234"));
            

        }
        [Fact]
        public void Test6()
        {
            Cassaforte cassa = new Cassaforte(1234, "sorint", "newx gen", "12345", false);
            cassa.ImpostaCodiceUtente("21");
            Assert.Throws<Exception>(() => cassa.Apri("1234"));
            //non dice in nessun modo che ho sbagliato a inseirire il codice;

        }
        [Fact]
        public void Test7()
        {
            Cassaforte cassa = new Cassaforte(1234, "sorint", "newx gen", "12345", false);
            DateTime data = DateTime.Now;
            cassa.ImpostaData(data);
            Assert.True(cassa.DataProgrammata == data);

        }
        [Fact]
        public void Test8()
        {
            Cassaforte cassa = new Cassaforte(1234, "sorint", "newx gen", "12345", false);
            cassa.ImpostaCodiceUtente("21");
            cassa.Apri("21");
            Assert.True(cassa.Stato == true);

        }
        [Fact]
        public void Test9()
        {
            Cassaforte cassa = new Cassaforte(1234, "sorint", "newx gen", "12345", false);
            cassa.ImpostaCodiceUtente("21");
            cassa.Apri("21");
            Assert.False(cassa.Stato == false);

        }
        [Fact]
        public void Test10()
        {
            Cassaforte cassa = new Cassaforte(1234, "sorint", "newx gen", "12345",false);
            cassa.GeneraCod("12345");
            Assert.True(cassa.CodiceSblocco == "12345");
            //come so quale è il nuovo codice?

        }
        [Fact]
        public void Test11()
        {
            Cassaforte cassa = new Cassaforte(1234, "sorint", "newx gen", "12345", false);
            DateTime data = DateTime.Now;
            cassa.ImpostaData(data);
            Assert.True(cassa.DataProgrammata == data);

        }
        [Fact]
        public void Test12()
        {
            Cassaforte cassa = new Cassaforte(1234, "sorint", "newx gen", "12345", false);
            cassa.ImpostaCodiceUtente("21");
            DateTime data = DateTime.Now;
            cassa.ImpostaData(data);
            cassa.AperturaProgrammata("21");
            Assert.True(cassa.Stato==true);
           

        }


    }
}