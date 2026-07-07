public class Solution {
    public int[][] KClosest(int[][] points, int k) {
        var initArray = new List<((int, int), double)>();
        foreach(var point in points){
            var x = point[0];
            var y = point[1];
            var distanse = Math.Sqrt((Math.Pow(x, 2) + Math.Pow(y, 2)));
            initArray.Add(((x, y), distanse));
        }

        var heap = new PriorityQueue<(int, int), double>(initArray.ToArray());

        var result = new List<int[]>();

        while(k != 0){
            k--;
            (int x, int y) = heap.Dequeue();
            result.Add(new int[2]{ x, y });
        }

        return result.ToArray();
    }
}