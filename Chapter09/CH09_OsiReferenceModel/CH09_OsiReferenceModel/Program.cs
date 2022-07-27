using CH09_OsiReferenceModel;

Console.WriteLine("Hello, World!");
SendMail();
Console.WriteLine("Email has been sent.");

void SendMail()
{
    EmailServer.SendEmail(
        "FROM_EMAIL"
        , "TO_EMAIL"
        , "Test Message"
        , "Test Body. You can delete!"
    );

}