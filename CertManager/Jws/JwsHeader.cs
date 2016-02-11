namespace CertManager.Jws
{
    public class JwsHeader
    {
        /// <summary>
        /// Algorithm
        /// </summary>
        public string Alg { get; set; }

        /// <summary>
        /// JWK Set Url
        /// </summary>
        public string Jku { get; set; }

        /// <summary>
        /// JSON Web Key
        /// </summary>
        public string Jwk { get; set; }

        /// <summary>
        /// Key ID
        /// </summary>
        public string Kid { get; set; }

        /// <summary>
        /// X.509 URL
        /// </summary>
        public string X5u { get; set; }

        /// <summary>
        /// X.509 Certificate Chain
        /// </summary>
        public string[] X5c { get; set; }

        /// <summary>
        /// X.509 Certificate SHA-1 Thumbprint
        /// </summary>
        public string X5t { get; set; }

        /// <summary>
        /// X.509 Certificate SHA-256 Thumbprint
        /// </summary>
        public string X5ts256 { get; set; }

        /// <summary>
        /// Type
        /// </summary>
        public string Typ { get; set; }

        /// <summary>
        /// Content Type
        /// </summary>
        public string Cty { get; set; }

        /// <summary>
        /// Critical
        /// </summary>
        public string Crit { get; set; }
    }
}