using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Helper
{
    public class Helpers
    {
        private static Random _rand = new Random();

        public static string MakeUniqueCustomerName(List<string> names)
        {
            int maxNames = bizPrefix.Count * bizPrefix.Count;
            if (names.Count > maxNames)
            {
                throw new InvalidOperationException("Maximum number of unique names exceeded");
            }
            var prefix = GetRandom(bizPrefix);
            var suffix = GetRandom(bizsuffix);
            var bizName = string.Format($"{prefix}{suffix}");
            if (names.Contains(bizName))
            {
                MakeUniqueCustomerName(names);
            }
            return bizName;
        }

        public static decimal GetRandomOrderTotal()
        {
            return _rand.Next(100, 5000);
        }

        public static DateTime GetRandomOrderPlaced()
        {
            DateTime end = DateTime.Now;

            DateTime start = end.AddDays(-90);

            TimeSpan possibleSpan = end - start;
            TimeSpan newSpan = new TimeSpan(0, _rand.Next((int)possibleSpan.TotalMinutes), 0);

            return start + newSpan;
        }
        public static DateTime? GetRandomOrderCompleted(DateTime OrderPlaced)
        {
            DateTime now = DateTime.Now;
            TimeSpan minLeadTime= TimeSpan.FromDays(7);
            TimeSpan timePassed = now - OrderPlaced;

            if (timePassed < minLeadTime)
            {
                return null;
            }
            return OrderPlaced.AddDays(_rand.Next(7,14));
        }
        private static string GetRandom(IList<string> items)
        {
            return items[_rand.Next(items.Count)];
        }

        public static string MakeCustomerEmail(string CustomerName)
        {
            return string.Format($"contact@{CustomerName.ToLower()}.com");
        }
        public static string MakeCustomerState()
        {
            return GetRandom(brStates);
        }
        private static readonly List<string> brStates = new List<string>()
        {
            "AC",
            "AL",
            "AM",
            "BA",
            "CE",
            "DF",
            "ES",
            "GO",
            "MA",
            "MT",
            "MS",
            "MG",
            "PA",
            "PB",
            "PR",
            "PE",
            "PI",
            "RJ",
            "RN",
            "RS",
            "RO",
            "RR",
            "SC",
            "SP",
            "SE",
            "TO"
        };
        private static readonly List<string> bizPrefix = new List<string>() 
        {
            "Technology",
            "Music",
            "MainSt",
            "Sales",
            "Enterprise",
            "Quick",
            "Ready",
            "Budget",
            "Peak",
            "Magic",
            "Family",
            "Comfort"
        };
        private static readonly List<string> bizsuffix = new List<string>() 
        {
            "Corporation",
            "Co",
            "Logistics",
            "Transit",
            "Barkery",
            "Goods",
            "Foods",
            "Cleaners",
            "Hotels",
            "Planners",
            "Automotive",
            "Books"
        };
    }
}
