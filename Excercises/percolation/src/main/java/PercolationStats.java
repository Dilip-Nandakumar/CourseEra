import edu.princeton.cs.algs4.StdRandom;
import edu.princeton.cs.algs4.StdStats;

public class PercolationStats {
    private double[] percolationThresholds;
    private int siteCount;
    private int trials;

    public PercolationStats(int n, int trials) {
        if(n <= 0 || trials <= 0)
            throw new IllegalArgumentException();

        percolationThresholds = new double[trials];
        siteCount = n * n;
        this.trials = trials;

        simulate(n, trials);
    }

    public double mean() {
        return StdStats.mean(percolationThresholds);
    }

    public double stddev() {
        return StdStats.stddev(percolationThresholds);
    }

    public double confidenceLo() {
        return mean() - ((1.96 * stddev()) / Math.sqrt(trials));
    }

    public double confidenceHi() {
        return mean() + ((1.96 * stddev()) / Math.sqrt(trials));
    }

    public String toString() {
        StringBuilder sb = new StringBuilder();

        sb.append(String.format("mean \t = %f", mean()));
        sb.append("\n");
        sb.append(String.format("stddev \t = %f", stddev()));
        sb.append("\n");
        sb.append(String.format("95pc confidence interval \t = [%f, %f]", confidenceLo(), confidenceHi()));

        return sb.toString();
    }

    public static void main(String[] args) {
        //System.out.println(LocalDateTime.now());
        PercolationStats percolationStats = new PercolationStats(1000, 100);
        //System.out.println(LocalDateTime.now());

        System.out.println(percolationStats);
    }

    private void simulate(int n, int trials) {
        while (trials > 0) {
            Percolation percolation = new Percolation(n);
            int openSiteCount = 0;

            while (!percolation.percolates()) {
                int rowIndex = StdRandom.uniform(1, n + 1);
                int colIndex = StdRandom.uniform(1, n + 1);

                percolation.open(rowIndex, colIndex);
                openSiteCount++;
            }

            percolationThresholds[trials - 1] = (double) openSiteCount / (double) siteCount;
            trials--;
        }
    }
}