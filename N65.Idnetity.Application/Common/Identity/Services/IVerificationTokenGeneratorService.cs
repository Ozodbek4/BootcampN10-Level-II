using N65.Identity.Application.Common.Enums;
using N65.Identity.Application.Common.Identity.Models;
using N65.Identity.Domain.Entities;

namespace N65.Identity.Application.Common.Identity.Services;

public interface IVerificationTokenGeneratorService
{
    string GeneratorTokenAsync(VerificationType type, Guid userId);

    (VerificationToken Token, bool IsValid) Decode(string token);
}