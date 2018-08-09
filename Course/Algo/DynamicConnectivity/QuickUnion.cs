using System;

namespace DynamicConnectivity
{
    public class QuickUnion
    {
        private int[] arr;

        public QuickUnion(int n)
        {
            this.arr = new int[n + 1];
            
            for(int i = 0; i < this.arr.Length; i++)
            {
                this.arr[i] = i;
            }
        }

        int Root(int i)
        {
            if(this.arr[i] == i)
            {
                return i;
            }

            return this.Root(this.arr[i]);
        }

        public void Union(int a, int b)
        {
            int rootA = this.Root(a);
            int rootB = this.Root(b);

            this.arr[rootA] = rootB;
        }

        public bool IsConnected(int a, int b)
        {
            return this.Root(a) == this.Root(b);
        }
    }
}