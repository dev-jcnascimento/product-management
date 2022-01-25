using ProductManagement.Domain.Entities.Base;
using ProductManagement.Domain.Enum;
using ProductManagement.Domain.ValueObject;
using System.Runtime.InteropServices;
using System.Text.Json.Serialization;

namespace ProductManagement.Domain.Entities
{
    public class User : EntityBase
    {
        public virtual Name Nome { get; private set; }
        public virtual Email Email { get; private set; }
        public virtual Password Password { get; private set; }
        public Roles Role { get; private set; }
        public ICollection<Stock> UserStocks { get; set; }
        protected User()
        {
        }
        [JsonConstructor]
        public User(Email email, Password password)
        {
            Email = email;
            Password = password;
        }
        public User(Name nome, Email email, Password password, [Optional] Roles role)
        {
            Nome = nome;
            Email = email;
            Password = password;
            if (role.ToString() == null)
            {
                Role = Roles.User;
            }
            Role = role;
        }
        public void UpdateRole(string role)
        {
            switch (role.ToLower())
            {
                case "admin":
                    Role = Roles.Admin;
                    break;
                case "employee":
                    Role = Roles.Employee;
                    break;
                default: 
                    Role = Roles.User;
                    break;
            }
        }
        public void UpdateUser(Name nome, Email email)
        {
            Nome = nome;
            Email = email;
        }
    }
}
