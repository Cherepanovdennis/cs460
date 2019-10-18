using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hw3
{
    public class LinkedQueue<T> : QueueInterface<T>
    {
        private Node<T> front;
        private Node<T> rear;


        public LinkedQueue()
        {
            front = null;
            rear = null;
        }

        public T push(T element)
        {
            if (element == null)
            {
                throw new System.ArgumentNullException("Parameter cannot be null");
            }

            if (isEmpty())
            {
                Node<T> tmp = new Node<T>(element, null);
                rear = front = tmp;
            }
            else
            {
                // General case
                Node<T> tmp = new Node<T>(element, null);
                rear.next = tmp;
                rear = tmp;
            }
            return element;
        }


        public T pop()
        {
            T tmp = default(T);
            if (isEmpty())
            {
                throw new QueueUnderflowException("The queue was empty when pop was invoked.");
            }
            else if (front == rear)
            {   // one item in queue
                tmp = front.data;
                front = null;
                rear = null;
            }
            else
            {
                // General case
                tmp = front.data;
                front = front.next;
            }

            return tmp;
        }


        public bool isEmpty()
        {
           if (front == null && rear == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public T peek()
        {
            if (isEmpty())
            {
                throw new QueueUnderflowException("The queue was empty when peek was invoked.");
            }
            return front.data;
        }

    }

   
}


