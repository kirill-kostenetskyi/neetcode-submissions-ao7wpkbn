public class Solution {
    public int MaxScore(int[] cardPoints, int k) {
        var leftPrefix = new int[k];
        var rightPrefix = new int[k];

        var sum = 0;
        for(int i = 0; i < k; i++){
            sum = sum + cardPoints[i];
            leftPrefix[i] = sum;
        }

        var lastPartArray = cardPoints[(cardPoints.Length - k)..cardPoints.Length];
        Array.Reverse(lastPartArray);
        sum = 0;
        for(int i = 0; i < lastPartArray.Length; i++){
            sum = sum + lastPartArray[i];
            rightPrefix[i] = sum;
        }

        var bestSum = 0;
        var takeFromFirst = k;
        while(takeFromFirst >= 0){
            var takeFromLast = k - takeFromFirst;
            int firstSum;
            int lastSum;
            if(takeFromFirst - 1 < 0){
                firstSum = 0;
            } else {
                firstSum = leftPrefix[takeFromFirst - 1];
            }
            if(takeFromLast - 1 < 0){
                lastSum = 0;
            } else {
                lastSum = rightPrefix[takeFromLast - 1];
            }
            bestSum = Math.Max(firstSum + lastSum, bestSum);
            takeFromFirst--;
        }

        return bestSum;
    }
}