var answers = new List<Answer>()
{
    new Answer(4, "Fil"),
    new Answer(3, "sichqon"),
    new Answer(2, "ot"),
    new Answer(1, "yo'l"),
    new Answer(1, "Tog' echkisi"),
};
var questions = new List<Question>()
{
    new Question(1, 4,"Eng katta hayvon qaysi", "o'txo'r"),
    new Question(2, 3,"Zararkunada", "kichik"),
    new Question(3, 2,"Tez chopadi", "4 oyoqli"),
    new Question(4, 1,"uzoq", "Asfalt")
};

var listAnswers = new List<AnswerList>()
{
    new AnswerList(1, answers),
    new AnswerList(3, answers),
    new AnswerList(2, answers),
    new AnswerList(4, answers),
};




void TakeAnwer(string item)
{
    var qId = questions.Find( x => x.Title == item );
    Console.WriteLine("Savol: " + qId.Title + "\nDescription: " + qId.Description);
    var aId = listAnswers.Find(x => x.ListAnswersId == qId.ListAnswer);
    Console.WriteLine("\nJavoblar :");
    aId.ListAnswers.ForEach(x => Console.WriteLine(x.Description));
    Console.WriteLine("\nTo'gri javob: " + aId.ListAnswers.Find(x => x.QuestionId == qId.CorrectAnswerId).Description);

}
TakeAnwer("Eng katta hayvon qaysi");

public class Question
{
    public Question(long listAnswer, long correctAnswerId, string title, string description)
    {
        ListAnswer = listAnswer;
        CorrectAnswerId = correctAnswerId;
        Title = title;
        Description = description;
    }

    public long ListAnswer { get; set; }
    public long CorrectAnswerId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
}

public class AnswerList
{
    public AnswerList(long listAnswersId, List<Answer> listAnswers)
    {
        ListAnswersId = listAnswersId;
        ListAnswers = listAnswers;
    }

    public long ListAnswersId { get; set; }
    public List<Answer> ListAnswers { get; set; }

}

public class Answer
{
    public Answer(long questionId, string description)
    {
        QuestionId = questionId;
        Description = description;
    }

    public long QuestionId { get; set; }
    public string Description { get; set; }
}