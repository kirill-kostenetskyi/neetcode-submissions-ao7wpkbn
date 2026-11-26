public class Solution {
    public List<List<string>> AccountsMerge(List<List<string>> accounts) {
        var adjList = new Dictionary<string, HashSet<string>>();
        for(int j = 0; j < accounts.Count; j++){
            var userAccounts = accounts[j];
            var firstAccount = userAccounts[1];
            if(!adjList.ContainsKey(firstAccount)){
                adjList[firstAccount] = new HashSet<string>();
            }
            var name = userAccounts[0];

            for(int i = 2; i < userAccounts.Count; i++){
                var nei = userAccounts[i];
                if(!adjList.ContainsKey(nei)){
                    adjList[nei] = new HashSet<string>();
                }
                adjList[firstAccount].Add(nei);
                adjList[nei].Add(firstAccount);
            }
        }
        List<List<string>> res = new List<List<string>>();
        var visited = new HashSet<string>();
        for(int j = 0; j < accounts.Count; j++){
            var userAccounts = accounts[j];
            var subRes = new List<string>();
            if(userAccounts.Count > 1){
                DFS(userAccounts[1], subRes);
            }
            if(subRes.Count > 0){
                subRes.Sort(StringComparer.Ordinal);
                subRes.Insert(0, userAccounts[0]);
                res.Add(subRes);
                subRes = new List<string>();
            }
        }
        return res;

        void DFS(string email, List<string> mergedEmails){
            if(visited.Contains(email)){
                return;
            }
            visited.Add(email);
            foreach(var nei in adjList[email]){
                DFS(nei, mergedEmails);
            }
            mergedEmails.Add(email);
            return;
        }

    }
}