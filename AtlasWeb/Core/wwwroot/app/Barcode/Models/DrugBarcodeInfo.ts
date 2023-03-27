export class DrugBarcodeInfo {
    public PrintDate: string = "";
    public ProcedureCode: string = "";
    public ProcedureName: string = "";
    public PatientFullName: string = "";
    public BirthDate: string = "";
    public AcceptionNumber: string = "";
    public AcceptionDoctor: string = "";
    public OrderDate: string = "";
    public IslemNo: string = "";
    public Drugs: Array<DrugsInfo> = new Array<DrugsInfo>();
   
}
export class DrugsInfo {
    public DrugName: string = "";
    public Mi: string = "";
    public EK: string = "";
    public Doz: string = "";
    public ExpireDate: string = "";
}
export class DrugStickerInfo {
    public HospitalName: string = "";
    public BarcodeCode: string = "";
    public DrugName: string = "";
    public ExpireDate: string = "";
}

export class HimsDrugInfo {
    public PrintDate: string = "";
    public ProcedureCode: string = "";
    public BarcodeCode: string = "";
    public ProcedureName: string = "";
    public PatientFullName: string = "";
    public Drugs: Array<HimsDrugsInfo> = new Array<HimsDrugsInfo>();
}

export class DrugUsedInfo {
    public PatientName: string = "";
    public BirthDate: string = "";
    public ClinicName: string = "";
    public Drug: string = "";
    public Drug2: string = "";
    public DrugDate: string = "";
    public DrugHour: string = "";
    public Room: string = "";
    public Dose: string = "";
    public AcceptionNumber: string = "";
}

export class HimsDrugsInfo {
    public DrugName: string = "";
    public Doz: string = "";
    public PlannedTime: string = "";
    public EK: string = "";
    public Mi: string = "";
}

