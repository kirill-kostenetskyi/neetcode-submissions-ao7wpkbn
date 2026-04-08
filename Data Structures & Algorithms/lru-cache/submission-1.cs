 public class CacheNode
    {
        public int Key { get; set; } = 0;
        public int Value { get; set; } = 0;
        public CacheNode Next { get; set; }
        public CacheNode Prev { get; set; }
        public string Name { get; set; }
    }

    public class LRUCache
    {
        private readonly int _capacity = 0;
        private readonly Dictionary<int, CacheNode> _d = new Dictionary<int, CacheNode>();
        // tail  - - - - - - - head
        private readonly CacheNode _head = new CacheNode() {Name = "dummy head"};
        private readonly CacheNode _tail = new CacheNode() {Name = "dummy tail"};

        public LRUCache(int capacity)
        {
            _capacity = capacity;
            _head.Prev = _tail;
            _tail.Next = _head;
        }

        public int Get(int key)
        {
            if (_d.ContainsKey(key))
            {
                var node = _d[key];
                RemoveFromList(node);
                InsertToListHead(node);
                return node.Value;
            }
            else
            {
                return -1;
            }
        }

        public void Put(int key, int value)
        {
            if (_d.ContainsKey(key))
            {
                var currentNode = _d[key];
                currentNode.Value = value;
                RemoveFromList(currentNode);
                InsertToListHead(currentNode);
            }
            else
            {
                _d[key] = new CacheNode() { Key = key, Value = value };
                InsertToListHead(_d[key]);
            }

            if (_d.Count > _capacity)
            {
                // remove LRU node
                var lruKey = this._tail.Next.Key;
                _d.Remove(lruKey);
                RemoveFromList(this._tail.Next);
            }
        }

        private void RemoveFromList(CacheNode node)
        {
            node.Prev.Next = node.Next;
            node.Next.Prev = node.Prev;
        }

        private void InsertToListHead(CacheNode node)
        {
            // to the end
            var oldHead = this._head.Prev;
            
            oldHead.Next = node;
            node.Prev = oldHead;
            this._head.Prev = node;
            node.Next = this._head;
        }
    }