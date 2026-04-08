public class Solution {
    public int CarFleet(int target, int[] position, int[] speed) {
        var cars = new List<(int Pos, int Speed)>{};
        for(int i = 0; i < position.Length; i++){
            cars.Add((position[i], speed[i]));
        }

        cars = cars.OrderByDescending(x=> x.Pos).ToList();

        var stack = new Stack<double>();

        for(int i = 0; i < cars.Count; i++){
            double time = (double)(target - cars[i].Pos) / (double) cars[i].Speed; //time to destination
            if(i == 0) {
                stack.Push(time);
            } else {
                var top = stack.Peek(); //1 sec
                if(time <= top){
                     continue;
                } else {
                    stack.Push(time);
                }
            }
        }

        return stack.Count;
    }
}