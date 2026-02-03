using SMS.Data;

namespace SMS.Services
{
    public static class SchoolContextFactory
    {
        public static SMSDbContext Create() => new SMSDbContext();
    }
}
