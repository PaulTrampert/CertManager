namespace CertManager.Jws.SignatureProviders
{
    public interface ISignatureProvider
    {
        dynamic Header { get; }
        string Algorithm { get; }
        byte[] ComputeSignature(byte[] data);
        bool VerifySignature(byte[] signature, byte[] data);
    }
}