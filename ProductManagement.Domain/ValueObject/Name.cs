using System.ComponentModel.DataAnnotations.Schema;

namespace ProductManagement.Domain.ValueObject
{
    
    public class Name
    {
        public string FistName { get;private set; }
        public string LastName { get;private set; }
        protected Name()
        {
        }
        public Name(string fistName, string lastName)
        {
            if (string.IsNullOrEmpty(fistName) || fistName.Length > 30)
            {
                throw new Exception("Name cannot be empty and cannot be shorter than 30 characters.");
            }
            FistName = fistName;
            if (string.IsNullOrEmpty(lastName) || lastName.Length > 30)
            {
                throw new Exception("Name cannot be empty and cannot be shorter than 30 characters.");
            }
            LastName = lastName;
        }
        public override string ToString()
        {
            return FistName + " " + LastName;
        }
    }
}
