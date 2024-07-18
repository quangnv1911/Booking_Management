namespace Group5_SE1730_BookingManagement.Models
{
    public class FAQ
    {
        public int Id { get; set; }
        public string Question { get; set; }
        public string Answer { get; set; }
        public FAQ()
        {
            
        }

        public FAQ(string question, string answer)
        {
            Question = question;
            Answer = answer;
        }
    }
}
