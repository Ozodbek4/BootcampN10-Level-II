﻿namespace N64_Identity.Application.Common.Identity.Models;

public class RegistrationDetails
{
    public string FirstName { get; set; }

    public string LastName { get; set; }

    public byte Age { get; set; }

    public string EmailAddress { get; set; }

    public string Password { get; set; }
}