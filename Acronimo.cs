using System;

namespace CS_P003
{
public class Acronimo
{
    // La stringa da trattare può ora essere richiesta direttamente all'utente
    public static void chiedi()
        {
            string str = "";
            do
            {
                Console.WriteLine("\nDigita una stringa di testo di cui desideri ricavare l'acronimo (o premi solo INVIO per uscire).");
                str = Console.ReadLine();
                if (str.Length > 0) Console.WriteLine($"Il suo acronimo è {trovaAcronimo(str)}.\n");
            } while (str != "" && str != null);
        }
        // La variabile che contiene i separatori è gestita attraverso una proprietà
        static private string _separatore; // variabile privata
        static public string separatore // ge/set pubblici
        {
            get // il getter effettua un controllo sulla nullità della stringa...
            {
                if (_separatore == null) separatore = null; // ...nel qual caso la passa al setter
                return _separatore; // altrimenti ne restituisce il valore corrente
            }
            set // anche il setter effettua un controllo sulla nullità del valore che si cerca di assegnare...
            { // ...e lo riempie automaticamente con tutti i valori non alfadecimali
                if (value == null || value == "") for (char ch = (char)0; ch < 256; ch++) { if (separa(ch)) _separatore += ch; }
                else _separatore = value; // se gli viene passata una stringa ne userà il contenuto
            }
        }

        // riconoscimento dei caratteri che separano le parole
        public static bool separa(char ch) => char.IsWhiteSpace(ch) || char.IsPunctuation(ch) || char.IsSeparator(ch);

        // RESTITUISCE UNA SERIE DI INIZIALI, PARTENDO DA UNA STRINGA
        static public string trovaAcronimo(string str)
        {
            string ret = ""; // stringa pronta per ricevere le iniziali
            char ch = ' '; // un carattere per ricordarsi di quello precedente nel ciclo di lettura...
            // ...(portato a ' ' per fare in modo che anche il primo carattere della stringa possa far parte dell'acronimo)
            foreach (char c in str) { if (separatore.Contains(ch) && char.IsLetter(c)) ret += c; ch = c; } // poi parte la lettura dei caratteri...
            // ...se il carattere precedente è un separatore, mentre quello attuale è una lettera, lo si aggiunge alle iniziali, poi si aggiorna il vecchio 'ch'
            return ret.ToUpper(); // infine viene restituito l'elenco delle iniziali, tutto maiuscolo
        }
}
}