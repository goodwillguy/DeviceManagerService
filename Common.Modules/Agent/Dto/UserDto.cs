namespace Common.Modules.Agent.Dto
{
    public class UserDto
    {
        public string Name { get; set; }

        public UserType UserType { get; set; }

        
    }

    public enum UserType
    {
        Agent,
        Resident
    }
}