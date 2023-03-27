//$C9768FA1
import { Exception } from '../System/Exception';
import { MessageIconEnum } from '../Utils/Enums/MessageIconEnum';
import { DynamicComponentInfo } from 'Fw/Models/DynamicComponentInfo';
import { IModalService } from 'Fw/Services/IModalService';
import { ServiceLocator } from 'Fw/Services/ServiceLocator';
import { ModalInfo } from 'Fw/Models/ModalInfo';

export class InfoBox {
    public static _myException: string = '';
    public static message: string;
    public static messageDetails: string = '';
    public static msgType: MessageIconEnum;
    public static width: number = null;
    public static height: number = null;
    static Alert(ex: Exception): void;
    static Alert(messageHeader: string, ex: Exception): void;
    static Alert(message: string): void;
    static Alert(message: string, msgType: MessageIconEnum): void;
    static Alert(message: string, messageDetails: string, msgType: MessageIconEnum, height?: number, width?: number): void;
    static Alert(exOrMessageHeader: any, exOrMsgTypeOrMessageDetails?: any, msgType?: MessageIconEnum, height?: number, width?: number): void{
        if (arguments.length === 1 && (exOrMessageHeader === null || exOrMessageHeader instanceof Exception)) {
            InfoBox.Alert_0(exOrMessageHeader);
            return;
        }
        if (arguments.length === 2 && (exOrMessageHeader === null || exOrMessageHeader.constructor === String)
         && (exOrMsgTypeOrMessageDetails === null || exOrMsgTypeOrMessageDetails instanceof Exception)) {
            InfoBox.Alert_1(exOrMessageHeader, exOrMsgTypeOrMessageDetails);
            return;
        }
        if (arguments.length === 1 && (exOrMessageHeader === null || exOrMessageHeader.constructor === String)) {
            InfoBox.Alert_2(exOrMessageHeader);
            return;
        }
        if (arguments.length === 2 && (exOrMessageHeader === null || exOrMessageHeader.constructor === String) && (exOrMsgTypeOrMessageDetails === null)) {
            InfoBox.Alert_3(exOrMessageHeader, exOrMsgTypeOrMessageDetails);
            return;
        }
        InfoBox.Alert_4(exOrMessageHeader, exOrMsgTypeOrMessageDetails, msgType, height, width);
    }
    private static Alert_0(ex: Exception): void {
        InfoBox.Alert(ex);
    }
    private static Alert_1(messageHeader: string, ex: Exception): void {
        InfoBox.Alert(messageHeader, ex);
    }
    private static Alert_2(message: string): void {
        InfoBox.Alert(message, 0);
    }
    private static Alert_3(message: string, msgType: MessageIconEnum): void {
        InfoBox._myException = message;
        InfoBox.ShowMessageInternal(null, message, '', msgType);
    }
    private static Alert_4(message: string, messageDetails: string, msgType: MessageIconEnum, height: number = null, width: number = null): void {
        InfoBox.ShowMessageInternal(null, message, messageDetails, msgType, height, width );
    }

    static Show(ex: Exception): void;
    static Show(messageHeader: string, ex: Exception): void;
    static Show(message: string): void;
    static Show(message: string, msgType: MessageIconEnum): void;
    static Show(message: string, messageDetails: string, msgType: MessageIconEnum): void;
    static Show(parent: Object, ex: Exception): void;
    static Show(parent: Object, messageHeader: string, ex: Exception): void;
    static Show(parent: Object, message: string): void;
    static Show(parent: Object, message: string, msgType: MessageIconEnum): void;
    static Show(parent: Object, message: string, messageDetails: string, msgType: MessageIconEnum): void;
    static Show(exOrMessageHeaderOrParent: any, exOrMsgTypeOrMessageDetailsOrMessageHeader?: any, msgTypeOrExOrMessageDetails?: any, msgType?: MessageIconEnum): void {
        if (arguments.length === 1 && (exOrMessageHeaderOrParent === null || exOrMessageHeaderOrParent instanceof Exception)) {
            InfoBox.Show_0(exOrMessageHeaderOrParent);
            return;
        }
        if (arguments.length === 2 && (exOrMessageHeaderOrParent === null || exOrMessageHeaderOrParent.constructor === String)
         && (exOrMsgTypeOrMessageDetailsOrMessageHeader === null || exOrMsgTypeOrMessageDetailsOrMessageHeader instanceof Exception)) {
            InfoBox.Show_1(exOrMessageHeaderOrParent, exOrMsgTypeOrMessageDetailsOrMessageHeader);
            return;
        }
        if (arguments.length === 1 && (exOrMessageHeaderOrParent === null || exOrMessageHeaderOrParent.constructor === String)) {
            InfoBox.Show_2(exOrMessageHeaderOrParent);
            return;
        }
        if (arguments.length === 2 && (exOrMessageHeaderOrParent === null || exOrMessageHeaderOrParent.constructor === String)
        && (exOrMsgTypeOrMessageDetailsOrMessageHeader === null)) {
            InfoBox.Show_3(exOrMessageHeaderOrParent, exOrMsgTypeOrMessageDetailsOrMessageHeader);
            return;
        }
        if (arguments.length === 3 && (exOrMessageHeaderOrParent === null || exOrMessageHeaderOrParent.constructor === String)
         && (exOrMsgTypeOrMessageDetailsOrMessageHeader === null || exOrMsgTypeOrMessageDetailsOrMessageHeader.constructor === String) && (msgTypeOrExOrMessageDetails === null)) {
            InfoBox.Show_4(exOrMessageHeaderOrParent, exOrMsgTypeOrMessageDetailsOrMessageHeader, msgTypeOrExOrMessageDetails);
            return;
        }
        if (arguments.length === 2 && (exOrMessageHeaderOrParent === null || exOrMessageHeaderOrParent instanceof Object)
         && (exOrMsgTypeOrMessageDetailsOrMessageHeader === null || exOrMsgTypeOrMessageDetailsOrMessageHeader instanceof Exception)) {
            InfoBox.Show_5(exOrMessageHeaderOrParent, exOrMsgTypeOrMessageDetailsOrMessageHeader);
            return;
        }
        if (arguments.length === 3 && (exOrMessageHeaderOrParent === null || exOrMessageHeaderOrParent instanceof Object)
        && (exOrMsgTypeOrMessageDetailsOrMessageHeader === null || exOrMsgTypeOrMessageDetailsOrMessageHeader.constructor === String)
         && (msgTypeOrExOrMessageDetails === null || msgTypeOrExOrMessageDetails instanceof Exception)) {
            InfoBox.Show_6(exOrMessageHeaderOrParent, exOrMsgTypeOrMessageDetailsOrMessageHeader, msgTypeOrExOrMessageDetails);
            return;
        }
        if (arguments.length === 2 && (exOrMessageHeaderOrParent === null || exOrMessageHeaderOrParent instanceof Object)
        && (exOrMsgTypeOrMessageDetailsOrMessageHeader === null || exOrMsgTypeOrMessageDetailsOrMessageHeader.constructor === String)) {
            InfoBox.Show_7(exOrMessageHeaderOrParent, exOrMsgTypeOrMessageDetailsOrMessageHeader);
            return;
        }
        if (arguments.length === 3 && (exOrMessageHeaderOrParent === null || exOrMessageHeaderOrParent instanceof Object)
        && (exOrMsgTypeOrMessageDetailsOrMessageHeader === null || exOrMsgTypeOrMessageDetailsOrMessageHeader.constructor === String) && (msgTypeOrExOrMessageDetails === null)) {
            InfoBox.Show_8(exOrMessageHeaderOrParent, exOrMsgTypeOrMessageDetailsOrMessageHeader, msgTypeOrExOrMessageDetails);
            return;
        }
        InfoBox.Show_9(exOrMessageHeaderOrParent, exOrMsgTypeOrMessageDetailsOrMessageHeader, msgTypeOrExOrMessageDetails, msgType);
    }
    private static Show_0(ex: Exception): void {
        InfoBox.Show(null, ex);
    }
    private static Show_1(messageHeader: string, ex: Exception): void {
        InfoBox.Show(messageHeader, ex);
    }
    private static Show_2(message: string): void {
        InfoBox.Show(message, 0);
    }
    private static Show_3(message: string, msgType: MessageIconEnum): void {
        InfoBox._myException = message;
        InfoBox.ShowMessageInternalv2(null, message, '', msgType);
    }
    private static Show_4(message: string, messageDetails: string, msgType: MessageIconEnum): void {

        InfoBox.ShowMessageInternalv2(null, message, messageDetails, msgType);
    }

    private static Show_5(parent: Object, ex: Exception): void {
        InfoBox.ShowMessageInternalv2(parent, ex.toString(), ex.toString(), 0);
    }

    private static Show_6(parent: Object, messageHeader: string, ex: Exception): void {
        InfoBox.Show(parent, new Exception(messageHeader, ex));
    }
    private static Show_7(parent: Object, message: string): void {
        InfoBox.Show(parent, message, 0);
    }
    private static Show_8(parent: Object, message: string, msgType: MessageIconEnum): void {
        InfoBox._myException = message;
        InfoBox.ShowMessageInternalv2(parent, message, '', msgType);
    }
    private static Show_9(parent: Object, message: string, messageDetails: string, msgType: MessageIconEnum): void {
        InfoBox.ShowMessageInternalv2(parent, message, messageDetails, msgType);
    }

    private static ShowMessageInternalv2(parent: Object, message: string, messageDetails: string, msgType: MessageIconEnum): void {
        this.message = message;
        this.messageDetails = messageDetails;
        this.msgType = msgType;
        let componentInfo = new DynamicComponentInfo();
        componentInfo.ComponentName = 'InfoBoxComponent';
        componentInfo.ModuleName = 'CoreModule';
        componentInfo.ModulePath = '/app/Fw/CoreModule';
        componentInfo.InputParam = this;

        let modalInfo: ModalInfo = new ModalInfo();
        modalInfo.Title = message;
        modalInfo.Width = 500;
        modalInfo.Height = 200;
        modalInfo.AllowMultiple = true;

        let modalService: IModalService = ServiceLocator.Injector.get(IModalService, [ServiceLocator.Compiler]);
        let result = modalService.create(componentInfo, modalInfo);
    }
    public static async CustomShow(message: string, messageDetails: string): Promise<string> {
        this.message = message;
        this.messageDetails = messageDetails;
        this.msgType = MessageIconEnum.InformationMessage;

        let componentInfo = new DynamicComponentInfo();
        componentInfo.ComponentName = 'InfoBoxComponent';
        componentInfo.ModuleName = 'CoreModule';
        componentInfo.ModulePath = '/app/Fw/CoreModule';
        componentInfo.InputParam = this;

        let modalInfo: ModalInfo = new ModalInfo();
        modalInfo.Title = message;
        modalInfo.Width = 500;
        modalInfo.Height = 200;

        let promise = new Promise<string>(function (resolve, reject) {
            let modalService: IModalService = ServiceLocator.Injector.get(IModalService, [ServiceLocator.Compiler]);
            let result = modalService.create(componentInfo, modalInfo);
            result.then(res => {
                let modalActionResult: any = res.Param;
                if (modalActionResult != undefined) {
                    resolve('OK');
                }
            })
                .catch(err => {
                    reject(err);
                });
        });

        return promise;
    }
    private static ShowMessageInternal(parent: Object, message: string, messageDetails: string, msgType: MessageIconEnum, height?: number , width?: number): void {
        if (messageDetails == undefined || messageDetails.toString() == "0") {
            messageDetails = message;
            message = i18n("M23736", "Uyarı !");
        }
        this.message = message;
        this.messageDetails = messageDetails;
        this.msgType = msgType;
        let componentInfo = new DynamicComponentInfo();
        componentInfo.ComponentName = 'InfoBoxComponent';
        componentInfo.ModuleName = 'CoreModule';
        componentInfo.ModulePath = '/app/Fw/CoreModule';
        componentInfo.InputParam = this;

        let modalInfo: ModalInfo = new ModalInfo();
        modalInfo.Title = message;
        modalInfo.AllowMultiple = true;
        if (height == null)
            modalInfo.Height = 200;
        else
            modalInfo.Height = height;

        if (width == null)
            modalInfo.Width = 500;
        else
            modalInfo.Width = width;





        let modalService: IModalService = ServiceLocator.Injector.get(IModalService, [ServiceLocator.Compiler]);
        let result = modalService.create(componentInfo, modalInfo);
    }
}