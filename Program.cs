namespace dotNet_Examanation_System;

class Program
{
    static void Main(string[] args)
    {
      Console.Clear();
      Subject sub = new Subject(10 , "C#");
      sub.CreateExam();
      if(sub.exam is not null){
        sub.doExam();
        sub.exam.show();
      }
        
    }
}
