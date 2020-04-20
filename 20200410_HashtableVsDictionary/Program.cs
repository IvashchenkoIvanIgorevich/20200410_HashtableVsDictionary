using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;

namespace _20200410_HashtableVsDictionary
{   
    class Program
    {
        static void Main(string[] args)
        {
            #region ===--- Create Date ---===

            Random rnd = new Random();

            long[] hash = new long[9];
            long[] dict = new long[9];
            long[] sortL = new long[9];
            long[] sortD = new long[9];

            ////HashTable 
            //Hashtable table1 = new Hashtable();
            //CollectionAnalyzer hashTableAnalyzer = new CollectionAnalyzer(table1);

            //Dictionary
            Dictionary<double, double> dict1 = new Dictionary<double, double>();
            CollectionAnalyzer<double, double> dictionaryAnalyzer = new CollectionAnalyzer<double, double>(dict1);

            //SortedList
            SortedList<double, double> sortList = new SortedList<double, double>();
            CollectionAnalyzer<double, double> sortListAnalyzer = new CollectionAnalyzer<double, double>(sortList);

            //SortedDictionary
            SortedDictionary<double, double> sortDict = new SortedDictionary<double, double>();
            CollectionAnalyzer<double, double> sortDictAnalyzer = new CollectionAnalyzer<double, double>(sortDict);

            ICollection<double> randomNumbers = CreateCollectionWithRndNum(rnd);
            int countNumbers = randomNumbers.Count;

            double[] rndNum = new double[countNumbers];
            randomNumbers.CopyTo(rndNum, 0);

            double[] MinToMaxNum = new double[countNumbers];
            rndNum.CopyTo(MinToMaxNum, 0);
            Array.Sort(MinToMaxNum);

            double[] MaxToMinNum = new double[countNumbers];
            MinToMaxNum.CopyTo(MaxToMinNum, 0);
            Array.Reverse(MaxToMinNum);

            #endregion

            #region ===--- TimeAdd Random Numbers ---===

            //hash[0] = hashTableAnalyzer.AddToCollection(rndNum, rnd);
            dict[0] = dictionaryAnalyzer.AddToCollection(rndNum, rndNum, rnd);
            sortL[0] = sortListAnalyzer.AddToCollection(rndNum, rndNum, rnd);
            sortD[0] = sortDictAnalyzer.AddToCollection(rndNum, rndNum, rnd);

            #endregion

            #region === ---TimeAdd MinToMax Numbers ---===

            //HashTable
           // hashTableAnalyzer.ClearCollection();

            //Dictionary
            dictionaryAnalyzer.ClearCollection();

            //SortedList
            sortListAnalyzer.ClearCollection();

            //SortedDictionary
            sortDictAnalyzer.ClearCollection();

           // hash[1] = hashTableAnalyzer.AddToCollection(MinToMaxNum, rnd);
            dict[1] = dictionaryAnalyzer.AddToCollection(MinToMaxNum, MinToMaxNum, rnd);
            sortL[1] = sortListAnalyzer.AddToCollection(MinToMaxNum, MinToMaxNum, rnd);
            sortD[1] = sortDictAnalyzer.AddToCollection(MinToMaxNum, MinToMaxNum, rnd);

            #endregion

            #region === ---TimeAdd MaxToMin Numbers ---===

            //HashTable
            //hashTableAnalyzer.ClearCollection();

            //Dictionary
            dictionaryAnalyzer.ClearCollection();

            //SortedList
            sortListAnalyzer.ClearCollection();

            //SortedDictionary
            sortDictAnalyzer.ClearCollection();

            //hash[2] = hashTableAnalyzer.AddToCollection(MaxToMinNum, rnd);
            dict[2] = dictionaryAnalyzer.AddToCollection(MaxToMinNum, MaxToMinNum, rnd);
            sortL[2] = sortListAnalyzer.AddToCollection(MaxToMinNum, MaxToMinNum, rnd);
            sortD[2] = sortDictAnalyzer.AddToCollection(MaxToMinNum, MaxToMinNum, rnd);

            #endregion

            #region ===--- TimeRemove By Key Random ---===

            //HashTable
            //hashTableAnalyzer.ClearCollection();
            //hashTableAnalyzer.AddToCollection(rndNum, rnd);

            //Dictionary
            dictionaryAnalyzer.ClearCollection();
            dictionaryAnalyzer.AddToCollection(rndNum, rndNum, rnd);

            //SortedList
            sortListAnalyzer.ClearCollection();
            sortListAnalyzer.AddToCollection(rndNum, rndNum, rnd);

            //SortedDictionary
            sortDictAnalyzer.ClearCollection();
            sortDictAnalyzer.AddToCollection(rndNum, rndNum, rnd);

            //hash[3] = hashTableAnalyzer.RemoveByKey(rndNum);
            dict[3] = dictionaryAnalyzer.RemoveByKey(rndNum);
            sortL[3] = sortListAnalyzer.RemoveByKey(rndNum);
            sortD[3] = sortDictAnalyzer.RemoveByKey(rndNum);

            #endregion

            //SortedList sortedHash = new SortedList(table1);
            //SortedList sortedDict = new SortedList(dict1);

            #region ===--- TimeRemove By Key MinToMax ---===

            //HashTable
            //hashTableAnalyzer.AddToCollection(MinToMaxNum, rnd);

            //Dictionary
            dictionaryAnalyzer.AddToCollection(MinToMaxNum, rndNum, rnd);

            //SortedList
            sortListAnalyzer.AddToCollection(MinToMaxNum, rndNum, rnd);

            //SortedDictionary
            sortDictAnalyzer.AddToCollection(MinToMaxNum, rndNum, rnd);

           // hash[4] = hashTableAnalyzer.RemoveByKey(MinToMaxNum);
            dict[4] = dictionaryAnalyzer.RemoveByKey(MinToMaxNum);
            sortL[4] = sortListAnalyzer.RemoveByKey(MinToMaxNum);
            sortD[4] = sortDictAnalyzer.RemoveByKey(MinToMaxNum);

            #endregion

            #region ===--- TimeRemove By Key MaxToMin ---===

            //HashTable
            //hashTableAnalyzer.AddToCollection(MaxToMinNum, rnd);

            //Dictionary
            dictionaryAnalyzer.AddToCollection(MaxToMinNum, rndNum, rnd);

            //SortedList
            sortListAnalyzer.AddToCollection(MaxToMinNum,rndNum, rnd);

            //SortedDictionary
            sortDictAnalyzer.AddToCollection(MaxToMinNum, rndNum, rnd);

            //hash[5] = hashTableAnalyzer.RemoveByKey(MaxToMinNum);
            dict[5] = dictionaryAnalyzer.RemoveByKey(MaxToMinNum);
            sortL[5] = sortListAnalyzer.RemoveByKey(MaxToMinNum);
            sortD[5] = sortDictAnalyzer.RemoveByKey(MaxToMinNum);

            #endregion

            #region ===--- TimeGet Random ---===

            //HashTable
            //hashTableAnalyzer.AddToCollection(rndNum, rnd);

            //Dictionary
            dictionaryAnalyzer.AddToCollection(rndNum, rndNum, rnd);

            //SortedList
            sortListAnalyzer.AddToCollection(rndNum, rndNum, rnd);

            //SortedDictionary
            sortDictAnalyzer.AddToCollection(rndNum, rndNum, rnd);

            //hash[6] = hashTableAnalyzer.GetByKey(rndNum, 90000, rnd);
            dict[6] = dictionaryAnalyzer.GetByKey(rndNum, 90000, rnd);
            sortL[6] = sortListAnalyzer.GetByKey(rndNum, 90000, rnd);
            sortD[6] = sortDictAnalyzer.GetByKey(rndNum, 90000, rnd);

            #endregion

            #region ===--- TimeGet MinToMax ---===

            //HashTable
            //hashTableAnalyzer.ClearCollection();
            //hashTableAnalyzer.AddToCollection(MinToMaxNum, rnd);

            //Dictionary
            dictionaryAnalyzer.ClearCollection();
            dictionaryAnalyzer.AddToCollection(MinToMaxNum, rndNum, rnd);

            //SortedList
            sortListAnalyzer.ClearCollection();
            sortListAnalyzer.AddToCollection(MinToMaxNum,rndNum, rnd);

            //SortedDictionary
            sortDictAnalyzer.ClearCollection();
            sortDictAnalyzer.AddToCollection(MinToMaxNum, rndNum, rnd);

            //hash[7] = hashTableAnalyzer.GetByKey(MinToMaxNum, 90000, rnd);
            dict[7] = dictionaryAnalyzer.GetByKey(MinToMaxNum, 90000, rnd);
            sortL[7] = sortListAnalyzer.GetByKey(MinToMaxNum, 90000, rnd);
            sortD[7] = sortDictAnalyzer.GetByKey(MinToMaxNum, 90000, rnd);

            #endregion

            #region ===--- TimeGet MinToMax ---===

            //HashTable
          //  hashTableAnalyzer.ClearCollection();
           // hashTableAnalyzer.AddToCollection(MaxToMinNum, rnd);

            //Dictionary
            dictionaryAnalyzer.ClearCollection();
            dictionaryAnalyzer.AddToCollection(MaxToMinNum, rndNum, rnd);

            //SortedList
            sortListAnalyzer.ClearCollection();
            sortListAnalyzer.AddToCollection(MaxToMinNum, rndNum, rnd);

            //SortedDictionary
            sortDictAnalyzer.ClearCollection();
            sortDictAnalyzer.AddToCollection(MaxToMinNum, rndNum, rnd);

            //hash[8] = hashTableAnalyzer.GetByKey(MaxToMinNum, 90000, rnd);
            dict[8] = dictionaryAnalyzer.GetByKey(MaxToMinNum, 90000, rnd);
            sortL[8] = sortListAnalyzer.GetByKey(MaxToMinNum, 90000, rnd);
            sortD[8] = sortDictAnalyzer.GetByKey(MaxToMinNum, 90000, rnd);

            #endregion

            PrinResult(hash, dict, sortL, sortD);

            Console.ReadKey();
        }

        public static ICollection<double> CreateCollectionWithRndNum(Random rnd)
        {
            HashSet<double> fillHashSet = new HashSet<double>(ConstantValue.NUMBER_OF_KEYS);

            while(fillHashSet.Count < ConstantValue.NUMBER_OF_KEYS)
            {
                fillHashSet.Add((double)rnd.Next(0, ConstantValue.NUMBER_OF_KEYS)
                    / (double)DateTime.Now.Millisecond);
            }
            
            return fillHashSet;
        }

        public static object GetKeyInMiddleCollection(IDictionary diction)
        {
            object result = default;
            int count = 0;

            foreach (DictionaryEntry item in diction)
            {
                ++count;

                if (count == (diction.Count / 2))
                {
                    result = item.Key;
                    break;
                }
            }

            return result;
        }

        public static void PrinResult(long[] hash, long[] dict, long[] sortL, long[] sortD)
        {
            Console.WriteLine("  ______________________________________________________________________________________________________________  ");
            Console.WriteLine(" |            |_____________Add_______________|______________Remove____________|_______________Get______________| ");
            Console.WriteLine(" | Collection |   Rnd   | MinToMax | MaxToMin |    Rnd   | MinToMax | MaxToMin |    Rnd   | MinToMax | MaxToMin | ");
            Console.WriteLine(" |____________|_________|__________|__________|__________|__________|__________|__________|__________|__________| ");
            Console.WriteLine(" |  HashTable |{0,9}|{1,10}|{2,10}|{3,10}|{4,10}|{5,10}|{6,10}|{7,10}|{8,10}| ", hash[0], hash[1], hash[2], hash[3], hash[4], hash[5], hash[6], hash[7], hash[8]);
            Console.WriteLine(" |____________|_________|__________|__________|__________|__________|__________|__________|__________|__________| ");
            Console.WriteLine(" | Dictionary |{0,9}|{1,10}|{2,10}|{3,10}|{4,10}|{5,10}|{6,10}|{7,10}|{8,10}| ", dict[0], dict[1], dict[2], dict[3], dict[4], dict[5], dict[6], dict[7], dict[8]);
            Console.WriteLine(" |____________|_________|__________|__________|__________|__________|__________|__________|__________|__________| ");
            Console.WriteLine(" | SortedList |{0,9}|{1,10}|{2,10}|{3,10}|{4,10}|{5,10}|{6,10}|{7,10}|{8,10}| ", sortL[0], sortL[1], sortL[2], sortL[3], sortL[4], sortL[5], sortL[6], sortL[7], sortL[8]);
            Console.WriteLine(" |____________|_________|__________|__________|__________|__________|__________|__________|__________|__________| ");
            Console.WriteLine(" |   Sorted   |{0,9}|{1,10}|{2,10}|{3,10}|{4,10}|{5,10}|{6,10}|{7,10}|{8,10}| ", sortD[0], sortD[1], sortD[2], sortD[3], sortD[4], sortD[5], sortD[6], sortD[7], sortD[8]);
            Console.WriteLine(" |_Dictionary_|_________|__________|__________|__________|__________|__________|__________|__________|__________| ");
        }        
    }
}
