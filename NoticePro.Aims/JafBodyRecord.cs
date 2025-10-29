namespace NoticePro.Aims;
public record JafBodyRecord
{
    public JafBodyRecord(string jobId, string mailPieceId)
    {
        if (string.IsNullOrWhiteSpace(jobId)) 
            throw new ArgumentNullException(nameof(jobId));

        if (string.IsNullOrWhiteSpace(mailPieceId)) 
            throw new ArgumentNullException(nameof(mailPieceId));

        JobId = jobId;
        MailPieceId = mailPieceId;
    }
    public string JobId { get; set; } = string.Empty;
    public string MailPieceId { get; set; } = string.Empty;
    public string CustomerId { get; set; } = string.Empty;
    public int TotalPrimeDocuments { get; set; }
    public bool Feeder1Count { get; set; }
    public bool Feeder2Count { get; set; }
    public bool Feeder3Count { get; set; }
    public bool Feeder4Count { get; set; }
    public bool Feeder5Count { get; set; }
    public bool Feeder6Count { get; set; }
    public bool Feeder7Count { get; set; }
    public bool Feeder8Count { get; set; }
    public bool Feeder9Count { get; set; }
    public bool Feeder10Count { get; set; }
    public bool Feeder11Count { get; set; }
    public bool Feeder12Count { get; set; }
    public bool Feeder13Count { get; set; }
    public bool Feeder14Count { get; set; }
    public bool Feeder15Count { get; set; }
    public bool Feeder16Count { get; set; }
    public bool EnvelopeDivert1 { get; set; }
    public bool EnvelopeDivert2 { get; set; }
    public bool EnvelopeDivert3 { get; set; }
    public bool FormDivert1 { get; set; }
    public bool FormDivert2 { get; set; }
    public bool Franker1 { get; set; }
    public bool Franker2 { get; set; }
    public bool Halt { get; set; }
    public bool InkMark1Jog { get; set; }
    public bool InkMark2PulseConveyor { get; set; }
    public bool NoSeal { get; set; }
    public bool AutoEnd { get; set; }
    public string RecipientFullName { get; set; } = string.Empty;
    public string RecipientOrganization { get; set; } = string.Empty;
    public string RecipientAddressLine1 { get; set; } = string.Empty;
    public string RecipientAddressLine2 { get;set; } = string.Empty;
    public string RecipientAddressLine3 { get;set; } = string.Empty;
    public string RecipientAddressLine4 { get;set; } = string.Empty;
    public string RecipientPostalCode { get; set; } = string.Empty;
    public string RecipientUserField1 { get; set; } = string.Empty;
    public string RecipientUserField2 { get; set; } = string.Empty;
    public string RecipientUserField3 { get; set; } = string.Empty;
    public bool FullFormatPackDivert { get; set; }
    public string ReturnAddressTitle { get; set; } = string.Empty;
    public string ReturnAddressFirstName { get; set; } = string.Empty;
    public string ReturnAddressSurname { get; set; } = string.Empty;
    public string ReturnAddressLine1 { get; set; } = string.Empty;
    public string ReturnAddressLine2 { get; set; } = string.Empty;
    public string ReturnAddressLine3 { get; set; } = string.Empty;
    public string ReturnAddressLine4 { get; set; } = string.Empty;
    public string ReturnAddressLine5 { get; set; } = string.Empty;
    public string ReturnAddressUserField1 { get; set; } = string.Empty;
    public string ReturnAddressUserField2 { get; set; } = string.Empty;
    public string ReturnAddressUserField3 { get; set; } = string.Empty;
    public string ReturnAddressUserField4 { get; set; } = string.Empty;
    public string ReturnAddressUserField5 { get; set; } = string.Empty;
    public string ReturnAddressImageReference1 { get; set; } = string.Empty;
    public string ReturnAddressImageReference2 { get; set; } = string.Empty;
    public string ReturnAddressImageReference3 { get; set; } = string.Empty;
    public string ReturnAddressImageReference4 { get; set; } = string.Empty;
    public string ReturnAddressImageReference5 { get; set; } = string.Empty;
}
