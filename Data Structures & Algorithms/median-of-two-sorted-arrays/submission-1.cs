
public class Solution {
    public double FindMedianSortedArrays(int[] nums1, int[] nums2) {
        int[] A;
        int[] B;

        // A всегда меньший массив, по нему делаем binary search
        if(nums2.Length < nums1.Length){
            A = nums2;
            B = nums1;
        } else {
            A = nums1;
            B = nums2;
        }

        // Сколько элементов должно быть в левой половине
        // При odd справа будет на 1 элемент больше
        var half = (nums1.Length + nums2.Length) / 2;

        var L = 0;
        var R = A.Length; // специально так, ибо считаем количество элементов в A, а не индекс

        while(L <= R){
            var M = (R + L) / 2; // сколько взять элементов из A. Крайний случай 0
            var ALastIndex = M - 1;
            var BLastIndex = half - M - 1; // сколько взять из B = half - M

            // Последние элементы левых частей
            // Если слева пусто, используем -Infinity
            var ALeft = ALastIndex >= 0
                ? A[ALastIndex]
                : int.MinValue;

            var BLeft = BLastIndex >= 0
                ? B[BLastIndex]
                : int.MinValue;

            // Первые элементы правых частей
            // Если справа пусто, используем +Infinity
            var ARight = ALastIndex + 1 < A.Length
                ? A[ALastIndex + 1]
                : int.MaxValue;

            var BRight = BLastIndex + 1 < B.Length
                ? B[BLastIndex + 1]
                : int.MaxValue;

            // Все элементы слева <= всех элементов справа
            if(ALeft <= BRight && BLeft <= ARight){
                // Нашли правильное разделение
                if((nums1.Length + nums2.Length) % 2 == 0){
                    // Even: среднее между max слева и min справа
                    var res = (double)Math.Min(BRight, ARight) * 0.5
                            + Math.Max(ALeft, BLeft) * 0.5;
                    return res;
                } else {
                    // Odd: справа на 1 элемент больше, медиана = min справа
                    return Math.Min(ARight, BRight);
                }
            } else if (ALeft > BRight){
                // Взяли слишком много элементов из A
                R = M - 1;
            } else if (BLeft > ARight){
                // Взяли слишком мало элементов из A
                L = M + 1;
            }
        }

        // Для валидных входных данных сюда никогда не попадём
        throw new InvalidOperationException();
    }
}
