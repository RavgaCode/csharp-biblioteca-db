// See https://aka.ms/new-console-template for more information
public class Biblioteca
{
    public List<Cliente> clienti = new List<Cliente>();
    public List<Documento> documenti = new List<Documento>();
    public List<Prestito> prestiti = new List<Prestito>();

    public void CreaClientiDefault()
    {
        Cliente cliente1 = new Cliente("Giacomuzzo", "Roberto", "roberto@email.it", "3280102321");
        Cliente cliente2 = new Cliente("Pasticcio", "Ciccio", "ciccio@email.it", "3280102321");
        Cliente cliente3 = new Cliente("Rana", "Giovanni", "rana@email.it", "3280102321");

        clienti.Add(cliente1);
        clienti.Add(cliente2);
        clienti.Add(cliente3);
    }

    public void CreaDocumentiDefault()
    {
        Dvd dvd1 = new Dvd("Il Ciclone", 1996, "commedia", true, 12, "Leonardo Pieraccioni", 93, "13A");
        Dvd dvd2 = new Dvd("Il Gladiatore", 2000, "storico", true, 11, "Ridley Scott", 155, "13B");
        Dvd dvd3 = new Dvd("Matrix", 1999, "fantascienza", true, 10, "Lana e Lily Wachowski", 136, "13C");

        Libro libro1 = new Libro("La Compagnia dell'Anello", 1954, "fantasy", true, 9, "J.R.R Tolkien", 704, "111");
        Libro libro2 = new Libro("Il principe", 1532, "saggistica", true, 8, "Niccolò Machiavelli", 236, "222");
        Libro libro3 = new Libro("La fata Carabina", 1987, "romanzo", true, 7, "Daniel Pennac", 234, "333");

        documenti.Add(dvd1);
        documenti.Add(dvd2);
        documenti.Add(dvd3);

        documenti.Add(libro1);
        documenti.Add(libro2);
        documenti.Add(libro3);

    }
    public void RegistraCliente()
    {
        Console.Write("Cognome : ");
        string cognome = Console.ReadLine();
        Console.Write("Nome : ");
        string nome = Console.ReadLine();
        Console.Write("Email : ");
        string email = Console.ReadLine();
        Console.Write("RecapitoTelefonico : ");
        string telefono = Console.ReadLine();

        Cliente nuovoCliente = new Cliente(cognome, nome, email, telefono);
        clienti.Add(nuovoCliente);
        Console.WriteLine();
        Console.WriteLine("Cliente registrato!");
        Console.WriteLine();
    }
    public void RicercaDocumento()
    {
        Console.WriteLine("Digita il titolo o il codice seriale/ISBN del documento che cerchi");
        string documentoDaCercare = Console.ReadLine();

        foreach (Documento documento in documenti)
        {
            if (documento.Titolo == documentoDaCercare || documento.Codice == documentoDaCercare)
            {
                Console.WriteLine(documento.ToString());
                Console.WriteLine();
                return;
            }

        }
        Console.WriteLine("Non c'è nessuno documento corrispondente al parametro di ricerca inserito");
        Console.WriteLine();
    }
    public void EffettuaPrestito()
    {
        Console.WriteLine("Digita il titolo o il codice seriale/ISBN del documento che cerchi");
        string documentoDaCercare = Console.ReadLine();

        foreach (Documento documento in documenti)
        {
            if (documento.Titolo == documentoDaCercare || documento.Codice == documentoDaCercare)
            {
                if (documento.Stato)
                {
                    Console.WriteLine("Trovato il seguente documento: " + documento.ToString());
                    Console.Write("Inserire cognome cliente: ");
                    string cognomeCliente = Console.ReadLine();
                    Console.Write("Inserire nome cliente: ");
                    string nomeCliente = Console.ReadLine();

                    foreach (Cliente cliente in clienti)
                    {
                        if (cliente.Nome == nomeCliente && cliente.Cognome == cognomeCliente)
                        {
                            Prestito nuovoPrestito = new Prestito(documento, cliente);
                            prestiti.Add(nuovoPrestito);
                            documento.Stato = false;
                            Console.WriteLine("Prestito eseguito");
                            Console.WriteLine();
                            return;
                        }

                    }
                }

            }
        }
    }
    public void RicercaPrestiti()
    {
        Console.Write("Inserire cognome cliente: ");
        string cognomeCliente = Console.ReadLine();
        Console.Write("Inserire nome cliente: ");
        string nomeCliente = Console.ReadLine();
        Console.WriteLine();

        foreach (Prestito prestito in prestiti)
        {
            if (prestito.ClientePrestito.Nome == nomeCliente && prestito.ClientePrestito.Cognome == cognomeCliente)
            {

                Console.WriteLine(prestito.ClientePrestito.Nome + " " + prestito.ClientePrestito.Cognome + " ha preso in prestito: " + prestito.DocumentoPrestato.ToString());
                Console.WriteLine();
            }

        }
    }
}