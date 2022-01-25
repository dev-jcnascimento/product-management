using ProductManagement.Domain.Extensions;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductManagement.Domain.ValueObject
{
  
    public class Password
    {
        public string Word { get;private set; }
        protected Password()
        {
        }
        public Password(string word)
        {
            if (string.IsNullOrEmpty(word))
            {
                throw new Exception("Enter a Password!");
            }
            if (word.Length < 6)
            {
                throw new Exception("Enter a password of at least 6 characters.");
            }
            Word = word.ConvertToMD5();
        }
    }
}
