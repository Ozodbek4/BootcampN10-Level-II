﻿namespace N65.Identity.Application.Common.Settings;

public class VerificationTokenSettings
{
    public string IdentityVerificationTokenPurpose { get; set; } = default!;

    public int IndentityExpirationTimeInMinutes { get; set; }
}