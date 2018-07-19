enum Site
{
    Open(0),
    Full(1);

    private final int site;

    Site(int site) {
        this.site = site;
    }
}

public class Percolation {
    private int[] array;
    private int[] size;
    private Site[][] grid;
    private int n;
    private int openCount = 0;
    private int[][] movements = new int[][]{{0, -1}, {0, 1}, {-1, 0}, {1, 0}};

    public Percolation(int n) // create n-by-n grid, with all sites blocked
    {
        if(n < 0)
        {
            throw new IllegalArgumentException();
        }

        this.n = n;
        array = new int[(n * n) + 1];
        size = new int[(n * n) + 1];
        grid = new Site[n + 1][n + 1];

        for(int i = 1; i < array.length; i++)
        {
            array[i] = i;
            size[i] = 1;
        }
    }

    public void open(int row, int col) // open site (row, col) if it is not open already
    {
        if(IsOutOfRange(row) || IsOutOfRange(col))
        {
            throw new IllegalArgumentException();
        }

        grid[row][col] = Site.Open;
        int index = GetIndex(row, col);

        for(int i = 0; i < movements.length; i++)
        {
            int adjRow = row + movements[i][0];
            int adjCol = col + movements[i][1];
            int adjIndex = GetIndex(adjRow, adjCol);

            if(isOpen(adjRow, adjCol))
            {
                Union(index, adjIndex);
            }
        }

        openCount++;
    }

    public boolean isOpen(int row, int col) // is site (row, col) open?
    {
        if(IsOutOfRange(row) || IsOutOfRange(col))
        {
            throw new IllegalArgumentException();
        }

        return grid[row][col] == Site.Open;
    }

    public boolean isFull(int row, int col) // is site (row, col) full?
    {
        if(IsOutOfRange(row) || IsOutOfRange(col))
        {
            throw new IllegalArgumentException();
        }

        return grid[row][col] == Site.Full;
    }

    public int numberOfOpenSites() // number of open sites
    {
        return openCount;
    }

    public boolean percolates() // does the system percolate?
    {
        return false;
    }

    private void Union(int x, int y)
    {
        int rootx = Root(array[x]);
        int rooty = Root(array[y]);

        if(size[rootx] <= size[rooty])
        {
            array[rootx] = rooty;
            size[rooty]+= size[rootx];
            return;
        }

        array[rooty] = rootx;
        size[rootx]+= size[rooty];
    }

    private boolean IsConnected(int x, int y)
    {
        return Root(array[x]) == Root(array[y]);
    }

    private int Root(int x)
    {
        while(array[x] != x)
        {
            x = array[x];
            this.array[x] = this.array[this.array[x]];
        }

        return x;
    }

    private int GetIndex(int row, int column)
    {
        return (row - 1) * n + column;
    }

    private boolean IsOutOfRange(int i)
    {
        if(i < 0 || i > n)
        {
            return true;
        }

        return false;
    }
}
