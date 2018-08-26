import edu.princeton.cs.algs4.WeightedQuickUnionUF;

public class Percolation {
    private int[] site;
    private WeightedQuickUnionUF uf;
    private int siteCount;
    private int openSiteCount;
    private int[][] adjacentSites = {{1, 0}, {-1, 0}, {0, 1}, {0, - 1}};
    private int n;

    public Percolation(int n) {
        validate(n);

        this.n = n;
        siteCount = n * n;
        site = new int[siteCount + 2];
        uf = new WeightedQuickUnionUF(siteCount + 2);
    }

    public void open(int row, int col) {
        validate(row, col);

        if(site[getSiteIndex(row, col)] == 0) {
            site[getSiteIndex(row, col)] = 1;
            openSiteCount++;
            unionAdjacentSites(row, col);
        }
    }

    public boolean isOpen(int row, int col) {
        validate(row, col);

        return site[getSiteIndex(row, col)] == 1;
    }

    public boolean isFull(int row, int col) {
        validate(row, col);

        return site[getSiteIndex(row, col)] == 0;
    }

    public int numberOfOpenSites() {
        return openSiteCount;
    }

    public boolean percolates() {
        return uf.connected(0, siteCount + 1);
    }

    public String toString()
    {
        StringBuilder sb = new StringBuilder();

        for(int i = 1; i <= siteCount; i++)
        {
            sb.append(site[i]);

            if((i%n) == 0)
            {
                sb.append("\n");
            }
        }

        return sb.toString();
    }

    private void validate(int n)
    {
        if (n <= 0) {
            throw new IllegalArgumentException();
        }
    }

    private void validate(int row, int col)
    {
        if(row <= 0 || col <= 0)
        {
            throw new IllegalArgumentException();
        }
    }

    private boolean isSiteValid(int row, int col)
    {
        if(row <= 0 || col <= 0 || row > n || col > n)
        {
            return false;
        }

        return true;
    }

    private void unionAdjacentSites(int row, int col)
    {
        for(int i = 0; i < 4; i++)
        {
            int adjacentRow = row + adjacentSites[i][0];
            int adjacentCol = col + adjacentSites[i][1];

            if(isSiteValid(adjacentRow, adjacentCol) && isOpen(adjacentRow, adjacentCol))
            {
                uf.union(getSiteIndex(row, col), getSiteIndex(adjacentRow, adjacentCol));
            }
        }

        if(row == 1)
        {
            uf.union(getSiteIndex(row, col), 0);
        }

        if(row == n)
        {
            uf.union(getSiteIndex(row, col), siteCount + 1);
        }
    }

    private int getSiteIndex(int row, int col)
    {
        return (n * (row - 1)) + col;
    }
}