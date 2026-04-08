public class MinStack {

    Stack<int> s;
    Stack<int> minS;
    public MinStack() {
        s = new Stack<int>();
        minS = new Stack<int>();
    }
    
    public void Push(int val) {
        s.Push(val);

        if(minS.Count != 0){
            var lastMin = minS.Peek();
            if(lastMin < val){
                minS.Push(lastMin);
                return;
            }
        }
        minS.Push(val);
    }
    
    public void Pop() {
        minS.Pop();
        s.Pop();
    }
    
    public int Top() {
        return s.Peek();
    }
    
    public int GetMin() {
        return minS.Peek();
    }
}