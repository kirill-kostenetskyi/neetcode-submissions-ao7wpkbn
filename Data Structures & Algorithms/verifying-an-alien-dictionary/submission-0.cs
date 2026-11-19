public class Solution {
    public bool IsAlienSorted(string[] words, string order) {
        if(words.Length == 1){
            return true;
        }
        var orderHash = new Dictionary<char, int>();
        for(int i = 0; i< order.Length; i++){
            orderHash[order[i]] = i; 
        }
        
        var firstIndex = 0;
        var secondIndex = 1;

        while(secondIndex <= words.Length - 1){
            var res = CompareWords(words[firstIndex], words[secondIndex]);
            if(res == false){
                return false;
            }
            firstIndex++;
            secondIndex++;
        }

        return true;

        bool CompareWords(string w1, string w2){
            for(int i = 0; i < w1.Length; i++){
                var w1Letter = i < w1.Length ? w1[i] : '#';
                var w2Letter = i < w2.Length ? w2[i] : '#';
                if(w1Letter == w2Letter){
                    continue;
                }
                var w1LetterOrder = w1Letter != '#' ? orderHash[w1Letter] : int.MinValue;
                var w2LetterOrder = w2Letter != '#' ? orderHash[w2Letter] : int.MinValue;
                if(w1LetterOrder < w2LetterOrder){
                    return true;
                }
                if(w1LetterOrder > w2LetterOrder){
                    return false;
                }
            }
            return true;
        }
    }
}