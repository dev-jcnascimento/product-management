namespace ProductManagement.Domain.ValueObject
{

    public class Email
    {
        public string Webmail { get; private set; }
        protected Email()
        {
        }

        public Email(string webmail)
        {
            if (string.IsNullOrEmpty(webmail))
            {
                throw new Exception("Enter e-mail!");
            }
            if (!IsMail(webmail))
            {
                throw new Exception("E-mail is not valid!");
            }
            Webmail = webmail;
        }
        private static bool IsMail(string email)
        {
            bool validEmail = false;
            int indexArr = email.IndexOf('@');
            if (indexArr > 0)
            {
                int indexDot = email.IndexOf('.', indexArr);
                if (indexDot - 1 > indexArr)
                {
                    if (indexDot + 1 < email.Length)
                    {
                        string indexDot2 = email.Substring(indexDot + 1, 1);
                        if (indexDot2 != ".")
                        {
                            validEmail = true;
                        }
                    }
                }
            }
            return validEmail;
        }
    }
}
