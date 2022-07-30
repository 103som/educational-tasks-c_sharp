using System;
using EKRLib;
using System.Collections.Generic;
using System.IO;

namespace Очередной_пир
{
    class Program
    {
        public static Transport GenerateCarOrBoat()
        {
            while (true)
            {
                try
                {
                    if (new Random().Next(0, 100) < 50)
                        return (Transport)new Car(Transport.GenerateRandomModel(), Transport.GenerateRandomPower());

                    return (Transport)new MotorBoat(Transport.GenerateRandomModel(), Transport.GenerateRandomPower());
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                };
            }
        }

        public static void SaveInformation(Transport[] allTransport)
        {
            try
            {
                List<string> allCarsInformation = new List<string>();
                List<string> allMotorBoatsInformation = new List<string>();

                foreach (var transport in allTransport)
                {
                    if (transport is Car)
                        allCarsInformation.Add((transport as Car).ToString());
                    else if (transport is MotorBoat)
                        allMotorBoatsInformation.Add((transport as MotorBoat).ToString());
                    else
                        throw new ArgumentException("Unexpected params exception.");
                }

                File.WriteAllLines("MotorBoats.txt", allMotorBoatsInformation);
                File.WriteAllLines("Cars.txt", allCarsInformation);
            }
            catch(Exception ex) 
            {
                Console.WriteLine(ex.Message);
            }
        }

        static void DoProcess()
        {
            int transportsCount = new Random().Next(6, 10);
            Transport[] allTransport = new Transport[transportsCount];

            for (int i = 0; i < transportsCount; ++i)
            {
                allTransport[i] = GenerateCarOrBoat();

                Console.WriteLine(allTransport[i].StartEngine());
            }

            SaveInformation(allTransport);
        }

        static void Execute()
        {
            do
            {
                DoProcess();


                Console.WriteLine("Хотите сделать это еще раз?Введите Да/Yes.");
                string userAns = Console.ReadLine().ToUpper();

                if (userAns != "ДА" && userAns != "YES")
                    break;

                Console.Clear();
            }
            while (true);
        }

        static void Main(string[] args)
        {
            Execute();
        }
    }
}
