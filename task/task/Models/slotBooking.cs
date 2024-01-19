namespace task.models
{
    public class EventSlot
    {
        public int Id { get; set; }
        public DateTime StartTime { get; set; }
        public bool IsBooked { get; set; }
    }
}
