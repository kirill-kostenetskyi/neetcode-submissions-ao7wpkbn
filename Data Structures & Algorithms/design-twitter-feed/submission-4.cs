public class Twitter {
    
    private Dictionary<int, LinkedList<(int tweetId, int order)>> tweets = new Dictionary<int, LinkedList<(int tweetId, int order)>>();
    private Dictionary<int, HashSet<int>> followers = new Dictionary<int, HashSet<int>>();
    private int globalOrder = 0;
    public Twitter() {
        
    }
    
    public void PostTweet(int userId, int tweetId) {
        if(!tweets.ContainsKey(userId)){
            var newList = new LinkedList<(int, int)>();
            newList.AddLast((tweetId, globalOrder));
            tweets[userId] = newList;
            globalOrder++;
        } else {
            var tweetsOfCurrentUser = tweets[userId];
            
            tweetsOfCurrentUser.AddLast((tweetId, globalOrder));
            globalOrder++;

            if(tweetsOfCurrentUser.Count > 10){
                tweetsOfCurrentUser.RemoveFirst();
            }
        }
    }
    
    public List<int> GetNewsFeed(int userId) {
        var pq = new PriorityQueue<int, int>();
        if(followers.ContainsKey(userId)){
            foreach(var followerId in followers[userId]){
                if(followerId == userId) continue;
                if(tweets.ContainsKey(followerId)){
                    var listOfTweets = tweets[followerId];
                    foreach((int tweetId, int order) in listOfTweets){
                        pq.Enqueue(tweetId, -order);
                    }
                }
            }
        }

        if(tweets.ContainsKey(userId)){
            foreach((int tweetId, int order) in tweets[userId]){
                pq.Enqueue(tweetId, -order);
            }
        }
        
        var result = new List<int>();
        while(pq.Count > 0 && result.Count < 10){
            int tweet = pq.Dequeue();
            if(!result.Contains(tweet)) result.Add(tweet);
        }
        return result;
    }
    
    public void Follow(int followerId, int followeeId) {
        if(!followers.ContainsKey(followerId)){
            followers[followerId] = new HashSet<int>(){ followeeId };
        } else {
            followers[followerId].Add(followeeId);
        }
    }
    
    public void Unfollow(int followerId, int followeeId) {
        if(followers.ContainsKey(followerId)){
            followers[followerId].Remove(followeeId);
        }
    }
}