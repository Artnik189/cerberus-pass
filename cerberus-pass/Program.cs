using System.Net.WebSockets;
using cerberus_pass;

var pass1 = new PasswordEntry("Steam", 
"Artnik", 
"P@ssword");
var pass2 = new PasswordEntry("Origin", 
"Artnik", 
"P@ssword", 
"www.origin.com", 
"Traaaaash");

var pass3 = new PasswordEntry(
    "GOG",
    "Artnik",
    "P@ssword",
    "www.gog.com",
    "Good ol' games");

var manager = new PasswordManager();

Console.ForegroundColor = ConsoleColor.DarkRed;
System.Console.WriteLine("Willkommen zu Cerberus-Pass");
Console.ResetColor();

do
{
System.Console.WriteLine("Wähle was du tun willst");

System.Console.WriteLine(@"
1. Passwort-Liste ausgeben
2. Passwort mit ID ausgeben
3. Neues Passwort erstellen
4. Vorhandenes Passwort bearbeiten
5. Passwort löschen
");

var userInput = Console.ReadLine(); 

switch (userInput)
{
    case "1":
    // Liste ausgeben
    var vault = manager.GetAll();
    System.Console.WriteLine(vault);
    break;
    case "2":
    // Passwort vollständig ausgeben
    System.Console.WriteLine("Welchen Eintrag möchtest du sehen? (Title):");
    var title = Console.ReadLine();
    System.Console.WriteLine();
    break;
    case "3":
          // Erstellen
      Console.WriteLine("Gebe einen Titel für den Eintrag an:");
      var title = Console.ReadLine();
      Console.WriteLine("Gebe einen Login für den Eintrag an:");
      var login = Console.ReadLine();
      Console.WriteLine("Gebe ein Passwort für den Eintrag an:");
      var password = Console.ReadLine();
      var newEntry = manager.CreateEntry(title, login, password);
      Console.WriteLine("Neuer Eintrag erfolgreich erstellt:");
      Console.WriteLine(newEntry);
      break;
    case "4":
      // Update
      Console.WriteLine("Welchen Eintrag willst du ändern? (Title):");
      var title_to_change = Console.ReadLine();
      Console.WriteLine(
        "Gebe einen neuen Titel für den Eintrag an (Leer um nichts zu ändern):");
      var new_title = Console.ReadLine();
      Console.WriteLine(
        "Gebe einen neuen Login für den Eintrag an (Leer um nichts zu ändern):");
      var new_login = Console.ReadLine();
      Console.WriteLine(
        "Gebe ein neues Passwort für den Eintrag an (Leer um nichts zu ändern):");
      var new_password = Console.ReadLine();
      var entry = manager.GetEntry(title_to_change);
      var updatedEntry = manager.UpdateEntry(title_to_change, new PasswordEntry(
        String.IsNullOrEmpty(new_title) ? entry.Title : new_title,
        String.IsNullOrEmpty(new_login) ? entry.Login : new_login,
        String.IsNullOrEmpty(new_password) ? entry.Password : new_password
      ));
      Console.WriteLine($"Eintrag {updatedEntry.Title} wurde erfolgreich aktuallisiert.");
      break;
    case "5":
    // Delete
    System.Console.WriteLine("Welchen Eintrag möchtest du löschen (Title):");
    var titleToDelete = Console.ReadLine();
    var success = manager.DeleteEntry(titleToDelete);
    if (success) System.Console.WriteLine($"Eintrag {titleToDelete} wurde gelöscht.");
    else 
    System.Console.WriteLine(
        $"Fehler beim Löschen des Eintrags {titleToDelete} wurde nicht gefunden!");
    break;
    default:
    //Fehler anzeigen -> Eingabe-Hint (1-5)
    // Eingabe wiederholen
    break;
}
Console.ReadKey();
Console.Clear();
} while (true);

// System.Console.WriteLine("\n\nProgramm Ende");


