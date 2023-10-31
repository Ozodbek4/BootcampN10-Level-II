using N65.Identity.Application.Common.Enums;
using N65.Identity.Application.Common.Identity.Models;
using N65.Identity.Application.Common.Identity.Services;

namespace N65.Identity.Infrastructure.Common.Identity.Services;

public class VerificatioinTokenGeneratorService : IVerificationTokenGeneratorService
{
    public (VerificationToken Token, bool IsValid) Decode(string token)
    {
        throw new NotImplementedException();
    }

    public string GeneratorTokenAsync(VerificationType type, Guid userId)
    {
        throw new NotImplementedException();
    }
}