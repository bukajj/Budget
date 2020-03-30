namespace Budget.Infrastructure.Commands
{
    public class CreateUser : ICommand
    {
        public string Email { get; set; }
        public string Passsword { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
    }
}