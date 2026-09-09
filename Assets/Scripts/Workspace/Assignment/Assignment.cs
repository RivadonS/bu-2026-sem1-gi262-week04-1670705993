using UnityEngine;
using System.Collections.Generic;

namespace Assignment
{
    public class Assignment : MonoBehaviour
    {
        public void Start()
        {
            // AS01_CountWords();
            // AS02_CountNumber();
            // AS03_CheckValidBrackets();
            // AS04_PrintReverseLinkedList();
            // AS05_FindMiddleElement();
            // AS06_MergeDictionaries();
            // AS07_RemoveDuplicatesFromLinkedList();
            // AS08_TopFrequentNumber();
            // AS09_PlayerInventory();
             AS10_GameEventQueue();
            // AS11_PlayerStatsTracker();
        }

        #region Assignment

        [Header("AS01 - Count Words")]
        [SerializeField] private string[] as01Words;

        public void AS01_CountWords()
        {
            string[] words = as01Words;
            if (words == null || words.Length == 0)
            {
                Debug.Log("Words Not Provided");
                return;
            }

            Dictionary<string, int> wordCount = new Dictionary<string, int>();

            foreach (string word in words)
            {
                if (wordCount.ContainsKey(word))
                {
                    wordCount[word]++;
                }
                else
                {
                    wordCount[word] = 1;
                }
            }

            foreach (var kvp in wordCount)
            {
                Debug.Log($"Word: {kvp.Key}, Count: {kvp.Value}");
            }
        }

        [Header("AS02 - Count Number")]
        [SerializeField] private int[] as02Numbers;

        public void AS02_CountNumber()
        {
            int[] numbers = as02Numbers;
            if (numbers == null || numbers.Length == 0)
            {
                Debug.Log("Numbers Not Provided");
                return;
            }

            Dictionary<int, int> numberCount = new Dictionary<int, int>();

            foreach (int number in numbers)
            {
                if (numberCount.ContainsKey(number))
                {
                    numberCount[number]++;
                }
                else
                {
                    numberCount[number] = 1;
                }
            }

            foreach (var kvp in numberCount)
            {
                Debug.Log($"Number: {kvp.Key}, Count: {kvp.Value}");
            }
        }

        [Header("AS03 - Check Valid Brackets")]
        [SerializeField] private string as03Input;

        public void AS03_CheckValidBrackets()
        {
            string input = as03Input;
            Dictionary<char, char> bracketPairs = new Dictionary<char, char>
            {
                { '(', ')' },
                { '{', '}' },
                { '[', ']' }
            };

            LinkedList<char> stack = new LinkedList<char>();
            bool isValid = true;

            if (input != null)
            {
                foreach (char c in input)
                {
                    if (bracketPairs.ContainsKey(c))
                    {
                        stack.AddLast(c);
                    }
                    else if (bracketPairs.ContainsValue(c))
                    {
                        if (stack.Count == 0)
                        {
                            isValid = false;
                            break;
                        }

                        char lastOpenBracket = stack.Last.Value;
                        if (bracketPairs[lastOpenBracket] != c)
                        {
                            isValid = false;
                            break;
                        }
                        stack.RemoveLast();
                    }
                }
            }

            if (stack.Count > 0)
            {
                isValid = false;
            }

            Debug.Log(isValid ? "Valid" : "Invalid");
        }

        [Header("AS04 - Print Reverse Linked List")]
        [SerializeField] private IntLinkedListInput as04List = new IntLinkedListInput();

        public void AS04_PrintReverseLinkedList()
        {
            LinkedList<int> list = as04List.GetLinkedList();
            if (list == null || list.Count == 0)
            {
                Debug.Log("Linked List is empty.");
                return;
            }

            LinkedListNode<int> currentNode = list.Last;

            while (currentNode != null)
            {
                Debug.Log(currentNode.Value);
                currentNode = currentNode.Previous;
            }
        }

        [Header("AS05 - Find Middle Element")]
        [SerializeField] private StringLinkedListInput as05List = new StringLinkedListInput();

        public void AS05_FindMiddleElement()
        {
            LinkedList<string> list = as05List.GetLinkedList();
            if(list == null || list.Count == 0)
            {
                Debug.Log("Linked List is empty.");
                return;
            }

            LinkedListNode<string> slow = list.First;
            LinkedListNode<string> fast = list.First;

            while (fast != null && fast.Next != null)
            {
                slow = slow.Next;
                fast = fast.Next.Next;
            }

            Debug.Log("Middle element: " + slow.Value);
        }

        [Header("AS06 - Merge Dictionaries")]
        [SerializeField] private StringIntDictionaryInput as06FirstDictionary = new StringIntDictionaryInput();
        [SerializeField] private StringIntDictionaryInput as06SecondDictionary = new StringIntDictionaryInput();

        public void AS06_MergeDictionaries()
        {
            Dictionary<string, int> dict1 = as06FirstDictionary.GetDictionary();
            Dictionary<string, int> dict2 = as06SecondDictionary.GetDictionary();
            
            Dictionary<string, int> mergedDictionary = new Dictionary<string, int>(dict1);

            foreach (KeyValuePair<string, int> entry in dict2)
            {
                if (mergedDictionary.ContainsKey(entry.Key))
                {
                    mergedDictionary[entry.Key] += entry.Value;
                }
                else
                {
                    mergedDictionary[entry.Key] = entry.Value;
                }
            }

            foreach (KeyValuePair<string, int> entry in mergedDictionary)
            {
                Debug.Log($"Key: {entry.Key}, Value: {entry.Value}");
            }
        }

        [Header("AS07 - Remove Duplicates From Linked List")]
        [SerializeField] private IntLinkedListInput as07List = new IntLinkedListInput();

        public void AS07_RemoveDuplicatesFromLinkedList()
        {
            LinkedList<int> list = as07List.GetLinkedList();
            
            if (list == null || list.Count == 0)
            {
                Debug.Log("Linked List is empty.");
                return;
            }

            Dictionary<int, bool> seen = new Dictionary<int, bool>();

            LinkedListNode<int> currentNode = list.First;

            while (currentNode != null)
            {
                LinkedListNode<int> nextNode = currentNode.Next;
                if (seen.ContainsKey(currentNode.Value))
                {
                    list.Remove(currentNode);
                }
                else
                {
                    seen[currentNode.Value] = true;
                }
                currentNode = nextNode;
            }

            foreach (int value in list)
            {
                Debug.Log(value);
            }
        }

        [Header("AS08 - Top Frequent Number")]
        [SerializeField] private int[] as08Numbers;

        public void AS08_TopFrequentNumber()
        {
            int[] numbers = as08Numbers;
            
            if (numbers == null || numbers.Length == 0)
            {
                Debug.Log("Numbers Not Provided");
                return;
            }

            Dictionary<int, int> frequencyMap = new Dictionary<int, int>();

            foreach (int number in numbers)
            {
                if (frequencyMap.ContainsKey(number))
                {
                    frequencyMap[number]++;
                }
                else
                {
                    frequencyMap[number] = 1;
                }
            }

            int topNumber = numbers[0];
            int maxCount = frequencyMap[topNumber];

            foreach (int num in numbers)
            {
                int currentCount = frequencyMap[num];

                if (currentCount > maxCount)
                {
                    maxCount = currentCount;
                    topNumber = num;
                }
            }

            Debug.Log($"Top frequent number: {topNumber}, Frequency: {maxCount}");
        }

        [Header("AS09 - Player Inventory")]
        [SerializeField] private StringIntDictionaryInput as09Inventory = new StringIntDictionaryInput();
        [SerializeField] private string as09ItemName;
        [SerializeField] private int as09Quantity;

        public void AS09_PlayerInventory()
        {
            Dictionary<string, int> inventory = as09Inventory.GetDictionary();
            string itemName = as09ItemName;
            int quantity = as09Quantity;
            
            if (inventory.ContainsKey(itemName))
            {
                inventory[itemName] += quantity;
            }
            else
            {
                inventory[itemName] = quantity;
            }

            foreach (var kvp in inventory)
            {
                Debug.Log($"Item: {kvp.Key}, Quantity: {kvp.Value}");
            }
        }

        [Header("AS10 - Game Event Queue")]
        [SerializeField] private GameEventLinkedListInput as10EventQueue = new GameEventLinkedListInput();

        public void AS10_GameEventQueue()
        {
            LinkedList<GameEvent> eventQueue = as10EventQueue.GetLinkedList();
            
            if (eventQueue == null || eventQueue.Count == 0)
            {
                Debug.Log("Event Queue is empty.");
                return;
            }

            while (eventQueue.Count > 0)
            {
                GameEvent currentEvent = eventQueue.First.Value;

                eventQueue.RemoveFirst();

                Debug.Log($"Processing Event: {currentEvent.Name}");
                Debug.Log($"Remaining Events: {eventQueue.Count}");

                switch (currentEvent.EventType.ToLower())
                {
                    case "enemy":
                        Debug.Log($"Enemy event processed - {currentEvent.Name}");
                break;
                    case "powerup":
                        Debug.Log($"Power-up event processed - {currentEvent.Name}");
                break;
                    case "level":
                        Debug.Log($"Level event processed - {currentEvent.Name}");
                break;
                }
            }
        }

        [Header("AS11 - Player Stats Tracker")]
        [SerializeField] private StringIntDictionaryInput as11PlayerStats = new StringIntDictionaryInput();
        [SerializeField] private string as11StatName;
        [SerializeField] private int as11Value;

        public void AS11_PlayerStatsTracker()
        {
            Dictionary<string, int> playerStats = as11PlayerStats.GetDictionary();
            string statName = as11StatName;
            int value = as11Value;
            throw new System.NotImplementedException();
        }

        #endregion
    }
}
