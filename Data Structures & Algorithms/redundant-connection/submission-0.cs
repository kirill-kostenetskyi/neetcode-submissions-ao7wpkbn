public class Solution {
    public int[] FindRedundantConnection(int[][] edges) {
        var n = edges.Length;
        var uf = new UnionFind(n);

        for(int i = 0; i < edges.Length; i++) {
            var a = edges[i][0];
            var b = edges[i][1];

            var res = uf.Union(a, b);
            if(res == false){
                return new int[2] { a, b };
            }
        }
        return new int[2] { -1, -1 };
    }
}

public class UnionFind {
    private int[] parents;
    private int[] ranks;

    public UnionFind(int n){
        parents = new int[n + 1];
        ranks = new int[n + 1];
        for(int i = 1; i <= n; i++) {
            parents[i] = i;
            ranks[i] = 1;
        }
    }

    // Find root node
    public int Find(int x){
        while(parents[x] != x){
            var root = Find(parents[x]);
            parents[x] = root;
            break;
        }
        return parents[x];
    }

    public bool Union(int a, int b){
        var rootA = Find(a);
        var rootB = Find(b);
        if(rootA == rootB){
            return false; //cycle
        }

        if(ranks[rootA] > ranks[rootB]){
            parents[rootB] = rootA;
        } else if(ranks[rootB] > ranks[rootA]){
            parents[rootA] = rootB;
        } else {
            parents[rootA] = rootB;
            ranks[rootB] = ranks[rootB] + 1;
        }

        return true;
    }
}