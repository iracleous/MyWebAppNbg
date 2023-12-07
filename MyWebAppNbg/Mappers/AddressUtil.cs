using MyWebAppNbg.Entities;
using MyWebAppNbg.Models;

namespace MyWebAppNbg.Mappers
{
    public static class AddressHelper
    {
        public static AddressData GetAddressData(ContactInfo contactInfo)
        {
            return new AddressData
            {
                Id = contactInfo.Id,
                AddressDetails = "Info = " + contactInfo.Name
            };
        }
        public static ContactInfo GetContactInfo(AddressData addressData)
        {
            return new ContactInfo 
            { 
                Id = addressData.Id, 
                Name = addressData.AddressDetails 
            };
        }
    }
}
