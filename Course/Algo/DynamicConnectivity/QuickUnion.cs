using System;

namespace DynamicConnectivity
{
    public class QuickUnion
    {
        private int[] array;
        private int[] size;

        public QuickUnion(int n)
        {
            this.array = new int[n + 1];
            this.size = new int[n + 1];
            
            for(int i = 1; i < n + 1; i++)
            {
                this.array[i] = i;
                this.size[i] = 1;
            }
        }

        public void Union(int x, int y)
        {
            int rootx = this.Root(this.array[x]);
            int rooty = this.Root(this.array[y]);

            if(this.size[rootx] <= this.size[rooty])
            {
                this.array[rootx] = rooty;
                this.size[rooty]+= this.size[rootx];
                return;
            }

            this.array[rooty] = rootx;
            this.size[rootx]+= this.size[rooty];
        }
        
        public bool IsConnected(int x, int y)
        {
            return this.Root(this.array[x]) ==  this.Root(this.array[y]);
        }

        private int Root(int x)
        {
            while(this.array[x] != x)
            {
                x = this.array[x];
                this.array[x] = this.array[this.array[x]];
            }

            return x;
        }

        public void Print()
        {
            // for(int i = 0; i < this.array.Length; i++)
            // {
            //     Console.WriteLine(this.array[i]);
            // }
        }
    }
}