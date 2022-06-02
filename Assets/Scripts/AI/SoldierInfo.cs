using UnityEngine;

namespace AI
{   
    //Databaze 
    public class SoldierDatabase
    {
        private static string[] firstNames = new string[]{"Karel", "Dan", "Martin", "Tomas", "Vojta", "Šimon"};
        private static string[] lastNames = new[] {"Novák", "Růžička", "Hlaváček", "Zoubek", "Talíř", "Masaryk", "Fišer", "Ustál", "Dostál"};
        private static string[] ranks = new[] {"Vojín", "Desátník", "Četař", "Rotný", "Praporčík", "Kapitán", "Major", "Plukovník"};
        private static string[] cities = new[] {"Moskva", "Petrohrad", "Abakan", "Orsk", "Praha", "Berlin", "Brno", "Hulín", "Žopy" , "Pravčice", "Holešov", "Zlín", "Kroměříž", "Prusenovice"};

        //Generovani jmen, ranku, měst
        public static string GetRandomFirstName()
        {
            return firstNames[Random.Range(0, firstNames.Length)];
        }
        public static string GetRandomLastName()
        {
            return lastNames[Random.Range(0, lastNames.Length)];
        }
        public static string GetRandomRank()
        {
            return ranks[Random.Range(0, ranks.Length)];
        }
        public static string GetRandomCity()
        {
            return cities[Random.Range(0, cities.Length)];
        }
    }
    public struct SoldierInfo
    {

        public string firstName, lastName, rank, city;
        public int age;
        
        //Vytvoreni nahodneho vojaka
        public static SoldierInfo GetRandomSoldier()
        {
            return new SoldierInfo() {
                firstName = SoldierDatabase.GetRandomFirstName(),
                lastName =  SoldierDatabase.GetRandomLastName(),
                city = SoldierDatabase.GetRandomCity(),
                rank = SoldierDatabase.GetRandomRank(),
                age = Random.Range(18, 50)
                
            };
        }
    }
    
}