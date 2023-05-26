namespace ZavaJApplicationApi.Common
{
    public class CommonClass
    {
      public  string zavajEmail = "contact@zavaj.net";
      public  string password = "Z123@1";
     public   string subject = "OTP code for Registration Process";
       public string getEmailContent(string otpCode,  string email = "") {
             return $"Dear {email},\r\n\r\nThank you for registering with ZAVAJ Application. " +
                $"We are excited to have you on board! To ensure the security of your account, we require you to confirm your registration by entering a One-Time Password {otpCode}.\r\n\r\n" +
                $"Please use the following OTP to complete your registration: {otpCode}" +
                " Please note that this OTP is valid for [Time Limit -  5 minutes] minutes only. " +
                "If you don't complete the registration within this timeframe, you may need to request a new OTP.\r\n\r\nHere are the steps to complete your registration:\r\n\r\nOpen the ZAVAJ Application registration page." +
                "\r\nEnter your email address.\r\nWhen prompted, enter the OTP provided in this email.\r\nClick the \"Confirm\" or \"Verify\" button to finalize your registration.\r\n" +
                "Please ensure that you keep this OTP confidential" +
                " and do not share it with anyone. Our team will never ask you for your OTP or password.\r\n\r\nIf you did not register for ZAVAJ Application, please ignore this email. It is possible that someone entered your email address by mistake. If you continue to receive emails from us without your consent, please contact our support team immediately.\r\n\r\n" +
                "If you encounter any issues during the registration process or have any questions," +
                " please don't hesitate to reach out to our support team @contact@zavaj.net" +
                " We are here to assist you.\r\n\r\nOnce again, welcome to ZAVAJ Application. We look forward to providing you with a seamless and secure experience.\r\n\r\nBest regards,\r\n\r\nZAVAJ Application Team";
        }
    }
}
