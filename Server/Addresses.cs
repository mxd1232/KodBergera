using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    public static class Addresses
    {
        public static string IpAddress = "127.0.0.1";
        public static string MainPort = "1";

        public static List<int> GetConnections(int port)
        {
            if(port<1||port>8)
            {
                throw new ArgumentOutOfRangeException();
            }

            int[] connectionsArray = ConnectionsMap[port-1];
            List<int> connections = new List<int>();

            for (int i=0;i<8;i++)
            {
                if(connectionsArray[i]==1)
                {
                    connections.Add(i + 1);
                }
            }
            return connections;   
        }


        public static List<List<int>> AllPaths;

        public static List<int> FindShortestPath(int s, int d)
        {
            List<List<int>> allPaths = FindAllPaths(s, d);
            List<int> shortestPath = allPaths[0];


            foreach (var path in FindAllPaths(s,d))
            {
                if (path.Count < shortestPath.Count)
                {
                    shortestPath = path;
                }
            }

            return shortestPath;
        }

        public static List<List<int>> FindAllPaths(int s, int d)
        {
            AllPaths = new List<List<int>>();
            bool[] isVisited = new bool[8];
            List<int> pathList = new List<int>();

            // add source to path[]
            pathList.Add(s);

            // Call recursive utility
            FindAllPathsUtil(s, d, isVisited, pathList);
            return AllPaths;
        }

        // A recursive function to print
        // all paths from 'u' to 'd'.
        // isVisited[] keeps track of
        // vertices in current path.
        // localPathList<> stores actual
        // vertices in the current path
        private static void FindAllPathsUtil(int u, int d,
            bool[] isVisited,
            List<int> localPathList)
        {

            if (u.Equals(d))
            {
                List<int> path = new List<int>();
                foreach (var i in localPathList)
                {
                    path.Add(i);
                }

                AllPaths.Add(path);
                Console.WriteLine(string.Join(" ", localPathList));
                // if match found then no need
                // to traverse more till depth
                return;
            }

            // Mark the current node
            isVisited[u-1] = true;

            // Recur for all the vertices
            // adjacent to current vertex
            foreach (int i in GetConnections(u))
            {
                if (!isVisited[i-1])
                {
                    // store current node
                    // in path[]
                    localPathList.Add(i);
                    FindAllPathsUtil(i, d, isVisited,
                        localPathList);

                    // remove current node
                    // in path[]
                    localPathList.Remove(i);
                }
            }

            // Mark the current node
            isVisited[u-1] = false;
        }


        public static int[] connections1 = new int[8] { 0, 0, 1, 0, 0, 0, 0, 0 }; //3
        public static int[] connections2 = new int[8] { 0, 0, 1, 0, 0, 0, 0, 0 }; //3
        public static int[] connections3 = new int[8] { 1, 1, 0, 1, 0, 1, 0, 0 }; //1,2,4
        public static int[] connections4 = new int[8] { 0, 0, 1, 0, 1, 0, 0, 0 }; //3,5
        public static int[] connections5 = new int[8] { 0, 0, 0, 1, 0, 1, 1, 0 }; //4,6,7
        public static int[] connections6 = new int[8] { 0, 0, 1, 0, 1, 0, 0, 1 }; //5,8
        public static int[] connections7 = new int[8] { 0, 0, 0, 0, 1, 0, 0, 0 }; //5
        public static int[] connections8 = new int[8] { 0, 0, 0, 0, 0, 1, 0, 0 }; //6

        public static int[][] ConnectionsMap = new int[8][] { connections1, connections2, connections3, connections4, connections5, connections6, connections7, connections8 };
    }
}
