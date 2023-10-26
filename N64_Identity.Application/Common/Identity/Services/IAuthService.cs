using N64_Identity.Application.Common.Identity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N64_Identity.Application.Common.Identity.Services;

public interface IAuthService
{
    public ValueTask<bool> RegistenationAsync(RegistrationDetails registrationDetails);

    public ValueTask<string> LoginAsync(LoginDetails loginDetails);
}
