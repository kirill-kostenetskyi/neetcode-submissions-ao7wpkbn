public class Solution {
    public bool CheckValidString(string s) {
        // все возможные количества незакрытых левых скобок
        // если у нас {0, 1, 2} - до этого были способы как
        // прийти к состоянию где у нас 0 или 1 или 2 некзакрытых скобки
        var minLeft = 0;
        var maxLeft = 0;

        for(int i = 0; i < s.Length; i++){
            var c = s[i];
            if(c == '('){
                minLeft++;
                maxLeft++;
            } else if(c == ')'){
                minLeft--;
                maxLeft--;
            } else if(c == '*'){
                minLeft--;
                maxLeft++;
            }

            if(minLeft < 0){
                minLeft = 0;
            }
            if(maxLeft < 0){
                return false;
            }
        }

        if(minLeft == 0){
            return true;
        }
        return false;
    }
}