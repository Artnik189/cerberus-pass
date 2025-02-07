namespace cerberus_pass;

public class PasswordEntry
{
    public string Title {get; set;}
    public string Login {get; set;}
    public string Password {get; set;}
    public string Website {get; set;}
    public string Note {get; set;}

    public PasswordEntry (string title, 
    string login, 
    string password, 
    string website = "", 
    string note = "")
    {
        Title = title;
        Login = login;
        Password = password;
        Website = website;
        Note = note;
    }

    // ToString-Method wird überschrieben
    // Wird implizit von der Console.Writeline aufgerufen?
    public override string ToString()
    {
        return $"{Title}\t{Website}\t{Login}";
    }
}