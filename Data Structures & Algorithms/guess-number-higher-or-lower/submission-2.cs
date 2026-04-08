/** 
 * Forward declaration of guess API.
 * @param  num   your guess
 * @return 	     -1 if num is higher than the picked number
 *			      1 if num is lower than the picked number
 *               otherwise return 0
 * int guess(int num);
 */

public class Solution : GuessGame {
    public int GuessNumber(int n) {
        var l = 1;
        var r = n;
        while (l <= r) {
            var myGuess = (r - l) / 2 + l;
            var res = guess(myGuess);
            if(res == 1){
                // cut off the left range
                l = myGuess + 1;
            } else if (res == -1){
                // cut off the right range
                r = myGuess - 1;
            } else {
                // found
                return myGuess;
            }
        }
        return -1;
    }
}