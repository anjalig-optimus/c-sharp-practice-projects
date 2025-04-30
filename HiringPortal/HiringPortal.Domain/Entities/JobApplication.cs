namespace HiringPortal.Domain.Entities
{
    public class JobApplication
    {
        public int Id { get; set; }
        public string Remarks { get; set; }

        // Foreign Keys
        public int CreatedBy { get; set; }
        public int JobId { get; set; }
        public int CandidateId { get; set; }
        public int ReferredBy { get; set; }
        public int StatusId { get; set; }

        // Navigation Properties
        public Employee CreatedByEmployee { get; set; }
        public Job Job { get; set; }
        public Candidate Candidate { get; set; }
        public ApplicationStatus Status { get; set; }
    }

}
