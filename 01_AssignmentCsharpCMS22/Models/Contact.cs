using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_AssignmentCsharpCMS22.Models

{
    // Skapar olika värden att kunna läsa/skriva in. (getters/setters)
    // Skapar en constructor (som vi kan ladda med data/värden i våra objekt) med de parametrar som ska fyllas i och en tom som fångar upp ifall man inte skriver något.)
    // Internal som access modifier "eftersom det endast ska vara" inom detta projekt
    internal class Contact
    {
        internal Contact()
        {
        }

        internal Contact(Guid id, string firstName, string lastName, string email, string address, decimal phoneNumber)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Address = address;
            PhoneNumber = phoneNumber;
        }

        internal Guid Id { get; set; } = Guid.NewGuid();
        internal string FirstName { get; set; } = null!;
        internal string LastName { get; set; } = null!;
        internal string Email { get; set; } = null!;
        internal string Address { get; set; } = null!;
        internal decimal PhoneNumber { get; set; }
    }
}

