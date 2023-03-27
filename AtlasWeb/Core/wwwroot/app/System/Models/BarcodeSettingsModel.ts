import { Type } from 'NebulaClient/ClassTransformer';

export class BarcodeSettingsViewModel
{
    @Type(() => BarcodeSettings)
    public _Settings:Array<BarcodeSettings> = new Array<BarcodeSettings>();
}


export class BarcodeSettings 
{
    public BarcodeType: string;
    public Printer:string;
    @Type(() => Number)
    public BarcodeCount:number;

}