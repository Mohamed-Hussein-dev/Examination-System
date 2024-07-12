namespace dotNet_Examanation_System;

public class Answer
{
    private string ?AnswerText;
    public Answer()  { }

    public Answer(string text){
        AnswerText = text;
    }
    public void read(){
        AnswerText = Console.ReadLine();
    }

    public override string? ToString()
    {
        return AnswerText;
    }
}
