using Lab0_1170919_1132119.Helpers;

namespace Lab0_1170919_1132119.Models
{
    public class ClientModel
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Description { get; set; }

        public bool Save()
        {
            try
            {
                Storage.Instance.clientList.Add(this);
                return true;
            }
            catch 
            {
                return false;
            }
        }
    }
}