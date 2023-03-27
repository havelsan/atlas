import { IBarcodePrinterProvider } from './IBarcodePrinterProvider';
import { GodexBarcodeProvider } from './GodexBarcodeProvider';
import { ZebraBarcodeProvider } from './ZebraBarcodeProvider';
import { ArgoxA200 } from './ArgoxA200';
import { BarcodeSettings } from '../../System/Models/BarcodeSettingsModel';
export function barcodeProviderFactory(userPrinterOption: BarcodeSettings): IBarcodePrinterProvider {
    let localprinter;
    if (userPrinterOption != null) {
        localprinter = userPrinterOption.Printer;
    } else {
        localprinter = localStorage.getItem("BarcodePrinterType");
    }

    if (localprinter != null) {
        if (localprinter.indexOf("Godex") > -1)
            return new GodexBarcodeProvider();
        if (localprinter.indexOf("ZDesigner") > -1 || localprinter.indexOf("Zebra") > -1)
            return new ZebraBarcodeProvider();
        if (localprinter.indexOf("Argox") > -1)
            return new ArgoxA200();
    }
    if (localprinter == null)
        return new ZebraBarcodeProvider();
    return new ZebraBarcodeProvider();
}
