import { ServiceLocator } from 'Fw/Services/ServiceLocator';
import { ModalInfo, ModalActionResult } from "Fw/Models/ModalInfo";
import { DynamicComponentInfo } from "Fw/Models/DynamicComponentInfo";
import { IModalService } from "Fw/Services/IModalService";
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";

export class UsernamePwdBox {

    //public Name: string = "";
    /*getMkysUsernameOnInit true MKYS kullanıcı adını otomatik olarak çekmek için. (Stok tarafı). Normal dinamik kullanım için
    getMkysUsernameOnInit false verilip input taki model doldurulmalıdır.
    */
    public static async Show(isMkys: boolean, input: UsernamePwdInput = null): Promise<Object> {

        if (isMkys)
            input = new UsernamePwdInput();

        if (input != null) {
            let componentInfo = new DynamicComponentInfo();
            componentInfo.ComponentName = "UsernamePwdFormComponent";
            componentInfo.ModuleName = "CoreModule";
            componentInfo.ModulePath = "/app/Fw/CoreModule";
            componentInfo.InputParam = input;

            let modalInfo: ModalInfo = new ModalInfo();
            modalInfo.Title = input.Title;
            modalInfo.Width = 300;
            modalInfo.Height = 300;

            let promise = new Promise<Object>(function (resolve, reject) {
                let modalService: IModalService = ServiceLocator.Injector.get(IModalService, [ServiceLocator.Compiler]);
                let result = modalService.create(componentInfo, modalInfo);
                result.then(res => {
                    let modalActionResult: ModalActionResult = res;
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
        else
            TTVisual.InfoBox.Alert('UsernamePwdInput modelini doldurup kullanınız! MKYS için getMkysUsernameOnInit parametresi true diğer durumlar için false olmalı');
    }
}

export class UsernamePwdInput {
    public GetMkysUsernameOnInit: boolean = true;       //Kullanıcı adı olarak Mkys numarasının otomatik gelmesi için true set edilmelidir.
    public GetUserUniqueRefNoOnInit: boolean = false;   //Kullanıcı adı olarak T.C. Kimlik numarasının otomatik gelmesi için true set edilmelidir. Bu parametre true ise GetMkysUsernameOnInit false olmalıdır.
    public SessionStoragePwdName = 'MkysPwd';
    public SessionStorageUsername = 'MkysUserName';
    public Title = 'MKYS Kullanıcı Adı - Şifre';
    public doNotOpenSavedScreen: boolean = false;       //Kaydedilen şifre üzerinden ekran tekrar açılmasın.
}