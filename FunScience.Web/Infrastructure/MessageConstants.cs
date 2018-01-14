namespace FunScience.Web.Infrastructure
{
    public static class MessageConstants
    {
        private const string Error = "Error";

        public const string PlayWithSameNameExist = Error + "Вече съществува пиеса с това име.";
        public const string PlayWasChanged = "Пиесата беше променена.";

        public const string SchoolWithSameNameExist = Error + "Вече съществува училище с това име.";
        public const string SchoolWasChanged = "Училището беше променено.";

        public const string ScheduleWrongDateTime = Error + "Грешка. Моля преверете датата.";

        public const string UserWithSameEmailExist = Error + "Вече съществува потребител с този Email";

        public const string PasswordChanged = "Паролата е променена.";
        public const string ProfileChanged = "Профилът беше променен.";



    }
}
