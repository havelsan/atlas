//$FD412BB9
import { IBarcodePrintService } from './IBarcodePrintService';
import { Injectable } from '@angular/core';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { PatientBarcodeInfo, PatologyBarcodeInfo } from '../Models/PatientBarcodeInfo';
import { InpatientTreatmentBarcodeInfo, SerumBarcodeInfo } from '../Models/InpatientTreatmentBarcodeInfo';
import { InpatientWristBarcodeInfo } from '../Models/InpatientWristBarcodeInfo';
import { RadiologyBarcodeInfo } from '../Models/RadiologyBarcodeInfo';
import { DrugBarcodeInfo, DrugStickerInfo, HimsDrugInfo, DrugUsedInfo } from '../Models/DrugBarcodeInfo';
import { ArchiveBarcodeInfo } from '../Models/ArchiveBarcodeInfo';
import { LaboratoryBarcodeInfo } from '../Models/LaboratoryBarcodeInfo';
import { barcodeProviderFactory } from 'app/Barcode/Services/BarcodeProviderFactory';
import { MultiSelectForm } from 'NebulaClient/Visual/MultiSelectForm';
import { AtlasHttpService } from 'app/Fw/Services/AtlasHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import { BarcodeSettings } from 'app/System/Models/BarcodeSettingsModel';
@Injectable()
export class AtlasBarcodePrintService implements IBarcodePrintService {

    private httpPrintServiceUrl = 'http://localhost:5000/api/AtlasPrint/print';

    constructor(private http: AtlasHttpService, protected messageService: MessageService, protected httpService: NeHttpService) {
    }

    private _barcodePrinterName: string;
    private readonly BarcodePrinterType = 'BarcodePrinterType';
    setBarcodePrinterName(printerName: string): void {
        this._barcodePrinterName = printerName;
    }

    private async getSelectedPrinter(userPrinterOption: BarcodeSettings): Promise<string> {

        if (this._barcodePrinterName) {
            return this._barcodePrinterName;
        }


        let localprinter;
        if (userPrinterOption != null && userPrinterOption.BarcodeCount > 0) {
            localprinter = userPrinterOption.Printer;
            if (localprinter) {
                return localprinter;
            }
        } else {
            localprinter = localStorage.getItem("BarcodePrinterType");
            if (localprinter) {
                return localprinter;
            }
        }

        let response = await this.getPrinterList();
        if (response == undefined) {
            this.messageService.showError("Atlas Client Servis Kurunuz.")
            return;
        }
        if (response.json().Result instanceof Array) {
            const printers = response.json().Result as Array<any>;
            let multiSelectForm: MultiSelectForm = new MultiSelectForm();
            for (let item of printers) {
                multiSelectForm.AddMSItem(item.toString(), item.toString());
            }
            let selectedPrinter: string = await multiSelectForm.GetMSItem(this, i18n("M24480", "Yazıcı Seçiniz"), true);
            if (selectedPrinter) {
                localStorage.setItem("BarcodePrinterType", selectedPrinter);
                return selectedPrinter;
            }
        }
        else {
            this.messageService.showError("Atlas Client Servis Kurunuz.")
        }

        return null;
    }

    private async printBarcode(content: string, userBarcodeSettings: BarcodeSettings) {
        try {
            let input: any = { PrinterName: userBarcodeSettings.Printer, Text: content };
            for (var i = 0; i < userBarcodeSettings.BarcodeCount; i++) {
                this.http.post(this.httpPrintServiceUrl, input).toPromise();
            }

        } catch (error) {
            console.log(error);
        }
    }

    private async GetUserBarcodeSettings(functionName: string) {
        let apiUrl: string = '/api/CommonService/GetUserBarcodeSettingsByFunction?fromFuntion=' + functionName;
        let result: BarcodeSettings = await this.httpService.get<BarcodeSettings>(apiUrl);
        if (result == null || result.BarcodeCount == 0) {
            
        }
        if (result != null && result.BarcodeCount > 0) {
            return result;
        } else {
            const barcodePrinterName = await this.getSelectedPrinter(result);
            if (!barcodePrinterName) {
                this.messageService.showError("Yazıcı Bulunamadı.")
            }
            let barcodess: BarcodeSettings=new BarcodeSettings;
            barcodess.BarcodeCount = 1;
            barcodess.Printer = barcodePrinterName;

            return barcodess;
        }
    }

    public async printAllBarcode(info: any, providerType: string, userOptionType: string) {

        let userBarcodeSettings = await this.GetUserBarcodeSettings(userOptionType);
        const barcodePrinterProvider = barcodeProviderFactory(userBarcodeSettings);

        let barcodeContent: string = "";
        switch (providerType) {
            case "generatePatientBarcode": {
                barcodeContent = barcodePrinterProvider.generatePatientBarcode(info);
                break;
            }
            case "generateRadiologyBarcode": {
                barcodeContent = barcodePrinterProvider.generateRadiologyBarcode(info);
                break;
            }
            case "generateRadiologyBarcodeNew": {
                barcodeContent = barcodePrinterProvider.generateRadiologyBarcodeNew(info);
                break;
            }
            case "generateLaboratoryBarcode": {
                barcodeContent = barcodePrinterProvider.generateLaboratoryBarcode(info);
                break;
            }
            case "generatePeeLaboratoryBarcode": {
                barcodeContent = barcodePrinterProvider.generatePeeLaboratoryBarcode(info);
                break;
            }
            case "generateInPatientBarcode": {
                barcodeContent = barcodePrinterProvider.generateInPatientBarcode(info);
                break;
            }
            case "generateInpatientTreatmentBarcode": {
                barcodeContent = barcodePrinterProvider.generateInpatientTreatmentBarcode(info);
                break;
            }
            case "generateInpatientTreatmentBarcode2": {
                barcodeContent = barcodePrinterProvider.generateInpatientTreatmentBarcode2(info);
                break;
            }
            case "generateInPatientWristBarcode": {
                barcodeContent = barcodePrinterProvider.generateInPatientWristBarcode(info);
                break;
            }
            case "generateInPatientWristBarcode2": {
                barcodeContent = barcodePrinterProvider.generateInPatientWristBarcode2(info);
                break;
            }
            case "generateDrugBarcode": {
                barcodeContent = barcodePrinterProvider.generateDrugBarcode(info);
                break;
            }
            case "generateHimsDrugBarcode": {
                barcodeContent = barcodePrinterProvider.generateHimsDrugBarcode(info);
                break;
            }
            case "generateDrugSticker": {
                barcodeContent = barcodePrinterProvider.generateDrugSticker(info);
                break;
            }
            case "generateDrugUsedBarcode": {
                barcodeContent = barcodePrinterProvider.generateDrugUsedBarcode(info);
                break;
            }
            case "generateArchiveBarcode": {
                barcodeContent = barcodePrinterProvider.generateArchiveBarcode(info);
                break;
            }
            case "generatePatologyBarcode": {
                barcodeContent = barcodePrinterProvider.generatePatologyBarcode(info);
                break;
            }
            case "generateSerumBarcode": {
                barcodeContent = barcodePrinterProvider.generateSerumBarcode(info);
                break;
            }
            case "generateRadiologyAppointmentBarcode": {
                barcodeContent = barcodePrinterProvider.generateRadiologyAppointmentBarcode(info);
                break;
            }
            case "generateBabyMotherMatchBarcode": {
                barcodeContent = barcodePrinterProvider.generateBabyMotherBarcode(info);
                break;
            }
            case "generateDietCaloriBarcode": {
                barcodeContent = barcodePrinterProvider.generateDietCaloriBarcode(info);
                break;
            }
            case "generateGazilerPatientBarcode": {
                barcodeContent = barcodePrinterProvider.generateGazilerPatientBarcode(info);
                break;
            }
            case "generatePatientArchieveBarcode": {
                barcodeContent = barcodePrinterProvider.generatePatientArchieveBarcode(info);
                break;
            }
        }
        return await this.printBarcode(barcodeContent, userBarcodeSettings);
    }

    
    public async getPrinterList(): Promise<any> {
        try {
            let printers = await this.http.get('http://localhost:5000/api/AtlasPrint/PrinterList').toPromise();
            return printers;
        } catch (e) {
            this.messageService.showError("Atlas Client Servis Kurunuz.")
        }

    }
}