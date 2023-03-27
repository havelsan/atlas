//$D7FDCDE8
import { ShowBoxTypeEnum } from "../Utils/Enums/ShowBoxTypeEnum";
import { DynamicComponentInfo } from "Fw/Models/DynamicComponentInfo";
import { IModalService } from "Fw/Services/IModalService";
import { ShowBoxModel } from "Fw/Models/ShowBoxModel";
import { CustomShowBoxModel, CustomButtons } from "Fw/Models/CustomShowBoxModel";
import { ServiceLocator } from "Fw/Services/ServiceLocator";
import { ModalInfo } from "Fw/Models/ModalInfo";

export class ShowBox {

    static Show(boxType: ShowBoxTypeEnum, buttonCaptions: string, returnValues: string, windowCaption: string, title: string): Promise<string>;
    static Show(boxType: ShowBoxTypeEnum, buttonCaptions: string, returnValues: string, windowCaption: string, title: string, value: string): Promise<string>;
    static Show(): Promise<string>;
    static Show(boxType: ShowBoxTypeEnum, buttonCaptions: string, returnValues: string, windowCaption: string, title: string, value: string, DefaultButton: number, IsShowCloseButton?:boolean): Promise<string>;
    static Show(boxType?: ShowBoxTypeEnum, buttonCaptions?: string, returnValues?: string, windowCaption?: string, title?: string, value?: string, DefaultButton?: number, IsShowCloseButton?:boolean): Promise<string> {
        if (arguments.length === 5 && (boxType === null) && (buttonCaptions === null || buttonCaptions.constructor === String) && (returnValues === null || returnValues.constructor === String) && (windowCaption === null || windowCaption.constructor === String) && (title === null || title.constructor === String)) {
            return ShowBox.Show_0(boxType, buttonCaptions, returnValues, windowCaption, title);
        }
        if (arguments.length === 6 && (boxType === null) && (buttonCaptions === null || buttonCaptions.constructor === String) && (returnValues === null || returnValues.constructor === String) && (windowCaption === null || windowCaption.constructor === String) && (title === null || title.constructor === String) && (value === null || value.constructor === String)) {
            return ShowBox.Show_1(boxType, buttonCaptions, returnValues, windowCaption, title, value);
        }
        if (arguments.length === 0) {
            return ShowBox.Show_2();
        }
        return ShowBox.Show_3(boxType, buttonCaptions, returnValues, windowCaption, title, value, DefaultButton, IsShowCloseButton);
    }
    private static Show_0(boxType: ShowBoxTypeEnum, buttonCaptions: string, returnValues: string, windowCaption: string, title: string): Promise<string> {
        return ShowBox.Show(boxType, buttonCaptions, returnValues, windowCaption, title, "", 0);
    }
    private static Show_1(boxType: ShowBoxTypeEnum, buttonCaptions: string, returnValues: string, windowCaption: string, title: string, value: string): Promise<string> {
        return ShowBox.Show(boxType, buttonCaptions, returnValues, windowCaption, title, value, 0);
    }
    private static Show_2(): Promise<string> {
        return ShowBox.Show(0, "&Evet,&Hayır", "E,H", "Seçiniz", i18n("M13692", "Emin misiniz ?"), i18n("M12128", "Bunu yapmak istediğinize emin misiniz?"), 1);
    }
    private static async Show_3(boxType: ShowBoxTypeEnum, buttonCaptions: string, returnValues: string, windowCaption: string, title: string, value: string, DefaultButton: number, IsShowCloseButton?:boolean): Promise<string> {
        let model: ShowBoxModel = new ShowBoxModel();
        let buttonCap: Array<string> = new Array<string>();
        buttonCaptions = buttonCaptions.replace("&", "");
        buttonCap = buttonCaptions.split(",");
        model.okButtonCaption = buttonCap[0];
        model.cancelButtonCaption = buttonCap[1].replace("&", "");
        let retValues: Array<string> = new Array<string>();
        retValues = returnValues.split(",");
        model.okRetValue = retValues[0];
        model.cancelRetValue = retValues[1];
        model.title = title;
        model.value = value;
  
        let componentInfo = new DynamicComponentInfo();
        componentInfo.ComponentName = "ShowBoxComponent";
        componentInfo.ModuleName = "CoreModule";
        componentInfo.ModulePath = "/app/Fw/CoreModule";
        componentInfo.InputParam = model;

        let modalInfo: ModalInfo = new ModalInfo();
        modalInfo.Title = windowCaption + " !  " + title;
        modalInfo.Width = 500;
        modalInfo.Height = 300;
        if (IsShowCloseButton == true)
            modalInfo.IsShowCloseButton = false;

        let promise = new Promise<string>(function (resolve, reject) {
            let modalService: IModalService = ServiceLocator.Injector.get(IModalService, [ServiceLocator.Compiler]);
            let result = modalService.create(componentInfo, modalInfo);
            result.then(res => {
                let modalActionResult: any = res.Param;
                if (modalActionResult != undefined) {
                    resolve(modalActionResult);
                }
            })
                .catch(err => {
                    reject(err);
                });
        });

        return promise;
    }
    public static TreeShow(boxType: ShowBoxTypeEnum, buttonCaptions: string, returnValues: string, windowCaption: string, title: string, value: string, DefaultButton: number): Promise<string> {
        let model: ShowBoxModel = new ShowBoxModel();
        let buttonCap: Array<string> = new Array<string>();
        buttonCaptions = buttonCaptions.replace("&", "");
        buttonCap = buttonCaptions.split(",");
        model.okButtonCaption = buttonCap[0];
        model.cancelButtonCaption = buttonCap[1].replace("&", "");
        model.applyButtonCaption = buttonCap[2].replace("&", "");
        let retValues: Array<string> = new Array<string>();
        retValues = returnValues.split(",");
        model.okRetValue = retValues[0];
        model.cancelRetValue = retValues[1];
        model.applyRetValue = retValues[2];
        model.title = title;
        model.value = value;

        let componentInfo = new DynamicComponentInfo();
        componentInfo.ComponentName = "TreeShowBoxComponent";
        componentInfo.ModuleName = "CoreModule";
        componentInfo.ModulePath = "/app/Fw/CoreModule";
        componentInfo.InputParam = model;

        let modalInfo: ModalInfo = new ModalInfo();
        modalInfo.Title = windowCaption + " !  " + title;
        modalInfo.Width = 500;
        modalInfo.Height = 300;
        modalInfo.IsShowCloseButton = false;

        let promise = new Promise<string>(function (resolve, reject) {
            let modalService: IModalService = ServiceLocator.Injector.get(IModalService, [ServiceLocator.Compiler]);
            let result = modalService.create(componentInfo, modalInfo);
            result.then(res => {
                let modalActionResult: any = res.Param;
                if (modalActionResult != undefined) {
                    resolve(modalActionResult);
                }
            })
                .catch(err => {
                    reject(err);
                });
        });

        return promise;
    }

    public static FourShow(boxType: ShowBoxTypeEnum, buttonCaptions: string, returnValues: string, windowCaption: string, title: string, value: string, DefaultButton: number): Promise<string> {
        let model: ShowBoxModel = new ShowBoxModel();
        let buttonCap: Array<string> = new Array<string>();
        buttonCaptions = buttonCaptions.replace("&", "");
        buttonCap = buttonCaptions.split(",");
        model.okButtonCaption = buttonCap[0];
        model.cancelButtonCaption = buttonCap[1].replace("&", "");
        model.applyButtonCaption = buttonCap[2].replace("&", "");
        model.extraButtonCaption = buttonCap[3].replace("&", "");
        let retValues: Array<string> = new Array<string>();
        retValues = returnValues.split(",");
        model.okRetValue = retValues[0];
        model.cancelRetValue = retValues[1];
        model.applyRetValue = retValues[2];
        model.extraRetValue = retValues[3];
        model.title = title;
        model.value = value;

        let componentInfo = new DynamicComponentInfo();
        componentInfo.ComponentName = "FourShowBoxComponent";
        componentInfo.ModuleName = "CoreModule";
        componentInfo.ModulePath = "/app/Fw/CoreModule";
        componentInfo.InputParam = model;

        let modalInfo: ModalInfo = new ModalInfo();
        modalInfo.Title = windowCaption + " !  " + title;
        modalInfo.Width = 700;
        modalInfo.Height = 300;
        modalInfo.IsShowCloseButton = false;

        let promise = new Promise<string>(function (resolve, reject) {
            let modalService: IModalService = ServiceLocator.Injector.get(IModalService, [ServiceLocator.Compiler]);
            let result = modalService.create(componentInfo, modalInfo);
            result.then(res => {
                let modalActionResult: any = res.Param;
                if (modalActionResult != undefined) {
                    resolve(modalActionResult);
                }
            })
                .catch(err => {
                    reject(err);
                });
        });

        return promise;
    }
    public static CustomShow(boxType: ShowBoxTypeEnum, buttonCaptions: string, returnValues: string, windowCaption: string, title: string, value: string, DefaultButton: number): Promise<string> {
        let model: CustomShowBoxModel = new CustomShowBoxModel();
        let buttons: Array<CustomButtons> = new Array<CustomButtons>();
        let buttonCaptionList = buttonCaptions.split(",");
        let buttonValueList = returnValues.split(",");
        for (let i = 0; i < buttonCaptionList.length; i++) {
            let button: CustomButtons = new CustomButtons();
            button.buttonCaption = buttonCaptionList[i].replace("&", "");
            if (buttonValueList.length > i)
                button.buttonValue = buttonValueList[i];
            else
                button.buttonValue = "V" + i;

            buttons.push(button);
        }

        model.title = title;
        model.value = value;
        model.buttons = buttons;

        let componentInfo = new DynamicComponentInfo();
        componentInfo.ComponentName = "CustomShowBoxComponent";
        componentInfo.ModuleName = "CoreModule";
        componentInfo.ModulePath = "/app/Fw/CoreModule";
        componentInfo.InputParam = model;
 

        let modalInfo: ModalInfo = new ModalInfo();
        modalInfo.Title = windowCaption + " !  " + title;
        modalInfo.Width = 700;
        modalInfo.Height = 300;
        modalInfo.IsShowCloseButton = false;

        let promise = new Promise<string>(function (resolve, reject) {
            let modalService: IModalService = ServiceLocator.Injector.get(IModalService, [ServiceLocator.Compiler]);
            let result = modalService.create(componentInfo, modalInfo);
            result.then(res => {
                let modalActionResult: any = res.Param;
                if (modalActionResult != undefined) {
                    resolve(modalActionResult);
                }
            })
                .catch(err => {
                    reject(err);
                });
        });

        return promise;
    }

    private static ParseString(value: string, parsedValue: any): void {
        //parsedValue[0];
        //var num: number;
        //do {
        //    num = value.IndexOf(value, ",");
        //    var flag: boolean = num >= 0;
        //    if (flag) {
        //        parsedValue[0].Add(NString.Substring(value, 0, num));
        //        value = NString.Substring(value, num + 1);
        //    }
        //    else {
        //        parsedValue[0].Add(value);
        //    }
        //}
        //while (num >= 0);
    }
}