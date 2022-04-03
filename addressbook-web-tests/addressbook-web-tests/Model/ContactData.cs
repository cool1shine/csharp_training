using System.Text.RegularExpressions;
using System;

namespace Addressbook_web_tests
{
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {
        private string phones;
        private string emails;
        private string viewForm;

        public ContactData() { }

        public ContactData(string firstname, string lastname)
        {
            Firstname = firstname;
            Lastname = lastname;
        }

        public bool Equals(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
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

        private string CleanUpPhones(string phone)
        {
            if (phone == null || phone == "")
            {
                return "";
            }

            return Regex.Replace(phone, "[ ./<>()-]", "") + "\r\n";

            //return phone.Replace(" ", "")
            //            .Replace("-", "")
            //            .Replace("(", "")
            //            .Replace(")", "")
            //            + "\r\n";

        }

        private string CleanUpEmails(string email)
        {
            if (email == null || email == "")
            {
                return "";
            }

            return email + "\r\n";
        }

        public string Phones
        {
            get
            {
                if (phones != null)
                {
                    return phones;
                }
                else
                {
                    return (CleanUpPhones(Home) + CleanUpPhones(Mobile) + CleanUpPhones(Work))
                           .Trim();
                }
            }
            set
            {
                phones = value;
            }
        }

        public string Emails
        {
            get
            {
                if (emails != null)
                {
                    return emails;
                }
                else
                {
                    return (CleanUpEmails(Email) + CleanUpEmails(Email2) + CleanUpEmails(Email3)).Trim();
                }
            }
            set
            {
                emails = value;
            }
        }

        public string ViewForm
        {
            get
            {
                if (viewForm != null)
                {
                    return viewForm;
                }
                else
                {
                    string sumString = Firstname + Lastname + Address + Phones + Emails;
                    sumString = sumString.Replace("\r\n", "");
                    return sumString;
                }
            }
            set
            {
                viewForm = value;
            }
        }

        public string Id { get; set; }
        public string Firstname { get; set; }
        public string Middlename { get; set; }
        public string Lastname { get; set; }
        public string Nickname { get; set; }
        public string Title { get; set; }
        public string Company { get; set; }
        public string Address { get; set; }
        public string Home { get; set; }
        public string Mobile { get; set; }
        public string Work { get; set; }
        public string Fax { get; set; }        
        public string Email { get; set; }
        public string Email2 { get; set; }
        public string Email3 { get; set; }
        public string Homepage { get; set; }
        //Не получается сделать выбор даты
        //public string Bday { get; set; }
        //public string Bmonth { get; set; }
        //public string Byear { get; set; }
        //public string Aday { get; set; }
        //public string Amonth { get; set; }
        //public string Ayear { get; set; }
        public string Address2 { get; set; }
        public string Phone2 { get; set; }
        public string Notes { get; set; }
    }
}
