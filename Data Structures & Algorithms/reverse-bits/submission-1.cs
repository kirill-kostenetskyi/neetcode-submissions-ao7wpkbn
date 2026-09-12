public class Solution {
    public uint ReverseBits(uint n) {
        uint res = 0;
        int bitCounter = 32;
        while(bitCounter != 0){
            uint lastBit = n & 1;
            n = n >> 1; // remove last bit
            res = res << 1;
            res = res | lastBit;
            bitCounter--;
        }
        return res;
    }
}