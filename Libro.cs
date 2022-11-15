// See https://aka.ms/new-console-template for more information
public class Libro : Documento
{
    public int Pagine { get; set; }

    public Libro(string titolo, int anno, string settore, bool stato, int scaffale, string autore, int pagine, string codice) : base(titolo, anno, settore, stato, scaffale, autore, codice)
    {
        Pagine = pagine;
    }
    public override string ToString()
    {
        return base.ToString();
    }
}