﻿namespace N65.Identity.Application.Common.Notifications.Services;

public interface IEmailOrchestrationService
{
    ValueTask<bool> SendMessageAsync(string emailAddress, string message);
}