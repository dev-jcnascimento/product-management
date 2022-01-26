namespace ProductManagement.Domain.ValueObject
{
    public class Name
    {
        public string FistName { get; private set; }
        public string LastName { get; private set; }
        protected Name()
        {
        }
        public Name(string fistName, string lastName)
        {
            if (string.IsNullOrEmpty(fistName) || fistName.Length > 100)
            {
                throw new Exception("Name cannot be empty and cannot be shorter than 100 characters.");
            }
            FistName = fistName;
            if (string.IsNullOrEmpty(lastName) || lastName.Length > 100)
            {
                throw new Exception("Name cannot be empty and cannot be shorter than 100 characters.");
            }
            LastName = lastName;
        }
        public override string ToString()
        {
            return FistName + " " + LastName;
        }
    }
}
