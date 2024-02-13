using D365Assessment.External;
using DataverseModel;
using Microsoft.Xrm.Sdk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D365Assessment.Business
{
    public class ContactBusiness
    {
        public IOrganizationService OrganizationService { get; set; }
        public APIManager APIManager { get; set; }
        public ContactBusiness(IOrganizationService organizationService, APIManager apiManager)
        {
            OrganizationService = organizationService;
            APIManager = apiManager;
        }

        public void UploadConctactFromAPI()
        {
            var newContact = GetNewUser();

            Contact d365Contact = new Contact()
            {
                FirstName = newContact.Name.First,
                LastName = newContact.Name.Last,
                JobTitle = newContact.Name.Title,
                MobilePhone = newContact.Phone,
                EmailAddress1 = newContact.Email,
                Address1_AddressTypeCode = Contact_Address1_AddressTypeCode.Primary,
                Address1_City = newContact.Address.City,
                Address1_Line1 = newContact.Address.Street.Name,
                Address1_Line2 = newContact.Address.Street.Number

            };

            OrganizationService.Create(d365Contact);
        }

        public RandomUserDTO GetNewUser()
        {
            var request = APIManager.CreateWebRequest();

            var randomUsersDTO = APIManager.ExecuteRequest<UsersDTO>(request) as UsersDTO;

            return randomUsersDTO?.Users?.FirstOrDefault();
        }
    }
}
