public class Solution {
    public int SwimInWater(int[][] grid) {
        (int dr, int dc)[] dirs = {(1, 0), (0, 1), (-1, 0), (0, -1)};
        var heap = new PriorityQueue<(int, int), int>();
        var dict = new Dictionary<(int, int), int>(); // best time for this cell so far
        heap.Enqueue((0, 0), grid[0][0]);
        dict.Add((0, 0), grid[0][0]);

        while(heap.Count > 0){
            heap.TryDequeue(out var cell, out var priority);
            var (r, c) = cell;
            if(priority > dict[(r, c)]){
                continue;
            }
            if (r == grid.Length - 1 && c == grid[0].Length - 1)
            {
                return priority; // chat сказал чт оесли я уже дошел до клетки то согласно Дейкстре,
                // я точно и всегда сделал это за минимальный путь. Это ее свойство. Так что можно сразу вернуть
            }
            foreach((int dr, int dc) in dirs){
                var nr = dr + r;
                var nc = dc + c;
                if(nr < 0 || nr >= grid.Length || nc < 0 || nc >= grid[0].Length){
                    continue;
                }
                var newWeight = Math.Max(grid[nr][nc], priority);
                if(dict.TryGetValue((nr, nc), out var currentPriority)){
                    if(newWeight < currentPriority){
                        dict[(nr, nc)] = newWeight;
                        heap.Enqueue((nr, nc), newWeight);
                    }
                } else {
                    dict.Add((nr, nc), newWeight);
                    heap.Enqueue((nr, nc), newWeight);
                }
            }
        }
        return -1;
    }
}