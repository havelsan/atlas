
import { IBarcodePrinterProvider } from './IBarcodePrinterProvider';
import { PatientBarcodeInfo, PatologyBarcodeInfo, PatientArchieveBarcodeInfo } from '../Models/PatientBarcodeInfo';
import { InpatientTreatmentBarcodeInfo, SerumBarcodeInfo } from '../Models/InpatientTreatmentBarcodeInfo';
import { InpatientWristBarcodeInfo, BabyMotherMatchBarcodeInfo } from '../Models/InpatientWristBarcodeInfo';
import { RadiologyBarcodeInfo } from '../Models/RadiologyBarcodeInfo';
import { DrugBarcodeInfo, DrugStickerInfo, HimsDrugInfo, DrugUsedInfo } from '../Models/DrugBarcodeInfo';
import { ArchiveBarcodeInfo } from '../Models/ArchiveBarcodeInfo';
import { LaboratoryBarcodeInfo } from '../Models/LaboratoryBarcodeInfo';
import { DietBarcodeInfo } from '../Models/DietBarcodeInfo';

export class GodexBarcodeProvider implements IBarcodePrinterProvider {

    generateArchiveBarcode(info: ArchiveBarcodeInfo): string {
        let ezplContent: string = `^Q29,2,0+
^W40
^H8
^P1
^S4
^AD
^C1
^R0
~Q+0
^O0
^D0
^E18
~R200
^XSET,CODEPAGE,18
^L
Dy2-me-dd
Th:m:s
AD,52,8,1,1,0,0E,${info.PatientName}
AB,22,48,1,1,0,0E,Tc:
AB,72,48,1,1,0,0E,${info.PatientIdentifier}
AB,18,116,1,1,0,0E,Raf:
AB,20,148,1,1,0,0E,Prot. No.
AB,20,84,1,1,0,0E,Sıra:
AD,38,180,1,1,0,0E,${info.PolicilinicName}
AB,80,84,1,1,0,0E,${info.Row}
AB,80,118,1,1,0,0E,${info.Shelf}
AB,118,148,1,1,0,0E,${info.ProtocolNumber}
E
`;

        return ezplContent;
    }

    generateSerumBarcode(info: SerumBarcodeInfo): string {
        let ezplContent: string = `
`;
        return ezplContent;
    }


    generatePatientBarcode(info: PatientBarcodeInfo): string {
        let ezplContent: string = `^Q28,3,0-
^W40
^H8
^P1
^S4
^AD
^C1
^R0
~Q+0
^O0
^D0
^E18
~R200
^XSET,CODEPAGE,18
^L
Dy2-me-dd
Th:m:s
Dy2-me-dd
Th:m:s
AB,4,6,1,1,0,0,${info.PatientName}
AB,4,38,1,1,0,0,Tc:
AA,52,42,1,1,0,0,${info.PatientIdentifier}
AB,156,38,1,1,0,0,GSS No:
AA,245,72,1,1,0,0,${info.Gender}
AB,14,66,1,1,0,0,Bas.T.
AA,80,72,1,1,0,0,${info.StartDateWithDateandHour}
AB,18,94,1,1,0,0,${info.BirthDate}
AA,158,96,1,1,0,0,Islem NO:
AA,4,122,1,1,0,0,${info.Kurum}
AB,4,188,1,1,0,0,${info.DoctorName}
AA,4,146,1,1,0,0,${info.PoliclinicName}
AA,246,42,1,1,0,0,${info.GSSNo}
AA,256,96,1,1,0,0,${info.IslemNo}
AA,4,166,1,1,0,0,Tah. Bek. Süresi
AA,144,166,1,1,0,0,${info.RandevuSaati}
AA,250,110,1,1,0,0,${info.SiraNo}
E
`;

        return ezplContent;
    }

    generateInpatientTreatmentBarcode(info: InpatientTreatmentBarcodeInfo): string {
        let ezplContent: string = `^Q28,3,0-
^W40
^H8
^P1
^S4
^AD
^C1
^R0
~Q+0
^O0
^D0
^E18
~R200
^XSET,CODEPAGE,18
^L
Dy2-me-dd
Th:m:s
Dy2-me-dd
Th:m:s
AA,56,42,1,1,0,0,${info.PatientName}
AB,24,64,1,1,0,0,${info.BirthDate}
AA,22,96,1,1,0,0,${info.Clinicname}
AA,170,98,1,1,0,0,${info.KabulNo}
E
`;
        return ezplContent;
    }

    generateInpatientTreatmentBarcode2(info: InpatientTreatmentBarcodeInfo): string {
        let ezplContent: string = `
`;
        return ezplContent;
    }

    generateDrugUsedBarcode(info: DrugUsedInfo): string {
        let ezplContent: string = `^Q28,3,0-
^W40
^H8
^P1
^S4
^AD
^C1
^R0
~Q+0
^O0
^D0
^E18
~R200
^XSET,CODEPAGE,18
^L
Dy2-me-dd
Th:m:s
Dy2-me-dd
Th:m:s
AB,12,34,1,1,0,0,${info.PatientName}
AA,12,90,1,1,0,0,${info.BirthDate}
AA,12,8,1,1,0,0,${info.ClinicName}
AA,12,118,1,1,0,0,${info.Drug}
AA,12,194,1,1,0,0,${info.DrugDate}
AB,12,56,1,1,0,0,${info.AcceptionNumber}
AA,187,92,1,1,0,0,${info.Room}
AA,12,166,1,1,0,0,${info.Dose}
AA,12,140,1,1,0,0,${info.Drug2}
AA,187,194,1,1,0,0,${info.DrugHour}
E
`;
        return ezplContent;
    }


    generateRadiologyBarcode(info: RadiologyBarcodeInfo): string {
        let ezplContent: string = `^Q28,3,0-
^W40
^H8
^P1
^S4
^AD
^C1
^R0
~Q+0
^O0
^D0
^E18
~R200
^XSET,CODEPAGE,18
^L
Dy2-me-dd
Th:m:s
Dy2-me-dd
Th:m:s
AB,16,0,1,1,0,0,${info.PatientFullName}
AA,18,26,1,1,0,0,Is No:
AA,68,24,1,1,0,0,${info.ProcedureCode}
AA,170,26,1,1,0,0,${info.PrintDate}
AA,18,46,1,1,0,0,${info.RequestDoctor}
AC,6,176,1,1,0,0,${info.ProcedureName}
AA,210,182,1,1,0,0,${info.BirthDate}
BQ2,76,72,1,6,75,0,3,A${info.BarcodeCode}
E
`;

        return ezplContent;
    }

    generateRadiologyBarcodeNew(info: RadiologyBarcodeInfo): string {
        let ezplContent: string = `
`;

        return ezplContent;
    }
    generateRadiologyAppointmentBarcode(info: RadiologyBarcodeInfo): string {
        let ezplContent: string = `
`;

        return ezplContent;
    }

    generateLaboratoryBarcode(info: LaboratoryBarcodeInfo): string {
        let ezplContent: string = `^Q28,3
^W40
^H15
^P1
^S2
^AD
^C1
^R0
~Q+0
^O0
^D0
^E20
~R255
^XSET,CODEPAGE,18
^L
Dy2-me-dd
Th:m:s
AT,89,7,25,25,0,0,0,0,${info.PatientFullName}
AB,29,39,1,1,0,0,${info.FromResourceQRef}
AB,175,36,1,1,0,0,${info.PatientTCNo}
BQ,67,67,2,4,80,0,3,${info.BarcodeCode}
AB,74,172,1,1,0,0,${info.PrintDate}
AB,28,191,1,1,0,0,${info.TubeName}
E
`;
        return ezplContent;
    }



    generateInPatientBarcode(info: LaboratoryBarcodeInfo): string {
        let ezplContent: string = `^Q28,3,0-
^W40
^H8
^P1
^S4
^AD
^C1
^R0
~Q+0
^O0
^D0
^E18
~R200
^XSET,CODEPAGE,18
^L
Dy2-me-dd
Th:m:s
Dy2-me-dd
Th:m:s
AB,16,0,1,1,0,0,${info.PatientFullName}
AA,18,26,1,1,0,0,Is No:
AA,68,24,1,1,0,0,${info.FromResourceQRef}
AA,170,26,1,1,0,0,${info.PrintDate}
AA,18,46,1,1,0,0,${info.FromResourceName}
AC,6,176,1,1,0,0,${info.TubeName}
AA,210,182,1,1,0,0,${info.BirthDate}
BQ2,76,72,1,6,75,0,3,A${info.BarcodeCode}
E
`;
        return ezplContent;
    }
    generateDrugSticker(info: DrugStickerInfo): string {
        let ezplContent: string = `^Q28,3,0-
^W40
^H8
^P1
^S4
^AD
^C1
^R0
~Q+0
^O0
^D0
^E18
~R200
^XSET,CODEPAGE,18
^L
Dy2-me-dd
Th:m:s
Dy2-me-dd
Th:m:s
AB,16,6,1,1,0,0,${info.HospitalName}
BQ2,30,36,1,3,90,0,3,A${info.BarcodeCode}
AB,14,156,1,1,0,0,${info.DrugName}
AB,10,180,1,1,0,0,SKT:
AB,66,180,1,1,0,0,${info.ExpireDate}
E
`;
        return ezplContent;
    }

    generateDrugBarcode(info: DrugBarcodeInfo): string {
        let ezplContent: string = `^Q60,2,0-
^W80
^H8
^P1
^S4
^AD
^C1
^R0
~Q+0
^O0
^D0
^E18
~R200
^XSET,CODEPAGE,18
^L
Dy2-me-dd
Th:m:s
Dy2-me-dd
Th:m:s
AA,20,26,1,1,0,0,${info.PrintDate}
AB,20,4,1,1,0,0,${info.PatientFullName}
AA,20,64,1,1,0,0,Prot. No:
AA,92,64,1,1,0,0,${info.ProcedureCode}
AA,22,44,1,1,0,0,${info.ProcedureName}
Lo,8,92,633,94
Lo,6,138,631,140
AA,14,108,1,1,0,0,ILAÇ ADI
AA,250,108,1,1,0,0,DOZ
AA,480,108,1,1,0,0,Son Kullanım Tarihi
Lo,6,188,631,190
Lo,8,238,633,240
Lo,12,286,637,288
Lo,10,338,635,340
Lo,14,388,639,390
Lo,14,430,639,432
AA,18,143,1,1,0,0,${info.Drugs[0].DrugName}
AA,18,190,1,1,0,0,${info.Drugs[1].DrugName}
AA,18,244,1,1,0,0,${info.Drugs[2].DrugName}
AA,18,292,1,1,0,0,${info.Drugs[3].DrugName}
AA,18,342,1,1,0,0,${info.Drugs[4].DrugName}
AA,18,394,1,1,0,0,${info.Drugs[5].DrugName}
AA,18,438,1,1,0,0,${info.Drugs[6].DrugName}
AA,238,165,1,1,0,0,${info.Drugs[0].Doz}
AA,238,214,1,1,0,0,${info.Drugs[1].Doz}
AA,238,264,1,1,0,0,${info.Drugs[2].Doz}
AA,238,314,1,1,0,0,${info.Drugs[3].Doz}
AA,238,364,1,1,0,0,${info.Drugs[4].Doz}
AA,238,412,1,1,0,0,${info.Drugs[5].Doz}
AA,238,458,1,1,0,0,${info.Drugs[6].Doz}
AA,452,165,1,1,0,0,${info.Drugs[0].ExpireDate}
AA,452,214,1,1,0,0,${info.Drugs[1].ExpireDate}
AA,452,264,1,1,0,0,${info.Drugs[2].ExpireDate}
AA,452,314,1,1,0,0,${info.Drugs[3].ExpireDate}
AA,452,364,1,1,0,0,${info.Drugs[4].ExpireDate}
AA,452,412,1,1,0,0,${info.Drugs[5].ExpireDate}
AA,452,458,1,1,0,0,${info.Drugs[6].ExpireDate}
AA,18,165,1,1,0,0,${info.Drugs[0].EK}
AA,18,214,1,1,0,0,${info.Drugs[1].EK}
AA,18,314,1,1,0,0,${info.Drugs[3].EK}
AA,18,264,1,1,0,0,${info.Drugs[2].EK}
AA,18,364,1,1,0,0,${info.Drugs[4].EK}
AA,18,412,1,1,0,0,${info.Drugs[5].EK}
AA,18,458,1,1,0,0,${info.Drugs[6].EK}
AA,382,108,1,1,0,0,MİKTAR
AA,380,165,1,1,0,0,${info.Drugs[0].Mi}
AA,380,214,1,1,0,0,${info.Drugs[1].Mi}
AA,380,264,1,1,0,0,${info.Drugs[2].Mi}
AA,380,314,1,1,0,0,${info.Drugs[3].Mi}
AA,380,364,1,1,0,0,${info.Drugs[4].Mi}
AA,380,412,1,1,0,0,${info.Drugs[5].Mi}
AA,380,458,1,1,0,0,${info.Drugs[6].Mi}
E
`;
        return ezplContent;
    }

    generateHimsDrugBarcode(info: HimsDrugInfo): string {
        let ezplContent: string = `^Q60,2,0-
^W80
^H8
^P1
^S4
^AD
^C1
^R0
~Q+0
^O0
^D0
^E18
~R200
^XSET,CODEPAGE,18
^L
Dy2-me-dd
Th:m:s
Dy2-me-dd
Th:m:s
AA,8,24,1,1,0,0,${info.PrintDate}
AB,10,0,1,1,0,0,${info.PatientFullName}
AA,8,62,1,1,0,0,Prot. No:
AA,80,62,1,1,0,0,${info.ProcedureCode}
AA,10,42,1,1,0,0,${info.ProcedureName}
Lo,8,92,633,94
Lo,6,138,631,140
AA,14,108,1,1,0,0,ILAÇ ADI
AA,226,108,1,1,0,0,DOZ
AA,436,108,1,1,0,0,UYGULAMA SAATİ
Lo,0,184,625,186
Lo,0,238,625,240
Lo,0,286,625,288
Lo,0,336,625,338
Lo,0,388,625,390
Lo,0,430,625,432
AA,0,143,1,1,0,0,${info.Drugs[0].DrugName}
AA,0,190,1,1,0,0,${info.Drugs[1].DrugName}
AA,0,244,1,1,0,0,${info.Drugs[2].DrugName}
AA,0,292,1,1,0,0,${info.Drugs[3].DrugName}
AA,0,342,1,1,0,0,${info.Drugs[4].DrugName}
AA,0,394,1,1,0,0,${info.Drugs[5].DrugName}
AA,0,438,1,1,0,0,${info.Drugs[6].DrugName}
AA,220,165,1,1,0,0,${info.Drugs[0].Doz}
AA,220,214,1,1,0,0,${info.Drugs[1].Doz}
AA,220,264,1,1,0,0,${info.Drugs[2].Doz}
AA,220,314,1,1,0,0,${info.Drugs[3].Doz}
AA,220,364,1,1,0,0,${info.Drugs[4].Doz}
AA,220,412,1,1,0,0,${info.Drugs[5].Doz}
AA,220,458,1,1,0,0,${info.Drugs[6].Doz}
AA,434,165,1,1,0,0,${info.Drugs[0].PlannedTime}
AA,434,214,1,1,0,0,${info.Drugs[1].PlannedTime}
AA,434,264,1,1,0,0,${info.Drugs[2].PlannedTime}
AA,434,314,1,1,0,0,${info.Drugs[3].PlannedTime}
AA,434,364,1,1,0,0,${info.Drugs[4].PlannedTime}
AA,434,412,1,1,0,0,${info.Drugs[5].PlannedTime}
AA,434,458,1,1,0,0,${info.Drugs[6].PlannedTime}
BQ2,390,2,2,6,56,0,3,A${info.BarcodeCode}
AA,0,165,1,1,0,0,${info.Drugs[0].EK}
AA,0,214,1,1,0,0,${info.Drugs[1].EK}
AA,0,314,1,1,0,0,${info.Drugs[3].EK}
AA,0,264,1,1,0,0,${info.Drugs[2].EK}
AA,0,364,1,1,0,0,${info.Drugs[4].EK}
AA,0,412,1,1,0,0,${info.Drugs[5].EK}
AA,0,458,1,1,0,0,${info.Drugs[6].EK}
AA,358,108,1,1,0,0,MİKTAR
AA,362,165,1,1,0,0,${info.Drugs[0].Mi}
AA,362,214,1,1,0,0,${info.Drugs[1].Mi}
AA,362,264,1,1,0,0,${info.Drugs[2].Mi}
AA,362,314,1,1,0,0,${info.Drugs[3].Mi}
AA,362,364,1,1,0,0,${info.Drugs[4].Mi}
AA,362,412,1,1,0,0,${info.Drugs[5].Mi}
AA,362,458,1,1,0,0,${info.Drugs[6].Mi}
E
`;
        return ezplContent;
    }



    generatePeeLaboratoryBarcode(info: LaboratoryBarcodeInfo): string {
        let ezplContent: string = `^Q28,3
^W40
^H15
^P1
^S2
^AD
^C1
^R0
~Q+0
^O0
^D0
^E20
~R255
^XSET,CODEPAGE,18
^L
Dy2-me-dd
Th:m:s
AT,89,7,25,25,0,0,0,0,${info.PatientFullName}
AB,29,39,1,1,0,0,${info.FromResourceQRef}
AB,175,36,1,1,0,0,${info.PatientTCNo}
BQ,67,67,2,4,80,0,3,${info.BarcodeCode}
AB,74,172,1,1,0,0,${info.PrintDate}
AB,28,191,1,1,0,0,${info.TubeName}
E
`;
        return ezplContent;
    }

    generateInPatientWristBarcode(info: InpatientWristBarcodeInfo): string {
        let ezplContent: string = '';
        return ezplContent;
    }

    generateInPatientWristBarcode2(info: InpatientWristBarcodeInfo): string {
        let ezplContent: string = '';
        return ezplContent;
    }

    generatePatologyBarcode(info: PatologyBarcodeInfo): string {
        let ezplContent: string = ``;
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
A733,348,2,3,1,1,R,${info.HospitalName}
A287,233,2,3,1,1,R,${info.AdmissionNo}
A802,234,2,3,1,1,N,${info.MotherName}
A801,272,2,3,1,1,N,${info.FatherName}
A801,311,2,3,1,1,N,${info.BabyName}
P1
`;

        return ezplContent;
    }

    generateDietCaloriBarcode(info: DietBarcodeInfo): string {
        let ezplContent: string = ``;
        return ezplContent;
    }

    generatePatientArchieveBarcode(info: PatientArchieveBarcodeInfo): string {
        let ezplContent: string = ``;
        return ezplContent;
    }
    generateGazilerPatientBarcode(info: PatientBarcodeInfo): string {

        let ezplContent: string = `^Q28,3,0-
^W40
^H8
^P1
^S4
^AD
^C1
^R0
~Q+0
^O0
^D0
^E18
~R200
^XSET,CODEPAGE,18
^L
Dy2-me-dd
Th:m:s
Dy2-me-dd
Th:m:s
AB,4,6,1,1,0,0,${info.PatientName}
AB,4,38,1,1,0,0,Tc:
AA,52,42,1,1,0,0,${info.PatientIdentifier}
AB,156,38,1,1,0,0,GSS No:
AA,245,72,1,1,0,0,${info.Gender}
AB,14,66,1,1,0,0,Bas.T.
AA,80,72,1,1,0,0,${info.StartDateWithDateandHour}
AB,18,94,1,1,0,0,${info.BirthDate}
AA,158,96,1,1,0,0,Islem NO:
AA,4,122,1,1,0,0,${info.Kurum}
AB,4,188,1,1,0,0,${info.DoctorName}
AA,4,146,1,1,0,0,${info.PoliclinicName}
AA,246,42,1,1,0,0,${info.GSSNo}
AA,256,96,1,1,0,0,${info.IslemNo}
AA,4,166,1,1,0,0,Tah. Bek. Süresi
AA,144,166,1,1,0,0,${info.RandevuSaati}
AA,250,110,1,1,0,0,${info.SiraNo}
E
`;

        return ezplContent;
    }
}