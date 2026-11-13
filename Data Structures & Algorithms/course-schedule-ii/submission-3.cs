public class Solution {
    public int[] FindOrder(int numCourses, int[][] prerequisites) {
        var visited = 0;
        var visiting = 1;
        var unvisited = 2;

        var adjList = new Dictionary<int, List<int>>();
        var states = new Dictionary<int, int>();
        for(int i = 0; i < numCourses; i++){
            adjList[i] = new List<int>();
            states[i] = unvisited;
        }
        
        for(int i = 0; i < prerequisites.Length; i++){
            adjList[prerequisites[i][0]].Add(prerequisites[i][1]);
        }
        var res = new List<int>();

        for(int i = 0; i < numCourses; i++){
            var canFinish = CanFinish(i);
            if(canFinish == false){
                return new int[0];
            }
        }
        return res.ToArray();

        bool CanFinish(int course){
            if(states[course] == visited){
                return true;
            }
            if(states[course] == visiting){
                return false;
            }
            states[course] = visiting;
            foreach(var a in adjList[course]){
                var canFinish = CanFinish(a);
                if(canFinish == false){
                    return false;
                }
            }
            states[course] = visited;
            res.Add(course);
            return true;
        }
    }
}