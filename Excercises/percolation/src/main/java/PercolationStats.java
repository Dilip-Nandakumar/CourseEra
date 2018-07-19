import java.util.ArrayList;
import java.util.List;
import edu.princeton.cs.algs4.Polynomial;

public class PercolationStats {
    private List<Integer> siteCount = new ArrayList<>();

    public PercolationStats(int n, int trials) // perform trials independent experiments on an n-by-n grid
    {
        if(n < 0)
        {
            throw new IllegalArgumentException();
        }

        while(trials > 0)
        {
            Percolation percolation = new Percolation(n);
            int count = 0;

            while(percolation.percolates())
            {

                count++;
            }

            siteCount.add(count);
            trials--;
        }
    }

    public double mean() // sample mean of percolation threshold
    {
        return 0;
    }

    public double stddev() // sample standard deviation of percolation threshold
    {
        return 0;
    }

    public double confidenceLo() // low  endpoint of 95% confidence interval
    {
        return 0;
    }

    public double confidenceHi() // high endpoint of 95% confidence interval
    {
        return 0;
    }

}
