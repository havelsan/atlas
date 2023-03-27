import { PatientBarcodeInfo, PatologyBarcodeInfo } from '../Models/PatientBarcodeInfo';
import { InpatientTreatmentBarcodeInfo, SerumBarcodeInfo } from '../Models/InpatientTreatmentBarcodeInfo';
import { InpatientWristBarcodeInfo } from '../Models/InpatientWristBarcodeInfo';
import { RadiologyBarcodeInfo } from '../Models/RadiologyBarcodeInfo';
import { DrugBarcodeInfo, DrugStickerInfo, HimsDrugInfo, DrugUsedInfo } from '../Models/DrugBarcodeInfo';
import { ArchiveBarcodeInfo } from '../Models/ArchiveBarcodeInfo';
import { LaboratoryBarcodeInfo } from '../Models/LaboratoryBarcodeInfo';

export abstract class IBarcodePrintService {
    abstract setBarcodePrinterName(printerName: string);
    abstract printAllBarcode(info: any, providerType: string, userOptionType: string);

    abstract getPrinterList();
}