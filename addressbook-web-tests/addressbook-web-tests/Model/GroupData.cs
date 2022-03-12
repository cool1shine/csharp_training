﻿using System;

namespace Addressbook_web_tests
{
    public class GroupData : IEquatable<GroupData>
    {
        private string groupname;
        private string header = null;
        private string footer = null;


        public GroupData(string groupname)
        {
            this.groupname = groupname;
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
            return Groupname == other.Groupname;
        }

        public int GetHashCode()
        { 
            return Groupname.GetHashCode();
        }

        public string Groupname
        {
            get
            {
                return groupname;
            }
            set
            {
                groupname = value;
            }
        }

        public string Header
        {
            get
            {
                return header;
            }
            set
            {
                header = value;
            }
        }

        public string Footer
        {
            get
            {
                return footer;
            }
            set
            {
                footer = value;
            }
        }

    }
}
