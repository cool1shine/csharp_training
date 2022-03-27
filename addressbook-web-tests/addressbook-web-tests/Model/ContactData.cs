using System;

namespace Addressbook_web_tests
{
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {     
        private string firstname = null;
        private string middlename = null;
        private string lastname = null;
        private string nickname = null;
        private string title = null;
        private string company = null;
        private string address = null;
        private string home = null;
        private string mobile = null;
        private string work = null;
        private string fax = null;
        private string email = null;
        private string email2 = null;
        private string email3 = null;
        private string homepage = null;

        //Не получается сделать выбор даты
        //private string bday = "1";
        //private string bmonth = "January";
        //private string byear = "2000";
        //private string aday = "1";
        //private string amonth = "January";
        //private string ayear = "2000";

        private string address2 = null;
        private string phone2 = null;
        private string notes = null;

        public ContactData(string firstname, string lastname)
        {
            this.firstname = firstname;
            this.lastname = lastname;
        }

        public bool Equals(ContactData other)
        {
            if(Object.ReferenceEquals(other, null))
            {
                return false;
            }
            if (Object.ReferenceEquals(this, other))
            {
                return true;
            }
            return (Firstname + " " + Lastname) == (other.Firstname + " " + other.Lastname);
        }

        public override int GetHashCode()
        {
            return (Firstname + " " + Lastname).GetHashCode();
        }

        public override string ToString()
        {
            return Firstname + " " + Lastname;
        }

        public int CompareTo(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return 1;
            }
            if (Firstname.CompareTo(other.Firstname) == 0)
            {
                return Lastname.CompareTo(other.Lastname);
            }
            //return (Firstname + " " + Lastname).CompareTo(other.Firstname + " " + other.Lastname);
            return Firstname.CompareTo(other.Firstname);
        }

        public string Firstname
        { get { return firstname; } set { firstname = value; } }
        public string Middlename
        { get { return middlename; } set { middlename = value; } }
        public string Lastname
        { get { return lastname; } set { lastname = value; } }
        public string Nickname
        { get { return nickname; } set { nickname = value; } }
        public string Title
        { get { return title; } set { title = value; } }
        public string Company
        { get { return company; } set { company = value; } }
        public string Address
        { get { return address; } set { address = value; } }
        public string Home
        { get { return home; } set { home = value; } }
        public string Mobile
        { get { return mobile; } set { mobile = value; } }
        public string Work
        { get { return work; } set { work = value; } }
        public string Fax
        { get { return fax; } set { fax = value; } }
        public string Email
        { get { return email; } set { email = value; } }
        public string Email2
        { get { return email2; } set { email2 = value; } }
        public string Email3
        { get { return email3; } set { email3 = value; } }
        public string Homepage
        { get { return homepage; } set { homepage = value; } }

        //Не получается сделать выбор даты
        //public string Bday
        //{ get { return bday; } set { bday = value; } }
        //public string Bmonth
        //{ get { return bmonth; } set { bmonth = value; } }
        //public string Byear
        //{ get { return byear; } set { byear = value; } }
        //public string Aday
        //{ get { return aday; } set { aday = value; } }
        //public string Amonth
        //{ get { return amonth; } set { amonth = value; } }
        //public string Ayear
        //{ get { return ayear; } set { ayear = value; } }

        public string Address2
        { get { return address2; } set { address2 = value; } }
        public string Phone2
        { get { return phone2; } set { phone2 = value; } }
        public string Notes
        { get { return notes; } set { notes = value; } }
    }
}
