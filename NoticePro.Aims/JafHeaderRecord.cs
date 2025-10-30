namespace NoticePro.Aims;
public record class JafHeaderRecord
{
    public static readonly int[] FieldWidths = [1, 10, 19, 19, 32, 20];

    public JafHeaderRecord(string jobId)
    {
        if (string.IsNullOrWhiteSpace(jobId))
            throw new ArgumentNullException(nameof(jobId));

        JobId = jobId;
    }

    public string JobId { get; set; }
    public DateTime? Sla { get; set; }
    public DateTime? Created { get; set; }
    public string JobName { get; set; } = string.Empty;
    public string ImosJobName { get; set; } = string.Empty;
}
