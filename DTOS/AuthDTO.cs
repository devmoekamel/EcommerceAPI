namespace Ecommerce.DTOS
{
    public class AuthDTO
    {
        public string Id { get; set; }
        public string Message { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }
        public List<string> Roles { get; set; }
        public bool IsAuthenticated { get; set; }

        public DateTime ExpiredOn { get; set; }


    }
}
