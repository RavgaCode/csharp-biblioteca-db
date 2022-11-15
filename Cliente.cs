// See https://aka.ms/new-console-template for more information
public class Cliente
{
    public string Cognome { get; set; }
    public string Nome { get; set; }
    public string Email { get; set; }
    public string Telefono { get; set; }

    public Cliente(string cognome, string nome, string email, string telefono)
    {
        Cognome = cognome;
        Nome = nome;
        Email = email;
        Telefono = telefono;
    }
}