using System;

namespace PushCarLib
{
    public class Score
    {
        public float Time { get; set; }
        public float Distance { get; set; }
        
        public Score(float time, float distance)
        {
            Time = time;
            Distance = distance;
        }

        public byte[] CopyToBuffer(int size)
        {
            var buf = new byte[size];
            
            var timeBuf = BitConverter.GetBytes(Time);
            var distanceBuf = BitConverter.GetBytes(Distance);
            Buffer.BlockCopy(timeBuf, 0, buf, 0, sizeof(float));
            Buffer.BlockCopy(distanceBuf, 0, buf, sizeof(float), sizeof(float));

            return buf;
        }
        
        public static Score FromBuffer(byte[] buf)
        {
            var time = BitConverter.ToSingle(buf, 0);
            var distance = BitConverter.ToSingle(buf, sizeof(float));
            return new Score(time, distance);
        }
    }
}