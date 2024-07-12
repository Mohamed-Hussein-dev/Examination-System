using System.Diagnostics.Contracts;
using System.Security.Principal;

namespace dotNet_Examanation_System;

public abstract class Question
{
  
    private string ?header_Question; 
    private string ?body_Question;
    private int mark;

    private int choice;
    public int Choice
    {
        get { return choice; }
        set { choice = value; }
    }
    
    public int Mark {
         get { return mark; }
         set { mark = (value <= 0 ? 1 : value);} 
    }

    public string ?Body_Question{
        get { return body_Question; }
        set { body_Question = value; }
    }

     public string ?Header_Question{
        get { return header_Question; }
        set { header_Question = value; }
    }
    protected Answer[] AnswersList = new Answer[4];
    public int RightAnswer;

    public abstract void read();
    public abstract void write();
    public abstract bool getAnswer();

    public override string ToString(){
        return $"{body_Question} \t \t Right answer: {AnswersList[RightAnswer-1]}";
    }
}

public class MCQ :  Question{
    public MCQ(){
        Header_Question = "Choose the correct answer ";
    }

    public override void read(){
        Console.WriteLine("Enter the Question Body : ");
        Body_Question = Console.ReadLine();

        for(int i = 1 ; i <= 4 ; i++){
            Console.Write($"Enter Choice Number {i} : ");
            AnswersList[i-1] = new Answer();
            AnswersList[i-1].read();
        }
        do{
            Console.Write("Enter the right answer number [1:4] : ");
        }while(!int.TryParse(Console.ReadLine(), out RightAnswer) || RightAnswer < 1 || RightAnswer > 4);
        int mark;
        do{
            Console.Write("Enter Question Mark :  ");
        }while(!int.TryParse(Console.ReadLine(), out mark));
        Mark = mark;

    }

    public override void write()
    {
        Console.WriteLine(Header_Question);
        Console.WriteLine(Body_Question);
        for(int i = 0 ; i < 4 ; i ++){
            Console.Write($"{i+1}.{AnswersList[i]} \t");
        }
        Console.WriteLine();
        Console.WriteLine("------------------------------------------------------------");
    }

    public override bool getAnswer(){
        int ans;
        do{
            Console.Write("Answer : ");
        }while(!int.TryParse(Console.ReadLine() , out ans) || ans < 1 || ans > 4);
        return ans == RightAnswer;
    }
}


public class True_False : Question{
    public True_False(){
        Header_Question = "Ture or Faslse ";
    }

    public override bool getAnswer()
    {
        int ans;
        do{
            Console.Write("Answer : ");
        }while(!int.TryParse(Console.ReadLine() , out ans) || ans < 0 || ans > 4);
        return ans == RightAnswer;
    }

    public override void read(){
        Console.WriteLine("Enter the Question Body : ");
        Body_Question = Console.ReadLine();

        AnswersList[0] = new Answer("Ture");
        AnswersList[1] = new Answer("Faslse");

        do{
            Console.WriteLine("Enter the right answer number (1-ture , 2-false) : ");
        }while(!int.TryParse(Console.ReadLine(), out RightAnswer)|| RightAnswer < 1 || RightAnswer > 2);
        int mark;
        do{
            Console.Write("Enter Question Mark :  ");
        }while(!int.TryParse(Console.ReadLine(), out mark));
        Mark = mark;

    }

    public override void write()
    {
        Console.WriteLine(Header_Question + $"Mark({Mark})");
        Console.WriteLine(Body_Question);
        Console.WriteLine("1.True \t \t 2.False");
        Console.WriteLine("------------------------------------------------------------");
    }
}