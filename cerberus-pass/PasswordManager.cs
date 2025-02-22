namespace cerberus_pass;

public class PasswordManager
{
    private List<PasswordEntry> vault;

    public PasswordManager()
    {
        vault = [];
    }
    public List<PasswordEntry> GetAll() => vault;

    public PasswordEntry CreateEntry(
        string title,
        string login,
        string password,
        string website = "",
        string note = "")
    {
        var newEntry = new PasswordEntry(
            title,
            login,
            password,
            website,
            note
        );
        vault.Add(newEntry);
        return newEntry;
    }

    // GetEntry
public PasswordEntry GetEntry(string title) => 
vault.Find(x => x.Title == title);

    // UpdateEntry

    public PasswordEntry UpdateEntry(string titleToChange, PasswordEntry newEntry)
    {
       var indexToUpdate = vault.FindIndex(
        x => x.Title == titleToChange);
        vault[indexToUpdate] = newEntry;
        return vault[indexToUpdate];
       
    }

    // DeleteEntry
    public bool DeleteEntry(string titleToDelete) =>
    // bei Tobi schauen
    
}