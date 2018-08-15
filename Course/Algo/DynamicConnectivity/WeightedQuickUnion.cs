using System;

namespace DynamicConnectivity
{
    public class WeightedQuickUnion
    {
        private int[] arr;
        private int[] size;

        public WeightedQuickUnion(int n)
        {
            this.arr = new int[n + 1];
            this.size = new int[n + 1];
            
            for(int i = 0; i < this.arr.Length; i++)
            {
                this.arr[i] = i;
                this.size[i] = 1;
            }
        }

        int Root(int i)
        {
            while (this.arr[i] != i)
            {
                //Path Compression
                this.arr[i] = this.arr[this.arr[i]];
                i = this.arr[i];
            }

            return i;
        }

        public void Union(int a, int b)
        {
            int rootA = this.Root(a);
            int rootB = this.Root(b);

            if(this.size[rootA] < this.size[rootB])
            {
                this.arr[rootA] = rootB;
            }
            else
            {
                this.arr[rootB] = rootA;
                this.size[rootA] = Math.Max(this.size[rootB] + 1, this.size[rootA]);
            }
        }

        public bool IsConnected(int a, int b)
        {
            return this.Root(a) == this.Root(b);
        }
    }
}