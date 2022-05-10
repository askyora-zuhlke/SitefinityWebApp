namespace SitefinityWeb.Entities
{

    public class QuestionEntity
    { 
        public string Value { get; set; }
        public string Category { get; set; }
        public ResponseType ResponseType { get; set; }

        public string[] Options { get; set; }
    }

    public enum ResponseType {    Text, RadioButtons, CheckBox, DropDown, TextArea   }
}