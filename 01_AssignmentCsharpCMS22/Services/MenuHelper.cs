using _01_AssignmentCsharpCMS22.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_AssignmentCsharpCMS22.Services
{
    internal interface IMenuHelper
    {
        internal void GetMenu();
        internal void CreateContact();
        internal void GetAll();
        internal void GetContact();
        internal void RemoveContact();
        internal void Exit();
    }
    internal class MenuHelper
    {
        // Lista för att spara kontakterna i
        public List<Contact> contacts = new();
        // Sökväg för var min fil sparas
        string filePath = @$"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\Addressbook.json";
        // Skapar en metod som kör min meny
        // Därefter en switch som för en till nästa fönster beroende på det val man gjort
        internal void GetMenu()
        {
            Console.Clear();
            Console.WriteLine("/// Addressbook ///");
            Console.WriteLine("\n1. Create and save a new contact");
            Console.WriteLine("2. View list of contacts");
            Console.WriteLine("3. View and edit a specific contact");
            Console.WriteLine("4. Remove/delete a contact");
            Console.WriteLine("5. Exit addressbook");
            Console.Write("\nChoose one option please: ");

            var option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    CreateContact();
                    break;
                case "2":
                    GetAll(contacts);
                    break;
                case "3":
                    GetContact(ref contacts);
                    break;
                case "4":
                    RemoveContact(ref contacts);
                    break;
                case "5":
                    Exit();
                    break;
                default:
                    Console.WriteLine("Please choose a number :-))))");
                    break;
            }
        }
        // En metod för att skapa en kontakt i adressboken
        // Instansierar contact och skickar till listan Contact
        // Returnerar "värdet" (contact) till (contacts)listan med hjälp av en .add
        internal void CreateContact()
        {
            Console.Clear();
            Console.WriteLine("Create a contact for your addressbook");
            var contact = new Contact();

            Console.Write("First name: "); contact.FirstName = Console.ReadLine() ?? "";
            Console.Write("Last name: "); contact.LastName = Console.ReadLine() ?? "";
            Console.Write("Adress: "); contact.Address = Console.ReadLine() ?? "";
            Console.Write("Email: "); contact.Email = Console.ReadLine() ?? "";
            try
            {
                Console.Write("Phonenumber: "); contact.PhoneNumber = decimal.Parse(Console.ReadLine() ?? "0.0");
            }
            catch
            {
                Console.WriteLine("(If you wrote letters instead of numbers here, your contact won't have a phonenumber)");
            }
            Console.WriteLine("\nYour contact has been added");

            contacts.Add(contact);
            /*
            var json = JsonConvert.SerializeObject(contacts);
            Console.WriteLine(json);
            FileManager.Save(filePath, json);
            */
            Console.ReadKey();

        }
        // En metod för att lista upp alla kontakter i adressboken med hjälp av en foreach-loop
        internal static void GetAll(List<Contact> list)
        {
            Console.Clear();
            Console.WriteLine("Viewing your addressbook\n");
            foreach (var contact in list)
            {
                Console.WriteLine($"{contact.FirstName} - {contact.LastName} - {contact.Address} - {contact.Email} - {contact.PhoneNumber}");
            }
            Console.ReadKey();

            // Här tänkte jag att min read-del från json-filen skulle visas men funkade ju inte såatte... 
        }

        // En metod för att visa enskild kontakt samt kunna editera
        // Foreach-loopen visar id och efternamn
        // Du får sedan välja den du vill kunna se detaljerad info om via ett guid-nr
        // Efter det en do while-loop med en switch där editeringen sköts
        // Reffar tillbaka den till "min" lista, eller "den här specifika listan" genom ref list efter editering.

        internal void GetContact(ref List<Contact> list)
        {
            Console.Clear();
            foreach (var contact in list)
            {
                Console.WriteLine($"{contact.Id} - {contact.Email}");
            }
            Console.WriteLine("\nHere's a list of your contacts. Whom would you like to see more information about and edit");
            Console.Write("\nPlease enter id: ");
            var id = Guid.Parse(Console.ReadLine() ?? "");
            var contact1 = contacts.FirstOrDefault(x => x.Id == id);
            Console.WriteLine($"\n{contact1!.FirstName} - {contact1.LastName} - {contact1.Address} - {contact1.Email} - {contact1.PhoneNumber}");
            Console.ReadKey();

            do
            {
                Console.Clear();
                Console.WriteLine("What would you like to update?");
                Console.WriteLine("\n1. First name");
                Console.WriteLine("2. Last name");
                Console.WriteLine("3. Address");
                Console.WriteLine("4. Email");
                Console.WriteLine("5. Phonenumber");
                Console.WriteLine("6. Exit the edit menu");
                Console.Write("\nChoose one option please: ");

                switch (Console.ReadLine())
                {
                    case "1":
                        Console.Clear();
                        Console.Write("Enter new first name: ");
                        var firstName = Console.ReadLine();
                        contact1!.FirstName = firstName!;
                        break;
                    case "2":
                        Console.Clear();
                        Console.Write("Enter new last name: ");
                        var lastName = Console.ReadLine();
                        contact1!.LastName = lastName!;
                        break;
                    case "3":
                        Console.Clear();
                        Console.Write("Enter new address: ");
                        var address = Console.ReadLine();
                        contact1!.Address = address!;
                        break;
                    case "4":
                        Console.Clear();
                        Console.Write("Enter new email: ");
                        var email = Console.ReadLine();
                        contact1!.Email = email!;
                        break;
                    case "5":
                        Console.Clear();
                        Console.Write("Enter new phone number: ");
                        try
                        {
                            var phoneNumber = decimal.Parse(Console.ReadLine() ?? "0.0");
                            contact1!.PhoneNumber = phoneNumber!;
                        }
                        catch
                        {
                            Console.WriteLine("No new number was saved because you used letters instead of a decimal number with pin point accuracy :-)");
                        }
                        break;
                    case "6":
                        Console.Clear();
                        Console.WriteLine("Exiting the editing menu");
                        Console.ReadKey();
                        return;
                    default:
                        Console.Clear();
                        Console.WriteLine("Please choose a number :-))))");
                        break;
                }
            } while (true);
        }

        // En metod för att ta bort och uppdatera kontaktlistan
        // Tänker mig att man listar upp alla kontakter (med guid-id) och därefter raderar den specifika kontakt man anger id:t på.
        // Gör även en void här då ref uppdaterar listan med det nya värdet (att man raderat kontakten).

        internal static void RemoveContact(ref List<Contact> list)
        {
            Console.Clear();
            Console.WriteLine("Addressbook contains following contacts:");
            foreach (var contact in list)
            {
                
                Console.WriteLine($"{contact.Id} - {contact.FirstName} - {contact.LastName} - {contact.PhoneNumber}");
            }
            try
            {
                Console.WriteLine("\nRemove contact in addressbook using their designated id");
                var Id = Console.ReadLine();

                list = list.Where(x => x.Id.ToString() != (Id)).ToList();
                Console.WriteLine("Your contact has been removed from the addressbook");
                Console.ReadKey();
            }
            catch
            {
                Console.WriteLine("Failed to remove");
                Console.ReadKey();
            }


        }
        // En metod för att stänga av programmet
        internal static void Exit()
        {
            Console.Clear();
            Console.WriteLine("Exiting app");
            Console.ReadKey();
            Environment.Exit(0);
        }
    }
}
