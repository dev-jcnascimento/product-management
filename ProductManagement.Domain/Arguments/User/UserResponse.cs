using ProductManagement.Domain.Arguments.Base;

namespace ProductManagement.Domain.Arguments.User
{
    public class UserResponse : ResponseBase
    {
        public Guid Id { get; set; }
        public string NomeCompleto { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }

        public static explicit operator UserResponse(Entities.User entities)
        {
            return new UserResponse()
            {
                Id = entities.Id,
                NomeCompleto = entities.Nome.ToString(),
                Email = entities.Email.Webmail,
                Role = entities.Role.ToString()
            };
        }
    }
}
