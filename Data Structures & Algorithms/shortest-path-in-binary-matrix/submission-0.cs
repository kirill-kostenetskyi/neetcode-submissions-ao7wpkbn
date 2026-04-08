public class Solution {
    HashSet<(int r, int c)> visit = new HashSet<(int r, int c)>();
    Queue<(int r, int c, int lenght)> q = new Queue<(int r, int c, int lenght)>();
    List<(int dr, int dc)> dir = new List<(int dr, int dc)>(){
        (0, 1), // right
        (1, 1),
        (1, 0), //bottom
        (1, -1),
        (0, -1), // left 
        (-1, -1),
        (-1, 0), //top
        (-1, 1)
    };

    public int ShortestPathBinaryMatrix(int[][] grid) {
        q.Enqueue((0, 0, 1));
        visit.Add((0, 0));
        
        do{
            (int r, int c, int length) = q.Dequeue();
            if(r < 0 || c < 0 || r > grid.Length - 1|| c > grid[0].Length - 1 || grid[r][c] == 1){
                continue;
            }

            if(r == grid.Length - 1 && c == grid[0].Length - 1){
                return length;
            }
            foreach((int dr, int dc) in dir){
                var nr = r + dr;
                var nc = c + dc;
                if(!visit.Contains((nr, nc))){
                    var newLength = length + 1;
                    q.Enqueue((nr, nc, newLength));
                    visit.Add((nr, nc));
                }
            }

        } while(q.Count() > 0);

        return -1;
    }
}