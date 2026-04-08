public class Solution {
    public int CarFleet(int target, int[] position, int[] speed) {
        var cars = new List<(int Pos, int Speed)>{};
        for(int i = 0; i < position.Length; i++){
            cars.Add((position[i], speed[i]));
        }

        cars = cars.OrderByDescending(x=> x.Pos).ToList();
        int fleets = cars.Count > 0 ? 1 : 0;
        (int Pos, int Speed) prevFleet = cars.Count > 0 ? cars[0] : (0, 0);
        for(int i = 0; i < cars.Count; i++){
            double time = (double)(target - cars[i].Pos) / (double) cars[i].Speed; //time to destination
            var prevFleetTime = (double)(target - prevFleet.Pos) / (double) prevFleet.Speed;
            if(time > prevFleetTime){
                // won't catch
                fleets++;
                prevFleet = cars[i];
            } else {
                continue;
            }
        }

        return fleets;
    }
}