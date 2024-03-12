namespace DynamicQueue
{
    class DynamicQueue<T> : IQueue<T>
    {
        #region Private embedded class for individual nodes in the list
        private class Node
        {
            public T element { get; private set; }
            public Node Next { get; set; } //Recursive definition

            //Constructor
            public Node(T element, Node prevNode)
            {
                this.element = element;
                Next = null;
                if (prevNode != null) //if this is not the first node
                    prevNode.Next = this;
            } //Constructor

        } //embedded class Node
        #endregion Embedded class
        
        #region private data members of the list
        private Node head, tail;
        #endregion

        #region Property for count
        public int Count { get; private set; } //Count
        #endregion

        #region Constructor
        //Constructor for the list
        public DynamicQueue()
        {
            this.head = null;
            this.tail = null;
            this.Count = 0;
        } //Constructor
        #endregion
        
        #region Queue operations

        public void Enqueue(T item)
        {
            if (this.head == null) //Empty queue - this is the first element to be added
                this.head = this.tail = new Node(item, null);
            else //We have existing items - add the new node after the last element
                tail = new Node(item, tail);
            Count++;
        } //Enqueue

        public void Clear()
        {
            head = null;
            tail = null;
            Count = 0;
        } //Clear

        public T Dequeue()
        {
            if (head != null)
            {
                T item = head.element;
                head = head.Next;
                Count--;
                return item;
            }
            return default(T);
        } //Dequeue

        public T Peek()
        {
            if (head != null)
                return head.element;
            else
                return default(T);
        } //Peek

        public bool Contains(T item)
        {
            Node current = head;
            while (current != null)
            {
                if (object.Equals(current.element, item))
                    return true;
                else
                    current = current.Next;
            }
            return false;
        } //Contains

        public int Position(T item)
        {
            Node current = head;
            int i = 0;
            while (current != null)
            {
                if (object.Equals(current.element, item))
                    return i;
                else
                {
                    current = current.Next;
                    i++;
                }
            }
            return -1;

        } //Position

        #endregion Queue operations
    
    } //class DynamicQueue

    public interface IQueue<T>
    {
        void Enqueue(T value);
        void Clear();
        T Dequeue();
        T Peek();
        bool Contains(T item);
        int Position(T item);
        int Count { get; }
    } //interface

} //namespace
