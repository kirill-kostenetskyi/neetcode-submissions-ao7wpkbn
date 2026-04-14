public class Solution {
    private int Unvisited = 0;
    private int Visiting = 1;
    private int Visited = 2;

    private Dictionary<int, List<int>> prereqDic = new Dictionary<int, List<int>>();
    private Dictionary<int, int> states = new Dictionary<int, int> ();
    private List<int> result = new List<int>();

    public int[] FindOrder(int numCourses, int[][] prerequisites) {

        for(int i = 0; i < numCourses; i++) {
            prereqDic[i] = new List<int>(){};
            states[i] = Unvisited;
        }

        foreach(var cur in prerequisites){
            var a = cur[0];
            var b = cur[1];
            prereqDic[a].Add(b);
        }
        
        for(int i = 0; i < numCourses; i++) {
            var res = Dfs(i);
            if(res == false){
                return new int[0];
            }
        }

        return result.ToArray();
    }

    private bool Dfs(int current){
        if(states[current] == Visiting){
            // loop
            return false;
        }

        if(states[current] == Visited){
            return true;
        }

        states[current] = Visiting;

        foreach(var nei in prereqDic[current]){
            var res = Dfs(nei);
            if(!res){
                return false;
            }
        }

        states[current] = Visited;
        result.Add(current);
        
        return true;
    }
}