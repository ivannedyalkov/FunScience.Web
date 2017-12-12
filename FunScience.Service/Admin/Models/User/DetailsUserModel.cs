namespace FunScience.Service.Admin.Models.User
{
    public class DetailsUserModel
    {
        public string Id { get; set; }

        public string Email { get; set; }
        
        public string FirstName { get; set; }
        
        public string LastName { get; set; }

        public string PhoneNumber { get; set; }

        public string Description { get; set; }
        
        public string Profession { get; set; }
        
        public string FacebookUrlAddress { get; set; }

        public byte[] UserPhoto { get; set; }
    }
}
