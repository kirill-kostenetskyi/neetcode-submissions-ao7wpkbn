public class Solution {
    public void islandsAndTreasure(int[][] rooms) {
        (int dr, int dc)[] dirs = {(0, 1), (1, 0), (0, -1), (-1, 0)};
        var q = new Queue<(int r, int c, int d)>();
        for(int r = 0; r < rooms.Length; r++){
            for(int c = 0; c < rooms[0].Length; c++){
                if(rooms[r][c] == 0){
                    q.Enqueue((r, c, 0));
                }
            }
        }

        while(q.Count > 0){
            (int r, int c, int d) = q.Dequeue();
            foreach(var dir in dirs){
                var nr = dir.dr + r;
                var nc = dir.dc + c;
                if(nr < 0 || nr >= rooms.Length || nc < 0 || nc >= rooms[0].Length || rooms[nr][nc] == -1 || rooms[nr][nc] == 0 || rooms[nr][nc] <= d + 1){
                    continue;
                }
                rooms[nr][nc] = d + 1;
                q.Enqueue((nr, nc, d + 1));
            }
        }
    }

}