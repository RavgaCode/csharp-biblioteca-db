// See https://aka.ms/new-console-template for more information
public class Dvd : Documento
{
    public int Durata { get; set; }

    public Dvd(string titolo, int anno, string settore, bool stato, int scaffale, string autore, int durata, string codice) : base(titolo, anno, settore, stato, scaffale, autore, codice)
    {
        Durata = durata;
    }
    public override string ToString()
    {
        return base.ToString();
    }
}