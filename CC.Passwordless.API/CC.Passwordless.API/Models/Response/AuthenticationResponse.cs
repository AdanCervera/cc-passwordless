namespace CC.Passwordless.API.Models.Response
{
    public class AuthenticationResponse<T>
    {
        public T Data { get; set; }
        public string Token { get; set; }
        public bool HasErrors { get; set; }
        public string Error { get; set; }
    }
}
