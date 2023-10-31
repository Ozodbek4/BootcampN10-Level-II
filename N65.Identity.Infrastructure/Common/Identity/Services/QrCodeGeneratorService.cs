using N65.Identity.Application.Common.Identity.Services;

namespace N65.Identity.Infrastructure.Common.Identity.Services;

public class QrCodeGeneratorService : IQrCodeGeneratorService
{
    public ValueTask<bool> GenerateToken(string message)
    {
        throw new NotImplementedException();
    }
}