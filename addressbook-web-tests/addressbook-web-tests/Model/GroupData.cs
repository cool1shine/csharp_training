namespace Addressbook_web_tests
{
    public class GroupData
    {
        private string groupname;
        private string header = null;
        private string footer = null;


        public GroupData(string groupname)
        {
            this.groupname = groupname;
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
