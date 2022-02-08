using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Kod
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();
            List<int> rndL = new List<int>();
            List<int> rndl = new List<int>();
            Stopwatch stopwatch = new Stopwatch();
            Stopwatch stopwatch2 = new Stopwatch();

            for(int i = 0; i<1000;i++){
                rndL.Add(rnd.Next());
                rndl.Add(rnd.Next());
            }
            
            int LengthOfList = rndL.Count;
            int LengthOfList2 = rndl.Count;
          
           //Boublesort

            stopwatch.Start();
            for(int a = 0; a < LengthOfList; a++){
                for(int b = 0; b < (LengthOfList-1-a);b++){
                    if(rndL[b] > 
                    rndL[b+1]){
                        int c = rndL[b+1];
                        rndL[b+1] = rndL[b];
                        rndL[b] = c;
                    }
                }
            }
            stopwatch.Stop();

            
            Console.WriteLine(stopwatch.ElapsedMilliseconds);

            //insetionsort
            stopwatch2.Start();
            
            for(int d = 0; d < LengthOfList2; ++d){
                int key = rndl[d];
                int e = d-1;
            
                while(e >= 0 && rndl[e] > key){
                    rndl[e + 1] = rndl [e];
                    e = e - 1;
                }            
                rndl[e + 1] = key;
            
            }


            stopwatch2.Stop();

            Console.WriteLine(stopwatch2.ElapsedMilliseconds);
        }
    }
}
