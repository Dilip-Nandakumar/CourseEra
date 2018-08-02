using System;

namespace DynamicConnectivity
{
    public class QuickFind
    {
        private int[] arr;
        
        public QuickFind(int n)
        {
            this.arr = new int[n + 1];
            
            for(int i = 0; i < this.arr.Length; i++)
            {
                this.arr[i] = i;
            }
        }

        public bool IsConnected(int a, int b)
        {
            return this.arr[a] == this.arr[b];
        }

        public void Union(int a, int b)
        {
            int temp = this.arr[b];
            this.arr[b] = this.arr[a];

            for(int i = 1; i < this.arr.Length; i++)
            {
                if(this.arr[i] == temp)
                {
                    this.arr[i] = this.arr[a];
                }
            }
        }
    }
}