import { Component, ViewChild, OnInit } from '@angular/core';
import { IModal, ModalStateService, ModalInfo } from 'Fw/Models/ModalInfo';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { Guid } from 'app/NebulaClient/Mscorlib/Guid';
import * as TTVisual from 'NebulaClient/Visual/TTVisualControlInterfaces';
import { LogDataSource } from 'Modules/Core_Destek_Modulleri/Log_Modulu/AuditQueryFormViewModel';
import { ServiceLocator } from 'app/Fw/Services/ServiceLocator';
import { Type } from 'NebulaClient/ClassTransformer';
import { SystemApiService } from 'app/Fw/Services/SystemApiService';
import { MessageService } from 'app/Fw/Services/MessageService';
import { DynamicComponentInfo } from 'app/Fw/Models/DynamicComponentInfo';
import { IAuditObjectService, AuditObject } from 'app/Fw/Services/IAuditObjectService';
import { IModalService } from 'app/Fw/Services/IModalService';
import DateTime from 'app/NebulaClient/System/Time/DateTime';

@Component({
    selector: "kioskSurveyDefinition-component",
    templateUrl: './KioskSurveyDefinition.html',
    providers: [SystemApiService, MessageService]


})
export class KioskSurveyDefinition implements IModal {
    public loadingVisible: boolean = false;
    public LoadPanelMessage: string = "İşleminiz Yapılıyor Lütfen Bekleyiniz..";
    public surveyDefinitionListDTOs: Array<SurveyDefinitionListDTO> = new Array<SurveyDefinitionListDTO>();
    public selectedSurveyDefinitionItem: SurveyDefinitionListDTO;

    public activeSurveyDefinitionItem: SurveyDefinitionOutputItem = new SurveyDefinitionOutputItem();
    public activeSurveyDefinitionItemDetail: Array<SurveyQuestion> = new Array<SurveyQuestion>();

    public newQuestionDataSoruce: Array<NewQuestionDataSource> = new Array<NewQuestionDataSource>();

    public selectedItemFromOpen: boolean = false;
    public lastUpdateDate: Date;
    public lastUpdateUser: string;
    public creationDate: Date;
    public creationUser: string;
    public selectionGridObjectID: any;
    public isActive: boolean;
public isReadOnlyForm:boolean;
    public IsNewQestion: boolean = false;
    public newQuestionName: string;
    public newQuestionOrder: number;
    public newQuestionDesciption: string;


    constructor(private http: NeHttpService) {
        this.getAllSurveyDefinition();
    }

    public async getDetailAudit() {
        let that = this;
        return new Promise((resolve, reject) => {

            let componentInfo = new DynamicComponentInfo();
            componentInfo.ComponentName = 'ShowAuditForm';
            componentInfo.ModuleName = 'LogModule';
            componentInfo.ModulePath = '/Modules/Core_Destek_Modulleri/Log_Modulu/LogModule';
            const auditService = ServiceLocator.Injector.get(IAuditObjectService);
            auditService.ObjectIDList.Clear();
            let auditObject: AuditObject = new AuditObject;
            auditObject.AuditObjectID = this.activeSurveyDefinitionItem.ObjectID;
            auditObject.AuditObjectDefID = new Guid("f309df79-7e30-46bf-a1c0-6d69ff0c627a");
            auditService.ObjectIDList.push(auditObject);
            componentInfo.InputParam = auditService.ObjectIDList;

            let modalInfo: ModalInfo = new ModalInfo();
            modalInfo.Title = 'İşlem Tarihçesi';
            modalInfo.Width = 1300;
            modalInfo.Height = 750;

            const modalService = ServiceLocator.Injector.get(IModalService);
            let result = modalService.create(componentInfo, modalInfo);
            result.then(inner => {
                resolve(inner);
            }).catch(err => {
                reject(err);
            });
        });

    }


    private collapseAttr = 0;
    public collapseSelectedDivProperties(): string {
        if (this.collapseAttr == 1) {
            return "hidden";
        }
        return "col-md-3";

    }
    public collapseIconProperties(): string {

        if (this.collapseAttr == 1) {
            return "fa fa-2x fa-angle-up";
        }
        return "fa fa-2x fa-angle-left";

    }

    btnCollapse() {
        if (this.collapseAttr == 1) {
            this.collapseAttr = 0;
        } else
            this.collapseAttr = 1;
    }
    public collapseBtnProperties(): string {

        if (this.collapseAttr == 1) {
            return "float-left";
        }
        return "float-right";

    }

    public collapsedPanelProperties(): string {

        if (this.collapseAttr == 1) {
            return "col-md-11 episodeColMd11 col-sm-12 col-xs-12";
        }
        return "col-md-9";

    }

    public collapseSelectedHiddenDivProperties(): string {

        if (this.collapseAttr == 1) {
            return "col-md-1 episodeColMd1 col-sm-12 col-xs-12";
        }
        return "hidden";

    }

    public async setInputParam(value: Object) {
    }

    public setModalInfo(value: ModalInfo) {
    }

    public cancelClick(): void {
    }

    public okClick(): void {
    }

    surveyDefinitionColumn = [
        {
            caption: 'ObjectID',
            dataField: 'ObjectID',
            visible: false,
        },
        {
            caption: 'Anket Adı',
            dataField: 'Name',
            width: 300,
            sortOrder: 'desc',
        },
        {
            caption: "Aktif",
            dataField: 'IsActive',
            dataType: 'boolean',
            width: 'auto',
        }
    ];


    async selectGridRow(value: any): Promise<void> {
        let component = value.component,
            prevClickTime = component.lastClickTime;
        component.lastClickTime = new Date();
        if (prevClickTime && (component.lastClickTime - prevClickTime < 300)) {
            this.loadingVisible = true;
            this.selectedItemFromOpen = true;
            let input: GetSurveyDefinition_Input = new GetSurveyDefinition_Input();
            input.ObjectID = value.data.ObjectID;

            let that= this;
            let fullApiUrl: string = 'api/KioskSurveyDefinition/getSurveyDefinitionItem';
            that.http.post<SurveyDefinitionOutputItem>(fullApiUrl, input)
                .then((res) => {
                    that.activeSurveyDefinitionItem = res as SurveyDefinitionOutputItem;
                    that.activeSurveyDefinitionItemDetail = that.activeSurveyDefinitionItem.SurveyQuestions;
                    that.isActive = that.activeSurveyDefinitionItem.IsActive;
                    that.isReadOnlyForm = res.isReadOnlyForm;
                    debugger;

                    that.getAuditInfo(value.data.ObjectID);
                }).catch(error => {
                    TTVisual.InfoBox.Alert(error);
                    that.loadingVisible = false;
                });
                that.loadingVisible = false;
        }

    }

    public getAuditInfo(objID: string) {
        let apiUrl: string = '/api/AuditQuery/GetObjectAuditRecords?auditObjectID=' + new Guid(objID);
        this.http.get<Array<LogDataSource>>(apiUrl).then(
            x => {
                if (x != null && x.length > 0) {
                    this.lastUpdateDate = x[x.length - 1].Date;
                    this.lastUpdateUser = x[x.length - 1].AccountName;
                    this.creationDate = x[0].Date;
                    this.creationUser = x[0].AccountName;
                }
            }
        );
    }

    clearData() {
        this.lastUpdateDate = null;
        this.lastUpdateUser = "";
        this.creationDate = null;
        this.creationUser = "";
        this.isActive = null;
        this.IsNewQestion = false;
        this.newQuestionName = null
        this.newQuestionOrder = null;
        this.newQuestionDesciption = null;
        this.newQuestionDataSoruce = new Array<NewQuestionDataSource>();
        this.isReadOnlyForm = false;
    }


    getAllSurveyDefinition() {
        this.loadingVisible = true;
        let that = this;
        let fullApiUrl: string = 'api/KioskSurveyDefinition/getAllSurveyDefinition';
        this.http.post<GetSurveyDefinition>(fullApiUrl, null)
            .then((res) => {
                that.surveyDefinitionListDTOs = res.surveyDefinitionListDTOs as Array<SurveyDefinitionListDTO>;
                this.loadingVisible = false;
            })
            .catch(error => {
                TTVisual.InfoBox.Alert(error);
                this.loadingVisible = false;
            });
    }


    async addNew() {
        this.clearData();
        this.selectedItemFromOpen = true;
        this.activeSurveyDefinitionItem = new SurveyDefinitionOutputItem();
        this.activeSurveyDefinitionItem.isNew = true;
        this.activeSurveyDefinitionItem.IsActive = true;
        this.activeSurveyDefinitionItemDetail = new Array<SurveyQuestion>();
        this.isActive = true;
       


    }

    Cancel() {
        this.selectedItemFromOpen = false;
        this.clearData();
        this.selectedSurveyDefinitionItem = null;
    }

    Save() {
        let currentDate: DateTime = new DateTime();
        if (this.activeSurveyDefinitionItem.Name == null) {
            ServiceLocator.MessageService.showError("Anket Başlığı Boş Olamaz!");
            this.loadingVisible = false;
            return;
        }
        if (this.activeSurveyDefinitionItem.StartDate == null) {
            ServiceLocator.MessageService.showError("Anket Başlangıç Zamanı  Boş Olamaz!");
            this.loadingVisible = false;
            return;
        }
        if (this.activeSurveyDefinitionItem.EndDate == null && this.activeSurveyDefinitionItem.EndDate <= currentDate) {
            ServiceLocator.MessageService.showError("Anket Bitiş Zamanı  Boş Olamaz veya Bugünden Küçük olamaz!");
            this.loadingVisible = false;
            return;
        }

        this.activeSurveyDefinitionItem.SurveyQuestions = this.activeSurveyDefinitionItemDetail;

        if (this.activeSurveyDefinitionItem.SurveyQuestions == null) {
            ServiceLocator.MessageService.showError("Anket için Sorular kısmı Boş Olamaz!");
            this.loadingVisible = false;
            return;
        }
        else {
            if (this.activeSurveyDefinitionItem.SurveyQuestions.length == 0) {
                ServiceLocator.MessageService.showError("Anket için Sorular kısmı Boş Olamaz!");
                this.loadingVisible = false;
                return;
            }
            else {
                for (let item of this.activeSurveyDefinitionItem.SurveyQuestions) {
                    if (item.detail == null) {
                        ServiceLocator.MessageService.showError("Cevap Seçenekleri Boş Olamaz!");
                        this.loadingVisible = false;
                        return;
                    }
                    else {
                        if (item.detail.length == 0) {
                            ServiceLocator.MessageService.showError("Cevap Seçenekleri Boş Olamaz!");
                            this.loadingVisible = false;
                            return;
                        }
                    }

                    for (let answ of item.detail) {
                        if (item.detail.filter(x => x.Point == answ.Point).length > 1) {
                            ServiceLocator.MessageService.showError("Aynı Puan Olamaz!");
                            this.loadingVisible = false;
                            return;
                        }
                    }
                }
            }
        }

        this.activeSurveyDefinitionItem.IsActive = this.isActive;

        this.loadingVisible = true;
        let that = this;
        let fullApiUrl: string = 'api/KioskSurveyDefinition/saveObject';
        this.http.post(fullApiUrl, that.activeSurveyDefinitionItem)
            .then((res) => {
                TTVisual.InfoBox.Alert(res.toString());
                // this.selectedItemFromOpen = false;
                this.getAllSurveyDefinition();
                this.loadingVisible = false;
            })
            .catch(error => {
                TTVisual.InfoBox.Alert(error);
                this.loadingVisible = false;
            });
    }

    AddQuestion() {
        this.IsNewQestion = true;
    }
    CancelQuestion() {
        this.newQuestionName = null
        this.newQuestionOrder = null;
        this.newQuestionDesciption = null;
        this.newQuestionDataSoruce = new Array<NewQuestionDataSource>();
        this.IsNewQestion = false;
    }

    NewQuestionAdd() {
        let error: boolean = false;
        if (this.newQuestionName == null) {
            ServiceLocator.MessageService.showError("Soru başlık kısmı Boş Olamaz!");
            this.loadingVisible = false;
            error = true;
            return;
        }
        if (this.newQuestionOrder == null) {
            ServiceLocator.MessageService.showError("Soru sırası Boş Olamaz!");
            this.loadingVisible = false;
            error = true;
            return;
        } else {
            if (this.activeSurveyDefinitionItemDetail.find(x => x.QuestionOrder == this.newQuestionOrder)) {
                ServiceLocator.MessageService.showError("Soru sırası aynı olamaz!");
                this.loadingVisible = false;
                error = true;
                return;
            }
        }
        if (this.newQuestionDataSoruce == null) {
            ServiceLocator.MessageService.showError("Cevaplar Boş Olamaz!");
            this.loadingVisible = false;
            error = true;
            return;
        }
        for (let item of this.newQuestionDataSoruce) {
            if (item.newChoise == null) {
                ServiceLocator.MessageService.showError("Cevap Boş Olamaz!");
                this.loadingVisible = false;
                error = true;
                return;
            }
            if (item.newPoint == null) {
                ServiceLocator.MessageService.showError("Cevap Puanı Boş Olamaz!");
                this.loadingVisible = false;
                error = true;
                return;
            }
        }

        for (let detail of this.newQuestionDataSoruce) {
            if (this.newQuestionDataSoruce.filter(x => x.newPoint == detail.newPoint).length > 1) {
                ServiceLocator.MessageService.showError("Aynı Puan Olamaz!");
                this.loadingVisible = false;
                error = true;
                return;
            }
        }

        if (error == false) {
            let question: SurveyQuestion = new SurveyQuestion();
            question.Description = this.newQuestionDesciption;
            question.QuestionOrder = this.newQuestionOrder;
            question.Question = this.newQuestionName;
            question.detail = new Array<SurveyAnswer>();
            for (let item of this.newQuestionDataSoruce) {
                let choise: SurveyAnswer = new SurveyAnswer();
                choise.Answer = item.newChoise;
                choise.Point = item.newPoint;
                choise.Description = item.newDesciption;
                question.detail.push(choise);
            }

            if (this.activeSurveyDefinitionItem.SurveyQuestions == null)
                this.activeSurveyDefinitionItem.SurveyQuestions = new Array<SurveyQuestion>();

            // this.activeSurveyDefinitionItem.SurveyQuestions.push(question);
            this.activeSurveyDefinitionItemDetail.push(question);

            this.newQuestionName = null
            this.newQuestionOrder = null;
            this.newQuestionDesciption = null;
            this.newQuestionDataSoruce = new Array<NewQuestionDataSource>();
        }
    }

  
    resultSurveyDefinition() {
        let componentInfo = new DynamicComponentInfo();
        componentInfo.ComponentName = 'SurveyGraphicComponent';
        componentInfo.ModuleName = 'KioskDefinitionModule';
        componentInfo.ModulePath = 'Modules/Kiosk_Modulleri/KioskDefinitionModule';
        componentInfo.InputParam = this.activeSurveyDefinitionItem.ObjectID;

        let modalInfo: ModalInfo = new ModalInfo();
        modalInfo.Title = 'GRAFİK';
        modalInfo.Width = 1800;
        modalInfo.Height = 550;

        let promise = new Promise<string>(function (resolve, reject) {
            let modalService: IModalService = ServiceLocator.Injector.get(IModalService, [ServiceLocator.Compiler]);
            let result2 = modalService.create(componentInfo, modalInfo);
            result2.then(res2 => {
                let modalActionResult: any = res2.Param;
                if (modalActionResult !== undefined) {
                    resolve(modalActionResult);
                }
            })
                .catch(err => {
                    TTVisual.InfoBox.Alert(err);
                });
        });




    }

}


export class SurveyDefinitionListDTO {
    @Type(() => Guid)
    public ObjectID: Guid;
    public Name: string;
    public IsActive: boolean;
}

export class GetSurveyDefinition {
    public surveyDefinitionListDTOs: Array<SurveyDefinitionListDTO>;
}

export class GetSurveyDefinition_Input {
    @Type(() => Guid)
    public ObjectID: Guid;
}


export class SurveyDefinitionOutputItem {

    public isReadOnlyForm:boolean;

    public isNew: boolean;
    public ObjectID: Guid;
    public Name: string;
    public IsActive: boolean;
    public StartDate: DateTime;
    public EndDate: DateTime;
    public SurveyQuestions: Array<SurveyQuestion>;
}
export class SurveyQuestion {
    @Type(() => Guid)
    public ObjectID: Guid;
    public Description: string;
    public QuestionOrder: number;
    public Question: string;
    public detail: Array<SurveyAnswer>;
}

export class SurveyAnswer {
    @Type(() => Guid)
    public ObjectID: Guid;
    public Description: string;
    public Point: number;
    public Answer: string;
}

export class NewQuestionDataSource {
    public newChoise: string;
    public newPoint: number;
    public newDesciption: string;
}


export class Order {
    ID: number;
    OrderNumber: number;
    OrderDate: string;
    SaleAmount: number;
    Terms: string;
    TotalAmount: number;
    CustomerStoreState: string;
    CustomerStoreCity: string;
    Employee: string;
}