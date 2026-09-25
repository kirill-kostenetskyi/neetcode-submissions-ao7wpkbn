public class MinStack {
    private Stack<(int Value, int Min)> s = new Stack<(int, int)>(); // value, currentMin

    public MinStack() {
    }
    
    public void Push(int value) {
        if(s.Count == 0){
            s.Push((value, value));
        } else {
            var top = s.Peek();
            if(top.Min < value){
                s.Push((value, top.Min));
            } else {
                s.Push((value, value));
            }
        }
    }
    
    public void Pop() {
        s.Pop();
    }
    
    public int Top() {
        return s.Peek().Value;
    }
    
    public int GetMin() {
        return s.Peek().Min;
    }
}

/**
 * Your MinStack object will be instantiated and called as such:
 * MinStack obj = new MinStack();
 * obj.Push(value);
 * obj.Pop();
 * int param_3 = obj.Top();
 * int param_4 = obj.GetMin();
 */