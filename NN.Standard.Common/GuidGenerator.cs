using System;

namespace NN.Standard.Common
{
    public static class GuidGenerator
    {
        private static readonly object Mutex = new object();

        public static Guid NewId()
        {
            lock (GuidGenerator.Mutex)
            {
                byte[] byteArray = Guid.NewGuid().ToByteArray();
                DateTime dateTime = new DateTime(1900, 1, 1);
                DateTime now = DateTime.Now;
                TimeSpan timeSpan = new TimeSpan(now.Ticks - dateTime.Ticks);
                TimeSpan timeOfDay = now.TimeOfDay;
                byte[] bytes1 = BitConverter.GetBytes(timeSpan.Days);
                byte[] bytes2 = BitConverter.GetBytes((long)(timeOfDay.TotalMilliseconds / 3.333333));
                Array.Reverse((Array)bytes1);
                Array.Reverse((Array)bytes2);
                Array.Copy((Array)bytes1, bytes1.Length - 2, (Array)byteArray, byteArray.Length - 6, 2);
                Array.Copy((Array)bytes2, bytes2.Length - 4, (Array)byteArray, byteArray.Length - 4, 4);
                return new Guid(byteArray);
            }
        }
    }
}
