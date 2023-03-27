import { PatientBarcodeInfo, PatologyBarcodeInfo, PatientArchieveBarcodeInfo} from '../Models/PatientBarcodeInfo';
import { InpatientTreatmentBarcodeInfo, SerumBarcodeInfo} from '../Models/InpatientTreatmentBarcodeInfo';
import { InpatientWristBarcodeInfo, BabyMotherMatchBarcodeInfo } from '../Models/InpatientWristBarcodeInfo';
import { RadiologyBarcodeInfo } from '../Models/RadiologyBarcodeInfo';
import { DrugBarcodeInfo, DrugStickerInfo, HimsDrugInfo, DrugUsedInfo } from '../Models/DrugBarcodeInfo';
import { ArchiveBarcodeInfo } from '../Models/ArchiveBarcodeInfo';
import { LaboratoryBarcodeInfo} from '../Models/LaboratoryBarcodeInfo';
import { DietBarcodeInfo } from '../Models/DietBarcodeInfo';

export abstract class IBarcodePrinterProvider {
    abstract generatePatientBarcode(info: PatientBarcodeInfo): string;
    abstract generateRadiologyBarcode(info: RadiologyBarcodeInfo): string;
    abstract generateLaboratoryBarcode(info: LaboratoryBarcodeInfo): string;
    abstract generatePeeLaboratoryBarcode(info: LaboratoryBarcodeInfo): string;
    abstract generateInPatientBarcode(info: LaboratoryBarcodeInfo): string;
    abstract generateInPatientWristBarcode(info: InpatientWristBarcodeInfo): string;

    abstract generateInPatientWristBarcode2(info: InpatientWristBarcodeInfo): string;

    abstract generateInpatientTreatmentBarcode(info: InpatientTreatmentBarcodeInfo): string;
    abstract generateInpatientTreatmentBarcode2(info: InpatientTreatmentBarcodeInfo): string;
    abstract generateDrugBarcode(info: DrugBarcodeInfo): string;
    abstract generateDrugSticker(info: DrugStickerInfo): string;
    abstract generateHimsDrugBarcode(info: HimsDrugInfo): string;
    abstract generateArchiveBarcode(info: ArchiveBarcodeInfo): string;
    abstract generateDrugUsedBarcode(info: DrugUsedInfo): string;
    abstract generateSerumBarcode(info: SerumBarcodeInfo): string;
    abstract generatePatologyBarcode(info: PatologyBarcodeInfo): string;
    abstract generateRadiologyBarcodeNew(info: RadiologyBarcodeInfo): string;
    abstract generateRadiologyAppointmentBarcode(info: RadiologyBarcodeInfo): string;
    abstract generateBabyMotherBarcode(info: BabyMotherMatchBarcodeInfo): string;
    abstract generateDietCaloriBarcode(info: DietBarcodeInfo): string;
    abstract generatePatientArchieveBarcode(info: PatientArchieveBarcodeInfo): string;
    abstract generateGazilerPatientBarcode(info: PatientBarcodeInfo): string;


}


