using System;
using System.Collections.Generic;
using System.Text;

namespace Graph
{
    class GraphNode<T> where T : IComparable
    {
        private T id;
        private LinkedList<T> adjList;
        private char color;
        private int discovery, finishing; 
        
        public GraphNode(T id)
        {
            this.id = id;
            this.adjList = new LinkedList<T>();
            this.color = 'W';
            //this.discovery = 0;
            //this.finishing = 0;
            
        }

        public T ID
        {
            get { return this.id; }
            set { this.id = value; }
        }

        public void AddEdge(GraphNode<T> to)
        {

            this.adjList.AddFirst(to.ID);
        }

        public int CompareTo(object obj)
        {
            if (obj == null) return 1;
            GraphNode<T> other = (GraphNode<T>)obj;
            return this.FINISHING.CompareTo(other.FINISHING);
            throw new NotImplementedException(" cannot compare these two ");
        }

        public LinkedList<T> GetAdjList
        {
            get{ return this.adjList; }
        }

        public char COLOR
        {
            get { return this.color; }
            set { this.color = value; }
        }

        public int DISCOVERY
        {
            get { return this.discovery; }
            set { this.discovery = value; }
        }

        public int FINISHING
        {
            get { return this.finishing; }
            set { this.finishing = value; }
        }
    }

}
