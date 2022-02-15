using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Kod
{
    class Program
    {
        
        static void Main(string[] args)
        {
            Random rnd = new Random();
           
            int antal = 8000;


         //Bubblesort
             List<int> rndBBL = new List<int>();
             for(int a = 0; a<antal;a++){
                 rndBBL.Add(rnd.Next());
             }


             int LengthOfList = rndBBL.Count;
             Stopwatch stopwatchBBL = new Stopwatch();

            stopwatchBBL.Start();
            for(int bblA = 0; bblA < LengthOfList; bblA++){
                for(int bblB = 0; bblB < (LengthOfList-1-bblA);bblB++){
                    if(rndBBL[bblB] > 
                    rndBBL[bblB+1]){
                        int bblC = rndBBL[bblB+1];
                        rndBBL[bblB+1] = rndBBL[bblB];
                        rndBBL[bblB] = bblC;
                    }
                }
            }
            stopwatchBBL.Stop();

            
            Console.WriteLine("Bubble: " +stopwatchBBL.ElapsedMilliseconds);



            //insetionsort
            List<int> rndINS = new List<int>();
             for(int b = 0; b<antal;b++){
                rndINS.Add(rnd.Next());
             }
             int LengthOfList2 = rndINS.Count;
              Stopwatch stopwatchINS = new Stopwatch();


            stopwatchINS.Start();
            
            for(int insA = 0; insA < LengthOfList2; ++insA){
                int key = rndINS[insA];
                int insB = insA-1;
            
                while(insB >= 0 && rndINS[insB] > key){
                    rndINS[insB + 1] = rndINS [insB];
                    insB = insB - 1;
                }            
                rndINS[insB + 1] = key;
            
            }


            stopwatchINS.Stop();

            Console.WriteLine("insetion: " +stopwatchINS.ElapsedMilliseconds);

           
           
            
            //Merge Sort
            List<int> rndMRG = new List<int>();
            List<int> sorted;

            for(int c = 0; c< antal;c++){
                rndMRG.Add(rnd.Next(0, 100));
            }

             Stopwatch stopwatchMRG = new Stopwatch();
            
            stopwatchMRG.Start();

            sorted = MergeSort(rndMRG);

            stopwatchMRG.Stop();

            Console.WriteLine("Merge: " +stopwatchMRG.ElapsedMilliseconds);




            //Quicksort
            List<int> rndQCK = new List<int>();

            for(int d = 0; d < antal; d++){
                rndQCK.Add(rnd.Next());
            }

            Stopwatch stopwatchQCK = new Stopwatch();
            stopwatchQCK.Start();

            QuickSort(rndQCK, 0, rndQCK.Count -1);

            stopwatchQCK.Stop();

            Console.WriteLine("Quicksort: " +stopwatchQCK.ElapsedMilliseconds);
        }

            //Mergesort
        private static List<int> MergeSort(List<int> rndMRG)
        {
            if (rndMRG.Count <= 1)
                return rndMRG;

            List<int> left = new List<int>();
            List<int> right = new List<int>();

            int middle = rndMRG.Count / 2;
            for (int i = 0; i < middle;i++)
            {
                left.Add(rndMRG[i]);
            }
            for (int i = middle; i < rndMRG.Count; i++)
            {
                right.Add(rndMRG[i]);
            }

            left = MergeSort(left);
            right = MergeSort(right);
            return Merge(left, right);
        }
            //Mergesort
        private static List<int> Merge(List<int> left, List<int> right)
        {
            List<int> result = new List<int>();

            while (left.Count > 0 || right.Count > 0)
            {
                if(left.Count > 0 && right.Count > 0)
                {
                    if(left.First() <= right.First())
                    {
                        result.Add(left.First());
                        left.Remove(left.First());
                    }
                    
                    else
                    {
                        result.Add(right.First());
                        right.Remove(right.First());
                    }  
                }

                else if(left.Count > 0)
                {
                    result.Add(left.First());
                    left.Remove(left.First());
                }

                else if(right.Count > 0)
                {
                    result.Add(right.First());
                    right.Remove(right.First());
                }
            }
            return result;
        }

            //QuickSort

            private static void QuickSort(List<int> list, int left, int right){
                if (left < right){
                    int pivot = Partition(list, left, right);

                    if (pivot > 1){
                        QuickSort(list, left, pivot - 1);
                    }
                    if (pivot + 1 < right){
                        QuickSort(list, pivot + 1, right);
                    }
                }
            }


            private static int Partition(List<int> list, int left, int right)
            {
                int pivot = list[left];
                while(true)
                {
                    while (list[left] < pivot)
                    {
                        left++;
                    }

                    while(list[right] > pivot)
                    {
                        right--;
                    }

                    if (left < right)
                    {
                        if (list[left] == list[right]) return right;

                        int temp = list[left];
                        list[left] = list[right];
                        list[right] = temp;
                    }
                    else
                    {
                        return right;
                    }
                }
            }
    }
}
