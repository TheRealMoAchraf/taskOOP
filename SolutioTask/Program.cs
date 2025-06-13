namespace task
{
    class Question
    {
        public int Marks { get; set; }
        public string Body { get; set; }
        public string Header { get; set; }
        public Question(int marks, string body, string header)
        {
            Marks = marks;
            Body = body;
            Header = header;
        }
        public void Display()
        {
            Console.WriteLine(Header + " " + $"(Marks {Marks})");
            Console.WriteLine(Body);
        }

    }

    class TrueFalseQ : Question
    {
        public bool Answer { get; set; }
        public TrueFalseQ(int marks, string body, string header, bool answer) : base(marks, body, header)
        {
            Answer = answer;
        }
        public void DisplayTF()
        {
            this.Display();
            Console.WriteLine("1. True");
            Console.WriteLine("2. False");
        }
    }
    class Mcq : Question
    {
        public string[] Options { get; set; }
        public int AnswerIndex { get; set; }
        public Mcq(int marks, string body, string header, string[] Options, int answerIndex) : base(marks, body, header)
        {
            this.Options = Options;
            this.AnswerIndex = answerIndex;
        }
        public void DisplayMcq()
        {
            this.Display();
            for (int i = 0; i < Options.Length; i++)
            {
                Console.WriteLine($"{i+1}. {Options[i]}");
            }
        }

    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(" hello can u please enter the num of questions ?");
            int questionsNum = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Can u pleae choose Mcq Or True & false ?");
            Console.WriteLine("M for mcq - T for true & false ?");
            char op = Convert.ToChar(Console.ReadLine().ToLower());

            switch (op)
            {
                case 'm':
                    Mcq[] examMcq = new Mcq[questionsNum];

                    for (int i = 0; i < questionsNum; i++)
                    {
                        Console.WriteLine("Enter Marks: ");
                        int marks = Convert.ToInt32(Console.ReadLine());

                        Console.WriteLine("Enter Header: ");
                        string header = Console.ReadLine();

                        Console.WriteLine("Enter Body: ");
                        string body = Console.ReadLine();

                        Console.WriteLine("how many options ?");
                        int optionsNum = Convert.ToInt32(Console.ReadLine());

                        string[] options = new string[optionsNum];
                        for (int j = 1; j <= optionsNum; j++)
                        {
                            Console.WriteLine($"enter the option number {j}");
                            options[j - 1] = Console.ReadLine();
                        }

                        Console.WriteLine("what is the correct answer index count from 1");
                        int answerIndex = Convert.ToInt32(Console.ReadLine());

                        examMcq[i] = new Mcq(marks, body, header, options, answerIndex);
                    }
                    Console.WriteLine("---------------------------------------------");
                    Console.WriteLine("---------------------------------------------");
                    Console.WriteLine("---------------------------------------------");
                    int studentScore = 0;
                    int totalMarks = 0;
                    for (int i = 0; i < examMcq.Length; i++)
                    {
                        totalMarks = totalMarks + examMcq[i].Marks;
                        examMcq[i].DisplayMcq();
                        Console.WriteLine("Answer is ?");
                        int studentAnswer = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("---------------------------------------------");
                        if (studentAnswer == examMcq[i].AnswerIndex)
                        {
                            studentScore = studentScore + examMcq[i].Marks;
                        }
                    }
                    Console.WriteLine($"the total score is {studentScore} out of {totalMarks}");
                    break;
                case 't':
                    TrueFalseQ[] examTF = new TrueFalseQ[questionsNum];
                    int tfScore = 0;
                    int tfTotal = 0;
                    for (int i = 0; i < questionsNum; i++)
                    {
                        Console.WriteLine("Enter Marks: ");
                        int marks = Convert.ToInt32(Console.ReadLine());

                        Console.WriteLine("Enter Header: ");
                        string header = Console.ReadLine();

                        Console.WriteLine("Enter Body: ");
                        string body = Console.ReadLine();

                        Console.WriteLine("Enter the correct answer (true/false): ");
                        bool answer = Convert.ToBoolean(Console.ReadLine());

                        examTF[i] = new TrueFalseQ(marks, body, header, answer);
                    }
                    Console.WriteLine("---------------------------------------------");
                    Console.WriteLine("---------------------------------------------");
                    Console.WriteLine("---------------------------------------------");
                    for (int i = 0; i < examTF.Length; i++)
                    {
                        tfTotal = tfTotal + examTF[i].Marks;
                        examTF[i].DisplayTF();
                        Console.WriteLine("Answer is ?");
                        bool sAnswer = Convert.ToBoolean(Console.ReadLine());
                        Console.WriteLine("---------------------------------------------");
                        if (sAnswer == examTF[i].Answer)
                        {
                            tfScore = tfScore + examTF[i].Marks;
                        }
                    }
                    Console.WriteLine($"the total score is {tfScore} out of {tfTotal}");
                    break;
            }
        }
    }
}

