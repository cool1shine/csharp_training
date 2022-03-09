using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Addressbook_web_tests
{
    public class AuthTestBase : TestBase
    {
        [SetUp]
        protected void SetupLogin()
        {
            AccountData user = new AccountData("admin", "secret");
            applicationManager.LoginHelper.Login(user);
        }
    }
}
