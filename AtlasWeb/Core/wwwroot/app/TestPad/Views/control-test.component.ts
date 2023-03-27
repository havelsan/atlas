//$B6065C0B
import { Component, OnInit, ViewChild } from '@angular/core';
import { IModalService } from 'Fw/Services/IModalService';
import { DynamicComponentInfo } from 'Fw/Models/DynamicComponentInfo';
import { AtlasListDefComponent } from 'Fw/Components/AtlasListDefComponent';
import { ModalInfo } from 'Fw/Models/ModalInfo';
import { DrugOrderIntroduction } from 'NebulaClient/Model/AtlasClientModel';
import { ObjectContextService } from 'Fw/Services/ObjectContextService';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { CommonHelper } from '../../Helper/CommonHelper';
import { SortByEnum } from 'NebulaClient/Utils/Enums/SortByEnum';

@Component({
    selector: 'control-test-component',
    template: `<h1>Hello </h1>

    <hvl-enum-combobox [(Value)]="ComboValue1" [DataTypeName]="'AccountEntegrationAccountTypeEnum'"></hvl-enum-combobox>
    <div>Combo1Value: {{ComboValue1}}</div>
    <hvl-enum-combobox [(Value)]="ComboValue2" [DataTypeName]="'AccountEntegrationAccountTypeEnum'" [SortBy]="Combo1SortBy"></hvl-enum-combobox>
    <div>Combo2Value: {{ComboValue2}}</div>
    <hvl-enum-combobox [(Value)]="ComboValue3" [DataTypeName]="'AccountEntegrationAccountTypeEnum'" [SortBy]="Combo2SortBy"></hvl-enum-combobox>
    <div>Combo3Value: {{ComboValue3}}</div>
    <hvl-enum-combobox [(Value)]="ComboValue4" [DataTypeName]="'AccountEntegrationAccountTypeEnum'" [SortBy]="Combo3SortBy"></hvl-enum-combobox>
    <div>Combo4Value: {{ComboValue4}}</div>


<dx-button text="Test Exception" (onClick)="testException()"></dx-button>

<hvl-checkbox #Validation [TitleFontSize]="TitleFontSize" [Title]="'Test Check Box'" (ValueChange)="emergencyChecked($event)" [Value]="ViewModel?.isEmergency"></hvl-checkbox>

<dx-button text="Increase Font Size" (onClick)="increaseFontSize()"></dx-button>

<p>{{listDefNameTemp}} -- {{listDefName}}</p>

<dx-text-box [(value)]="listDefNameTemp"></dx-text-box>
<dx-button text="Show List" (onClick)="showList()"></dx-button>
<dx-button text="Show Modal" (onClick)="showModal()"></dx-button>

<dx-text-box [(value)]="TemplateGroupName" [showClearButton]="true"></dx-text-box>

<atlas-listdef-component [ListDefName]="listDefName"></atlas-listdef-component>

 <dx-file-uploader
        #fileUploader
        uploadUrl="/api/Test/Upload"
        [multiple]="false"
        accept="*"
        [(value)]="value"
        [uploadHeaders]="uploadHeaders"
        [accept]="uploadAcceptTypes"
        uploadMode="useButtons">
</dx-file-uploader>

<dx-button text="Save Xml File" (onClick)="saveXmlFile()"></dx-button>

<div #webcamcontainer></div>

<dx-button text="Test GetNewObject" (onClick)="testGetNewObject()"></dx-button>


    `,
})
export class ControlTestComponent implements OnInit {
    public ViewModel: ControlTestViewModel;
    public listDefNameTemp: string;
    public listDefName: string;
    public uploadHeaders: any;
    public value: any[] = [];
    public uploadAcceptTypes: any;
    public TitleFontSize: string = '12px';
    private TitleFontSizePoint: number = 12;

    public ComboValue1: any;
    public ComboValue2: any;
    public ComboValue3: any;
    public ComboValue4: any;

    public Combo1SortBy: SortByEnum = SortByEnum.DisplayText;
    public Combo2SortBy: SortByEnum = SortByEnum.Name;
    public Combo3SortBy: SortByEnum = SortByEnum.Value;

    public TemplateGroupName: string = '';

    constructor(private modalService: IModalService, private objectContextService: ObjectContextService, private http: NeHttpService) {
    }

    ngOnInit() {
        this.ViewModel = new ControlTestViewModel();
        this.listDefNameTemp = 'PharmacyStoreDefinitionList';

        // aşağıdaki satırlar file upload için gereklidir.
        let token = sessionStorage.getItem('token');
        if (token) {
            this.uploadHeaders = {
                Authorization: `Bearer ${token}`,
                ObjectId: '2d59198d-131e-48e7-8a64-40bbdb2be41c'
            };
        }
        // opsiyonel
        this.uploadAcceptTypes = "application/pdf";
        
    }

    emergencyChecked(event: any) {

    }

    public showList(): void {
        if (this.listDefNameTemp != null) {
            this.listDefName = this.listDefNameTemp;
        }
    }

    public showModal(): void {
        let dynamicComponentInfo = new DynamicComponentInfo();
        dynamicComponentInfo.ComponentType = AtlasListDefComponent;
        dynamicComponentInfo.InputParam = this.listDefNameTemp;
        let modalInfo = new ModalInfo();
        modalInfo.Width = 600;
        modalInfo.Height = 500;
        modalInfo.fullScreen = true;
        modalInfo.Title = i18n("M18393", "Lütfen seçim yapınız");
        this.modalService.create(dynamicComponentInfo, modalInfo).then(result => {
            console.log(result);
        });
    }

    private downloadXmlFile(xml: string): Promise<Blob> {
        const blob = new Blob([xml], { type: 'application/xml' });
        return Promise.resolve(blob);
    }

    saveXmlFile(): void {
        this.downloadXmlFile(`<document><element id="1"></element></document>`).then(
            (res: Blob) => {
                CommonHelper.saveFile(res, 'export.xml');
            }
        );
    }

    increaseFontSize() {
        this.TitleFontSizePoint = this.TitleFontSizePoint + 1;
        this.TitleFontSize = `${this.TitleFontSizePoint}px`;
    }

    testGetNewObject() {
        this.objectContextService.getNewObject<DrugOrderIntroduction>(DrugOrderIntroduction.ObjectDefID, DrugOrderIntroduction).then(result => {
            console.log(result);
        });
    }

    testException() {
        this.http.get('/api/Test/CheckFormRender').then(r => {
            console.log(r);
        });
    }

}

export class ControlTestViewModel {
    public isEmergency: boolean;
}