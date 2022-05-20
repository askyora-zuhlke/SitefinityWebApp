using Newtonsoft.Json;

namespace SitefinityWebApp.AnswersDto
{
    public class AnswersDto
    {
        [JsonProperty("value")]
        public List<Answer> AnswerList { get; set; }
    }

    public class Answer
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public bool IsCorrectAnswer { get; set; }
        public string ParentId { get; set; }
    }


}