using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Camera.Hotel
{
    public class Camera
    {

        private string numero;
        private float dimensione;
        private int posti_letto;// i posti letto corrispondino anche al numero i persone nella camera
        private bool tv;
        private bool frigo;
        private bool bagno;
        private float costo;
        private int persone;
        public int Persone
        {
            get { return persone; }
            private set
            {
                if (value != null && value > 0)
                    persone = value;
                else
                    throw new Exception("numero persone non valido");
            }
        }
        public string Numero
        {
            get { return numero; }
            private set
            {
                Regex rx = new Regex("^[0-9]{3}$");
                if (value != null && rx.IsMatch(value))
                    numero = value;
                else
                    throw new Exception("numero camera non valido");

            }
        }
        public float Dimensione
        {
            get { return dimensione; }
            private set
            {
                if (value != null && value > 0)
                    dimensione = value;
                else
                    throw new Exception("dimensione non valida");
            }
        }
        public int Posti_letto
        {
            get { return posti_letto; }
            private set
            {
                if (value != null && value > 0)
                    posti_letto = value;
                else
                    throw new Exception("numero letti non valido ");
            }

        }
        public bool TV
        {
            get { return tv; }
            private set
            {
                if (value != null)
                    tv = value;
                else
                    throw new Exception("valore non valido");
            }
        }
        public bool Frigo
        {
            get { return frigo; }
            private set
            {
                if (value != null)
                    frigo = value;
                else
                    throw new Exception("valore non valido");
            }
        }
        public bool Bagno
        {
            get { return bagno; }
            private set
            {
                if (value != null)
                    bagno = value;
                else
                    throw new Exception("valore non valido");
            }
        }
        public float Costo
        {
            get { return costo; }
            private set
            {
                if (value != null)
                    costo = value;
                else
                    throw new Exception("valore non valida");
            }
        }
        public Camera(string numero, float dimensione, int posti_letto, bool tv, bool frigo, bool bagno, float costo, int persone)
        {
            Numero = numero;
            Dimensione = dimensione;
            Posti_letto = posti_letto;
            Frigo = frigo;
            Bagno = bagno;
            Costo = costo;
            Persone = persone;
        }
        public Camera() : this("000", 5, 1, false, false, false, 100, 1)
        {
        }//se non viene inserita la dimensione inseirsco 5 che è la misura media per una camera singola 
        public override string ToString()
        {
            return "camera:" + Numero + ";" + Dimensione + ";" + Posti_letto + ";" + TV + ";" + Frigo + ";" + Bagno + ";" + Costo + ";" + Persone;
        }
        protected Camera(Camera other) : this(other.Numero, other.Dimensione, other.Posti_letto, other.TV, other.Frigo, other.Bagno, other.Costo, other.Persone)
        {
        }
        public bool Equals(Camera p)
        {
            if (p == null) return false;

            if (this == p) return true;

            return (this.numero == p.numero);
        }
        public Camera Clone()
        {
            return new Camera(this);
        }
        public void Modifica_frigo(bool valore)
        {
            Frigo = valore;
        }
        public void Modifica_tv(bool valore)
        {
            TV = valore;
        }
        public void Modifica_dimensione(float valore)
        {
            Dimensione = valore;
        }
        public void Modifica_bagno(bool valore)
        {
            Bagno = valore;
        }
        public void Aggiungi_per()
        {
            Persone++;
        }
        public void Diminuisci_per()
        {
            if (Persone != 0)
                Persone--;
            else
                throw new Exception("la camera è gia vuota");
        }
        public float prezzo_singola()
        {
            return (Costo / Persone);
        }
        public string confronta_Prezzo(Camera camera2)
        {
            if (camera2 != null)
            {
                if (camera2.prezzo_singola() < this.prezzo_singola())
                {
                    return "la camera più conveniente è quella numero " + camera2.Numero;
                }
                if (camera2.prezzo_singola() > this.prezzo_singola())
                {
                    return "la camera più conveniente è quella numero " + this.Numero;
                }
                if (camera2.prezzo_singola() == this.prezzo_singola())
                {
                    return "il prezzo medio delle stanze è equivalente";
                }
                return "";
            }
            else
            {
                return "valore in entrata non valido";
            }
        }
    }
}
