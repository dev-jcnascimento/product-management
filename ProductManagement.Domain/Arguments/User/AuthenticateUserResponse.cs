namespace ProductManagement.Domain.Arguments.User
{
    public class AuthenticateUserResponse 
    {
        public Guid Id { get; set; }
        public string NameCompleto { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }

        public static explicit operator AuthenticateUserResponse(Entities.User entity)
        {
            if (entity == null)
            {
                return null;
            }
            return new AuthenticateUserResponse() {
                Id = entity.Id,
                NameCompleto = entity.Nome.ToString(),
                Email = entity.Email.Webmail.ToString(),
                Role = entity.Role.ToString()
            };
        }
    }
}
