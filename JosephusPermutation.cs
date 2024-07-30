using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW
{
    internal class JosephusPermutation
    {
        static void Main()
        {
            /*
             * 1번부터 N번까지 N명의 사람이 원을 이루면서 앉아있고, 양의 정수 K(≤ N)가 주어진다. 
             * 이제 순서대로 K번째 사람을 제거한다.
             * 한 사람이 제거되면 남은 사람들로 이루어진 원을 따라 이 과정을 계속해 나간다. 
             * 이 과정은 N명의 사람이 모두 제거될 때까지 계속된다. 
             * 원에서 사람들이 제거되는 순서를 (N, K)-요세푸스 순열이라고 한다.
             * 예를 들어 (7, 3)-요세푸스 순열은 <3, 6, 2, 7, 5, 1, 4>이다.
             */


            LinkedList<int> josephus = new LinkedList<int>();
            int n;
            int k; // k의 배수만큼 뛰어넘어서 제거

            Console.WriteLine("요세푸스 순열");
            Console.WriteLine("사람이 총 몇명인지 입력해주세요.");
            bool toDetermine1 = int.TryParse(Console.ReadLine(), out n);
            Console.WriteLine("몇번째 사람을 제거할 지 입력해주세요.");
            bool toDetermine2 = int.TryParse(Console.ReadLine(),out k);
            Console.Clear();

            for (int i = 1; i <=n; i++)
            {
                josephus.AddLast(i);
            }

            LinkedListNode<int> node1; // = josephus.First;

            /* ➀-➁-➂-➃-➄-➅-➆
             * 3,6,2,7,5,1,4 순으로 빠져야함
             * k의 배수만큼 건너뜀
             * 원형 연결리스트 or 다른방법
             * ➂-➃-➄-➅-➆-➀-➁ 제거하지 않은 수는 맨 뒤에 연결하고 반복 돌리면 .
             * ➃-➄-➅-➆-➀-➁ -> 3 제거
             * ➅-➆-➀-➁-➃-➄
             * ➆-➀-➁-➃-➄ -> 6 제거
             * ➁-➃-➄-➆-➀
             * ➃-➄-➆-➀ -> 2 제거
             */

            while (josephus.Count>0) // 남아있는게 없을때까지 뺌
            {
                for(int i = 1; i <=k; i++) // 매번 k만큼 반복을 돌려서
                {
                    // josephus.Remove(k); //이건 값을 찾아서 제거하는것, index 없음
                    // 찾아서 지우려면 linkedlistnode를 써야함 
                    node1 = josephus.First;
                    
                    if(i == k) // k까지 오면 빼고
                    {
                        // Console.Write($"{node1.Value}을(를) 제거합니다.");
                        josephus.Remove(node1);
                        Console.WriteLine($"{node1.Value}");
                    }
                    else // 아니면 맨 뒤에 붙임
                    {
                        // Console.Write($"{node1.Value}을(를) 맨 뒤로 보냅니다.");
                        josephus.RemoveFirst();
                        josephus.AddLast(node1); 
                    }
                }
                
            }
            /*1.  4 1 6 5 7 3 2 k+1만큼 뛰어넘고 있음 일단 뛰어넘는건 구현
             *  for 반복문 i를 1부터 바꿈
             */



        }
    }
}
