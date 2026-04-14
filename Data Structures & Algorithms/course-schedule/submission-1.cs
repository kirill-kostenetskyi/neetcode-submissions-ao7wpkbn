public class Solution {
    private const int Unvisited = 0;
    private const int Visiting = 1;
    private const int Visited = 2;

    Dictionary<int, List<int>> adjList = new Dictionary<int, List<int>>();
    Dictionary<int, int> states = new Dictionary<int, int>();

    public bool CanFinish(int numCourses, int[][] prerequisites) {

        for(int i = 0; i < numCourses; i++){
            states[i] = Unvisited;
            adjList[i] = new List<int>();
        }

        for(int i = 0; i < prerequisites.Length; i++){
            var a = prerequisites[i][0];
            var b = prerequisites[i][1]; 

            adjList[a].Add(b);
        }

        for(int i = 0; i < numCourses; i++){
            var res = DFS(i);
            if(!res){
                return false;
            }
        }
        return true;
    }

    private bool DFS(int current){
        // return true if no loops
        if(states[current] == Visiting){
            // loop
            return false;
        }

        if(states[current] == Visited){
            return true;
        }

        states[current] = Visiting;

        foreach(var nei in adjList[current]){
            var res = DFS(nei);
            if(!res) {
                return false;
            }
        }
        states[current] = Visited;
        return true;
    }
}