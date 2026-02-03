using SMS.Data.Entities;

namespace SMS.Session
{
    public static class SessionManager
    {
        public static User CurrentUser { get; set; }

        public static bool IsLoggedIn => CurrentUser != null;
        public static bool IsAdmin => CurrentUser?.Role == "Admin";
        public static bool IsTeacher => CurrentUser?.Role == "Teacher";
        public static bool IsStudent => CurrentUser?.Role == "Student";

        public static void Login(User user) => CurrentUser = user;

        public static void Logout() => CurrentUser = null;
    }
}
