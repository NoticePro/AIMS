using WillSoss.FixedWidth;

namespace NoticePro.Aims;
public class JafWriter : IDisposable, IAsyncDisposable
{
    private readonly FixedWidthWriter _writer;
    private bool _headerWritten = false;
    private bool _bodyWritten = false;

    private const string DateFormat = "YYYY-MM-DD hh:mm:ss";

    private static readonly int[] HeaderWidths = 
        [1, 10, 19, 19, 32, 20];

    private static readonly int[] BodyWidths =
        [1, 10, 10, 32,  3,  1,  1,  1,  1,  1,
         1,  1,  1,  1,  1,  1,  1,  1,  1,  1,
         1,  1,  1,  1,  1,  1,  1,  1,  1,  1,
         1,  1,  1, 50, 50, 50, 50, 50, 50, 50, 
        50, 50, 50,  1,414, 25, 25, 25, 50, 50, 
        50, 50, 50,200,200,200,200,200,200,200,
        200,200,200]; 

    public JafWriter(string filePath)
        : this(File.Open(filePath, FileMode.Create)) { }

    public JafWriter(Stream stream)
    {
        _writer = new FixedWidthWriter(stream, BodyWidths, new FixedWidthWriterOptions
        {
            Alignment = ValueAlignment.End
        });
    }

    private string PadLeft(object? value, int length, char padding = ' ') =>
        (value?.ToString() ?? string.Empty).PadLeft(length, padding);

    private string YesNo(bool? value) =>
        value.HasValue && value.Value ? "1" : "0";

    public async Task WriteHeaderRecord(JafHeaderRecord header)
    {
        if (_headerWritten)
            throw new InvalidOperationException("The header can only be written once, at the beginning of the file.");

        if (_bodyWritten)
            throw new InvalidOperationException("The header must be written before the body.");

        await _writer.WriteAsync(HeaderWidths,
            "H", 
            jobId, 
            sla?.ToString(DateFormat), 
            created?.ToString(DateFormat), 
            jobName, 
            imosJobName);

        _headerWritten = true;
    }

    public async Task WriteBodyRecord(JafBodyRecord body)
    {
        _bodyWritten = true;

        await _writer.WriteAsync(
            "B",
            body.JobId,
            body.MailPieceId,
            body.CustomerId,
            PadLeft(body.TotalPrimeDocuments, 3, '0'),
            YesNo(body.Feeder1Count),
            YesNo(body.Feeder2Count),
            YesNo(body.Feeder3Count),
            YesNo(body.Feeder4Count),
            YesNo(body.Feeder5Count),
            YesNo(body.Feeder6Count),
            YesNo(body.Feeder7Count),
            YesNo(body.Feeder8Count),
            YesNo(body.Feeder9Count),
            YesNo(body.Feeder10Count),
            YesNo(body.Feeder11Count),
            YesNo(body.Feeder12Count),
            YesNo(body.Feeder13Count),
            YesNo(body.Feeder14Count),
            YesNo(body.Feeder15Count),
            YesNo(body.Feeder16Count),
            YesNo(body.EnvelopeDivert1),
            YesNo(body.EnvelopeDivert2),
            YesNo(body.EnvelopeDivert3),
            YesNo(body.FormDivert1),
            YesNo(body.FormDivert2),
            YesNo(body.Franker1),
            YesNo(body.Franker2),
            YesNo(body.Halt),
            YesNo(body.InkMark1Jog),
            YesNo(body.InkMark2PulseConveyor),
            YesNo(body.NoSeal),
            YesNo(body.AutoEnd),
            body.RecipientFullName,
            body.RecipientOrganization,
            body.RecipientAddressLine1,
            body.RecipientAddressLine2,
            body.RecipientAddressLine3,
            body.RecipientAddressLine4,
            body.RecipientPostalCode,
            body.RecipientUserField1,
            body.RecipientUserField2,
            body.RecipientUserField3,
            YesNo(body.FullFormatPackDivert),
            null,
            body.ReturnAddressTitle,
            body.ReturnAddressFirstName,
            body.ReturnAddressSurname,
            body.ReturnAddressLine1,
            body.ReturnAddressLine2,
            body.ReturnAddressLine3,
            body.ReturnAddressLine4,
            body.ReturnAddressLine5,
            body.ReturnAddressUserField1,
            body.ReturnAddressUserField2,
            body.ReturnAddressUserField3,
            body.ReturnAddressUserField4,
            body.ReturnAddressUserField5,
            body.ReturnAddressImageReference1,
            body.ReturnAddressImageReference2,
            body.ReturnAddressImageReference3,
            body.ReturnAddressImageReference4,
            body.ReturnAddressImageReference5);
    }

    public Task FlushAsync() => _writer?.FlushAsync() ?? Task.CompletedTask;

    public void Flush() => _writer?.Flush();

    public ValueTask DisposeAsync() => _writer?.DisposeAsync() ?? ValueTask.CompletedTask;

    public void Dispose() => _writer?.Dispose();
}
