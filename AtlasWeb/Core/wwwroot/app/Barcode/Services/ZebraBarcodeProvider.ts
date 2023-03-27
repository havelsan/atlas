
import { IBarcodePrinterProvider } from './IBarcodePrinterProvider';
import { PatientBarcodeInfo, PatologyBarcodeInfo, PatientArchieveBarcodeInfo } from '../Models/PatientBarcodeInfo';
import { InpatientTreatmentBarcodeInfo, SerumBarcodeInfo } from '../Models/InpatientTreatmentBarcodeInfo';
import { RadiologyBarcodeInfo } from '../Models/RadiologyBarcodeInfo';
import { DrugBarcodeInfo, DrugStickerInfo, HimsDrugInfo, DrugUsedInfo } from '../Models/DrugBarcodeInfo';
import { ArchiveBarcodeInfo } from '../Models/ArchiveBarcodeInfo';
import { LaboratoryBarcodeInfo } from '../Models/LaboratoryBarcodeInfo';
import { InpatientWristBarcodeInfo, BabyMotherMatchBarcodeInfo } from "../Models/InpatientWristBarcodeInfo";
import { DietBarcodeInfo } from '../Models/DietBarcodeInfo';

export class ZebraBarcodeProvider implements IBarcodePrinterProvider {

    generateArchiveBarcode(info: ArchiveBarcodeInfo): string {
        let ezplContent: string = `I8,E,001


Q239,024
q831
rN
S4
D7
ZT
JF
OD
R255,0
f100
N
A308,52,2,4,1,1,R,"${info.PolicilinicName}"
A305,228,2,4,1,1,R,"${info.PatientName}"
A307,106,2,1,1,1,N,"Sıra:"
A252,107,2,1,1,1,N,"${info.Row}"
A259,132,2,1,1,1,N,"${info.Shelf}"
A307,132,2,1,1,1,N,"Raf:"
A270,177,2,1,1,1,N,"${info.PatientIdentifier}"
A306,177,2,1,1,1,N,"Tc:"
A307,152,2,1,1,1,N,"Prot No:"
A219,153,2,1,1,1,N,"${info.ProtocolNumber}"
P1
`;
        return ezplContent;
    }
    generatePatientBarcode(info: PatientBarcodeInfo): string {
        let ezplContent: string = `I8,E,001


Q240,024
q831
rN
S4
D7
ZT
JF
OD
R136,0
f100
N
A553,233,2,1,2,2,N,"${info.PoliclinicName}"
A126,208,2,1,3,3,R,"${info.SiraNo}"
A211,200,2,3,1,1,R,"${info.StartDate}"
A117,166,2,2,1,1,N,"${info.TAKIPNO}"
A244,167,2,2,1,1,N,"${info.Gender}"
A99,137,2,2,1,1,N,"${info.DNo}"
A216,136,2,2,1,1,N,"DosyaNo :"
A553,40,2,3,1,1,N,"${info.HospitalName}"
A551,114,2,3,1,1,N,"${info.KabulTarihi}"
A553,80,2,3,1,1,N,"${info.IslemNo}-${info.RandevuSaati}"
A552,143,2,3,1,1,N,"${info.BirthPlace} / ${info.BirthDate} "
A551,169,2,3,1,1,N,"${info.PatientIdentifier}"
A552,199,2,3,1,1,N,"${info.PatientName}"
B261,105,2,1,2,6,82,B,"${info.IslemNo}"
P1
`;
        return ezplContent;
    }



    generateRadiologyBarcode(info: RadiologyBarcodeInfo): string {
        let ezplContent: string = `I8,E,001


Q240,024
q831
rN
S4
D7
ZT
JF
OD
R136,0
f100
N
A548,117,2,3,1,1,N,"${info.PrintDate}"
A549,173,2,3,1,1,N,"${info.BirthDate}"
A549,61,2,3,1,1,N,"${info.AccessionNumber}"
A549,92,2,3,1,1,N,"${info.ProcedureCode}"
A549,144,2,3,1,1,N,"${info.ProcedureName}"
A549,199,2,3,1,1,N,"${info.PatientIdentifier}"
A548,225,2,3,1,1,N,"${info.PatientFullName}"
P1
`;
        return ezplContent;
    }

    generateRadiologyBarcodeNew(info: RadiologyBarcodeInfo): string {
        let ezplContent: string = `I8,E,001


Q240,024
q831
rN
S3
D7
ZT
JF
O
R136,0
f100
N
A15,26,0,1,1,2,N,"${info.PatientFullName}"
A19,86,0,1,1,2,N,"${info.PatientAge}"
A151,86,0,1,1,2,N,"${info.PatientGender}"
A17,118,0,1,1,2,N,"${info.RequestDoctor}"
A19,149,0,1,1,2,N,"${info.ProcedureName}"
A19,194,0,1,1,2,N,"Tarih :${info.RequestDate}"
A269,194,0,1,1,2,N,"${info.AccessionNumber}"
A307,26,0,1,1,2,N,"Kabul No :${info.ProtocolNo}"
A17,55,0,1,1,2,N,"T.C:${info.UniqueRefNo}"
P1
`;





        //        let ezplContent: string = `I8,E,001


        //Q406,024
        //q831
        //rN
        //S3
        //D7
        //ZT
        //JF
        //O
        //R111,0
        //f100
        //N
        //A32,26,0,1,1,2,N,"${info.PatientFullName}"
        //A45,90,0,1,1,2,N,"${info.PatientAge}"
        //A184,90,0,1,1,2,N,"${info.PatientGender}"
        //A32,121,0,1,1,2,N,"${info.RequestDoctor}"
        //A32,153,0,1,1,2,N,"${info.ProcedureName}"
        //A32,194,0,1,1,2,N,"Tarih :${info.RequestDate}"
        //A269,194,0,1,1,2,N,"${info.AccessionNumber}"
        //A307,26,0,1,1,2,N,"Kabul No :${info.ProtocolNo}"
        //A32,57,0,1,1,2,N,"T.C:${info.UniqueRefNo}"
        //P1
        //`;
        return ezplContent;
    }



    generateRadiologyAppointmentBarcode(info: RadiologyBarcodeInfo): string {
        let ezplContent: string = `I8,E,001


Q240,024
q831
rN
S3
D7
ZT
JF
O
R136,0
f100
N
GW3,37,70,3,]_WWÕÕõu}]_WWÕÕõu}]_WWÕÕõu}]_WWÕÕõu}]_WWÕÕõu}]_WWÕÕõu}]_WWÕÕõu}]_WWÕÕÿÀàp8Ààp8Ààp8Ààp8Ààp8Ààp8Ààp8ÀÿÀàp8Ààp8Ààp8Ààp8Ààp8Ààp8Ààp8Àÿ
GW0,68,70,3,]_WWÕÕõu}]_WWÕÕõu}]_WWÕÕõu}]_WWÕÕõu}]_WWÕÕõu}]_WWÕÕõu}]_WWÕÕõu}]_WWÕÕÿÀàp8Ààp8Ààp8Ààp8Ààp8Ààp8Ààp8ÀÿÀàp8Ààp8Ààp8Ààp8Ààp8Ààp8Ààp8Àÿ
GW3,101,70,3,]_WWÕÕõu}]_WWÕÕõu}]_WWÕÕõu}]_WWÕÕõu}]_WWÕÕõu}]_WWÕÕõu}]_WWÕÕõu}]_WWÕÕÿÀàp8Ààp8Ààp8Ààp8Ààp8Ààp8Ààp8ÀÿÀàp8Ààp8Ààp8Ààp8Ààp8Ààp8Ààp8Àÿ
GW3,139,70,3,]_WWÕÕõu}]_WWÕÕõu}]_WWÕÕõu}]_WWÕÕõu}]_WWÕÕõu}]_WWÕÕõu}]_WWÕÕõu}]_WWÕÕÿÀàp8Ààp8Ààp8Ààp8Ààp8Ààp8Ààp8ÀÿÀàp8Ààp8Ààp8Ààp8Ààp8Ààp8Ààp8Àÿ
GW3,182,70,3,]_WWÕÕõu}]_WWÕÕõu}]_WWÕÕõu}]_WWÕÕõu}]_WWÕÕõu}]_WWÕÕõu}]_WWÕÕõu}]_WWÕÕÿÀàp8Ààp8Ààp8Ààp8Ààp8Ààp8Ààp8ÀÿÀàp8Ààp8Ààp8Ààp8Ààp8Ààp8Ààp8Àÿ
A60,16,0,2,1,1,N,"Kabul No:${info.ProtocolNo}"
A24,46,0,2,1,1,N,"Adi Soyadi :${info.PatientFullName}"
A72,77,0,2,1,1,N,"Servis :${info.FromResource}"
A36,118,0,2,1,1,N,"İstem Adi :${info.ProcedureName}"
A72,155,0,2,1,1,N,"Doktor :${info.RequestDoctor}"
A12,188,0,2,1,1,N,"Ran.Tah.Saat:${info.AppointmentDate}"
P1
`;


        return ezplContent;
    }

    generateLaboratoryBarcode(info: LaboratoryBarcodeInfo): string {
        let ezplContent: string = `I8,E,001


Q230,024
q831
rN
S4
D7
ZT
JF
OD
R255,0
f100
N
A248,75,2,1,1,1,N,"${info.PrintDate}"
A289,38,2,2,1,1,N,"${info.TubeName}"
A289,196,2,1,1,1,N,"${info.FromResourceQRef}"
A126,197,2,1,1,1,N,"${info.PatientTCNo}"
A289,219,2,2,1,1,R,"${info.PatientFullName}"
B277,179,2,1,2,6,75,B,"${info.BarcodeCode}"
P1
`;
        return ezplContent;
    }

    generateDrugSticker(info: DrugStickerInfo): string {
        let ezplContent: string = `
        I8,E,001


Q240,024
q831
rN
S4
D7
ZT
JF
OD
R136,0
f100
N
A495,236,2,3,1,1,R,"${info.HospitalName}"
A193,158,2,3,1,1,R,"${info.BarcodeCode}"
A542,159,2,3,1,1,N,"Kabul No"
A541,184,2,3,1,1,N,"${info.ExpireDate}"
A541,211,2,3,1,1,N,"${info.DrugName}"
P1
        
        
        `;
        return ezplContent;
    }

    generateHimsDrugBarcode(info: HimsDrugInfo): string {
        let ezplContent: string = `I8,E,001


Q480,024
q831
rN
S4
D7
ZT
JF
OD
R96,0
f100
N
A507,421,2,2,1,1,N,"${info.ProcedureCode}"
A633,421,2,2,1,1,N,"Prot . No:"
A633,439,2,2,1,1,N,"${info.ProcedureName}"
A633,458,2,2,1,1,N,"${info.PrintDate}"
A223,390,2,2,1,1,N,"Uygulama Saati"
A341,388,2,2,1,1,N,"Doz"
A223,104,2,1,1,1,N,"${info.Drugs[6].PlannedTime}"
A223,144,2,1,1,1,N,"${info.Drugs[5].PlannedTime}"
A223,188,2,1,1,1,N,"${info.Drugs[4].PlannedTime}"
A223,226,2,1,1,1,N,"${info.Drugs[3].PlannedTime}"
A223,271,2,1,1,1,N,"${info.Drugs[2].PlannedTime}"
A339,103,2,1,1,1,N,"${info.Drugs[6].Doz}"
A339,143,2,1,1,1,N,"${info.Drugs[5].Doz}"
A637,110,2,1,1,1,N,"${info.Drugs[6].DrugName}"
A338,188,2,1,1,1,N,"${info.Drugs[4].Doz}"
A637,152,2,1,1,1,N,"${info.Drugs[5].DrugName}"
A339,226,2,1,1,1,N,"${info.Drugs[3].Doz}"
A637,195,2,1,1,1,N,"${info.Drugs[4].DrugName}"
A340,270,2,1,1,1,N,"${info.Drugs[2].Doz}"
A637,234,2,1,1,1,N,"${info.Drugs[3].DrugName}"
A223,310,2,1,1,1,N,"${info.Drugs[1].PlannedTime}"
A637,277,2,1,1,1,N,"${info.Drugs[2].DrugName}"
A340,310,2,1,1,1,N,"${info.Drugs[1].Doz}"
A637,318,2,1,1,1,N,"${info.Drugs[1].DrugName}"
A223,350,2,1,1,1,N,"${info.Drugs[0].PlannedTime}"
A341,350,2,1,1,1,N,"${info.Drugs[0].Doz}"
A637,95,2,1,1,1,N,"${info.Drugs[6].EK}"
A637,136,2,1,1,1,N,"${info.Drugs[5].EK}"
A637,181,2,1,1,1,N,"${info.Drugs[4].EK}"
A637,220,2,1,1,1,N,"${info.Drugs[3].EK}"
A637,262,2,1,1,1,N,"${info.Drugs[2].EK}"
A637,304,2,1,1,1,N,"${info.Drugs[1].EK}"
A637,357,2,1,1,1,N,"${info.Drugs[0].DrugName}"
A637,344,2,1,1,1,N,"${info.Drugs[0].EK}"
A635,389,2,2,1,1,N,"İlaç Adı"
A633,476,2,2,1,1,R,"${info.PatientFullName}"
LO33,394,603,8
LO32,360,606,8
LO34,320,604,8
LO32,281,606,8
LO32,236,607,8
LO31,198,605,8
LO32,155,607,8
LO32,113,607,8
B266,470,2,1,2,6,40,B,"${info.BarcodeCode}"
P1
`;
        return ezplContent;
    }

    generateDrugUsedBarcode(info: DrugUsedInfo): string {
        let ezplContent: string = `I8,E,001


Q224,024
q831
rN
S4
D7
ZT
JF
OD
R255,0
f100
N
A314,78,2,3,1,1,N,"${info.Dose}"
A314,100,2,2,1,1,N,"${info.Drug2}"
A313,118,2,2,1,1,N,"${info.Drug}"
A132,51,2,3,1,1,N,"${info.DrugHour}"
A315,52,2,3,1,1,N,"${info.DrugDate}"
A118,141,2,3,1,1,N,"${info.Room}"
A312,166,2,3,1,1,N,"${info.AcceptionNumber}"
A312,141,2,3,1,1,N,"${info.BirthDate}"
A315,190,2,3,1,1,R,"${info.PatientName}"
A312,212,2,1,1,1,N,"${info.ClinicName}"
P1
`;
        return ezplContent;
    }

    generateSerumBarcode(info: SerumBarcodeInfo): string {
        let ezplContent: string = `I8,E,001


Q230,024
q831
rN
S4
D7
ZT
JF
OD
R255,0
f100
N
A315,113,2,2,1,1,N,"Hızı:"
A314,158,2,2,1,1,N,"Saati:"
A314,31,2,1,1,1,N,"${info.NurseName}"
A314,47,2,1,1,1,N,"Uygulayan:"
A315,202,2,2,1,1,N,"İlaç Adı:"
A315,225,2,2,1,1,R,"${info.PatientName}"
P1
`;
        return ezplContent;
    }


    generatePeeLaboratoryBarcode(info: LaboratoryBarcodeInfo): string {
        let ezplContent: string = `I8,E,001


Q230,024
q831
rN
S4
D7
ZT
JF
OD
R255,0
f100
N
A248,75,2,1,1,1,N,"${info.PrintDate}"
A289,38,2,2,1,1,N,"${info.TubeName}"
A289,196,2,1,1,1,N,"${info.FromResourceQRef}"
A126,197,2,1,1,1,N,"${info.PatientTCNo}"
A289,219,2,2,1,1,R,"${info.PatientFullName}"
B277,179,2,1,2,6,75,B,"${info.BarcodeCode}"
P1
`;
        return ezplContent;
    }


    generateInPatientBarcode(info: LaboratoryBarcodeInfo): string {
        let ezplContent: string = `I8,E,001


Q239,024
q831
rN
S4
D7
ZT
JF
OD
R255,0
f100
N
A245,185,2,1,1,1,N,"${info.FromResourceQRef}"
A306,46,2,1,2,2,N,"${info.TubeName}"
A144,64,2,1,1,1,N,"DoğT"
A309,185,2,1,1,1,N,"Iş No:"
A100,64,2,1,1,1,N,"${info.BirthDate}"
A301,214,2,4,1,1,R,"${info.PatientFullName}"
A162,185,2,1,1,1,N,"${info.PrintDate}"
B288,168,2,1,2,6,76,B,"${info.BarcodeCode}"
P1
`;
        return ezplContent;
    }

    generateDrugBarcode(info: DrugBarcodeInfo): string {
        let ezplContent: string = `I8,E,001


Q799,024
q831
rN
S3
D12
ZT
JF
OD
R16,0
f100
N
A573,640,2,1,2,2,R,"Ilaç Bilgileri"
A584,772,2,1,2,2,R,"Hasta Bilgileri"
A785,221,2,2,1,1,N,"${info.Drugs[6].DrugName}"
A785,286,2,2,1,1,N,"${info.Drugs[5].DrugName}"
A256,196,2,2,1,1,N,"${info.Drugs[6].ExpireDate}"
A785,347,2,2,1,1,N,"${info.Drugs[4].DrugName}"
A353,196,2,2,1,1,N,"${info.Drugs[6].Doz}"
A256,261,2,2,1,1,N,"${info.Drugs[5].ExpireDate}"
A107,195,2,2,1,1,N,"${info.Drugs[6].Mi}"
A785,409,2,2,1,1,N,"${info.Drugs[3].DrugName}"
A353,261,2,2,1,1,N,"${info.Drugs[5].Doz}"
A256,322,2,2,1,1,N,"${info.Drugs[4].ExpireDate}"
A107,260,2,2,1,1,N,"${info.Drugs[5].Mi}"
A785,470,2,2,1,1,N,"${info.Drugs[2].DrugName}"
A353,322,2,2,1,1,N,"${info.Drugs[4].Doz}"
A256,384,2,2,1,1,N,"${info.Drugs[3].ExpireDate}"
A107,321,2,2,1,1,N,"${info.Drugs[4].Mi}"
A785,525,2,2,1,1,N,"${info.Drugs[1].DrugName}"
A353,384,2,2,1,1,N,"${info.Drugs[3].Doz}"
A256,445,2,2,1,1,N,"${info.Drugs[2].ExpireDate}"
LO3,173,787,1
A107,383,2,2,1,1,N,"${info.Drugs[3].Mi}"
A785,580,2,2,1,1,N,"${info.Drugs[0].DrugName}"
A353,445,2,2,1,1,N,"${info.Drugs[2].Doz}"
A256,500,2,2,1,1,N,"${info.Drugs[1].ExpireDate}"
LO5,238,787,1
A107,444,2,2,1,1,N,"${info.Drugs[2].Mi}"
A256,555,2,2,1,1,N,"${info.Drugs[0].ExpireDate}"
A353,500,2,2,1,1,N,"${info.Drugs[1].Doz}"
A353,555,2,2,1,1,N,"${info.Drugs[0].Doz}"
LO6,299,787,2
A107,499,2,2,1,1,N,"${info.Drugs[1].Mi}"
A107,555,2,2,1,1,N,"${info.Drugs[0].Mi}"
A787,743,2,2,1,1,N,"${info.PatientFullName}"
A787,719,2,2,1,1,N,"${info.BirthDate}"
LO6,361,787,1
A787,694,2,2,1,1,N,"${info.AcceptionNumber}"
A787,670,2,2,1,1,N,"${info.AcceptionDoctor}"
A186,734,2,2,1,1,N,"${info.IslemNo}"
A186,710,2,2,1,1,N,"${info.OrderDate}"
LO7,422,787,1
A324,609,2,2,1,1,N,"Doz"
A786,609,2,2,1,1,N,"Ilaç Adi"
A240,609,2,2,1,1,N,"Miadi"
A104,609,2,2,1,1,N,"Miktar"
LO4,477,787,1
LO3,533,787,1
LO6,588,787,2
A186,686,2,2,1,1,N,"${info.ProcedureName}"
P1
`;
        return ezplContent;
    }

    generateInPatientWristBarcode(info: InpatientWristBarcodeInfo): string {
        let ezplContent: string = `I8,E,001


Q240,024
q831
rN
S4
D7
ZT
JF
OD
R136,0
f100
N
A495,236,2,3,1,1,R,"${info.HospitalName}"
A193,158,2,3,1,1,R,"${info.AcceptionNumber}"
A542,159,2,3,1,1,N,"Kabul No"
A541,184,2,3,1,1,N,"${info.BirthDate}"
A541,211,2,3,1,1,N,"${info.PatientName}"
P1
`;
        return ezplContent;
    }

    generateInPatientWristBarcode2(info: InpatientWristBarcodeInfo): string {
        let ezplContent: string = `CT~~CD,~CC^~CT~\r
^XA~TA000~JSN^LT0^MNM^MTD^PON^PMN^LH0,0^JMA^PR2,2~SD21^JUS^LRN^CI35^XZ\r
^XA\r
^MMT\r
^PW300\r
^LL3300\r
^LS0\r
^FT123,1553^A0R,42,40^FH\\^FD${info.BirthDate}^FS\r
^FT191,1598^A0R,42,40^FH\\^FD${info.AcceptionNumber}^FS\r
^FT191,1426^A0R,42,40^FH\\^FDKabul No:^FS\r
^FT122,1426^A0R,42,40^FH\\^FDDoğ T:^FS\r
^FT194,800^A0R,42,40^FH\\^FD${info.PatientName}^FS\r
^FT248,800^A0R,42,40^FH\\^FD${info.HospitalName}^FS\r
^BY3,3,135^FT21,882^B3R,N,,N,N\r
^FD>;${info.BarcodeCode}^FS\r
^PQ1,0,1,Y^XZ\r
`;
        return ezplContent;
    }


    generateInpatientTreatmentBarcode(info: InpatientTreatmentBarcodeInfo): string {
        let ezplContent: string = `I8,E,001


Q240,024
q831
rN
S4
D7
ZT
JF
OD
R136,0
f100
N
A549,233,2,4,1,1,N,"${info.HospitalName}"
A549,166,2,3,1,1,N,"${info.Clinicname}"
A147,93,2,3,1,1,R,"${info.KabulNo}"
A130,232,2,2,1,1,R,"${info.BirthDate}"
A232,93,2,3,1,1,N,"Kabul:"
A231,55,2,3,1,1,N,"Arsiv:"
A147,55,2,3,1,1,R,"${info.ArchiveNumber}"
A108,140,2,3,1,1,N,"${info.TakipNo}"
A80,199,2,3,1,1,N,"${info.Sex}"
A150,168,2,3,1,1,N,"${info.InPatientDate}"
A549,197,2,3,1,1,N,"${info.PatientName}"
A549,137,2,3,1,1,N,"T.C.No: ${info.PatientIdentifier}"
B548,99,2,1,2,6,65,N,"${info.KabulNo}"
P1
`;
        return ezplContent;
    }

    generateInpatientTreatmentBarcode2(info: InpatientTreatmentBarcodeInfo): string {
        let ezplContent: string = `I8,E,001


Q230,024
q831
rN
S4
D7
ZT
JF
OD
R255,0
f100
N
A312,186,2,2,1,1,N,"${info.BirthDate}"
A312,214,2,2,1,1,N,"${info.PatientName}"
A312,130,2,2,1,1,N,"${info.KabulNo}"
A312,157,2,2,1,1,N,"${info.Clinicname}"
P1
`;
        return ezplContent;
    }

    generatePatologyBarcode(info: PatologyBarcodeInfo): string {
        let ezplContent: string = `I8,E,001


Q406,024
q831
rN
S4
D7
ZT
JF
OD
R111,0
f100
N
A588,397,2,3,2,2,R,"${info.PatientName}"
A525,351,2,1,1,1,R,"${info.PatientIdentifier}"
A458,333,2,1,1,1,R,"${info.Protocol}"
A584,351,2,1,1,1,R,"TC :"
A584,332,2,1,1,1,R,"Protokol No:"
A426,55,2,1,1,1,R,"${info.Organ}"
A589,54,2,1,1,1,R,"Alındığı Organ."
A513,314,2,1,1,1,R,"${info.PoliclinicName}"
A424,92,2,1,1,1,R,"${info.MaterialAcceptionDate}"
A588,91,2,1,1,1,R,"M.Kabul Tarihi:"
A413,291,2,1,1,1,R,"${info.SampleAcceptionDate}"
A584,314,2,1,1,1,R,"Bölüm:"
A584,290,2,1,1,1,R,"N.Alınma Tarihi:"
B509,255,2,1,6,18,76,B,"${info.Barcode}"
P1
`;
        return ezplContent;
    }

    generateBabyMotherBarcode(info: BabyMotherMatchBarcodeInfo): string {
        let ezplContent: string = `
        I8,A,001
Q354,035
q1228
rN
S4
D10
ZT
JF
O
R200,0
f100
N
A733,348,2,3,1,1,R,"${info.HospitalName}"
A287,233,2,3,1,1,R,"${info.AdmissionNo}"
A802,234,2,3,1,1,N,"${info.MotherName}"
A801,272,2,3,1,1,N,"${info.FatherName}"
A801,311,2,3,1,1,N,"${info.BabyName}"
P1
`;
        return ezplContent;
    }

    generateDietCaloriBarcode(info: DietBarcodeInfo): string {
        let ezplContent: string = `
        I8,A,001


Q240,024
q831
rN
S4
D7
ZT
JF
OD
R136,0
f100
N
A136,7,0,2,1,1,R,"   PURSAKLAR DEVLET XXXXXX  "
A397,84,0,2,1,1,R,"${info.ProtocolNumber}"
A18,89,0,1,2,2,N,"${info.Room}"
A18,56,0,4,1,1,N,"${info.ServiceName}"
A18,29,0,4,1,1,N,"${info.PatientName}"
A18,123,0,4,1,1,N,"${info.PatientName}"
A397,43,0,2,1,1,R,"${info.PatientIdentifier}"
B18,161,0,1,2,6,48,B,"${info.ProtocolNumber}"
P1`;
        return ezplContent;
    }

    generatePatientArchieveBarcode(info: PatientArchieveBarcodeInfo): string {
        let ezplContent: string = `I8,E,001


Q406,024
q831
rN
S4
D7
ZT
JF
OD
R111,0
f100
N
A121,90,0,4,1,1,N,"${info.PatientName}"
A351,135,0,4,1,1,N,"${info.BarcodeDate}"
A118,135,0,4,1,1,N,"Barkod Tarihi:"
B121,203,0,1,3,9,87,B,"${info.PatientTC}"
P1
`;
        return ezplContent;
    }
    
    generateGazilerPatientBarcode(info: PatientBarcodeInfo): string {


        let ezplContent: string = `I8,E,001


Q224,024
q831
rN
S4
D10
ZT
JF
OD
R255,0
f100
N
A311,210,2,2,1,1,N,"${info.PatientName}"
A62,163,2,2,1,1,N,"${info.Gender}"
A312,137,2,2,1,1,N,"${info.BirthDate}"
A261,163,2,2,1,1,N,"${info.KabulTarihi}"
A311,187,2,2,1,1,N,"${info.PatientIdentifier}"
A136,184,2,2,1,1,N,"GSS"
A90,185,2,2,1,1,N,"${info.TAKIPNO}"
A312,162,2,2,1,1,N,"BS.T"
A184,137,2,2,1,1,N,"ISL NO"
A97,137,2,2,1,1,N,"${info.IslemNo}"
A312,113,2,2,1,1,N,"${info.Kurum}"
A311,90,2,2,1,1,N,"${info.PoliclinicName}"
A311,68,2,2,1,1,N,"TAH.BEK.SÜRESI"
A136,69,2,2,1,1,N,"${info.RandevuSaati}"
A311,42,2,2,1,1,N,"${info.DoctorName}"
P1

`;
        return ezplContent;
    }

}