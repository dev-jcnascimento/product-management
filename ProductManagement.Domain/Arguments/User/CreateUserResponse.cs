using ProductManagement.Domain.Arguments.Base;

namespace ProductManagement.Domain.Arguments.User
{
    public class CreateUserResponse : ResponseBase
    {
        public Guid Id { get; set; }
        public string FistName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }

        public static explicit operator CreateUserResponse(Entities.User entity)
        {
           return new CreateUserResponse()
            {
                Id = entity.Id,
                FistName = entity.Nome.FistName,
                LastName = entity.Nome.LastName,
                Email = entity.Email.Webmail,
                Role = entity.Role.ToString()
            };
        }
    }
}
