// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");


Biblioteca biblioteca = new Biblioteca();
biblioteca.CreaClientiDefault();
biblioteca.CreaDocumentiDefault();

bool programma = true;

while (programma)
{
    Console.WriteLine("Scegliere un'operazione:");
    Console.WriteLine("1 - Registra un nuovo cliente");
    Console.WriteLine("2 - Ricerca documento");
    Console.WriteLine("3 - Effettua prestito");
    Console.WriteLine("4 - Ricerca prestiti");
    Console.WriteLine("9 - Esci");

    int rispostaUtente = Convert.ToInt32(Console.ReadLine());

    switch (rispostaUtente)
    {
        case 1:
            biblioteca.RegistraCliente();
            break;
        case 2:
            biblioteca.RicercaDocumento();
            break;
        case 3:
            biblioteca.EffettuaPrestito();
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