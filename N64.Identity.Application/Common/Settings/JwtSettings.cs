﻿namespace N64.Identity.Application.Common.Settings;

public class JwtSettings
{
    public bool ValidateIssuer { get; set; }

    public string ValidIssuer { get; set; } = default!;

    public bool ValidateAudience { get; set; }

    public string ValidAudience { get; set; } = default!;

    public bool ValidLifeTime { get; set; }

    public int ExpirationTimeInMinutes { get; set; }

    public bool ValidateIssuerSingingKey { get; set; }

    public string SecretKey { get; set; } = default!;
}