import { DateTime } from 'NebulaClient/System/Time/DateTime';
import { ComboListItem } from './ComboListItem';
import { DynamicComponentInfo } from 'Fw/Models/DynamicComponentInfo';
import { IModalService } from 'Fw/Services/IModalService';
import { InputFormModel } from 'Fw/Models/InputFormModel';
import { ServiceLocator } from 'Fw/Services/ServiceLocator';
import { ModalInfo } from 'Fw/Models/ModalInfo';

export class InputForm {
    static GetDateTime(windowCaption: string): Promise<Date>;
    static GetDateTime(windowCaption: string, currentValue: DateTime): Promise<Date>;
    static GetDateTime(windowCaption: string, maskInput: string): Promise<Date>;
    static GetDateTime(windowCaption: string, maskInput: string, UseExpireDate: boolean): Promise<Date>;
    static GetDateTime(windowCaption: string, currentValue: DateTime, maskInput: string, ForceToChoose: boolean): Promise<Date>;
    static GetDateTime(windowCaption: string, currentValueOrMaskInput?: any, UseExpireDateOrMaskInput?: any, ForceToChoose?: boolean): Promise<Date> {
        if (arguments.length === 1 && (windowCaption === null || windowCaption.constructor === String)) {
            return InputForm.GetDateTime_0(windowCaption);
        }
        if (arguments.length === 2 && (windowCaption === null || windowCaption.constructor === String) && (currentValueOrMaskInput === null || currentValueOrMaskInput instanceof DateTime)) {
            return InputForm.GetDateTime_1(windowCaption, currentValueOrMaskInput);
        }
        if (arguments.length === 2 && (windowCaption === null || windowCaption.constructor === String) && (currentValueOrMaskInput === null || currentValueOrMaskInput.constructor === String)) {
            return InputForm.GetDateTime_2(windowCaption, currentValueOrMaskInput);
        }
        if (arguments.length === 3 && (windowCaption === null || windowCaption.constructor === String)
            && (currentValueOrMaskInput === null || currentValueOrMaskInput.constructor === String) && (UseExpireDateOrMaskInput === null || UseExpireDateOrMaskInput.constructor === Boolean)) {
            return InputForm.GetDateTime_3(windowCaption, currentValueOrMaskInput, UseExpireDateOrMaskInput);
        }
        return InputForm.GetDateTime_4(windowCaption, currentValueOrMaskInput, UseExpireDateOrMaskInput, ForceToChoose);
    }
    private static GetDateTime_0(windowCaption: string): Promise<Date> {
        return InputForm.GetDateTimeInternal(windowCaption, null, '', false, false);
    }
    private static GetDateTime_1(windowCaption: string, currentValue: DateTime): Promise<Date> {
        return InputForm.GetDateTimeInternal(windowCaption, new DateTime(currentValue), '', false, false);
    }
    private static GetDateTime_2(windowCaption: string, maskInput: string): Promise<Date> {
        return InputForm.GetDateTimeInternal(windowCaption, null, maskInput, false, false);
    }
    private static GetDateTime_3(windowCaption: string, maskInput: string, UseExpireDate: boolean): Promise<Date> {
        return InputForm.GetDateTimeInternal(windowCaption, null, maskInput, false, UseExpireDate);
    }
    private static GetDateTime_4(windowCaption: string, currentValue: DateTime, maskInput: string, ForceToChoose: boolean): Promise<Date> {
        return InputForm.GetDateTimeInternal(windowCaption, new DateTime(currentValue), maskInput, ForceToChoose, false);
    }
    static async GetDateTimeInternal(windowCaption: string, currentValue: any, maskInput: string, ForceToChoose: boolean, UseExpireDate: boolean): Promise<Date> {
        let componentInfo = new DynamicComponentInfo();
        componentInfo.ComponentName = 'GetDateComponent';
        componentInfo.ModuleName = 'CoreModule';
        componentInfo.ModulePath = '/app/Fw/CoreModule';
        componentInfo.InputParam = this;

        let modalInfo: ModalInfo = new ModalInfo();
        modalInfo.Title = windowCaption;
        modalInfo.Width = 300;
        modalInfo.Height = 150;

        let promise = new Promise<Date>(function (resolve, reject) {
            let modalService: IModalService = ServiceLocator.Injector.get(IModalService, [ServiceLocator.Compiler]);
            let result = modalService.create(componentInfo, modalInfo);
            result.then(res => {
                let modalActionResult: any = res.Param;
                if (modalActionResult !== undefined) {
                    resolve(modalActionResult);
                }
            }).catch(err => {
                reject(err);
            });
        });
        return promise;
    }

    public static async GetDateTimeCustom(windowCaption: string, maskInput: string): Promise<Date> {
        let model: InputFormModel = new InputFormModel();
        model.dateType = maskInput;
        let componentInfo = new DynamicComponentInfo();
        componentInfo.ComponentName = 'GetDateComponent';
        componentInfo.ModuleName = 'CoreModule';
        componentInfo.ModulePath = '/app/Fw/CoreModule';
        componentInfo.InputParam = model;

        let modalInfo: ModalInfo = new ModalInfo();
        modalInfo.Title = windowCaption;
        modalInfo.Width = 300;
        modalInfo.Height = 150;

        let promise = new Promise<Date>(function (resolve, reject) {
            let modalService: IModalService = ServiceLocator.Injector.get(IModalService, [ServiceLocator.Compiler]);
            let result = modalService.create(componentInfo, modalInfo);
            result.then(res => {
                let modalActionResult: any = res.Param;
                if (modalActionResult !== undefined) {
                    resolve(modalActionResult);
                }
            }).catch(err => {
                reject(err);
            });
        });
        return promise;
    }

    static GetText(windowCaption: string): Promise<string>;
    static GetText(windowCaption: string, ForceToChoose: boolean): Promise<string>;
    static GetText(windowCaption: string, currentValue: string): Promise<string>;
    static GetText(windowCaption: string, currentValue: string, ForceToChoose: boolean): Promise<string>;
    static GetText(windowCaption: string, currentValue: string, ForceToChoose: boolean, multiLine: boolean): Promise<string>;
    static GetText(windowCaption: string, currentValue: string, ForceToChoose: boolean, multiLine: boolean, selectCommandText: string): Promise<string>;
    static GetText(windowCaption: string, ForceToChooseOrCurrentValue?: any, ForceToChoose?: boolean, multiLine?: boolean, selectCommandText?: string): Promise<string> {
        if (arguments.length === 1 && (windowCaption === null || windowCaption.constructor === String)) {
            return InputForm.GetText_0(windowCaption);
        }
        if (arguments.length === 2 && (windowCaption === null || windowCaption.constructor === String)
            && (ForceToChooseOrCurrentValue === null || ForceToChooseOrCurrentValue.constructor === Boolean)) {
            return InputForm.GetText_1(windowCaption, ForceToChooseOrCurrentValue);
        }
        if (arguments.length === 2 && (windowCaption === null || windowCaption.constructor === String)
            && (ForceToChooseOrCurrentValue === null || ForceToChooseOrCurrentValue.constructor === String)) {
            return InputForm.GetText_2(windowCaption, ForceToChooseOrCurrentValue);
        }
        if (arguments.length === 3 && (windowCaption === null || windowCaption.constructor === String)
            && (ForceToChooseOrCurrentValue === null || ForceToChooseOrCurrentValue.constructor === String)
            && (ForceToChoose === null || ForceToChoose.constructor === Boolean)) {
            return InputForm.GetText_3(windowCaption, ForceToChooseOrCurrentValue, ForceToChoose);
        }
        if (arguments.length === 4 && (windowCaption === null || windowCaption.constructor === String)
            && (ForceToChooseOrCurrentValue === null || ForceToChooseOrCurrentValue.constructor === String)
            && (ForceToChoose === null || ForceToChoose.constructor === Boolean) && (multiLine === null || multiLine.constructor === Boolean)) {
            return InputForm.GetText_4(windowCaption, ForceToChooseOrCurrentValue, ForceToChoose, multiLine);
        }
        return InputForm.GetText_5(windowCaption, ForceToChooseOrCurrentValue, ForceToChoose, multiLine, selectCommandText);
    }
    private static GetText_0(windowCaption: string): Promise<string> {
        return InputForm.GetText(windowCaption, null, false);
    }
    private static GetText_1(windowCaption: string, ForceToChoose: boolean): Promise<string> {
        return InputForm.GetText(windowCaption, null, ForceToChoose);
    }
    private static GetText_2(windowCaption: string, currentValue: string): Promise<string> {
        return InputForm.GetText(windowCaption, currentValue, false);
    }
    private static GetText_3(windowCaption: string, currentValue: string, ForceToChoose: boolean): Promise<string> {
        return InputForm.GetText(windowCaption, currentValue, false, false);
    }
    private static GetText_4(windowCaption: string, currentValue: string, ForceToChoose: boolean, multiLine: boolean): Promise<string> {
        return InputForm.GetText(windowCaption, currentValue, ForceToChoose, multiLine, null);
    }
    private static async GetText_5(windowCaption: string, currentValue: string, ForceToChoose: boolean, multiLine: boolean, selectCommandText: string): Promise<string> {
        if (multiLine === false) {
            let componentInfo = new DynamicComponentInfo();
            componentInfo.ComponentName = 'GetTextComponent';
            componentInfo.ModuleName = 'CoreModule';
            componentInfo.ModulePath = '/app/Fw/CoreModule';
            componentInfo.InputParam = this;

            let modalInfo: ModalInfo = new ModalInfo();
            modalInfo.Title = windowCaption;
            modalInfo.Width = 300;
            modalInfo.Height = 150;

            let promise = new Promise<string>(function (resolve, reject) {
                let modalService: IModalService = ServiceLocator.Injector.get(IModalService, [ServiceLocator.Compiler]);
                let result = modalService.create(componentInfo, modalInfo);
                result.then(res => {
                    let modalActionResult: any = res.Param;
                    if (modalActionResult !== undefined) {
                        resolve(modalActionResult);
                    }
                }).catch(err => {
                    reject(err);
                });
            });
            return promise;
        } else {
            let componentInfo = new DynamicComponentInfo();
            componentInfo.ComponentName = 'GetTextComponentMultiple';
            componentInfo.ModuleName = 'CoreModule';
            componentInfo.ModulePath = '/app/Fw/CoreModule';
            componentInfo.InputParam = this;

            let modalInfo: ModalInfo = new ModalInfo();
            modalInfo.Title = windowCaption;
            modalInfo.Width = 300;
            modalInfo.Height = 180;

            let promise = new Promise<string>(function (resolve, reject) {
                let modalService: IModalService = ServiceLocator.Injector.get(IModalService, [ServiceLocator.Compiler]);
                let result = modalService.create(componentInfo, modalInfo);
                result.then(res => {
                    let modalActionResult: any = res.Param;
                    if (modalActionResult !== undefined) {
                        resolve(modalActionResult);
                    }
                })
                    .catch(err => {
                        reject(err);
                    });
            });
            return promise;
        }
    }

    static GetValueListItem(windowCaption: string, comboListItems: ComboListItem[]): Promise<ComboListItem>;
    static GetValueListItem(windowCaption: string, comboListItems: ComboListItem[], selectedIndex: number): Promise<ComboListItem>;
    static GetValueListItem(windowCaption: string, comboListItems: ComboListItem[], selectedIndex: number, forceToChoose: boolean): Promise<ComboListItem>;
    static GetValueListItem(windowCaption: string, comboListItems: any, selectedIndex?: number, forceToChoose?: boolean): Promise<ComboListItem> {
        if (arguments.length === 2 && (windowCaption === null || windowCaption.constructor === String) && (comboListItems === null || comboListItems instanceof Array)) {
            return InputForm.GetValueListItem_0(windowCaption, comboListItems);
        }
        if (arguments.length === 3 && (windowCaption === null || windowCaption.constructor === String)
            && (comboListItems === null || comboListItems instanceof Array) && (selectedIndex === null || selectedIndex.constructor === Number)) {
            return InputForm.GetValueListItem_1(windowCaption, comboListItems, selectedIndex);
        }
        return InputForm.GetValueListItem_2(windowCaption, comboListItems, selectedIndex, forceToChoose);
    }

    private static GetValueListItem_0(windowCaption: string, comboListItems: ComboListItem[]): Promise<ComboListItem> {
        return InputForm.GetValueListItemInternal(windowCaption, comboListItems, 0, false);
    }

    private static GetValueListItem_1(windowCaption: string, comboListItems: ComboListItem[], selectedIndex: number): Promise<ComboListItem> {
        return InputForm.GetValueListItemInternal(windowCaption, comboListItems, selectedIndex, false);
    }

    private static GetValueListItem_2(windowCaption: string, comboListItems: ComboListItem[], selectedIndex: number, forceToChoose: boolean): Promise<ComboListItem> {
        return InputForm.GetValueListItemInternal(windowCaption, comboListItems, selectedIndex, forceToChoose);
    }

    static async GetValueListItemInternal(windowCaption: string, comboListItems: ComboListItem[], selectedIndex: number, forceToChoose: boolean): Promise<ComboListItem> {
        let model: InputFormModel = new InputFormModel();
        model.list = comboListItems;
        let componentInfo = new DynamicComponentInfo();
        componentInfo.ComponentName = 'GetValueListComponent';
        componentInfo.ModuleName = 'CoreModule';
        componentInfo.ModulePath = '/app/Fw/CoreModule';
        componentInfo.InputParam = model;

        let modalInfo: ModalInfo = new ModalInfo();
        modalInfo.Title = windowCaption;
        modalInfo.Width = 300;
        modalInfo.Height = 150;

        let promise = new Promise<ComboListItem>(function (resolve, reject) {
            let modalService: IModalService = ServiceLocator.Injector.get(IModalService, [ServiceLocator.Compiler]);
            let result = modalService.create(componentInfo, modalInfo);
            result.then(res => {
                let modalActionResult: any = res.Param as ComboListItem;
                if (modalActionResult !== undefined) {
                    resolve(modalActionResult);
                }
            }).catch(err => {
                reject(err);
            });
        });
        return promise;
    }
}