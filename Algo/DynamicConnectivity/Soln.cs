using System;

namespace DynamicConnectivity
{
    public class Soln
    {
        private int[] array;
        //private int i = 1;

        public Soln(int n)
        {
            this.array = new int[n + 1];
            
            for(int i = 1; i < n + 1; i++)
            {
                this.array[i] = i;
            }
        }

        public void Test()
        {
            Console.WriteLine("Testing");
        }

        public void Union(int x, int y)
        {
            this.Refresh(this.array[x], this.array[y]);
        }

        private void Refresh(int oldValue, int newValue)
        {
            for(int j = 1; j < 5; j++)
            {
                if(this.array[j] == oldValue)
                {
                    this.array[j] = newValue;
                }
            }
        }

        public bool IsConnected(int x, int y)
        {
            return this.array[x] ==  this.array[y];
        }
    }
}