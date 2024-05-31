using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text.Json;

namespace prove_06
{
    public static class MapsTester
    {
        public static void Run()
        {
            // Todo Problem 1
            Console.WriteLine("\n=========== PROBLEM 1 TESTS ===========");
            var englishToGerman = new Translator();
            englishToGerman.AddWord("House", "Haus");
            englishToGerman.AddWord("Car", "Auto");
            englishToGerman.AddWord("Plane", "Flugzeug");
            Console.WriteLine(englishToGerman.Translate("Car")); // Auto
            Console.WriteLine(englishToGerman.Translate("Plane")); // Flugzeug
            Console.WriteLine(englishToGerman.Translate("Train")); // ???

            // Sample Test Cases (may not be comprehensive) 
            // Todo Problem 2
            Console.WriteLine("\n=========== PROBLEM 2 TESTS ===========");
            Console.WriteLine(SummarizeDegrees("census.txt").AsString()); // You might need to add a path for the file
            // Results may be in a different order:
            // <Dictionary>{[Bachelors, 5355], [HS-grad, 10501], [11th, 1175],
            // [Masters, 1723], [9th, 514], [Some-college, 7291], [Assoc-acdm, 1067],
            // [Assoc-voc, 1382], [7th-8th, 646], [Doctorate, 413], [Prof-school, 576],
            // [5th-6th, 333], [10th, 933], [1st-4th, 168], [Preschool, 51], [12th, 433]}

            // Sample Test Cases (may not be comprehensive) 
            // Todo Problem 3
            Console.WriteLine("\n=========== PROBLEM 3 TESTS ===========");
            Console.WriteLine(IsAnagram("CAT", "ACT")); // true
            Console.WriteLine(IsAnagram("DOG", "GOOD")); // false
            Console.WriteLine(IsAnagram("AABBCCDD", "ABCD")); // false
            Console.WriteLine(IsAnagram("ABCCD", "ABBCD")); // false
            Console.WriteLine(IsAnagram("BC", "AD")); // false
            Console.WriteLine(IsAnagram("Ab", "Ba")); // true
            Console.WriteLine(IsAnagram("A Decimal Point", "Im a Dot in Place")); // true
            Console.WriteLine(IsAnagram("tom marvolo riddle", "i am lord voldemort")); // true
            Console.WriteLine(IsAnagram("Eleven plus Two", "Twelve Plus One")); // true
            Console.WriteLine(IsAnagram("Eleven plus One", "Twelve Plus One")); // false

            // Todo Problem 4
            Console.WriteLine("\n=========== PROBLEM 4 TESTS ===========");
            Dictionary<ValueTuple<int, int>, bool[]> map = SetupMazeMap();
            var maze = new Maze(map);
            maze.ShowStatus(); // Should be at (1,1)
            maze.MoveUp(); // Error
            maze.MoveLeft(); // Error
            maze.MoveRight();
            maze.MoveRight(); // Error
            maze.MoveDown();
            maze.MoveDown();
            maze.MoveDown();
            maze.MoveRight();
            maze.MoveRight();
            maze.MoveUp();
            maze.MoveRight();
            maze.MoveDown();
            maze.MoveLeft();
            maze.MoveDown(); // Error
            maze.MoveRight();
            maze.MoveDown();
            maze.MoveDown();
            maze.MoveRight();
            maze.ShowStatus(); // Should be at (6,6)

            // Sample Test Cases (may not be comprehensive) 
            // Todo Problem 5
            Console.WriteLine("\n=========== PROBLEM 5 TESTS ===========");
            EarthquakeDailySummary();

            // Sample output from the function.  Number of earthquakes, places, and magnitudes will vary.
            // 1km NE of Pahala, Hawaii - Mag 2.36
            // 58km NW of Kandrian, Papua New Guinea - Mag 4.5
            // 16km NNW of Truckee, California - Mag 0.7
            // 9km S of Idyllwild, CA - Mag 0.25
            // 14km SW of Searles Valley, CA - Mag 0.36
            // 4km SW of Volcano, Hawaii - Mag 1.99
        }

        private static Dictionary<string, int> SummarizeDegrees(string filename)
        {
            var degrees = new Dictionary<string, int>();
            foreach (var line in File.ReadLines(filename))
            {
                var fields = line.Split(",");
                var degree = fields[3].Trim(); // Assuming the degree is in the 4th column
                if (degrees.ContainsKey(degree))
                {
                    degrees[degree]++;
                }
                else
                {
                    degrees[degree] = 1;
                }
            }

            return degrees;
        }

        private static bool IsAnagram(string word1, string word2)
        {
            if (word1.Length != word2.Length)
                return false;

            var dict1 = new Dictionary<char, int>();
            var dict2 = new Dictionary<char, int>();

            foreach (var c in word1.ToLower())
            {
                if (c != ' ')
                {
                    if (dict1.ContainsKey(c))
                        dict1[c]++;
                    else
                        dict1[c] = 1;
                }
            }

            foreach (var c in word2.ToLower())
            {
                if (c != ' ')
                {
                    if (dict2.ContainsKey(c))
                        dict2[c]++;
                    else
                        dict2[c] = 1;
                }
            }

            foreach (var key in dict1.Keys)
            {
                if (!dict2.ContainsKey(key) || dict1[key] != dict2[key])
                    return false;
            }

            return true;
        }

        private static Dictionary<ValueTuple<int, int>, bool[]> SetupMazeMap()
        {
            Dictionary<ValueTuple<int, int>, bool[]> map = new()
            {
                { (1, 1), new[] { false, true, false, true } },
                { (1, 2), new[] { false, true, true, false } },
                { (1, 3), new[] { false, false, false, false } },
                { (1, 4), new[] { false, true, false, true } },
                { (1, 5), new[] { false, false, true, true } },
                { (1, 6), new[] { false, false, true, false } },
                { (2, 1), new[] { true, false, false, true } },
                { (2, 2), new[] { true, false, true, true } },
                { (2, 3), new[] { false, false, true, true } },
                { (2, 4), new[] { true, true, true, false } },
                { (2, 5), new[] { false, false, false, false } },
                { (2, 6), new[] { false, false, false, false } },
                { (3, 1), new[] { false, false, false, false } },
                { (3, 2), new[] { false, false, false, false } },
                { (3, 3), new[] { false, false, false, false } },
                { (3, 4), new[] { true, true, false, true } },
                { (3, 5), new[] { false, false, true, true } },
                { (3, 6), new[] { false, false, true, false } },
                { (4, 1), new[] { false, true, false, false } },
                { (4, 2), new[] { false, false, false, false } },
                { (4, 3), new[] { false, true, false, true } },
                { (4, 4), new[] { true, true, true, false } },
                { (4, 5), new[] { false, false, false, false } },
                { (4, 6), new[] { false, false, false, false } },
                { (5, 1), new[] { true, true, false, true } },
                { (5, 2), new[] { false, false, true, true } },
                { (5, 3), new[] { true, true, true, true } },
                { (5, 4), new[] { true, false, true, true } },
                { (5, 5), new[] { false, false, true, true } },
                { (5, 6), new[] { false, true, true, false } },
                { (6, 1), new[] { true, false, false, false } },
                { (6, 2), new[] { false, false, false, false } },
                { (6, 3), new[] { true, false, false, false } },
                { (6, 4), new[] { false, false, false, false } },
                { (6, 5), new[] { false, false, false, false } },
                { (6, 6), new[] { true, false, false, false } }
            };
            return map;
        }

        private static void EarthquakeDailySummary()
        {
            const string uri = "https://earthquake.usgs.gov/earthquakes/feed/v1.0/summary/all_day.geojson";

            using var client = new HttpClient();
            using var getRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);
            using var jsonStream = client.Send(getRequestMessage).Content.ReadAsStream();
            using var reader = new StreamReader(jsonStream);
            var json = reader.ReadToEnd();

            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            var featureCollection = JsonSerializer.Deserialize<FeatureCollection>(json, options);

            foreach (var feature in featureCollection.Features)
            {
                Console.WriteLine($"{feature.Properties.Place} - Mag { feature.Properties.Mag}");
            }
        }
    }
}


