// See https://aka.ms/new-console-template for more information
public class Documento
{
    public string Titolo { get; set; }
    public int Anno { get; set; }
    public string Settore { get; set; }
    public bool Stato { get; set; }
    public int Scaffale { get; set; }
    public string Autore { get; set; }
    public string Codice { get; set; }

    public Documento(string titolo, int anno, string settore, bool stato, int scaffale, string autore, string codice)
    {
        Titolo = titolo;
        Anno = anno;
        Settore = settore;
        Stato = stato;
        Scaffale = scaffale;
        Autore = autore;
        Codice = codice;
    }
    public string Disponibilità()
    {
        return Stato ? "disponibile" : "in prestito";
    }
    public override string ToString()
    {
        return Titolo + " - " + Autore + " - " + Codice + " - " + Disponibilità();
    }
}