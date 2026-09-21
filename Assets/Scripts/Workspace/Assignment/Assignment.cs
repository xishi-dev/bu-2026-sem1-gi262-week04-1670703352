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
            // AS10_GameEventQueue();
            //AS11_PlayerStatsTracker();
        }

        #region Assignment

        [Header("AS01 - Count Words")]
        [SerializeField] private string[] as01Words;

        public void AS01_CountWords()
        {
            string[] words = as01Words;
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

            foreach (var word in wordCount)
            {
                {
                    Debug.Log($"Word: {word.Key}, Count: {word.Value}");
                }
            }

        }

        [Header("AS02 - Count Number")]
        [SerializeField] private int[] as02Numbers;

        public void AS02_CountNumber()
        {
            int[] numbers = as02Numbers;
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

            foreach (var number in numberCount)
            {
                Debug.Log($"Number: {number.Key}, Count: {number.Value}");
            }
        }

        [Header("AS03 - Check Valid Brackets")]
        [SerializeField] private string as03Input;

        public void AS03_CheckValidBrackets()
        {
            string input = as03Input;
            Dictionary<char, char> bracketPairs = new Dictionary<char, char>();
            bracketPairs.Add('(', ')');
            LinkedList<char> stack = new LinkedList<char>();

            foreach (char c in input)
            {
                if (c == '(')
                {
                    stack.AddLast(c);
                }
                else if (c == ')')
                {
                    if (stack.Count == 0)
                    {
                        Debug.Log("Invalid");
                        return;
                    }
                    else if (bracketPairs.ContainsKey(stack.Last.Value))
                    {
                        stack.RemoveLast();
                    }
                    else
                    {
                        Debug.Log("Invalid");
                        return;
                    }
                }

            }
            if (stack.Count == 0)
            {
                Debug.Log("Valid");
            }
            else
            {
                Debug.Log("Invalid");
            }
        }

        [Header("AS04 - Print Reverse Linked List")]
        [SerializeField] private IntLinkedListInput as04List = new IntLinkedListInput();

        public void AS04_PrintReverseLinkedList()
        {
            LinkedList<int> list = as04List.GetLinkedList();
            var currentNode = list.Last;

            if (currentNode == null)
            {
                Debug.Log("Linked list is empty.");
                return;
            }
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
            if (list.Count == 0)
            {
                Debug.LogError("List is empty");
                return;
            }

            var slow = list.First;
            var fast = list.First;
            while (fast != null && fast.Next != null)
            {
                slow = slow.Next;
                fast = fast.Next.Next;
            }
            Debug.Log("Middle: " + slow.Value);
        }

        [Header("AS06 - Merge Dictionaries")]
        [SerializeField] private StringIntDictionaryInput as06FirstDictionary = new StringIntDictionaryInput();
        [SerializeField] private StringIntDictionaryInput as06SecondDictionary = new StringIntDictionaryInput();

        public void AS06_MergeDictionaries()
        {
            Dictionary<string, int> dict1 = as06FirstDictionary.GetDictionary();
            Dictionary<string, int> dict2 = as06SecondDictionary.GetDictionary();

            Dictionary<string, int> mergedDict = new Dictionary<string, int>(dict1);
            foreach (var pair in dict2)
            {
                if (mergedDict.ContainsKey(pair.Key))
                {
                    mergedDict[pair.Key] += pair.Value;
                }
                else
                {
                    mergedDict[pair.Key] = pair.Value;
                }
            }

            foreach (var pair in mergedDict)
            {
                Debug.Log("key: " + pair.Key + ", value: " + pair.Value);
            }
        }

        [Header("AS07 - Remove Duplicates From Linked List")]
        [SerializeField] private IntLinkedListInput as07List = new IntLinkedListInput();

        public void AS07_RemoveDuplicatesFromLinkedList()
        {
            LinkedList<int> list = as07List.GetLinkedList();

            if (list.Count <= 1)
            {
                foreach (int value in list)
                {
                    Debug.Log(value);
                }
                return;
            }
            Dictionary<int, bool> seen = new Dictionary<int, bool>();
            LinkedListNode<int> current = list.First;

            while (current != null)
            {

                LinkedListNode<int> next = current.Next;

                if (seen.ContainsKey(current.Value))
                {
                    list.Remove(current);
                }
                else
                {
                    seen.Add(current.Value, true);
                }
                current = next;
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
            if (as08Numbers == null || as08Numbers.Length <= 0)
            {
                Debug.Log("Input array is empty");
                return;
            }
            Dictionary<int, int> countMap = new Dictionary<int, int>();
            foreach (int number in as08Numbers)
            {
                if (countMap.ContainsKey(number))
                {
                    countMap[number]++;
                }
                else
                {
                    countMap[number] = 1;
                }
            }

            int topNumber = as08Numbers[0];
            int maxCount = countMap[topNumber];

            foreach (int number in as08Numbers)
            {
                int currentCount = countMap[number];
                if (currentCount > maxCount)
                {
                    topNumber = number;
                    maxCount = currentCount;
                }
            }
            Debug.Log(topNumber + " count: " + maxCount);
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
            foreach (var item in inventory)
            {
                var key = item.Key;
                var count = item.Value;
                Debug.Log($"{key} : {count}");
            }

        }

        [Header("AS10 - Game Event Queue")]
        [SerializeField] private GameEventLinkedListInput as10EventQueue = new GameEventLinkedListInput();

        public void AS10_GameEventQueue()
        {
            LinkedList<GameEvent> eventQueue = as10EventQueue.GetLinkedList();
            if (eventQueue.Count <= 0)
            {
                Debug.Log("Event queue is empty!");
                return;
            }

            while (eventQueue.Count > 0)
            {
                var current = eventQueue.First.Value;
                eventQueue.RemoveFirst();
                Debug.Log("Processing event: " + current.Name);
                Debug.Log("Remaining events: " + eventQueue.Count);
                Debug.Log($"{current.EventType} event processed: {current.Name}");
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

            if (playerStats.ContainsKey(statName))
            {
                playerStats[statName] += value;
            }
            else playerStats[statName] = value;
            Debug.Log($"Updated {statName} : {playerStats[statName]}");

            Debug.Log("Current player stats:");
            foreach (var stat in playerStats)
            {
                var key = stat.Key;
                var val = stat.Value;

                Debug.Log($"{key} : {val}");
            }
        }

        #endregion
    }
}