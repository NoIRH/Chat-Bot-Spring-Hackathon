using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using Timer = System.Timers.Timer;

namespace GameEngine.MiniGames
{
    public class CalculationGame : MiniGame
    {

        private List<(string view, Func<double, double, double> operation)> operations = new()
            {
                ("+", (a,b) => a + b),
                ("-",(a,b) => a - b),
                ("*",(a,b) => a * b),
                ("/",(a,b) => a / b)
            };
        public int Level { get; set; }
        public (int start, int end) NumberRange { get; set; }
        public int CountSteps;
        private Timer timer;
        private int levelTime = 30000;
        private double rightAnswer;
        public List<(double answer, bool isRight)> answers;

        public CalculationGame()
        {
            Name = "Игра в вычисления";
            GameDescription = "В этой игре вам нужно решить как можно больше примеров. Вам дается сам пример и четыре варианта ответа, ваша задача выбрать как можно больше правильных пока не закончится время ";
        }
        public void Start(int level = 1, int start = 1, int end = 100)
        {
            Level = level;
            timer = new Timer();
            timer.Interval = levelTime / level;
            IsWorked = true;
            timer.Elapsed += (object source, ElapsedEventArgs e) => IsWorked = false;
            timer.AutoReset = false;
            answers = new List<(double answer, bool isRight)>();
            NumberRange = (start, end);
            timer.Start();
        }
        public (string example, List<double> variants) GetNext()
        {
            if (!IsWorked) return ("время окончено", new List<double>());
            var variants = new List<double>();
            var r = new Random();
            var numberOperation = r.Next(0, operations.Count());
            double answer = r.Next(NumberRange.start, NumberRange.end);
            var example = answer.ToString();
            for (int i = 0; i < Level; i++)
            {
                var b = r.Next(NumberRange.start, NumberRange.end);
                numberOperation = r.Next(0, operations.Count());
                example += " " + operations[numberOperation].view + " ";
                example += b;
                answer = Math.Round(operations[numberOperation].operation(answer, b), 2);
            }
            example += " = ??";
            variants.Add(answer);
            numberOperation = r.Next(0, operations.Count());
            variants.Add(Math.Round(operations[numberOperation]
                .operation(answer, r.Next(NumberRange.start, NumberRange.end)), 2));
            numberOperation = r.Next(0, operations.Count());
            variants.Add(Math.Round(operations[numberOperation]
                .operation(r.Next(NumberRange.start, NumberRange.end),
                r.Next(NumberRange.start, NumberRange.end)), 2));
            numberOperation = r.Next(0, 2);
            variants.Add(Math.Round(operations[numberOperation]
                .operation(answer, 1), 2));
            CountSteps++;
            Shuffle(variants);
            rightAnswer = answer;
            return (example, variants);
        }
        public void WriteAnswer(double answer)
        {
            if (IsWorked) answers.Add((answer, answer == rightAnswer));
        }
        public string ShowStatistics()
        {
            var countRight = 0;
            foreach (var a in answers)
                if (a.isRight)
                    countRight++;
            return $"Общее количество примеров: {CountSteps} \n\rКоличество правильных ответов: {countRight}";
        }
        private void Shuffle<T>(List<T> list)
        {
            Random rand = new Random();
            for (int i = list.Count - 1; i >= 1; i--)
            {
                int j = rand.Next(i + 1);
                T tmp = list[j];
                list[j] = list[i];
                list[i] = tmp;
            }
        }
    }
}
