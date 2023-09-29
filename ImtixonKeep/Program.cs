var answers = new List<Answer>()
{
    new Answer(true, "Fil", QuestionType.ShortAnswer),
    new Answer(false, "sichqon", QuestionType.ShortAnswer),
    new Answer(false, "ot", QuestionType.ShortAnswer),
    new Answer(false, "yo'l", QuestionType.ShortAnswer),
    new Answer(false, "Tog' echkisi", QuestionType.ShortAnswer),
};

var answers1 = new List<Answer>()
{
    new Answer(true, "Fil", QuestionType.ShortAnswer),
    new Answer(false, "sichqon", QuestionType.ShortAnswer),
    new Answer(true, "ot", QuestionType.ShortAnswer),
    new Answer(true, "yo'l", QuestionType.ShortAnswer),
    new Answer(false, "Tog' echkisi", QuestionType.ShortAnswer),
};

var answers2 = new List<Answer>()
{
    new Answer(true, "Fil", QuestionType.ShortAnswer),
    new Answer(false, "sichqon", QuestionType.ShortAnswer),
    new Answer(false, "ot", QuestionType.ShortAnswer),
    new Answer(false, "yo'l", QuestionType.ShortAnswer),
    new Answer(false, "Tog' echkisi", QuestionType.ShortAnswer),
};

var answers3 = new List<Answer>()
{
    new Answer(true, "Fil", QuestionType.ShortAnswer),
    new Answer(false, "sichqon", QuestionType.ShortAnswer),
    new Answer(false, "ot", QuestionType.ShortAnswer),
    new Answer(false, "yo'l", QuestionType.ShortAnswer),
    new Answer(true, "Tog' echkisi", QuestionType.ShortAnswer),
};

var questions = new List<Question>()
{
    new Question(1, QuestionType.ShortAnswer,"Eng katta hayvon qaysi", "o'txo'r"),
    new Question(2, QuestionType.CheckboxQuestion,"Zararkunada", "kichik"),
    new Question(3, QuestionType.MultipleChoice,"Tez chopadi", "4 oyoqli"),
    new Question(4, QuestionType.ShortAnswer,"uzoq", "Asfalt")
};

var listAnswers = new List<AnswerList>()
{
    new AnswerList(1, answers),
    new AnswerList(3, answers1),
    new AnswerList(2, answers2),
    new AnswerList(4, answers3),
};




void TakeAnwer(string item)
{
    var qId = questions.Find( x => x.Title == item );
    Console.WriteLine("Savol: " + qId.Title + "\nDescription: " + qId.Description);
    var aId = listAnswers.Find(x => x.ListAnswersId == qId.ListAnswer);
    Console.WriteLine("\nJavoblar :");
    aId.ListAnswers.ForEach(x => Console.WriteLine(x.Description));
    Console.WriteLine("\nTo'gri javob: ");
    aId.ListAnswers.FindAll(x => x.IsCorrect == true).ToList().ForEach(x => Console.WriteLine(x.Description));
}

TakeAnwer("Eng katta hayvon qaysi");
Console.WriteLine("\n**** ");
TakeAnwer("Zararkunada");
Console.WriteLine("\n****");
TakeAnwer("Tez chopadi");
Console.WriteLine("\n***");
TakeAnwer("uzoq");
Console.WriteLine("\n***");

enum QuestionType
{
    MultipleChoice,
    ShortAnswer,
    CheckboxQuestion
}

public class Question
{
    public Question(long listAnswer, Enum questionType, string title, string description)
    {
        ListAnswer = listAnswer;
        QuestionType = questionType;
        Title = title;
        Description = description;
    }

    public long ListAnswer { get; set; }
    Enum QuestionType { get; set; }
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
    public Answer(bool isCorrect, string description, Enum answerType)
    {
        IsCorrect = isCorrect;
        Description = description;
        AnswerType = answerType;
    }

    public bool IsCorrect { get; set; }
    public string Description { get; set; }
    Enum AnswerType { get; set; }
}