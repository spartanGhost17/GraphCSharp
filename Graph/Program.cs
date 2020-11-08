using System;
using System.Collections.Generic;

namespace Graph
{
    class Program
    {
        static void Main(string[] args)
        {
            GraphNode<int> current;
            GraphNode<int> to;
            Graph<int> myGraph = new Graph<int>();

            

            myGraph.AddNode(0);
            myGraph.AddNode(1);
            myGraph.AddNode(2);
            myGraph.AddNode(3);
            myGraph.AddNode(4);
            myGraph.AddNode(5);
            myGraph.AddNode(6);

            myGraph.AddEdge(0, 1);
            myGraph.AddEdge(0, 2);
            myGraph.AddEdge(1, 3);
            myGraph.AddEdge(4, 1);
            myGraph.AddEdge(5, 2);
            myGraph.AddEdge(5, 6);
            myGraph.AddEdge(6, 0);
            myGraph.AddEdge(6, 4);


            current = myGraph.GetNodeByID(0);
            to = myGraph.GetNodeByID(2);

            //to.GetAdjList.Contains('A');

            Console.WriteLine("Is myGraph empty? Answer: {0}", myGraph.IsEmptyGraph());
            Console.WriteLine("Is myGraph contain {0} ? Answer: {1}", current.ID, myGraph.ContainsGraph(current));
            Console.WriteLine("Is node {0} and {1} adjacent ? Answer : {2}", current.ID, to.ID, myGraph.IsAdjacent(current, to));
            Console.WriteLine("Is node {0} and {1} adjacent ? Answer : {2}", to.ID, current.ID, myGraph.IsAdjacent(to, current));
            List<int> test3 = new List<int>();
            myGraph.DepthFirstTraverse(5, ref test3);
            foreach(int c in test3)
               System.Console.WriteLine("Reacheable items item "+c);


            
            foreach(int c in myGraph.mothervertex())
                Console.WriteLine("vertex "+c);
           // System.Console.WriteLine(myGraph.mothervertex());

            List<int> test1 = new List<int>();
            test1.Add(1);
            test1.Add(2);
            test1.Add(3);


            List<int> test2 = new List<int>();
            test2.Add(1);
            test2.Add(2);
            test2.Add(3);
            test2.Add(4);

            System.Console.WriteLine("Same lists {0} ",myGraph.ListEq(test1, test2));

            System.Console.WriteLine("---------------------- Nodes BEFORE topological sort -------------");
            System.Console.WriteLine("graph time " + myGraph.TIME);
            foreach (GraphNode<int> node in myGraph.Nodes)
            {
                System.Console.WriteLine(" node id " + node.ID);
                System.Console.WriteLine(" node discovery time" + node.DISCOVERY);
                System.Console.WriteLine(" node finishing time" + node.FINISHING);
                System.Console.WriteLine(" node color" + node.COLOR);
                System.Console.WriteLine("\n");
            }
            List<GraphNode<int>> orderdList = new List<GraphNode<int>>();
            //orderdList.AddFirst(new GraphNode<int>(4));
            //orderdList.AddFirst(new GraphNode<int>(5));
            //orderdList.AddFirst(new GraphNode<int>(6));
            

            //foreach (GraphNode<int> node in orderdList)
            //{
            //    System.Console.WriteLine(" -------node id " + node.ID);
            //    System.Console.WriteLine(" --------node discovery time" + node.DISCOVERY);
            //    System.Console.WriteLine(" --------node finishing time" + node.FINISHING);
            //    System.Console.WriteLine(" --------node color" + node.COLOR);
            //    System.Console.WriteLine("\n");
            //}


            orderdList = myGraph.TopologicalSort();
            System.Console.WriteLine("graph time "+myGraph.TIME);

            System.Console.WriteLine("---------------------- Nodes after topological sort -------------");
            foreach(GraphNode<int> node in orderdList )
            {
                System.Console.WriteLine(" node id "+node.ID);
                System.Console.WriteLine(" adjacent node count " + node.GetAdjList.Count);
                System.Console.WriteLine(" node discovery time"+ node.DISCOVERY);
                System.Console.WriteLine(" node finishing time" + node.FINISHING);
                System.Console.WriteLine(" node color" + node.COLOR);
                System.Console.WriteLine("\n");
               // break;
            }

            Console.ReadKey();
        }
    }
}
