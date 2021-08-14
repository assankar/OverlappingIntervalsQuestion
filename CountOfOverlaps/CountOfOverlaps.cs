using System;
using System.Collections.Generic;

namespace CountOfOverlaps
{
    class CountOfOverlaps
    {
        /// <summary>
        /// 
        /// This question is basically you'll get input of [[-2, 3], [2,3], [2,1]]
        /// which corresponds to coordinates on a linear line of (-5,1), (-1, 5), (1,3)
        /// 
        /// Goal is to see how much overlapping is going on here. 
        /// 
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            CountOfOverlaps countOfOverlaps = new CountOfOverlaps();
            Tuple<int, int> t1 = new Tuple<int, int>(-2, 3);
            Tuple<int, int> t2 = new Tuple<int, int>(2, 3);
            Tuple<int, int> t3 = new Tuple<int, int>(2, 1);
            List<Tuple<int, int>> list = new List<Tuple<int, int>>();
            list.Add(t1);
            list.Add(t2);
            list.Add(t3);
            Tuple<int, List<int>> result = countOfOverlaps.FindTheResultOfOverlaps(list);
            Console.WriteLine(result.Item1);
            List<int> results = result.Item2;
            for (int i = 0; i < results.Count; i++)
            {
                Console.WriteLine("["+results[i]+","+results[i+1]+"]");
                i++;
            }
        }

        public CountOfOverlaps()
        {

        }

        public Tuple<int, List<int>> FindTheResultOfOverlaps(List <Tuple<int,int>> list)
        {
            char startCharacter = 's';
            char endCharacter = 'e';
            List<Tuple<int, char>> coordinates = new List<Tuple<int, char>>();
            foreach(var item in list)
            {
                int startValue = item.Item1 - item.Item2;
                int endValue = item.Item1 + item.Item2;
                Tuple<int, char> start = new Tuple<int, char>(startValue, startCharacter);
                Tuple<int, char> end = new Tuple<int, char>(endValue, endCharacter);
                coordinates.Add(start);
                coordinates.Add(end);
            }

            coordinates.Sort((x, y) => {
                int result = x.Item1.CompareTo(y.Item1);
                return result == 0 ? y.Item2.CompareTo(x.Item2) : result;
            });

            int currentOverlap = 0;
            int maxOverlap = 0;
            List<int> overlapCoorindates = new List<int>();

            foreach(var entry in coordinates)
            {
                if(entry.Item2 == startCharacter)
                {
                    currentOverlap++;
                    if (maxOverlap < currentOverlap)
                    {
                        maxOverlap = currentOverlap;
                        overlapCoorindates.Clear();
                        overlapCoorindates.Add(entry.Item1);
                    }
                }
                else if(entry.Item2 == endCharacter)
                {
                    if(currentOverlap == maxOverlap)
                    {
                        overlapCoorindates.Add(entry.Item1);
                    }
                    currentOverlap--;
                }
            }

            return new Tuple<int, List<int>>(maxOverlap, overlapCoorindates);
        }
    }
}
