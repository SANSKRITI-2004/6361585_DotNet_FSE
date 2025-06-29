namespace CustomerCommLib
{
    public class CustomerComm
    {
        IMailSender _mailSender;

        public CustomerComm(IMailSender mailSender)
        {
            _mailSender = mailSender;
        }

        public bool SendMailToCustomer()
        {
            // In real case, this could be dynamic data
            _mailSender.SendMail("cust123@abc.com", "Some Message");
            return true;
        }
    }
}
