using Newtonsoft.Json;

namespace SitefinityWebApp.QuestionsDto{

public class QuestionsDto
{
    public int MaxQuestions { get; set; }
    public bool SkipQuestion { get; set; }
    
    [JsonProperty("value")]
    public List<Question> QuestionList { get; set; }

    public QuestionsDto()
    {
        MaxQuestions = 3;
        SkipQuestion = true;
    }
}

public class Question
{
    public string Id { get; set; }
    public AnswersDto.AnswersDto Answers { get; set; }
    public string Title { get; set; }
    public string ParentId { get; set; }
    protected bool Equals(Question other)
    {
        return Id == other.Id;
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((Question) obj);
    }

    public override int GetHashCode()
    {
        return Id.GetHashCode();
    }
}

}
