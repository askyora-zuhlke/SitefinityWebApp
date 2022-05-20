using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Progress.Sitefinity.AspNetCore.ViewComponents;
using SitefinityWebApp.AnswersDto;
using SitefinityWebApp.QuestionsDto;
using Value = SitefinityWebApp.QuestionsDto.Question;

namespace SitefinityWeb.ViewComponents
{

    [SitefinityWidget(Title = "Random Quiz Widget")]
    [ViewComponent(Name = "RandomQuiz")]
    public class RandomQuizViewComponent : ViewComponent
    {
        private static readonly HttpClient client = new HttpClient();
        private static QuestionsDto questions;

        // Invokes the view.
        public IViewComponentResult Invoke(IViewComponentContext<QuestionsDto> context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }
            getQuestions(context.Entity.MaxQuestions);
            return this.View(questions);
        }

        private void getQuestions(int randomSize)
        {
            String jsonString = client.GetStringAsync("https://localhost:8080/api/default/quizquestions?$select=Id,Title,parentId").Result;
                if (jsonString != null)
                {
                    questions = JsonConvert.DeserializeObject<QuestionsDto>(jsonString);
                    questions.QuestionList = populateAnswers(replaceWithRandomQuestions(randomSize).ToList());
                }
        }



        private List<Question> populateAnswers( List<Question> questionItems )
        {
            for (var index=0;index<questionItems.Count;index++) {
                String jsonString = client
                    .GetStringAsync("https://localhost:8080/api/default/quizquestionoptions?$select=TItle,IsCorrectAnswer,Id,ParentId&$filter=ParentId eq "+questionItems[index].Id)
                    .Result;
                if (jsonString != null)
                {
                    AnswersDto answersDto= JsonConvert.DeserializeObject<AnswersDto>(jsonString);
                    questionItems[index].Answers = answersDto;
                }
            }

            return questionItems;
        }
        
        private ICollection<Question> replaceWithRandomQuestions(int maxQuestions)
        {
            ICollection<Question> valueItems = new HashSet<Question>();
            Random random = new Random();
            while (valueItems.Count < maxQuestions)
            {
                int index = random.Next(0, questions.QuestionList.Count - 1);
                if (!valueItems.Contains(questions.QuestionList[index]))
                {
                    valueItems.Add(questions.QuestionList[index]);
                }
            }
            return valueItems;
        }
    }
}