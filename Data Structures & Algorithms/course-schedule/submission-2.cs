public class Solution {
    public bool CanFinish(int numCourses, int[][] prerequisites) {
        var visited = 0;
        var notVisited = 1;
        var inProgress = 2;
        var adjList = new Dictionary<int, List<int>>();
        var states = new Dictionary<int, int>();
        
        for(int i = 0; i < numCourses; i++){
            adjList[i] = new List<int>();
            states[i] = notVisited;
        }       
        for(int i = 0; i < prerequisites.Length; i++){
            adjList[prerequisites[i][0]].Add(prerequisites[i][1]);
        }
        
        for(int i = 0; i < prerequisites.Length; i++){
            var res = IsLoopExists(prerequisites[i][0]);
            if(res){
                return false;
            } 
        }
        return true;

        bool IsLoopExists(int course){
            if(states[course] == visited){
                return false;
            }

            if(states[course] == inProgress){
                return true;
            }
            states[course] = inProgress;
            foreach(var a in adjList[course]){
                var res = IsLoopExists(a);
                if(res) {
                    return true;
                } 
            }
            states[course] = visited;

            return false;
        }
    }
}