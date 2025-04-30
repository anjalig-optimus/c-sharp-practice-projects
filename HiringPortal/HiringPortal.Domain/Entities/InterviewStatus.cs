namespace HiringPortal.Domain.Entities
{
    public class InterviewStatus
    {
        public int Id { get; set; }
        public string Name { get; set; }

        // Relationships
        public ICollection<JobInterview> JobInterviews { get; set; } = new List<JobInterview>();
    }

}
