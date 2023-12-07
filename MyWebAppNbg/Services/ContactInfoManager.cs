using MyWebAppNbg.Models;

namespace MyWebAppNbg.Services
{
    public class ContactInfoManager : IContactInfoManager
    {
        public ContactInfo ReadContactInfo()
        {
            var contactInfo = new ContactInfo
            {
                Id = 1,
                Name = "Nbg Athens"
            };
            return contactInfo;
        }
    }
}
