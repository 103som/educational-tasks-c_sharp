using System;

namespace EKRLib
{
    public abstract class Transport
    {
        public Transport(string Model, uint Power)
        {
            this.Model = Model;
            this.Power = Power;
        }

        private string model = null;
        protected string Model
        {
            get
            {
                return model;
            }

            set 
            {
                if (value.Length != 5 || value != value.ToUpper())
                    throw new TransportException($"Недопустимая модель {value}");

                model = value;
            }
        }

        private uint power = 0;
        public uint Power
        {
            get
            {
                return power;
            }

            set
            {
                if (value < 20)
                    throw new TransportException($"мощность не может быть меньше 20 л.с.");

                power = value;
            }
        }

        public static string GenerateRandomModel()
        {
            string randomModel = null;
            Random newRand = new Random();

            for (int i = 0; i < 5; ++i)
                randomModel += (char)('A' + newRand.Next(0, 26));

            return randomModel;
        }

        public static uint GenerateRandomPower()
        {
            Random newRand = new Random();

            return (uint)newRand.Next(10, 100);
        }

        public abstract string StartEngine();

        public override string ToString()
        {
            return ($"Model: {Model}, Power {Power}");
        }
    }
}
