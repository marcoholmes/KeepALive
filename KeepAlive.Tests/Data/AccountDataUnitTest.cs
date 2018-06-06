using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using KeepAlive.Core.Domain;
using KeepAlive.Core.Contracts.Data;
using System.Web.Mvc;
using KeepAlive.Data;

namespace KeepAlive.Tests.Data
{
    /// <summary>
    /// Summary description for AccountDataUnitTest
    /// </summary>
    [TestClass]
    public class AccountDataUnitTest
    {

        private IAccountData accountData;

        public AccountDataUnitTest()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        [TestInitialize()]
        public void AccountDataInitialize()
        {
            accountData = DependencyResolver.Current.GetService<AccountData>();
        }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void TestCreateUser()
        {
            User user = new User
            {
                AccountBloccato = false,
                DataRegistrazione = DateTime.Now,
                Email = "poi@poi.it",
                EmailConfermata = false,
                Password = "poiu",
                PasswordHash = new Guid().ToString(),
                UserName = "fakeUSer"
            };

            Assert.IsTrue(accountData.CreateUser(user));
        }
    }
}
