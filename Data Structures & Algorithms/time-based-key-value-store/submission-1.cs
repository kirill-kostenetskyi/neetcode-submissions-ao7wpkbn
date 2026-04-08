public class TimeMap {

    Dictionary<string, List<Storage>> d = new Dictionary<string, List<Storage>>();

    public TimeMap() {
        
    }
    
    public void Set(string key, string value, int timestamp) {
        if(d.ContainsKey(key)){
            var l = d[key];
            l.Add(new Storage(){
                Value = value,
                Timestamp = timestamp
            });

        } else {
            d[key] = new List<Storage>(){ new Storage(){
                Value = value,
                Timestamp = timestamp
            }};
        }
    }
    
    public string Get(string key, int timestamp) {
        if(d.ContainsKey(key)){
            var v = d[key];

            // binary search
            var l = 0;
            var r = v.Count - 1;

            Storage closeVal = null;

            while(l <= r){
                var m = l + (r - l) / 2;
                        
                if(v[m].Timestamp <= timestamp){
                    closeVal = v[m];                  
                    l = m + 1;
                } else {
                    r = m - 1;
                }
            }
            return closeVal?.Value != null ? closeVal.Value : "";

        } else {
            return "";
        }
    }
}

public class Storage {
    public string Value {get; set;}
    public int Timestamp {get; set;}
}
/**
 * Your TimeMap object will be instantiated and called as such:
 * TimeMap obj = new TimeMap();
 * obj.Set(key,value,timestamp);
 * string param_2 = obj.Get(key,timestamp);
 */