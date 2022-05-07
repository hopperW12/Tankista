using System;

namespace AI
{
    public class SoldierDatabase
    {
        private static string[] firstNames = new string[]{"Karel", "Dan", "Martin", "Tomas", "Vojta", "Simon"};
        private static string[] lastNames = new[] {"Novy", "Chytry"};

        public static string GetRandomFirstName()
        {
            return firstNames[new Random().Next(0, firstNames.Length)];
        }
        public static string GetRandomLastName()
        {
            return lastNames[new Random().Next(0, lastNames.Length)];
        }
    }
    public struct SoldierInfo
    {

        public string FirstName, LastName;
        public int Age;

        public override string ToString()
        {
            return $"{FirstName} {LastName}, {Age}";
        }

        public static SoldierInfo GetRandomSoldier()
        {
            return new SoldierInfo(){FirstName = SoldierDatabase.GetRandomFirstName(), LastName =  SoldierDatabase.GetRandomLastName(), Age = new Random().Next(18, 50)};
        }
    }
    
}