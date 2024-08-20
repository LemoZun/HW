using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW
{
    internal class TaskSchedule
    {
        static void Main1()
        {
            int[] tasks = { 4, 4, 12, 10, 2, 10 };
            int[] day = CalculateCompletionDates(tasks);

            Console.WriteLine("출력: [" + string.Join(", ", day) + "]");
        }

        static int[] CalculateCompletionDates(int[] tasks)
        {
            // 하루 작업 시간
            int hoursPerDay = 8;

            // 결과 배열
            int[] day = new int[tasks.Length];

            // 작업을 저장할 큐
            Queue<Tuple<int, int>> taskQueue = new Queue<Tuple<int, int>>();

            int currentDay = 1;
            int currentHour = 0;

            for (int i = 0; i < tasks.Length; i++)
            {
                // 큐에 현재 작업과 그 작업의 남은 시간을 추가
                taskQueue.Enqueue(Tuple.Create(i, tasks[i]));

                while (taskQueue.Count > 0)
                {
                    var task = taskQueue.Dequeue();
                    int taskIndex = task.Item1;
                    int remainingHours = task.Item2;

                    if (currentHour + remainingHours <= hoursPerDay)
                    {
                        // 작업이 하루 안에 완료되는 경우
                        currentHour += remainingHours;
                        day[taskIndex] = currentDay;
                    }
                    else
                    {
                        // 하루에 다 완료되지 않는 경우
                        int hoursToCompleteToday = hoursPerDay - currentHour;
                        remainingHours -= hoursToCompleteToday;

                        currentHour = hoursPerDay; // 하루를 다 쓴 상태
                        day[taskIndex] = currentDay;

                        // 다음 날로 넘어갑니다
                        currentDay++;
                        currentHour = 0; // 새로운 하루의 시작

                        // 남은 작업을 다시 큐에 추가
                        taskQueue.Enqueue(Tuple.Create(taskIndex, remainingHours));
                    }
                }

                // 만약 큐가 비어있지 않다면, 현재 날짜를 계속 업데이트
                if (taskQueue.Count > 0)
                {
                    while (taskQueue.Count > 0)
                    {
                        var task = taskQueue.Dequeue();
                        int taskIndex = task.Item1;
                        int remainingHours = task.Item2;

                        // 현재 작업이 완료되지 않았으므로, 남은 시간만큼 추가
                        if (currentHour + remainingHours <= hoursPerDay)
                        {
                            currentHour += remainingHours;
                            day[taskIndex] = currentDay;
                        }
                        else
                        {
                            int hoursToCompleteToday = hoursPerDay - currentHour;
                            remainingHours -= hoursToCompleteToday;

                            currentHour = hoursPerDay;
                            day[taskIndex] = currentDay;

                            currentDay++;
                            currentHour = 0;

                            taskQueue.Enqueue(Tuple.Create(taskIndex, remainingHours));
                        }
                    }
                }
            }

            return day;
        }
    }
}