public class StockSpanner {
    private Stack<(int Price, int Counter)> s;
    public StockSpanner() {
        s = new Stack<(int, int)>();
    }
    
    public int Next(int price) {
        var counter = 1;
        while(s.Count > 0 && s.Peek().Price <= price){
            var item = s.Pop();
            counter = counter + item.Counter;
        }
        s.Push((price, counter));
        return counter;
    }
}

/**
 * Your StockSpanner object will be instantiated and called as such:
 * StockSpanner obj = new StockSpanner();
 * int param_1 = obj.Next(price);
 */