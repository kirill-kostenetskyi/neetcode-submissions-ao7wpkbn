public class TimeMap {
    private Dictionary<string, List<(int, string)>> map = new Dictionary<string, List<(int, string)>>();

    public TimeMap() {
        
    }
    
    public void Set(string key, string value, int timestamp) {
        if(map.TryGetValue(key, out var list)){
            list.Add((timestamp, value));
        } else {
            map[key] = new List<(int, string)>(){ (timestamp, value) };
        }
    }
    
    public string Get(string key, int timestamp) {
        if(map.TryGetValue(key, out var list)){
            var L = 0;
            var R = list.Count - 1;
            var bestTimestamp = list[L].Item1;
            var bestIndex = 0;
            if(timestamp < list[L].Item1){
                return "";
            }
            while(L <= R){
                var M = (R - L) / 2 + L; 
                if(list[M].Item1 > timestamp){
                    R = M - 1;
                } else { // M <= T
                    if(bestTimestamp < list[M].Item1){// 1 < 4
                        bestTimestamp = list[M].Item1;
                        bestIndex = M;
                    }
                    L = M + 1;
                }
            }
            return map[key][bestIndex].Item2;
        } else {
            return "";
        }
    }
}

/**
 * Your TimeMap object will be instantiated and called as such:
 * TimeMap obj = new TimeMap();
 * obj.Set(key,value,timestamp);
 * string param_2 = obj.Get(key,timestamp);
 */