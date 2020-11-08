using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Graph
{
    class Graph<T> where T : IComparable
    {
        private LinkedList<GraphNode<T>> nodes;
        private int time;


        public Graph()
        {
            nodes = new LinkedList<GraphNode<T>>();
        }

        public int TIME
        {
            get { return this.time; }
            set { this.time = value; }
        }

        public LinkedList<GraphNode<T>> Nodes
        {
            get { return this.nodes; }
        }

        public bool IsEmptyGraph()
        {
            return nodes.Count == 0;
        }
       // public void TopologicalSort()
        //{
         // TopologicalSort(ref nodes);
        //}
        public bool ContainsGraph(GraphNode<T> node)
        {
            foreach (GraphNode<T> n in nodes)
            {
                if (n.ID.CompareTo(node.ID) == 0)
                    return true;
            }
            return false;
        }

        public bool IsAdjacent(GraphNode<T> from, GraphNode<T> to)
        {
            foreach (GraphNode<T> n in nodes)
            {
                if (n.ID.CompareTo(from.ID) == 0)
                {
                   if (from.GetAdjList.Contains(to.ID))
                        return true;
                }
                
            }
            return false;
        }

        public void AddNode(T id)
        {
            GraphNode<T> n = new GraphNode<T>(id);
            nodes.AddFirst(n);
        }

        public GraphNode<T> GetNodeByID(T id)
        {
            foreach (GraphNode<T> n in nodes)
            {
                if (id.CompareTo(n.ID) == 0)
                    return n;
            }
            return null;
        }

        public void AddEdge(T from, T to)
        {
            GetNodeByID(from).AddEdge(GetNodeByID(to));
        }

        public void DepthFirstTraverse(T startID, ref List<T> visited)
        {
            LinkedList<T> adj;
            Stack<T> toVisit = new Stack<T>();

            GraphNode<T> current = new GraphNode<T>(startID);
            toVisit.Push(startID);

            while (toVisit.Count != 0)
            {
                current = GetNodeByID(toVisit.Pop());
                visited.Add(current.ID);
                foreach (T id in current.GetAdjList)
                {
                    if (!visited.Contains(id) && !toVisit.Contains(id))
                        toVisit.Push(id);
                }
            }
        }

        public void BreadthFirstTraverse(T startID, ref List<T> visited)
        {
            LinkedList<T> adj;
            Queue<T> toVisit = new Queue<T>();
            GraphNode<T> current = new GraphNode<T>(startID);

            toVisit.Enqueue(startID);

            while (toVisit.Count != 0)
            {
                current = GetNodeByID(toVisit.Dequeue());
                visited.Add(current.ID);
                foreach (T id in current.GetAdjList)
                {
                    if (!toVisit.Contains(id) && !visited.Contains(id))
                        toVisit.Enqueue(id);
                }
            }

        }
        public Boolean ListEq(List<T> L1, List<T> L2)
        {
            IEnumerable<T> L3;
           
            L3 = L2.Except(L1).ToList();
            return (L3.Count() == 0);
        }
        public List<T> mothervertex()
        {
            List<T> result = new List<T>();
            
            List<T> listOfID = new List<T>();
            foreach (GraphNode<T> n in nodes)
                listOfID.Add(n.ID);

            foreach (GraphNode<T> n in nodes)
            {
                List<T> reacheableNodes = new List<T>();
                DepthFirstTraverse(n.ID, ref reacheableNodes);
                //temp_adjNodes = n.GetAdjList.ToList()

                foreach (T item in reacheableNodes) 
                     System.Console.WriteLine("  ///// "+item );
                System.Console.WriteLine(" \n");
                if (ListEq(reacheableNodes, listOfID))
                {
                    System.Console.WriteLine(" Node id  " + n.ID + " is a mother vertex " + ListEq(reacheableNodes, listOfID));
                    break;
                }
                else
                    System.Console.WriteLine(" item {0} no mother vertex ", n.ID);

            }

            return result;
        }

        public List<GraphNode<T>> TopologicalSort()//ref LinkedList<GraphNode<T>> orderdList)
        {
            List<GraphNode<T>> orderdList = new List<GraphNode<T>>();
            foreach (GraphNode<T> node in this.nodes)
            {
                node.COLOR = 'W';
            }
            this.time = 0;
            foreach(GraphNode<T> node in this.nodes)
            {
                if (node.COLOR.Equals('W'))
                    TS_Visit(node);
            }
            //this.Nodes
            foreach(GraphNode<T> n in this.nodes)
            {
                orderdList.Add(n);
                System.Console.WriteLine(" ------- id "+ n.ID);
                System.Console.WriteLine(" ------- d " + n.DISCOVERY);
                System.Console.WriteLine(" ------- f " + n.FINISHING);
                System.Console.WriteLine(" \n");
            }
            //orderdList //= this.Nodes;
            return orderdList.OrderByDescending(x => x.FINISHING).ToList();
        }

        public void TS_Visit(GraphNode<T> node)
        {
            this.time = time + 1;
            node.DISCOVERY = this.time;
            node.COLOR = 'g';

            foreach(T adjNode in node.GetAdjList)
            {
                if (GetNodeByID(adjNode).COLOR.Equals('W'))
                    TS_Visit(GetNodeByID(adjNode));
            }

            node.COLOR = 'b';
            this.time = this.time + 1;
            node.FINISHING = this.time;
        }
    }
}
