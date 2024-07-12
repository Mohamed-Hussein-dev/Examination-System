namespace dotNet_Examanation_System;

public abstract class Exam
{
    private int examTime;
    private int numberOfQuestions;
    private int score , totalScore;
    protected  Question[] QuestionList;

    public Exam(){
        Score = 0;
        TotalScore = 0;
        QuestionList = new Question[1];
    }

    public Exam(int time , int numberQ) : this(){
        QuestionList = new Question[numberQ]; 
        ExamTime = time;
        NumberOfQuestions = numberQ;
        
    }
    public int ExamTime
    {
        get { return examTime; }
        set { examTime = value < 30 ? 30 : value; }
    }

    public int NumberOfQuestions
    {
        get { return numberOfQuestions; }
        set { numberOfQuestions = value < 1 ? 1 : value; }
    }

    public int Score{
        get { return score; }
        set { score = value;}
    }

     public int TotalScore{
        get { return totalScore; }
        set { totalScore = value;}
    }
    public abstract void show();
    public abstract void create();

    public void startExam(){
        for(int i = 0 ; i < numberOfQuestions ; i++){
            QuestionList[i].write();
            if(QuestionList[i].getAnswer())
                score += QuestionList[i].Mark;
        }
    }
    
}


public class FinalExam : Exam
{
    public FinalExam(int time , int numberQ) : base(time , numberQ){}
    public FinalExam(){}

    public override void create(){
        int number;
        do{
            Console.WriteLine("Enter number of Question");
        }while(!int.TryParse(Console.ReadLine(), out  number));
        NumberOfQuestions = number;
        QuestionList = new Question[NumberOfQuestions];
        for(int i = 1 ; i <= NumberOfQuestions ; i++){
            Console.Clear();
            int type;
            do{
                Console.WriteLine($"Enter type of Question number {i} :(1-MCQ , 2-T or F) :");
            }while(!int.TryParse(Console.ReadLine() , out type) || type > 2 || type < 1);

            QuestionList[i-1] = type == 1 ? new MCQ() : new True_False();
            QuestionList[i-1].read();
            TotalScore += QuestionList[i-1].Mark;
        }
    }
    public override void show()
    {
        foreach (var Q in QuestionList){
            Console.WriteLine(Q);
        }

        Console.WriteLine($"Your score: {Score} / {TotalScore}");
    }
}


public class PracticalExam : Exam
{
    public PracticalExam(int time , int numberQ) : base(time , numberQ){}
    public PracticalExam(){}

    public override void create(){

        int number;
        do{
            Console.WriteLine("Enter number of Question");
        }while(!int.TryParse(Console.ReadLine(), out  number));
        NumberOfQuestions = number;
        QuestionList = new Question[NumberOfQuestions];
        for(int i = 1 ; i <= NumberOfQuestions ; i++){
            Console.Clear();
            QuestionList[i-1] = new True_False();
            QuestionList[i-1].read();
            TotalScore += QuestionList[i-1].Mark;
        }
    }
    public override void show()
    {
        foreach (var Q in QuestionList){
            Console.WriteLine(Q);
        }

        Console.WriteLine($"Your score: {Score} / {TotalScore}");
    }
}