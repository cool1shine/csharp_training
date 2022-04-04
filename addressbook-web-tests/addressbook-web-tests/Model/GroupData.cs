using System;

namespace Addressbook_web_tests
{
    public class GroupData : IEquatable<GroupData>, IComparable<GroupData>
    {
        public GroupData() { }

        public GroupData(string groupname)
        {
            Groupname = groupname;
        }

        public bool Equals(GroupData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return false;
            }
            if (Object.ReferenceEquals(this, other))
            {
                return true;
            }
            //return Groupname.Equals(other.Groupname, StringComparison.OrdinalIgnoreCase)/* == other.Groupname*/;
            return Groupname == other.Groupname;
        }

        public override int GetHashCode()
        {
            return Groupname.GetHashCode();
        }

        public override string ToString()
        {
            return "Groupname=" + Groupname + "\n"
                    + "Header=" + Header + "\n"
                    + "Footer=" + Footer + "\n";
        }

        public int CompareTo(GroupData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return 1;
            }

            return Groupname.CompareTo(other.Groupname);
        }

        public string Id { get; set; }
        public string Groupname { get; set; }
        public string Header { get; set; }
        public string Footer { get; set; }        
    }
}
