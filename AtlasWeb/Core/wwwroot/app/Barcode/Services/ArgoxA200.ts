
import { IBarcodePrinterProvider } from './IBarcodePrinterProvider';
import { PatientBarcodeInfo, PatologyBarcodeInfo, PatientArchieveBarcodeInfo } from '../Models/PatientBarcodeInfo';
import { InpatientTreatmentBarcodeInfo, SerumBarcodeInfo } from '../Models/InpatientTreatmentBarcodeInfo';
import { InpatientWristBarcodeInfo, BabyMotherMatchBarcodeInfo } from '../Models/InpatientWristBarcodeInfo';
import { RadiologyBarcodeInfo } from '../Models/RadiologyBarcodeInfo';
import { DrugBarcodeInfo, DrugStickerInfo, HimsDrugInfo, DrugUsedInfo } from '../Models/DrugBarcodeInfo';
import { ArchiveBarcodeInfo } from '../Models/ArchiveBarcodeInfo';
import { LaboratoryBarcodeInfo } from '../Models/LaboratoryBarcodeInfo';
import { DietBarcodeInfo } from '../Models/DietBarcodeInfo';

export class ArgoxA200 implements IBarcodePrinterProvider {

    generateArchiveBarcode(info: ArchiveBarcodeInfo): string {
        let ezplContent: string = `
`;

        return ezplContent;
    }


    generatePatientBarcode(info: PatientBarcodeInfo): string {
        const TURKISH_MAP = {
            'ş': 's', 'Ş': 'S', 'ı': 'i', 'İ': 'I', 'ç': 'c', 'Ç': 'C', 'ü': 'u',
            'Ü': 'U', 'ö': 'o', 'Ö': 'O', 'ğ': 'g', 'Ğ': 'G'
        };

        for (var key in TURKISH_MAP) {
            info.PatientName = info.PatientName.replace(new RegExp('[' + key + ']', 'g'), TURKISH_MAP[key]);
            info.BirthPlace = info.BirthPlace.replace(new RegExp('[' + key + ']', 'g'), TURKISH_MAP[key]);
            info.HospitalName = info.HospitalName.replace(new RegExp('[' + key + ']', 'g'), TURKISH_MAP[key]);
            info.PoliclinicName = info.PoliclinicName.replace(new RegExp('[' + key + ']', 'g'), TURKISH_MAP[key]);
        }



        let ezplContent: string = `
n
M0500
KI70
O0220
V0
f220
D
L
D11
A2
1e4203400140146B${info.IslemNo}
121100000020181${info.IslemNo}
131100000790000${info.PatientName}
121100000650000${info.PatientIdentifier}
121100000810146${info.Gender}
121100000530000${info.BirthPlace} / ${info.BirthDate}
121100000410000${info.KabulTarihi}
121100000300000${info.RandevuSaati}
121100000650213${info.TAKIPNO}
121100000530213${info.DNo}
121100000140000${info.HospitalName}
121100000810205${info.StartDate}
121100000530162DosyaNo:
121100000650162TakipNo:
171100000990000${info.PoliclinicName}
Q0001
E
`;


//        let ezplContent: string = `
//I8,E,001


//n
//M0500
//KI70
//O0220
//V0
//f220
//D
//L
//D11
//A2
//1e4203400140153B${info.IslemNo}
//121100000020189${info.IslemNo}
//131100000750008${info.PatientName}
//121100000650008${info.PatientIdentifier}
//121100000810154${info.Gender}
//121100000530008${info.BirthPlace} / ${info.BirthDate}
//121100000410008${info.KabulTarihi}
//121100000300008TAHMINI MUYAENE SAATI
//121100000610221${info.TAKIPNO}
//121100000490221${info.DNo}
//121100000140008${info.HospitalName}
//121100000490170DosyaNo:
//121100000610170TakipNo:
//121100001000233${info.SiraNo}
//Q0001
//E
//`;

        return ezplContent;
    }

    generateSerumBarcode(info: SerumBarcodeInfo): string {
        let ezplContent: string = `
`;
        return ezplContent;
    }

    generateInpatientTreatmentBarcode2(info: InpatientTreatmentBarcodeInfo): string {
        let ezplContent: string = `
`;
        return ezplContent;
    }

    generateInpatientTreatmentBarcode(info: InpatientTreatmentBarcodeInfo): string {
        let ezplContent: string = `<xpml><page quantity='0' pitch='30.0 mm'></xpml>I8,E
        ZN
        q550
        O
        JF
        KI9+0.0
        ZT
        Q240,25
        <xpml></page></xpml><xpml><page quantity='1' pitch='30.0 mm'></xpml>N
        B549,103,2,1,2,4,70,N,"${info.AcceptionNumber}"
        A444,28,2,2,1,1,N,"${info.AcceptionNumber}"
        A549,197,2,2,1,1,N,"${info.PatientName}"
        A549,133,2,2,1,1,N,"${info.PatientIdentifier}"
        A221,221,2,2,1,1,R,"${info.BirthDate}"
        A245,189,2,2,1,1,N,"${info.Sex}"
        A549,165,2,2,1,1,N,"${info.Clinicname}"
        A285,157,2,2,1,1,N,"${info.InPatientDate}"
        A117,157,2,2,1,1,N,"${info.TakipNo}"
        A549,221,2,2,1,1,N,"${info.HospitalName}"
        A117,189,2,2,1,1,R,"${info.AcceptionNumber}"
        A126,29,2,2,1,1,R,"${info.ArchiveNumber}"
        A205,29,2,2,1,1,N,"Arşiv:"
        P1
        <xpml></page></xpml><xpml><end/></xpml>`;
        return ezplContent;
    }

    generateDrugUsedBarcode(info: DrugUsedInfo): string {
        let ezplContent: string = `I8,E
ZN
q320
O
JF
D50
KI9+0.0
ZT
Q224,25
d8,0
N
A273,211,2,2,1,1,N,"${info.ClinicName}"
A313,181,2,2,1,1,R,"${info.PatientName}"
A313,154,2,2,1,1,N,"${info.BirthDate}"
A93,153,2,2,1,1,N,"${info.Room}"
A257,129,2,2,1,1,N,"${info.Drug}"
A276,109,2,2,1,1,N,"${info.Drug2}"
A257,80,2,2,1,1,N,"${info.Dose}"
A313,45,2,2,1,1,N,"${info.DrugDate}"
A93,51,2,2,1,1,N,"${info.DrugHour}"
P1
`;
        return ezplContent;
    }


    generateRadiologyBarcode(info: RadiologyBarcodeInfo): string {
        let ezplContent: string = `
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
        let ezplContent: string = `
`;
        return ezplContent;
    }



    generateInPatientBarcode(info: LaboratoryBarcodeInfo): string {
        let ezplContent: string = `
`;
        return ezplContent;
    }
    generateDrugSticker(info: DrugStickerInfo): string {
        let ezplContent: string = `
`;
        return ezplContent;
    }

    generateDrugBarcode(info: DrugBarcodeInfo): string {
        let ezplContent: string = `
`;
        return ezplContent;
    }

    generateHimsDrugBarcode(info: HimsDrugInfo): string {
        let ezplContent: string = `I8,E
ZN
q640
OD
JF
D50
ZT
Q480,120
d8,0
N
A625,464,2,2,1,1,N,"${info.PatientFullName}"
A625,438,2,2,1,1,N,"${info.ProcedureCode}"
A625,414,2,2,1,1,N,"${info.ProcedureName}"
A625,390,2,2,1,1,N,"${info.PrintDate}"
B195,466,2,1,2,4,48,N,"${info.BarcodeCode}"
A148,412,2,2,1,1,N,"${info.BarcodeCode}"
LO0,363,639,2
A625,357,2,2,1,1,N,"ILAC ADI"
A413,357,2,2,1,1,N,"DOZ"
A202,357,2,2,1,1,N,"UYGULAMA ZAMANI"
A316,357,2,2,1,1,N,"MIKTAR"
LO0,332,639,2
A625,329,2,2,1,1,N,"${info.Drugs[0].DrugName}"
A625,309,2,2,1,1,N,"${info.Drugs[0].EK}"
A413,309,2,2,1,1,N,"${info.Drugs[0].Doz}"
A305,309,2,2,1,1,N,"${info.Drugs[0].Mi}"
A202,309,2,2,1,1,N,"${info.Drugs[0].PlannedTime}"
LO0,289,639,2
A625,286,2,2,1,1,N,"${info.Drugs[1].DrugName}"
A625,266,2,2,1,1,N,"${info.Drugs[1].EK}"
A413,266,2,2,1,1,N,"${info.Drugs[1].Doz}"
A305,266,2,2,1,1,N,"${info.Drugs[1].Mi}"
A202,263,2,2,1,1,N,"${info.Drugs[1].PlannedTime}"
LO0,246,639,2
A625,243,2,2,1,1,N,"${info.Drugs[2].DrugName}"
A625,220,2,2,1,1,N,"${info.Drugs[2].EK}"
A413,220,2,2,1,1,N,"${info.Drugs[2].Doz}"
A305,220,2,2,1,1,N,"${info.Drugs[2].Mi}"
A202,220,2,2,1,1,N,"${info.Drugs[2].PlannedTime}"
LO0,200,639,2
A625,199,2,2,1,1,N,"${info.Drugs[3].DrugName}"
A625,176,2,2,1,1,N,"${info.Drugs[3].EK}"
A413,176,2,2,1,1,N,"${info.Drugs[3].Doz}"
A305,176,2,2,1,1,N,"${info.Drugs[3].Mi}"
A202,176,2,2,1,1,N,"${info.Drugs[3].PlannedTime}"
LO0,156,639,2
A625,153,2,2,1,1,N,"${info.Drugs[4].DrugName}"
A625,130,2,2,1,1,N,"${info.Drugs[4].EK}"
A413,130,2,2,1,1,N,"${info.Drugs[4].Doz}"
A305,130,2,2,1,1,N,"${info.Drugs[4].Mi}"
A202,130,2,2,1,1,N,"${info.Drugs[4].PlannedTime}"
LO0,66,639,2
A625,107,2,2,1,1,N,"${info.Drugs[5].DrugName}"
A625,85,2,2,1,1,N,"${info.Drugs[5].EK}"
A413,85,2,2,1,1,N,"${info.Drugs[5].Doz}"
A305,85,2,2,1,1,N,"${info.Drugs[5].Mi}"
A202,85,2,2,1,1,N,"${info.Drugs[5].PlannedTime}"
LO0,0,639,2
LO0,110,639,2
A625,63,2,2,1,1,N,"${info.Drugs[6].DrugName}"
A625,39,2,2,1,1,N,"${info.Drugs[6].EK}"
A413,39,2,2,1,1,N,"${info.Drugs[6].Doz}"
A305,39,2,2,1,1,N,"${info.Drugs[6].Mi}"
A202,39,2,2,1,1,N,"${info.Drugs[6].PlannedTime}"
P1
`;
        return ezplContent;
    }



    generatePeeLaboratoryBarcode(info: LaboratoryBarcodeInfo): string {
        let ezplContent: string = '';
        return ezplContent;
    }

    generateInPatientWristBarcode(info: InpatientWristBarcodeInfo): string {
        let ezplContent: string = `<xpml><page quantity='0' pitch='30.0 mm'></xpml>I8,E
        ZN
        q550
        O
        JF
        KI9+0.0
        ZT
        Q240,25
        <xpml></page></xpml><xpml><page quantity='1' pitch='30.0 mm'></xpml>N
        GW117,200,46,24,                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                        
        A549,189,2,2,1,1,N,"${info.PatientName}"
        A549,141,2,2,1,1,N,"${info.PatientIdentifier}"
        A453,221,2,2,1,1,R,"${info.HospitalName}"
        A126,165,2,2,1,1,N,"${info.Sex}"
        A549,165,2,2,1,1,N,"${info.BirthDate}"
        A118,189,2,2,1,1,R,"${info.AcceptionNumber}"
        P1
        <xpml></page></xpml><xpml><end/></xpml>`;
        return ezplContent;
    }

    generateInPatientWristBarcode2(info: InpatientWristBarcodeInfo): string {
        let ezplContent: string = ``;
        return ezplContent;
    }

    generatePatologyBarcode(info: PatologyBarcodeInfo): string {
        let ezplContent: string = ``;
        return ezplContent;
    }

    generateBabyMotherBarcode(info: BabyMotherMatchBarcodeInfo): string {
        let ezplContent: string = ``;
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

        let ezplContent: string = ``;
        return ezplContent;
    }
}