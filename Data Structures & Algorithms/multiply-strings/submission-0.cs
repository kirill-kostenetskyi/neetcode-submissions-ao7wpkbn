public class Solution {
    public string Multiply(string num1, string num2) {
        if(num1 == "0" || num2 == "0"){
            return "0";
        }
        var res = new int[num1.Length + num2.Length];
        num1 = new string(num1.Reverse().ToArray());
        num2 = new string(num2.Reverse().ToArray());
        
        for(int i1 = 0; i1 < num1.Length; i1++){
            for(int i2 = 0; i2 < num2.Length; i2++){
                var resPosition = i1 + i2;
                var digit1 = num1[i1] - '0';
                var digit2 = num2[i2] - '0';
                var multiplyRes = digit2 * digit1 + res[resPosition];
                res[resPosition] = multiplyRes % 10;
                if(multiplyRes / 10 > 0){
                    res[resPosition + 1] = res[resPosition + 1] + multiplyRes / 10;
                }
            }
        }

        Array.Reverse(res);

        var startPosition = 0;
        if(res[0] == 0){
            for(int i = 0; i < res.Length; i++){
                if(res[i] != 0){
                    startPosition = i;
                    break;
                }
            }
        }

        var sb = new StringBuilder();
        for(int i = startPosition; i < res.Length; i++){
            sb.Append(res[i]);
        }
        return sb.ToString();
    }
}