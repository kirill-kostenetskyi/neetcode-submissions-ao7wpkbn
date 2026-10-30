
public class MyHashSet {
    LinkedList<int>[] arr;

    public MyHashSet() {
        arr = new LinkedList<int>[10000];
    }

    public void Add(int key) {
        var bucket = key % arr.Length;

        if (arr[bucket] == null) {
            arr[bucket] = new LinkedList<int>();
        }

        if (!arr[bucket].Contains(key)) {
            arr[bucket].AddLast(key);
        }
    }

    public void Remove(int key) {
        var bucket = key % arr.Length;

        if (arr[bucket] != null) {
            arr[bucket].Remove(key);
        }
    }

    public bool Contains(int key) {
        var bucket = key % arr.Length;

        return arr[bucket] != null && arr[bucket].Contains(key);
    }
}
