namespace Addressbook_web_tests
{
    public class AccountData
    {

        public AccountData(string username, string password)
        { 
            Username = username;
            Password = password;
        }

        public string Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
