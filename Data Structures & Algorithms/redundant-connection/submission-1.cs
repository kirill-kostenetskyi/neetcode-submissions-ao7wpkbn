public class Solution {
    public int[] FindRedundantConnection(int[][] edges) {
        var parents = new int[edges.Length + 1];
        var ranks = new int[edges.Length + 1];
        for(int i = 0; i < parents.Length; i++){
            parents[i] = i;
        }
        foreach(var edge in edges){
            var a = edge[0];
            var b = edge[1];
            if(Union(a, b) == false){
                return edge;
            }
        }

        return new int[2];

        int Find(int e){
            while(e != parents[e]){
                parents[e] = parents[parents[e]];
                e = parents[e];
            }
            return e;
        }

        bool Union(int a, int b){
            var parentA = Find(a);
            var parentB = Find(b);
            if(parentA == parentB){
                return false;
            }
            if(ranks[parentA] == ranks[parentB]){
                parents[parentB] = parentA;
                ranks[parentA] += 1;
            } else if(ranks[parentA] > ranks[parentB]){
                parents[parentB] = parentA;
            } else {
                parents[parentA] = parentB;
            }
            return true;
        }
    }
}