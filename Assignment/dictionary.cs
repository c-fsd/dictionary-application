using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2080_Assignment1
{
    class dictonary
    {
        private int numWords;
        private int maxWords;
        private wordInfo[] wlist; //private wordInfo[] m_array???;

        public dictonary(int max)
        {
            numWords = 0;
            maxWords = max;
            wlist = new wordInfo[maxWords];
        }
        public bool addWord(string word, string meaning)
        {
            for (int x = 0; x < numWords; x++)
            {
                if (word == wlist[x].getWord() || (numWords > maxWords))
                {
                    Console.WriteLine("Duplicate!");
                    return false;
                }
            }
            wordInfo w = new wordInfo(word, meaning);
            wlist[numWords] = w;
            numWords++;
            return true;
        }
        public bool deleteWord(string word)
        {
            int loc = -1;
            for (int x = 0; x < numWords; x++)
            {
                if (wlist[x].getWord() == word)
                {
                    loc = x;
                }
            }
            if (loc == -1) return false;
            wlist[loc] = wlist[numWords - 1];
            numWords--;
            return true;
        }
        /*public void findWord(string word)
        {
            for (int x = 0; x < numWords; x++)
            {
                if (wlist[x].getWord() == word)
                    Console.WriteLine( wlist[x].getWord());
            }
            Console.WriteLine("Can't find");
        }*/
        public string findWord(string word)
        {
            for (int x = 0; x < numWords; x++)
            {
                if (wlist[x].getWord() == word)
                    return wlist[x].getWord() + ": "+ wlist[x].getMeaning();
            }
            return "Can't find";
        }
        public string search(string word)
        {
            int low, high, mid;
            low = 0;
            high = numWords - 1;
            while (low <= high)
            {
                mid = (low + high) / 2;
                if(wlist[mid].getWord() == word)
                {
                    return wlist[mid].getMeaning();
                }
                int compare = string.Compare(word, wlist[mid].getWord());
                if (compare < 0)
                {
                    high = mid - 1;
                }
                else
                {
                    low = mid + 1;
                }
            }
            return "Can't find";
        }
        public string printDictionary()
        {
            
            string s = "";
            for (int x = 0; x < numWords; x++)
            {
                s = s + "\n" + wlist[x].getWord() + "\t" + wlist[x].getMeaning();
            }
            return s;
        }
        public string printOrder()
        {
            insertionSort(wlist);
            string s = "";
            for (int x = 0; x < numWords; x++)
            {
                s = s + "\n" + wlist[x].getWord() + "\t" + wlist[x].getMeaning();
            }
            return s;
        }
        public string printWordList()
        {
            string s = "";
            for (int x = 0; x < numWords; x++)
            {
                s = s + "\n" + wlist[x].getWord();
            }
            return s;
        }
        /*public void printOrder(wordInfo[] array)
        {
            int start, presentLoc;
            //int presentLoc = start - 1;
            for ( start = 1; start < numWords; start++)
            {
                presentLoc = start - 1;
                wordInfo temp = wlist[start];
                //string z ="";
                //int compare = string.Compare(wlist[start].getWord(), wlist[presentLoc].getWord());
                while ((presentLoc >= 0) && (wlist[presentLoc].getWord().CompareTo(temp)>0)){
                    wlist[presentLoc + 1] = wlist[presentLoc];
                    presentLoc--;
                }

               wlist[presentLoc + 1] = temp;
                
                    //wlist[presentLoc].getWord() > temp)
            }
        }*/
        public void insertionSort(wordInfo[] array)
        {
            for (int start = 1; start < numWords; start++)
            {
                wordInfo temp = wlist[start];
                int presentLoc = start - 1;
                //string z ="";
                int compare = string.Compare(wlist[start].getWord(), wlist[presentLoc].getWord());
                while (presentLoc >= 0 && compare > 0) {
                    wlist[presentLoc + 1] = wlist[presentLoc];
                    presentLoc--;
                }
                wlist[presentLoc + 1]=temp;         
            }
        }
        /*public void InsertSort(IComparable[] array)
        {
            int i, j;

            for (i = 1; i < wlist.Length; i++)
            {
                wordInfo value = wlist[i];
                j = i - 1;
                while ((j >= 0) && (array[j].CompareTo(value) > 0))
                {
                    array[j + 1] = array[j];
                    j--;
                }
                array[j + 1] = value;
            }
        }*/
        /*public void printOrder(wordInfo[] array)
        {
            int i, j;

            for (i = 1; i < wlist.Length; i++)
            {
                wordInfo temp = wlist[i];
                j = i - 1;
                while ((j >= 0) && (wlist[j].CompareTo(temp) > 0))
                {
                    array[j + 1] = array[j];
                    j--;
                }
                array[j + 1] = temp;
            }
        }*/

        public int getCount()
        {
            return numWords;
        }
    }
}
