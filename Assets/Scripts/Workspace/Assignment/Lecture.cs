using UnityEngine;
using System.Collections.Generic;

namespace Assignment
{
    public class Lecture : MonoBehaviour
    {
        public void Start()
        {
            // LCT01_SyntaxList();
            // LCT02_SyntaxLinkedList();
            // LCT03_SyntaxHashTable();
            // LCT04_SyntaxDictionary();
        }

        #region Lecture

        public void LCT01_SyntaxList()
        {
            List<string> list = new List<string>();
            list.Add("Item 1");
        }

        public void LCT02_SyntaxLinkedList()
        {
            LinkedList<string> linkedList = new LinkedList<string>();
            linkedList.AddLast("Node 1");
            linkedList.AddLast("Node 2");
            linkedList.AddFirst("Node 0");
            PrintLinkedList(linkedList);

            LinkedListNode<string> firstNode = linkedList.First;
            LinkedListNode<string> lastNode = linkedList.Last;
            LinkedListNode<string> node1 = linkedList.Find("Node 1");

            Debug.Log("First Node: " + firstNode.Value);
            Debug.Log("Last Node: " + lastNode.Value);
            Debug.Log("Node 1: " + node1.Value);
            Debug.Log("Node 1 Previous: " + node1.Previous.Value);
            Debug.Log("Node 1 Next: " + node1.Next.Value);

            if (firstNode.Previous == null)
            {
                Debug.Log("First node has no previous node.");
            }
            if (lastNode.Next == null)
            {
                Debug.Log("Last node has no Next node.");
            }

            linkedList.AddAfter(node1, "Node 1.5");
            linkedList.AddBefore(node1, "Node 0.5");
            PrintLinkedList(linkedList);

            linkedList.RemoveFirst();
            PrintLinkedList(linkedList);
            linkedList.Remove("Node 2"); //ถ้ามี Node 2 มากกว่า 1 ตัว ลบตัวแรกสุดที่เจอ
            //linkedList.Remove(node1);
            PrintLinkedList(linkedList);
            linkedList.Clear();
            PrintLinkedList(linkedList);
        }

        void PrintLinkedList(LinkedList<string> linkedList)
        {
            Debug.Log("----Linked List----");
            foreach (var node in linkedList)
            {
                Debug.Log(node);
            }
        }

        public void LCT03_SyntaxHashTable()
        {
            throw new System.NotImplementedException();
        }

        public void LCT04_SyntaxDictionary()
        {
            Dictionary<int, string> dictionary = new Dictionary<int, string>();
            dictionary.Add(1, "Apple");
            dictionary.Add(2, "Banana");
            dictionary[3] = "Cherry"; // = Add

            //Debug.Log($"{dictionary[1]}");
            int keytocheck = 1;
            bool haskey = dictionary.ContainsKey(keytocheck);
            Debug.Log($"Dictionary has key {keytocheck}: {haskey}");
            if (haskey)
            {
                Debug.Log(dictionary[keytocheck]);
            }

            foreach (int k in dictionary.Keys)
            {
                Debug.Log(k);
            }
            foreach (string s in dictionary.Values)
            {
                Debug.Log(s);
            }
            dictionary.Remove(1);
            foreach (string s in dictionary.Values)
            {
                Debug.Log(s);
            }
            dictionary.Clear();
            foreach (string s in dictionary.Values)
            {
                Debug.Log(s);
            }
        }

        #endregion
    }
}
