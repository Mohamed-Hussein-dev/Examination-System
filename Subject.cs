namespace dotNet_Examanation_System;

public class Subject
{
    // Properties
    public int SubjectId { get; set; }
    public string SubjectName { get; set; }
    public Exam? exam { get; private set; }

    // Constructor
    public Subject(int subjectId, string subjectName)
    {
        SubjectId = subjectId;
        SubjectName = subjectName;
        exam = null; // Initialize Exam to null initially
    }


    public void CreateExam()
    {
        
        int type;
        do{
            Console.Write("Enter Exam Type {1-Practical , 2-Final} : ");
        }while (!int.TryParse(Console.ReadLine() , out type) || type < 1 || type > 2);

        exam = type == 1 ? new PracticalExam() : new FinalExam();
        exam.create();
    }

    public void doExam(){
        if(exam is not null)
            exam.startExam();
        else
            Console.WriteLine($"ther is no Exame for subject : {SubjectName}");
    }
}