namespace N52Home1.Models;

internal class Email
{
    public Guid Id { get; set; }

    public Guid SenderUserId { get; set; }
    
    public Guid ReceiverUserId { get; set; }

    public string Subject { get; set; }

    public string Body { get; set; }

    public string SenderEmailAddress { get; set; }

    public string  ReceiverEmailAddress { get; set; }

    public bool IsSend {  get; set; }
}