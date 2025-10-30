
namespace NoticePro.Aims.Tests;

public class JafWriterTests
{
    [Fact]
    public async Task TestsAsync()
    {
        var path = Path.GetTempFileName();

        using var writer = new JafWriter(path);
        var jobId = "job1";

        await writer.WriteHeader(new JafHeaderRecord(jobId)
        {
            Sla = DateTime.Now.Date.AddDays(1),
            Created = DateTime.Now,
            JobName = "My urgent job"
        });

        await writer.WriteBody(new JafBodyRecord(jobId, "MP0123")
        {
            Feeder1Count = true,
            ReturnAddressImageReference5 = new string('5', 200)
        });

        await writer.FlushAsync();
        await writer.DisposeAsync();
    }
}
