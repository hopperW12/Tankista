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
    [Serializable]
    public struct SoldierInfo
    {

        public string firstName, lastName;
        public int age;

        public override string ToString()
        {
            return $"{firstName} {lastName}, {age}";
        }

        public static SoldierInfo GetRandomSoldier()
        {
            return new SoldierInfo(){firstName = SoldierDatabase.GetRandomFirstName(), lastName =  SoldierDatabase.GetRandomLastName(), age = new Random().Next(18, 50)};
        }
    }
    
}