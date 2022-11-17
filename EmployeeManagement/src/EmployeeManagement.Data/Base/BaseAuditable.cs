namespace EmployeeManagement.Data.Base
{
    public class BaseAuditable : BaseAuditable<string>
    {
    }
    public class BaseAuditable<TKey> : BaseEntity<TKey>
    {
        public DateTime CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }
        public string CreatedBy { get; set; } = null!;
        public string? UpdatedBy { get; set; }
    }
}
