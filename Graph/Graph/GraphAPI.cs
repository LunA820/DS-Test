using System;
using System.Collections;


namespace Graph
{
	public class GraphAPI
	{
		// Find path by DFS
		public static ArrayList DFS_path(Node start, Node dest){
			ArrayList t = DFS.traversal(start);
			return findPath(t, dest);
		}

		// Find path by BFS
		public static ArrayList BFS_path(Node start, Node dest)
		{
			ArrayList t = BFS.traversal(start);
			return findPath(t, dest);
		}

		// Use DFS to find path between two nodes
		public static ArrayList findPath(ArrayList traversal, Node dest)
        {
			// If start and dest are not connected, return empty array
			ArrayList path = new ArrayList();
			if (!traversal.Contains(dest)) { return path; }

			/*
			 Convert DFS/BFS traversal to path by filtering unconnected nodes:
				1. Reverse original path
				2. Only add node which is connected to the prev node
				3. The first prev node is dest
			*/
			traversal.Reverse();
			Node Prev = null;

			foreach (Node n in traversal){
				/*
					The first Prev should be dest:
					 - Ignore nodes that is not connected to prev node
					 - Add nodes that is connect to prev, update prev
				*/
				if (Prev != null){
					if (n.isConnected(Prev)){
						path.Add(n);
						Prev = n;
					}
				}

				// Add first node = dest, prev = dest
				if (n == dest){
					path.Add(n);
					Prev = n;
                }
            }

			// Reverse path and return
			path.Reverse();
			return path;
        }


		// Print Path
		public static void printPath(ArrayList p){
			if (p.Count == 0) {
				Console.WriteLine("No path exists.");
				return;
			}

			for (int i = 0; i < p.Count; i++){
				Console.Write(((Node)p[i]).getX());
				if (i == p.Count - 1) { Console.WriteLine(""); }
                else { Console.Write(" -> "); }
            }
        }
	}
}
