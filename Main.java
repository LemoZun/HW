public class Main {
    public static void main(String[] args) {
        int[] workArr = new int[] {4,4,12,10,2,10};
        int[] result = printWorkCal(workArr, 8);

        for(int i : result) {
            System.out.print(i + " ");
        }
    }

    public static int[] printWorkCal(int[] workArr, int workForDay) {
        int[] result = new int[workArr.length];
        int restTime = workForDay;
        int now = 1;

        for(int i = 0; i < workArr.length; i++) {
            while(true) {
                if(workArr[i] > restTime) {
                    workArr[i] -= restTime;
                    now++;
                    restTime = workForDay;
                }
                else {
                    restTime -= workArr[i];
                    result[i] = now;
                    break;
                }
            }
        }
        return result;
    }
}