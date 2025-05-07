namespace TaskManagement.Models
{
    public class WeeklyManagerViewModel
    {
        public List<Mission> Missions { get; set; }
        public string[] Staff { get; set; }
        public Dictionary<string, string> TaskColors { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int StartHour { get; set; }
        public int EndHour { get; set; }
    }
}
