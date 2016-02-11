namespace CertManager.Jws.Crypto
{
    public interface ISignatureProvider
    {
        string Algorithm { get; }
        byte[] VerificationKey { get; }
        byte[] ComputeSignature(byte[] data);
    }
}