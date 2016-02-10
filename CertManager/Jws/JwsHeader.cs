namespace CertManager.Jws
{
    public class JwsHeader
    {
        public string Alg { get; set; }
        public string Jwk { get; set; }
        public string Nonce { get; set; }
    }
}