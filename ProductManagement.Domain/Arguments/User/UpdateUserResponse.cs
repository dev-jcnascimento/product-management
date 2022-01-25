namespace ProductManagement.Domain.Arguments.User
{
    public class UpdateUserResponse
    {
        public string FistName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }

        public static explicit operator UpdateUserResponse(Entities.User entities)
        {
            return new UpdateUserResponse()
            {
                FistName = entities.Nome.FistName,
                LastName = entities.Nome.LastName,
                Email = entities.Email.Webmail,
                Role = entities.Role.ToString()
            };
        }
    }
}
