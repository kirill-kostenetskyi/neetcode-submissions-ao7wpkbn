public class LRUCache {
    LinkedList<(int Key, int Value)> list;
    Dictionary<int, LinkedListNode<(int Key, int Value)>> map;
    int capacity;
    public LRUCache(int capacity) {
        list = new LinkedList<(int, int)>();
        map = new Dictionary<int, LinkedListNode<(int, int)>>(capacity);
        this.capacity = capacity;
    }
    
    public int Get(int key) {
        if(map.TryGetValue(key, out var listRef)){
            list.Remove(listRef);
            list.AddLast(listRef);
            
            return listRef.Value.Value;
        } else {
            return -1;
        }
    }
    
    public void Put(int key, int value) {
        if(map.ContainsKey(key)){
            var listRef = map[key];
            listRef.Value = (key, value);
            list.Remove(listRef);
            list.AddLast(listRef);
        } else {
            if(map.Count >= capacity){
                var first = list.First.Value;
                map.Remove(first.Key);
                list.RemoveFirst();
            }
            LinkedListNode<(int, int)> newObj = list.AddLast((key, value));
            map[key] = newObj;
        }
    }
}

/**
 * Your LRUCache object will be instantiated and called as such:
 * LRUCache obj = new LRUCache(capacity);
 * int param_1 = obj.Get(key);
 * obj.Put(key,value);
 */