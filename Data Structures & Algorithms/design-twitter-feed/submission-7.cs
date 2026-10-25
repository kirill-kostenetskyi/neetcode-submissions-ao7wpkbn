public class Twitter {
    private Dictionary<int, HashSet<int>> subs;
    private Dictionary<int, List<(int id, int time)>> tweets;
    private int Count = 0;
    public Twitter() {
        subs = new Dictionary<int, HashSet<int>>();
        tweets = new Dictionary<int, List<(int id, int time)>>();
    }
    
    public void PostTweet(int userId, int tweetId) {
        if(tweets.TryGetValue(userId, out var currentTweets)){
            currentTweets.Add((tweetId, Count));
        } else {
            tweets[userId] = new List<(int, int)>(){
                (tweetId, Count)
            };
        }
        Count++;
    }
    
    public List<int> GetNewsFeed(int userId) {
        var pq = new PriorityQueue<(int userId, int i, int tweetId), int>(
            Comparer<int>.Create((a, b) => b.CompareTo(a))
        );
        var usersIds = subs.ContainsKey(userId) ? subs[userId] : new HashSet<int>();
        usersIds.Add(userId);
        foreach(var uId in usersIds){
            if(tweets.ContainsKey(uId) && tweets[uId].Count > 0){
                var lastTweet = tweets[uId][^1];
                pq.Enqueue((uId, tweets[uId].Count - 1, lastTweet.id), lastTweet.time);
            }
        }

        var res = new List<int>();
        while(res.Count < 10 && pq.Count > 0){
            var top = pq.Dequeue();
            res.Add(top.tweetId);
            if(tweets.ContainsKey(top.userId)){
                var usersTweets = tweets[top.userId];

                if(top.i > 0){
                    var nextTweet = usersTweets[top.i - 1];
                    pq.Enqueue((top.userId, top.i - 1, nextTweet.id), nextTweet.time);
                }
            }
        }
        return res;
    }
    
    public void Follow(int followerId, int followeeId) {
        if (followerId == followeeId) return;

        if (subs.TryGetValue(followerId, out var curr)) {
            curr.Add(followeeId);
        } else {
            subs[followerId] = new HashSet<int>() { followeeId };
        }
    }
    
    public void Unfollow(int followerId, int followeeId) {
        if(subs.TryGetValue(followerId, out var curr)){
            curr.Remove(followeeId);
        }
    }
}

/**
 * Your Twitter object will be instantiated and called as such:
 * Twitter obj = new Twitter();
 * obj.PostTweet(userId,tweetId);
 * IList<int> param_2 = obj.GetNewsFeed(userId);
 * obj.Follow(followerId,followeeId);
 * obj.Unfollow(followerId,followeeId);
 */