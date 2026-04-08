public class Solution {
    private (int r, int c)[] dirs = new []{
        (0, 1),
        (1, 0),
        (-1, 0),
        (0, -1),
    };
    public void islandsAndTreasure(int[][] rooms) {
        var q = new Queue<(int r, int c, int length)>();
        var visited = new HashSet<(int r, int c)>();

        for(int i = 0; i < rooms.Length; i++){
            for(int j = 0; j < rooms[0].Length; j++){
                if(rooms[i][j] == 0){
                    //gate
                    q.Enqueue((i, j, 0));
                }
            }
        }

        while(q.Count() > 0){
            var (r, c, length) = q.Dequeue();
            
            if(visited.Contains((r,c))){
                continue;
            }

            visited.Add((r, c));
            
            rooms[r][c] = length;
            length++;

            foreach(var dir in dirs){
                var nr = dir.r + r;
                var nc = dir.c + c;

                if(nr < 0 || nc < 0 || nr >= rooms.Length || nc >=rooms[0].Length 
                || visited.Contains((nr, nc))
                || rooms[nr][nc] != int.MaxValue || rooms[nr][nc] == -1){
                    continue;
                }
                q.Enqueue((nr, nc, length));

            }

        }

        return;
    }

}