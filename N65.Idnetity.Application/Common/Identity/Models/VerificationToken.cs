﻿using N65.Identity.Application.Common.Enums;

namespace N65.Identity.Application.Common.Identity.Models;

public class VerificationToken
{
    public Guid UserId { get; set; }

    public VerificationType Type { get; set; }

    public DateTimeOffset ExpiryTime { get; set; }
}