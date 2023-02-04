namespace SimplePhoneBookApp
{
    public interface IPhoneBook
    {
        void AddNewContact();

        void DeleteContact();

        void UpdateContact();

        void ListAllContacts();

        void SearchContact();

        void PreferencesOrExitMenu();

        void ExitPhoneBook();
    }
}