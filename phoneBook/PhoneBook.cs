using System;
using System.Collections.Generic;

namespace SimplePhoneBookApp
{
    public class PhoneBook : IPhoneBook
    {
        private static List<Contact> contacts = new List<Contact>();

        public PhoneBook()
        {
            // Fake contacts
            contacts.Add(new Contact("Raif", "Çınar", "05311112233"));
            contacts.Add(new Contact("Tam", "Weblik", "05322223344"));
            contacts.Add(new Contact("Patika", "Dev", "02123334455"));
            contacts.Add(new Contact("Jane", "Doe", "05334445566"));
            contacts.Add(new Contact("John", "Doe", "05345556677"));

        }

        public void AddNewContact()
        {
            Console.WriteLine("\n***** ADD A NEW CONTACT *****");

            string name = "", surname = "", number = "";

            bool nameIsValid = false, surnameIsValid = false, numberIsValid = false;

            while (true)
            {
                if (!nameIsValid)
                {
                    Console.Write("Please enter Name: ");
                    name = Console.ReadLine().Trim();

                    if (string.IsNullOrEmpty(name))
                        Console.WriteLine("Name cannot be empty!");
                    else
                        nameIsValid = true;
                }
                else if (!surnameIsValid)
                {
                    Console.Write("Please enter Surname: ");
                    surname = Console.ReadLine().Trim();

                    if (string.IsNullOrEmpty(surname))
                        Console.WriteLine("Surname cannot be empty!");
                    else
                        surnameIsValid = true;
                }
                else if (!numberIsValid)
                {
                    Console.Write("Please enter the 11 digit phone number: ");
                    number = Console.ReadLine().Trim();

                    if (string.IsNullOrEmpty(number))
                        Console.WriteLine("Phone number cannot be empty!");
                    else if (number.Length == 11)
                    {
                        if (long.TryParse(number, out long longNum) == false)
                        {
                            Console.WriteLine("You entered an invalid phone number. Please try again.");
                        }
                        else
                        {
                            numberIsValid = true;
                        }
                    }
                    else
                        Console.WriteLine("The phone number must be 11 digits. Please try again.");
                }

                if (nameIsValid && surnameIsValid && numberIsValid)
                    break;
            }

            contacts.Add(new Contact(name, surname, number));

            Console.WriteLine(name + " " + surname + " has been added to the Phonebook.");

            PreferencesOrExitMenu();
        }

        public void DeleteContact()
        {
            Console.WriteLine("\n**************** DELETE EXISTING CONTACT *****************");
            bool isChoiceOk = false;
            int choose = 0;
            while (!isChoiceOk)
            {
                Console.WriteLine("Please write the number of the transaction you want to do.");
                Console.WriteLine("----------------------------------------------------------");
                Console.WriteLine(""
                    + "(1) Delete by name,\n"
                    + "(2) Delete by surname,\n"
                    + "(3) Delete by phone number,\n"
                    + "(4) Return to main menu... ,\n"
                    );

                string userInput = Console.ReadLine().Trim();

                if (userInput.Equals("1"))
                {
                    isChoiceOk = true;
                    choose = 1;
                }
                else if (userInput.Equals("2"))
                {
                    isChoiceOk = true;
                    choose = 2;
                }
                else if (userInput.Equals("3"))
                {
                    isChoiceOk = true;
                    choose = 3;
                }
                else if (userInput.Equals("4"))
                {
                    isChoiceOk = true;
                    choose = 4;
                }
                else
                {
                    Console.WriteLine("Invalid entry!");
                    isChoiceOk = false;
                    choose = 0;
                }
            }

            switch (choose)
            {
                case 1:
                    DeleteByName();
                    break;
                case 2:
                    DeleteBySurname();
                    break;
                case 3:
                    DeleteByPhoneNumber();
                    break;
                case 4:
                    ReturnToMainMenu();
                    break;
            }
        }

        private void DeleteByName()
        {
            Console.WriteLine("Enter the contact name you want to delete.");

            string name = Console.ReadLine().Trim();
            Contact contact = GetContactByName(name);

            if (contact == null)
            {
                Console.WriteLine("Name: {" + name + "} invalid or not found!");
            TrayAgainForName:
                Console.WriteLine(""
                        + "(1) Try again,\n"
                        + "(2) Return to main menu.\n"
                        );
                string choose = Console.ReadLine();
                if (choose.Equals("1"))
                {
                    DeleteByName();
                }
                else if (choose.Equals("2"))
                {
                    ReturnToMainMenu();
                }
                else
                {
                    Console.WriteLine("Invalid entry!");
                    goto TrayAgainForName;
                }
            }
            else
            {
                while (true)
                {
                    Console.WriteLine("{" + contact.GetFullName + ", " + contact.ContactPhoneNumber + "} will be deleted from phone book. Do you confirm? (y/n)");

                    string confirm = Console.ReadLine();
                    if (confirm.Equals("y", StringComparison.InvariantCultureIgnoreCase))
                    {
                        Console.WriteLine(contact.GetFullName + " has been deleted.");
                        contacts.Remove(contact);
                        break;
                    }
                    else if (confirm.Equals("n", StringComparison.InvariantCultureIgnoreCase))
                    {
                        Console.WriteLine("Contact deletion was cancelled.");
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Invalid entry!");
                    }
                }

                ReturnToMainMenu();
            }
        }

        private void DeleteBySurname()
        {
            Console.WriteLine("Enter the contact surname you want to delete.");

            string surname = Console.ReadLine().Trim();
            Contact contact = GetContactBySurname(surname);

            if (contact == null)
            {
                Console.WriteLine("Surname: {" + surname + "} invalid or not found!");

            TrayAgainForSurname:

                Console.WriteLine(""
                        + "(1) Try again,\n"
                        + "(2) Return to main menu.\n"
                        );
                string choose = Console.ReadLine();
                if (choose.Equals("1"))
                {
                    DeleteBySurname();
                }
                else if (choose.Equals("2"))
                {
                    ReturnToMainMenu();
                }
                else
                {
                    Console.WriteLine("Invalid entry!");
                    goto TrayAgainForSurname;
                }
            }
            else
            {
                while (true)
                {
                    Console.WriteLine("{" + contact.GetFullName + ", " + contact.ContactPhoneNumber + "} will be deleted from phone book. Do you confirm? (y/n)");

                    string confirm = Console.ReadLine();
                    if (confirm.Equals("y", StringComparison.InvariantCultureIgnoreCase))
                    {
                        Console.WriteLine(contact.GetFullName + " has been deleted.");
                        contacts.Remove(contact);
                        break;
                    }
                    else if (confirm.Equals("n", StringComparison.InvariantCultureIgnoreCase))
                    {
                        Console.WriteLine("Contact deletion was cancelled.");
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Invalid entry!");
                    }
                }

                ReturnToMainMenu();
            }
        }

        private void DeleteByPhoneNumber()
        {
            Console.WriteLine("Please enter the 11-digit phone number that you want to delete.");

            string number = Console.ReadLine().Trim();
            Contact contact = GetContactByPhoneNumber(number);

            if (contact == null)
            {
                Console.WriteLine("Number: {" + number + "} invalid or not found!");
            TryAgainForNumber:
                Console.WriteLine(""
                        + "(1) Try again,\n"
                        + "(2) Return to main menu.\n"
                        );
                string choose = Console.ReadLine();
                if (choose.Equals("1"))
                {
                    DeleteByPhoneNumber();
                }
                else if (choose.Equals("2"))
                {
                    ReturnToMainMenu();
                }
                else
                {
                    Console.WriteLine("Invalid entry!");
                    goto TryAgainForNumber;
                }
            }
            else
            {
                while (true)
                {
                    Console.WriteLine("{" + contact.GetFullName + ", " + contact.ContactPhoneNumber + "} will be deleted from phone book. Do you confirm? (y/n)");

                    string confirm = Console.ReadLine();
                    if (confirm.Equals("y", StringComparison.InvariantCultureIgnoreCase))
                    {
                        Console.WriteLine("{" + contact.GetFullName + ", " + contact.ContactPhoneNumber + "} has been deleted.");
                        contacts.Remove(contact);
                        break;
                    }
                    else if (confirm.Equals("n", StringComparison.InvariantCultureIgnoreCase))
                    {
                        Console.WriteLine("Contact deletion was cancelled.");
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Invalid entry!");
                    }
                }

                ReturnToMainMenu();
            }
        }

        public void ExitPhoneBook()
        {

        }

        public void ListAllContacts()
        {
            Console.WriteLine("\n********************** ALL CONTACTS **********************");
            Console.WriteLine("----------------------------------------------------------");

            foreach (Contact contact in contacts)
            {
                Console.Write("\n"
                    + "Name          : {" + contact.ContactName
                    + "}\nSurname       : {" + contact.ContactSurname
                    + "}\nPhone Number  : {" + contact.ContactPhoneNumber
                    + "}\n-\n");
            }

            ReturnToMainMenu();
        }

        public void SearchContact()
        {
            Console.WriteLine("\n********************* SEARCH CONTACT *********************");


        TryAgainForSearch:
            bool isChoiceOk = false;
            int choose = 0;
            while (!isChoiceOk)
            {
                Console.WriteLine("Please write the number of the transaction you want to do.");
                Console.WriteLine("----------------------------------------------------------");
                Console.WriteLine(""
                    + "(1) Search by name,\n"
                    + "(2) Search by surname,\n"
                    + "(3) Search by phone number,\n"
                    + "(4) Return to main menu... ,\n"
                    );

                string userInput = Console.ReadLine().Trim();

                if (userInput.Equals("1"))
                {
                    isChoiceOk = true;
                    choose = 1;
                }
                else if (userInput.Equals("2"))
                {
                    isChoiceOk = true;
                    choose = 2;
                }
                else if (userInput.Equals("3"))
                {
                    isChoiceOk = true;
                    choose = 3;
                }
                else if (userInput.Equals("4"))
                {
                    isChoiceOk = true;
                    choose = 4;
                }
                else
                {
                    Console.WriteLine("Invalid entry!");
                    isChoiceOk = false;
                    choose = 0;
                }
            }

            Contact contact = null;
            bool found = true;
            switch (choose)
            {
                case 1:
                    Console.WriteLine("Please enter contact name.");
                    string name = Console.ReadLine().Trim();
                    contact = GetContactByName(name);
                    if (contact == null)
                    {
                        Console.WriteLine("Name: {" + name + "} not found!");
                        goto TryAgainForSearch;
                    }
                    break;
                case 2:
                    Console.WriteLine("Please enter contact surname.");
                    string surname = Console.ReadLine().Trim();
                    contact = GetContactBySurname(surname);
                    if (contact == null)
                    {
                        Console.WriteLine("Surname: {" + surname + "} not found!");
                        goto TryAgainForSearch;
                    }
                    break;
                case 3:
                    Console.WriteLine("Please enter phone number.");
                    string number = Console.ReadLine().Trim();
                    contact = GetContactByPhoneNumber(number);
                    if (contact == null)
                    {
                        Console.WriteLine("Phone Number: {" + number + "} not found!");
                        goto TryAgainForSearch;
                    }
                    break;
                case 4:
                    found = false;
                    ReturnToMainMenu();
                    break;
            }

            if (found)
            {
                Console.WriteLine(contact.ToString());
                ReturnToMainMenu();
            }
        }

        private Contact GetContactByName(string name)
        {
            foreach (Contact contact in contacts)
            {
                if (contact.ContactName.Equals(name, StringComparison.InvariantCultureIgnoreCase))
                    return contact;
            }
            return null;
        }

        private Contact GetContactBySurname(string surname)
        {
            foreach (Contact contact in contacts)
            {
                if (contact.ContactSurname.Equals(surname, StringComparison.InvariantCultureIgnoreCase))
                    return contact;
            }
            return null;
        }

        private Contact GetContactByPhoneNumber(string number)
        {
            foreach (Contact contact in contacts)
            {
                if (contact.ContactPhoneNumber.Equals(number, StringComparison.InvariantCultureIgnoreCase))
                    return contact;
            }
            return null;
        }

        public void PreferencesOrExitMenu()
        {
            Console.WriteLine("\nPlease write the number of the transaction you want to do.");
            Console.WriteLine("----------------------------------------------------------");

            Console.WriteLine(""
                + "(0) Close the phone book and finish the program!\n"
                + "(1) Return To Main Menu...,\n"
                );

            string input = Console.ReadLine().Trim();

            if (input.Equals("0"))
                ExitPhoneBook();
            else if (input.Equals("1"))
                ReturnToMainMenu();
            else
            {
                Console.WriteLine("\nYou have entered invalid.");
                PreferencesOrExitMenu();
            }
        }

        private void ReturnToMainMenu()
        {
            Program.PhoneBookMainMenu(this);
        }

        public void UpdateContact()
        {
            Console.WriteLine("\n********************* UPDATE CONTACT *********************");
        TryAgainForUpdate:
            bool isChoiceOk = false;
            int choose = 0;
            while (!isChoiceOk)
            {
                Console.WriteLine("Please write the number of the transaction you want to do.");
                Console.WriteLine("----------------------------------------------------------");
                Console.WriteLine(""
                    + "(1) Name update,\n"
                    + "(2) Surname update,\n"
                    + "(3) Phone number update,\n"
                    + "(4) Return to main menu... ,\n"
                    );

                string userInput = Console.ReadLine().Trim();

                if (userInput.Equals("1"))
                {
                    isChoiceOk = true;
                    choose = 1;
                }
                else if (userInput.Equals("2"))
                {
                    isChoiceOk = true;
                    choose = 2;
                }
                else if (userInput.Equals("3"))
                {
                    isChoiceOk = true;
                    choose = 3;
                }
                else if (userInput.Equals("4"))
                {
                    isChoiceOk = true;
                    choose = 4;
                }
                else
                {
                    Console.WriteLine("Invalid entry!");
                    isChoiceOk = false;
                }
            }

            Contact contact = null;
            bool found = true;
            switch (choose)
            {
                case 1:
                    Console.WriteLine("Please enter the updated name.");
                    string name = Console.ReadLine().Trim();
                    contact = GetContactByName(name);
                    if (contact == null)
                    {
                        Console.WriteLine("Name: {" + name + "} not found!");
                        goto TryAgainForUpdate;
                    }

                    Console.WriteLine("Please enter the new name.");
                    string newName = Console.ReadLine().Trim();
                    if (string.IsNullOrEmpty(newName))
                    {
                        Console.WriteLine("New name cannot be empty!");
                        goto TryAgainForUpdate;
                    }
                    contact.ContactName = newName;
                    break;
                case 2:
                    Console.WriteLine("Please enter the updated surname.");
                    string surname = Console.ReadLine().Trim();
                    contact = GetContactBySurname(surname);
                    if (contact == null)
                    {
                        Console.WriteLine("Surname: {" + surname + "} not found!");
                        goto TryAgainForUpdate;
                    }
                    Console.WriteLine("Please enter the new surname.");
                    string newSurname = Console.ReadLine().Trim();
                    if (string.IsNullOrEmpty(newSurname))
                    {
                        Console.WriteLine("New surname cannot be empty!");
                        goto TryAgainForUpdate;
                    }
                    contact.ContactSurname = newSurname;
                    break;
                case 3:
                    Console.WriteLine("Please enter the updated phone number.");
                    string number = Console.ReadLine().Trim();
                    contact = GetContactByPhoneNumber(number);
                    if (contact == null)
                    {
                        Console.WriteLine("Phone Number: {" + number + "} not found!");
                        goto TryAgainForUpdate;
                    }
                    Console.WriteLine("Please enter the new 11 digit phone number.");
                    string newPhoneNumber = Console.ReadLine().Trim();
                    if (string.IsNullOrEmpty(newPhoneNumber))
                    {
                        Console.WriteLine("New phone number cannot be empty!");
                        goto TryAgainForUpdate;
                    }
                    else if (newPhoneNumber.Length == 11)
                    {
                        if (long.TryParse(number, out long longNum) == false)
                        {
                            Console.WriteLine("You entered an invalid phone number. Please try again.");
                            goto TryAgainForUpdate;
                        }
                    }
                    contact.ContactPhoneNumber = newPhoneNumber;
                    break;
                case 4:
                    found = false;
                    ReturnToMainMenu();
                    break;
            }

            if (found)
            {
                Console.WriteLine("Phone book updated.");
                ReturnToMainMenu();
            }
        }

    }
}