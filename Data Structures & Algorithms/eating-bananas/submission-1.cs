public class Solution {
    public int MinEatingSpeed(int[] piles, int h) {
        piles = piles.OrderBy(x=> x).ToArray(); 
        var low = 1;
        var high = piles[piles.Length - 1];
        var speed = 0;
        // for(int i = low; i <= high; i++){
        //     var hours = TotalHoursToEatPiles(piles, i);
        //     if(hours <= h){
        //         return i;
        //     } 
        // }
        var answer = high;
        while(low <= high){
            var middleSpeed = ((high - low) / 2) + low;
            var hours = TotalHoursToEatPiles(piles, middleSpeed);
            if(hours > h){
                low = middleSpeed + 1;
            } else {
                high = middleSpeed - 1;
                if(middleSpeed <= answer){
                    answer = middleSpeed;
                }
            }
        }
        return answer;
        //return low;

        // [3, 6, 7, 11] h = 8
        // [1 ... 11] 
        // [...4,5,6,7,8,9,10,11]
        // hours > h --> cut off every speed on a left of the range

        // [1 .. 11]
        // [1 .. 6 .. 11]
        // hours <= h --> cut off every speed on the right
        // [1 .. 6]
        // [1 .. 3 .. 6]
        // [4 .. 6]
    }

    private long TotalHoursToEatPiles(int[] piles, int speed){
        long totalHours = 0;
        foreach(var pile in piles){
            var hoursForTheCurrentPile = (int) Math.Ceiling((double)pile / speed);
            totalHours += hoursForTheCurrentPile;
        }
        return totalHours;
    }
}