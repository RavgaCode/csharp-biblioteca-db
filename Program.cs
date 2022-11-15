// See https://aka.ms/new-console-template for more information
using System.Data.SqlClient;

Console.WriteLine("Hello, World!");


Biblioteca biblioteca = new Biblioteca();
biblioteca.CreaClientiDefault();
biblioteca.CreaDocumentiDefault();

string stringaDiConnessione = "Data Source=localhost;Initial Catalog=db-biblioteca;Integrated Security=True";

SqlConnection connessioneSql = new SqlConnection(stringaDiConnessione);

bool programma = true;

while (programma)
{
    Console.WriteLine("Scegliere un'operazione:");
    Console.WriteLine("1 - Inserisci un nuovo documento");
    Console.WriteLine("2 - Ricerca documento");
    Console.WriteLine("3 - Effettua prestito");
    Console.WriteLine("4 - Ricerca prestiti");
    Console.WriteLine("9 - Esci");

    int rispostaUtente = Convert.ToInt32(Console.ReadLine());

    switch (rispostaUtente)
    {
        case 1:
            CreazioneNuovoLibro();
            break;
        case 2:
            RicercaDocumento();
            break;
        case 3:
            EffettuaPrestito();
            break;
        case 4:
            biblioteca.RicercaPrestiti();
            break;
        case 9:
            programma = false;
            break;
        default:
            Console.WriteLine("Digitare un'operazione valida");
            break;
    }
}


void CreazioneNuovoLibro()
{
    Console.Write("Digita il codice libro: ");
    string codiceLibro = Console.ReadLine();
    Console.Write("Digita il titolo libro: ");
    string titoloLibro = Console.ReadLine();
    Console.Write("Digita l'anno del libro: ");
    int annoLibro = Convert.ToInt32(Console.ReadLine());
    Console.Write("Digita il settore del libro: ");
    string settoreLibro = Console.ReadLine();
    Console.Write("Digita lo stato libro (1: disponibile / 0: non disponibile) : ");
    int statoLibro = Convert.ToInt32(Console.ReadLine());
    Console.Write("Digita lo scaffale del libro: ");
    int scaffaleLibro = Convert.ToInt32(Console.ReadLine());
    Console.Write("Digita l'autore del libro: ");
    string autoreLibro = Console.ReadLine();
    Console.Write("Digita numero di pagine del libro: ");
    int pagineLibro = Convert.ToInt32(Console.ReadLine());


    try
    {
        connessioneSql.Open();
        string insertQuery = "INSERT INTO documenti (codice,titolo,anno,settore,stato,scaffale,autore,tipologia,pagine) VALUES (@codice, @titolo, @anno, @settore, @stato, @scaffale, @autore, @tipologia, @pagine)";

        SqlCommand insertCommand = new SqlCommand(insertQuery, connessioneSql);

        insertCommand.Parameters.Add(new SqlParameter("@codice", codiceLibro));
        insertCommand.Parameters.Add(new SqlParameter("@titolo", titoloLibro));
        insertCommand.Parameters.Add(new SqlParameter("@anno", annoLibro));
        insertCommand.Parameters.Add(new SqlParameter("@settore", settoreLibro));
        insertCommand.Parameters.Add(new SqlParameter("@stato", statoLibro));
        insertCommand.Parameters.Add(new SqlParameter("@scaffale", scaffaleLibro));
        insertCommand.Parameters.Add(new SqlParameter("@autore", autoreLibro));
        insertCommand.Parameters.Add(new SqlParameter("@tipologia", "libro"));
        insertCommand.Parameters.Add(new SqlParameter("@pagine", pagineLibro));

        int affectedRows = insertCommand.ExecuteNonQuery();

    }
    catch (Exception e)
    {
        Console.WriteLine(e.Message);
    }
    finally
    {
        connessioneSql.Close();
    }
    return;
}

void RicercaDocumento()
{
    try
    {
        connessioneSql.Open();

        Console.Write("Inserisci il titolo del documento da ricerca: ");
        string titoloDaRicercare = Console.ReadLine();

        string query = "SELECT * FROM documenti where titolo=@titolo";

        SqlCommand cmd = new SqlCommand(query, connessioneSql);
        cmd.Parameters.Add(new SqlParameter("@titolo", titoloDaRicercare));

        SqlDataReader reader = cmd.ExecuteReader();

        while (reader.Read())
        {
            string codice = reader.GetString(1);
            string titolo = reader.GetString(2);
            bool stato = reader.GetBoolean(5);
            string autore = reader.GetString(7);

            Console.WriteLine(codice + titolo + stato + autore);
        }
    }
    catch(Exception e)
    {
        Console.WriteLine(e.Message);
    }
    finally
    {
        connessioneSql.Close();
    }
    return;
}
void EffettuaPrestito()
{
    int idDocumentoDaPrestare = 0;

    //Ricerca Documento da prestare

    try
    {
        connessioneSql.Open();

        Console.Write("Inserisci il titolo del documento da ricerca: ");
        string titoloDaRicercare = Console.ReadLine();

        string query = "SELECT * FROM documenti where titolo=@titolo";

        SqlCommand cmd = new SqlCommand(query, connessioneSql);
        cmd.Parameters.Add(new SqlParameter("@titolo", titoloDaRicercare));

        SqlDataReader reader = cmd.ExecuteReader();

        while (reader.Read())
        {
            idDocumentoDaPrestare = reader.GetInt32(0);
            string codice = reader.GetString(1);
            string titolo = reader.GetString(2);
            bool stato = reader.GetBoolean(5);
            string autore = reader.GetString(7);

            Console.WriteLine("Documento trovato: " + codice + titolo + stato + autore);
        }
    }
    catch (Exception e)
    {
        Console.WriteLine(e.Message);
    }
    finally
    {
        connessioneSql.Close();
    }

    //Creazione Nuovo Prestito

    Console.Write("Inserire data inizio prestito (dd/mm/yyyy) : ");
    string dataInizio = Console.ReadLine();
    Console.Write("Inserire data fine prestito (dd/mm/yyyy) : ");
    string dataFine = Console.ReadLine();
    Console.Write("Inserire nome cliente del prestito : ");
    string nomeCliente = Console.ReadLine();

    try
    {
        connessioneSql.Open();
        string insertQuery = "INSERT INTO prestiti (data_inizio,data_fine,nome_cliente,documenti_id) VALUES (@data_inizio,@data_fine,@nome_cliente,@documenti_id)";

        SqlCommand insertCommand = new SqlCommand(insertQuery, connessioneSql);

        insertCommand.Parameters.Add(new SqlParameter("@data_inizio", dataInizio));
        insertCommand.Parameters.Add(new SqlParameter("@data_fine", dataFine));
        insertCommand.Parameters.Add(new SqlParameter("@nome_cliente", nomeCliente));
        insertCommand.Parameters.Add(new SqlParameter("@documenti_id", idDocumentoDaPrestare));

        int affectedRows = insertCommand.ExecuteNonQuery();
    }
    catch (Exception e)
    {
        Console.WriteLine(e.Message);
    }
    finally
    {
        connessioneSql.Close();
    }
 }