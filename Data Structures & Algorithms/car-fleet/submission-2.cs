public class Solution {
    public int CarFleet(int target, int[] position, int[] speed) {
        var ps = new (int position, float time)[position.Length];
        for(int i = 0; i < position.Length; i++){
            float time =  (float)(target - position[i]) / (float)speed[i]; 
            ps[i] = (position[i], time);
        }

        ps = ps.OrderBy(x => x.position).ToArray();

        var s = new Stack<float>();

        var res = 0;

        for(int i = ps.Length - 1; i >= 0 ; i--){
            var time = ps[i].time;
            if(s.Count > 0){
                var top = s.Peek();
                if(top < time){
                    s = new Stack<float>();
                    res++;
                    s.Push(time);
                }
            } else {
                s.Push(time);
            }
        }

        if(s.Count > 0){
            res++;
        }

        return res;
    }
}