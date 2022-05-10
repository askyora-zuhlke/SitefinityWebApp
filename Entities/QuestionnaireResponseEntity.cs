namespace SitefinityWeb.Entities
{

    public class QuestionnaireResponseEntity
    {
         public QuestionDetailsEntity QuestionnaireDetails { get; set; }
         public ICollection<QuestionResponseEntity> Responses { get; set; }
         public string Name { get; set; }
         public string Email { get; set; }
    }
}