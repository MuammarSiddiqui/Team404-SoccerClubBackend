namespace Team404_SoccerClubBackend.Config
{
    public static class LocalTime
    {
        public static DateTime GetTime()
        {
            try
            {
                DateTime serverTime = DateTime.Now;
                DateTime utcTime = serverTime.ToUniversalTime();

                TimeZoneInfo tzi = TimeZoneInfo.FindSystemTimeZoneById("Pakistan Standard Time");
                DateTime localTime = TimeZoneInfo.ConvertTimeFromUtc(utcTime, tzi);
                return localTime;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
