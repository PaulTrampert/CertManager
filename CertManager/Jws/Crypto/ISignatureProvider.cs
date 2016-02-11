namespace CertManager.Jws.Crypto
{
    public interface ISignatureProvider
    {
        byte[] VerificationKey { get; }
        byte[] ComputeSignature(byte[] data);
    }
}