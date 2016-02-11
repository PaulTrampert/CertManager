namespace CertManager.Jws.SignatureProviders
{
    public interface ISignatureProvider
    {
        string Algorithm { get; }
        byte[] VerificationKey { get; }
        byte[] ComputeSignature(byte[] data);
    }
}