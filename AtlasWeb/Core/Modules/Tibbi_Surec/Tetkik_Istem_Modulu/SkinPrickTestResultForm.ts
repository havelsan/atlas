//$ED2BDCCB
import { Component, ViewChild, OnInit, ApplicationRef  } from '@angular/core';
import { Http, Headers, Response, RequestOptions } from '@angular/http';
import { SkinPrickTestResultFormViewModel } from './SkinPrickTestResultFormViewModel';
import { NeResult } from 'NebulaClient/Utils/NeResult';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import { Util } from 'Fw/Components/Util';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { BaseAdditionalInfoForm } from 'Modules/Tibbi_Surec/Tetkik_Istem_Modulu/BaseAdditionalInfoFormForm';
import { SkinPrickTestResult } from 'NebulaClient/Model/AtlasClientModel';
import { SkinPrickTestDetail } from 'NebulaClient/Model/AtlasClientModel';

import { IModal, ModalInfo, ModalStateService } from "Fw/Models/ModalInfo";


@Component({
    selector: 'SkinPrickTestResultForm',
    templateUrl: './SkinPrickTestResultForm.html',
    providers: [MessageService]
})
export class SkinPrickTestResultForm extends BaseAdditionalInfoForm implements OnInit {
    DescriptionSkinPrickTestDetail: TTVisual.ITTTextBoxColumn;
    NegativeSkinPrickTestDetail: TTVisual.ITTCheckBoxColumn;
    PositiveSkinPrickTestDetail: TTVisual.ITTCheckBoxColumn;
    SkinPrickTestDetail: TTVisual.ITTGrid;
    public SkinPrickTestDetailColumns = [];
    public statesPanelClass: string = "col-lg-6";
    public skinPrickTestResultFormViewModel: SkinPrickTestResultFormViewModel = new SkinPrickTestResultFormViewModel();
    public get _SkinPrickTestResult(): SkinPrickTestResult {
        return this._TTObject as SkinPrickTestResult;
    }
    private SkinPrickTestResultForm_DocumentUrl: string = '/api/SkinPrickTestResultService/SkinPrickTestResultForm';
    constructor(protected httpService: NeHttpService, protected messageService: MessageService, protected modalStateService: ModalStateService) {
        super(httpService, messageService, modalStateService);
        this._DocumentServiceUrl = this.SkinPrickTestResultForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }


    // ***** Method declarations start *****


    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new SkinPrickTestResult();
        this.skinPrickTestResultFormViewModel = new SkinPrickTestResultFormViewModel();
        this._ViewModel = this.skinPrickTestResultFormViewModel;
        this.skinPrickTestResultFormViewModel._SkinPrickTestResult = this._TTObject as SkinPrickTestResult;
        this.skinPrickTestResultFormViewModel._SkinPrickTestResult.SkinPrickTestDetail = new Array<SkinPrickTestDetail>();
    }

    protected loadViewModel() {
        let that = this;
        that.skinPrickTestResultFormViewModel = this._ViewModel as SkinPrickTestResultFormViewModel;
        that._TTObject = this.skinPrickTestResultFormViewModel._SkinPrickTestResult;
        if (this.skinPrickTestResultFormViewModel == null)
            this.skinPrickTestResultFormViewModel = new SkinPrickTestResultFormViewModel();
        if (this.skinPrickTestResultFormViewModel._SkinPrickTestResult == null)
            this.skinPrickTestResultFormViewModel._SkinPrickTestResult = new SkinPrickTestResult();
        that.skinPrickTestResultFormViewModel._SkinPrickTestResult.SkinPrickTestDetail = that.skinPrickTestResultFormViewModel.SkinPrickTestDetailGridList;
        for (let detailItem of that.skinPrickTestResultFormViewModel.SkinPrickTestDetailGridList) {
        }

    }

    async ngOnInit() {
        await this.load(SkinPrickTestResultFormViewModel);
    }



    protected redirectProperties(): void {

    }

    public initFormControls(): void {
        this.SkinPrickTestDetail = new TTVisual.TTGrid();
        this.SkinPrickTestDetail.Name = "SkinPrickTestDetail";
        this.SkinPrickTestDetail.TabIndex = 0;

        this.NegativeSkinPrickTestDetail = new TTVisual.TTCheckBoxColumn();
        this.NegativeSkinPrickTestDetail.DataMember = "Negative";
        this.NegativeSkinPrickTestDetail.DisplayIndex = 0;
        this.NegativeSkinPrickTestDetail.HeaderText = "Negatif";
        this.NegativeSkinPrickTestDetail.Name = "NegativeSkinPrickTestDetail";
        this.NegativeSkinPrickTestDetail.Width = 80;

        this.PositiveSkinPrickTestDetail = new TTVisual.TTCheckBoxColumn();
        this.PositiveSkinPrickTestDetail.DataMember = "Positive";
        this.PositiveSkinPrickTestDetail.DisplayIndex = 1;
        this.PositiveSkinPrickTestDetail.HeaderText = "Pozitif";
        this.PositiveSkinPrickTestDetail.Name = "PositiveSkinPrickTestDetail";
        this.PositiveSkinPrickTestDetail.Width = 80;

        this.DescriptionSkinPrickTestDetail = new TTVisual.TTTextBoxColumn();
        this.DescriptionSkinPrickTestDetail.DataMember = "Description";
        this.DescriptionSkinPrickTestDetail.DisplayIndex = 2;
        this.DescriptionSkinPrickTestDetail.HeaderText = "Açıklama";
        this.DescriptionSkinPrickTestDetail.Name = "DescriptionSkinPrickTestDetail";
        this.DescriptionSkinPrickTestDetail.Width = 80;

        this.SkinPrickTestDetailColumns = [this.NegativeSkinPrickTestDetail, this.PositiveSkinPrickTestDetail, this.DescriptionSkinPrickTestDetail];
        this.Controls = [this.SkinPrickTestDetail, this.NegativeSkinPrickTestDetail, this.PositiveSkinPrickTestDetail, this.DescriptionSkinPrickTestDetail];

    }

    public SkinPrickTestColumns = [
        {
            caption: 'İşlem Kodu',
            dataField: 'ProcedureCode',
            width: 100,
            allowEditing: false

        },
        {
            caption: 'İşlem Adı',
            dataField: 'ProcedureName',
            width: 150,
            allowEditing: false

        },
        {
            caption: 'Negatif',
            dataField: 'Negative',
            width: '80px',
            dataType: 'boolean',
            allowEditing: true,
            cellTemplate: "NegativeChkTemplate"

        },
        {
            caption: 'Pozitif',
            dataField: 'Positive',
            width: '80px',
            dataType: 'boolean',
            allowEditing: true,
            cellTemplate: "PositiveChkTemplate"

        },
        {
            caption: 'Açıklama',
            dataField: 'Description',
            width: 150,
            dataType: 'string',
            allowEditing: true,
            cellTemplate: "DescriptionTemplate"

        }
    ]

    onNegativeValueChanged(data, event) {
        if (event.value == true)
            data.Positive = false;
    }
    onPositiveValueChanged(data, event) {
        if (event.value == true)
            data.Negative = false;
    }
}
