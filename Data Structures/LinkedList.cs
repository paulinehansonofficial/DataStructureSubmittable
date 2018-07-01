﻿using System;
using System.Threading;
using System.Transactions;

namespace Data_Structures 
{
    public class LinkedListNode 
    {
        public string Data;
        public LinkedListNode Next;


        public LinkedListNode(string data, LinkedListNode next) 
        {
            this.Data = data;
            this.Next = null;
        }
    }

    public class LinkedList 
    {
        public LinkedListNode Head;

        public LinkedList() 
        {
            Head = null;
        }

        public void AddToEnd(string newData) 
        {
            LinkedListNode newNode = new LinkedListNode(newData, null);
            
            if (Head == null) 
            {
                Head = newNode;
                return;
            } 
            
            LinkedListNode current = Head;

            while (current.Next != null) 
            {
                current = current.Next;
            }

                current.Next = newNode;
        }
        
        public LinkedListNode GetNodeAt(int index) 
        {
            int count = 0;

            if (index < 0) 
            {
                return null;
            }
            
            LinkedListNode current = Head;
            while (count < index) 
            {
                if (current.Next != null) 
                {
                    current = current.Next;
                } else 
                {
                    return null;
                }
                count++;
            }

            return current;
        }

        public bool Find(string searchTerm) 
        {
            LinkedListNode current = Head;

            while (current != null) 
            {
                if (current.Data == searchTerm) 
                {
                    return true;
                }

                current = current.Next;
            }

            return false;
        }

        /// <summary>
        /// Returns the number of nodes in the Linked List
        /// </summary>
        /// <returns>int: count</returns>
        public int Count() 
        {
            LinkedListNode current = Head;
            int totalNodes = 1;

            while (current.Next != null)
            {
                totalNodes = totalNodes + 1;
                current = current.Next;
                
            }
            return totalNodes;
        }

        /// <summary>
        /// Adds a node to the start of the list.
        /// </summary>
        /// <param name="data"></param>
        /// <returns>success: true</returns>
        public bool AddToStart(string data) 
        {
            LinkedListNode new_node = new LinkedListNode(data, null);

            if (Head == null) 
            {
                Head = new_node;
                return true;
            }

            LinkedListNode current = Head;
            new_node.Next = current;
            Head = new_node;

            return true;
        }

        public bool AddNodeAt(string data, int index) 
        {
            LinkedListNode new_node = new LinkedListNode(data, null);

            LinkedListNode node_before = new LinkedListNode(null, null);
            LinkedListNode node_after = new LinkedListNode(null, null);

            node_before = GetNodeAt(index-1);
            node_after = node_before.Next;
            new_node.Next = node_after;
            node_before.Next = new_node;
                                 
            return true;
        }

        public bool DeleteNodeAt(int index) 
        {
            LinkedListNode node_before = new LinkedListNode(null, null);
            LinkedListNode delete_node = GetNodeAt(index);

            node_before = GetNodeAt(index - 1);
            node_before.Next = delete_node.Next;

            return true;
        }

    }
}