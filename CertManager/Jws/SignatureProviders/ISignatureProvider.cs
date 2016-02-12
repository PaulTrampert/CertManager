namespace CertManager.Jws.SignatureProviders
{
    public interface ISignatureProvider
    {
        dynamic Header { get; }
        string Algorithm { get; }
        byte[] VerificationKey { get; }
        byte[] ComputeSignature(byte[] data);
    }
}