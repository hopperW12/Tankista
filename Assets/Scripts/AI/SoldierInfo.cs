using System;

namespace AI
{
    public class SoldierDatabase
    {
        private static string[] firstNames = new string[]{"Karel", "Dan", "Martin", "Tomas", "Vojta", "Šimon"};
        private static string[] lastNames = new[] {"Novák", "Růžička", "Hlaváček", "Zoubek", "Talíř", "Masaryk", "Fišer", "Ustál", "Dostál"};
        private static string[] ranks = new[] {"Vojín", "Desátník", "Četař", "Rotný", "Praporčík", "Kapitán", "Major", "Plukovník"};
        private static string[] cities = new[] {"Moskva", "Petrohrad", "Abakan", "Orsk", "Praha", "Berlin", "Brno", "Hulín", "Žopy" , "Pravčice", "Holešov", "Zlín", "Kroměříž", "Prusenovice"};

        public static string GetRandomFirstName()
        {
            return firstNames[new Random().Next(0, firstNames.Length)];
        }
        public static string GetRandomLastName()
        {
            return lastNames[new Random().Next(0, lastNames.Length)];
        }
        public static string GetRandomRank()
        {
            return ranks[new Random().Next(0, ranks.Length)];
        }
        public static string GetRandomCity()
        {
            return cities[new Random().Next(0, cities.Length)];
        }
    }
    [Serializable]
    public struct SoldierInfo
    {

        public string firstName, lastName, rank, city;
        public int age;
        
        public override string ToString()
        {
            return $"{firstName} {lastName}, {age}";
        }

        public static SoldierInfo GetRandomSoldier()
        {
            return new SoldierInfo() {
                firstName = SoldierDatabase.GetRandomFirstName(),
                lastName =  SoldierDatabase.GetRandomLastName(),
                city = SoldierDatabase.GetRandomCity(),
                rank = SoldierDatabase.GetRandomRank(),
                age = new Random().Next(18, 50)
                
            };
        }
    }
    
}