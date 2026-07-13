public class Solution {
    public int MinCostClimbingStairs(int[] cost) {
        for(int i = cost.Length - 1; i >=0; i--){
            var minCost = Math.Min(GetCost(i) + GetCost(i + 1), GetCost(i) + GetCost(i + 2));
            cost[i] = minCost;
        }

        return Math.Min(cost[0], cost[1]);

        int GetCost(int i){
            if(i >= cost.Length){
                return 0;
            } else{
                return cost[i];
            }
        }
    }
}