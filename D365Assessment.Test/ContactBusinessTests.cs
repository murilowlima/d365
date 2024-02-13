using D365Assessment.Business;
using D365Assessment.External;
using Microsoft.Xrm.Sdk;

namespace D365Assessment.Test
{
    [TestClass]
    public class ContactBusinessTests
    {
        [TestMethod]
        public void CanGetNewUser()
        {
            string url = "https://randomuser.me/api/";
            ContactBusiness contactBusiness = new ContactBusiness(null, new APIManager(url));

            var contact = contactBusiness.GetNewUser();

            Assert.IsNotNull(contact);
        }
    }
}