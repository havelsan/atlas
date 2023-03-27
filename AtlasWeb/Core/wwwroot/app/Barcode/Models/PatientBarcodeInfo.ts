export class PatientBarcodeInfo {
    public PatientIdentifier: string = "";
    public PatientName: string = "";
    public GSSNo: string = "";
    public Gender: string = "";
    public Age: string = "";
    public DNo: string = "";
    public StartDate: string = "";
    public StartDateWithDateandHour: string = "";
    public BirthDate: string = "";
    public BirthPlace: string = "";
    public IslemNo: string = "";
    public Kurum: string = "";
    public DoctorName: string = "";
    public PoliclinicName: string = "";
    public SiraNo: string = "";
    public SureAralik: string = "";
    public RandevuSaati: string = "";
    public HospitalName: string = "";
    public TAKIPNO: string = "";
    public KabulTarihi: string = "";
}
export class PatologyBarcodeInfo {
    public PatientIdentifier: string = "";//TC
    public PatientName: string = "";
    public Protocol: string = "";
    public DoctorName: string = "";//İstek yapan doktor
    public PoliclinicName: string = "";//istek yapan  birim
    public SampleAcceptionDate: string = "";
    public MaterialAcceptionDate: string = "";
    public Organ: string = "";
    public MaterialArchiveNo="";
    public Barcode: string = "";
}
export class PatientArchieveBarcodeInfo {
    public PatientTC: string = "";
    public PatientName: string = "";
    public BarcodeDate: string = "";
  
}