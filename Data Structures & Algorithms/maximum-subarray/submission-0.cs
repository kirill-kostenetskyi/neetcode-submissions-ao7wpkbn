public class Solution {
    public int MaxSubArray(int[] nums) {
        var maxSum = nums[0];
        var currentSum = 0;
        if(nums.Length == 1){
            return nums[0];
        }

        foreach(var num in nums){
           if(currentSum < 0){
            // обнуляем расчет (смещаем указатель)
                currentSum = 0;
           }
           currentSum = currentSum + num;
           maxSum = Math.Max(currentSum, maxSum);
        }
        return maxSum;
    }
}
// 1. Если слева от текущей позиции стоит отрицательное значение то мы должны ресетить поинтер. Негативное всегда будет тянуть "назад"
// 2. Если слева от текущей позиции негативный то мы обнуляем currentSum (считай поинтер)
// 3. считать мы должны по идее в конце итерации, ведь в начале нам надо понят или мы обнуляем currentSum
// 4. Мы должны определить какой максимальный был currentSum среди всех. Для этого в конце каждой итерации можно проверить или он больше текущего и если да то обновлять максимальный