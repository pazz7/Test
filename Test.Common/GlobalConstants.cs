namespace Test.Common
{
    public static class GlobalConstants
    {
        public const string HeaderAccountId = "X-Account-Id";
        public const string PrevCursor = "X-Prev-Cursor";
        public const string NextCursor = "X-Next-Cursor";

        public const string LogTemplate = "[{Timestamp:HH:mm:ss} {Level:u3}] {Message:lj}{NewLine}{Exception}";
        public const string GenericErrorMessage = "Error occured in processing your request. Please contact your administrator.";
    }
}
