namespace HW
{
    internal class BracketCheck
    {
        //enum Bracket { '(', ) }
        //열거형에 괄호를 넣고싶은데 안됨

        static public void Main1()
        {            
            Console.WriteLine("괄호를 입력하세요:");
            string bracket = Console.ReadLine();

            
            bool toDetermine = BRCheck(bracket);

            
            if (toDetermine)
                Console.WriteLine("괄호가 모두 완성되어 있습니다.");
            else
                Console.WriteLine("괄호가 완성되어 있지 않습니다.");

            //Stack<char> stack = new Stack<char>();
            //bool toDetermine;
            //char bracket = '(';
            //while (true)
            //{

            //    toDetermine = char.TryParse(Console.ReadLine(), out bracket);                
            //    stack.Push(bracket);

            //    Console.WriteLine("현재 스택");
            //    foreach (char c in stack)
            //    {
            //        Console.WriteLine(c);
            //    }


        }
        // 여는 괄호 먼저 받고 닫는 괄호 받기, 닫는괄호 먼저 들어오면 안됨
        // 
        static bool BRCheck(string _bracket)
        {
            Stack<char> stack = new Stack<char>();

            foreach (char c in _bracket) //입력받은 string을 한 글자씩 
            {
                if (c == '(' || c == '[' || c == '{') //이렇게 선택해서 받으면 수식같은것도 받을 수 있다.
                {                   
                    stack.Push(c); // 여는 괄호가 오면 스택에 넣기
                }
                else if (c == ')' || c == ']' || c == '}')
                {
                    
                    if (stack.Count == 0)
                    {
                        return false; // 스택에 아무것도 없는데 닫는 괄호가 올 경우 fals 리턴
                    }
                    
                    char open = stack.Pop();

                    if (!MatchBracket(open, c))
                    {
                        return false; // 괄호 짝이 맞지 않을 경우 
                    }
                }
            }
            if (stack.Count == 0)
                return true; // 괄호 값이 다 매칭이 되서 스택에 아무것도 없을경우
            else
                return false;
            
        }
        static bool MatchBracket(char open, char close)
        {
            bool check1 = (open == '(' && close == ')');
            bool check2 = (open == '[' && close == ']');
            bool check3 = (open == '{' && close == '}');

            return (check1 || check2 || check3);
        }
        // 작업 일정 계산기는 만들다가 폐기.. 잘 이해가 안가서 큐를 더 공부해야겠다..
    }
}

