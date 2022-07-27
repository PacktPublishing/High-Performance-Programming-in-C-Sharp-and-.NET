namespace CH13_CQRSPattern
{
    internal class CQRSBasedClass
    {
        public void SleepCommand(int milliseconds)
        {
            Thread.Sleep(milliseconds);
        }

        public DateTime DateTimeQuery()
        {
            return DateTime.Now;
        }
    }
}
