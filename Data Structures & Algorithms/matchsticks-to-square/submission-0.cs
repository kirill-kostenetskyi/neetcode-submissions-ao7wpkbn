public class Solution {
    public bool Makesquare(int[] matchsticks) {
        Array.Sort(matchsticks);
        Array.Reverse(matchsticks);
        var sum = matchsticks.Sum();
        if(sum % 4 > 0){
            return false;
        }
        var sideSize = sum / 4;
        if(matchsticks.Max() > sideSize){
            return false;
        }

        return DFS(0, new int[4]);

        bool DFS(int i, int[] sides){
            if(i == matchsticks.Length){
                if(sides[3] == sideSize){
                    return true;
                } else {
                    return false;
                }
            }

            for(int j = 0; j < 4; j++){
                sides[j] += matchsticks[i];
                if(sides[j] <= sideSize){
                    var res = DFS(i + 1, sides);
                    if(res){
                        return true;
                    }
                }
                sides[j] -= matchsticks[i];
            }

            return false;
        }
    }
}