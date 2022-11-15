// See https://aka.ms/new-console-template for more information
public class Prestito
{
    public DateTime DataInizio { get; set; }
    public DateTime DataFine { get; set; }
    public Documento DocumentoPrestato { get; set; }
    public Cliente ClientePrestito { get; set; }

    public Prestito(Documento documentoPrestato, Cliente clientePrestito)
    {
        //Un nuovo prestito avrà come data inizio prestito la data corrente e come durata prestabilita una settimana
        DataInizio = DateTime.Now;
        DataFine = DateTime.Now.AddDays(7);
        ClientePrestito = clientePrestito;
        DocumentoPrestato = documentoPrestato;
    }
}