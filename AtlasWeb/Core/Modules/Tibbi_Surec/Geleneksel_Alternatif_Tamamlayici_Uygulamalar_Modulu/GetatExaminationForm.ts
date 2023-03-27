//$65F19DEA
import { Component, ViewChild, OnInit, ApplicationRef } from '@angular/core';
import { Http, Headers, Response, RequestOptions } from '@angular/http';
import { GetatExaminationFormViewModel } from './GetatExaminationFormViewModel';
import { NeResult } from 'NebulaClient/Utils/NeResult';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import { Util } from 'Fw/Components/Util';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { TraditionalMedicine, SpecialityBasedObject } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSGETATTedaviSonucu } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSGETATUygulamaBirimi } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSGETATUygulamaBolgesi } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSGETATUygulamaTuru } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSGETATUygulandigiDurumlar } from 'NebulaClient/Model/AtlasClientModel';
import { TraditionalMedAppRegion } from 'NebulaClient/Model/AtlasClientModel';
import { TradititionalMedAppCases } from 'NebulaClient/Model/AtlasClientModel';

import { SpecialityBasedObjectForm } from '../Tibbi_Surec_Evrensel_Modulu/SpecialityBasedObjectForm';

@Component({
    selector: 'GetatExaminationForm',
    templateUrl: './GetatExaminationForm.html',
    providers: [MessageService]
})
export class GetatExaminationForm extends SpecialityBasedObjectForm implements OnInit {
    GetatApplicationType: TTVisual.ITTObjectListBox;
    GetatApplicationUnit: TTVisual.ITTObjectListBox;
    GetatExaminationResult: TTVisual.ITTObjectListBox;
    labelGetatApplicationType: TTVisual.ITTLabel;
    labelGetatApplicationUnit: TTVisual.ITTLabel;
    labelGetatExaminationResult: TTVisual.ITTLabel;
    SKRSGetatApplicationRegionTraditionalMedAppRegion: TTVisual.ITTListBoxColumn;
    SKRSGetatAppliedCasesTradititionalMedAppCases: TTVisual.ITTListBoxColumn;
    TraditionalMedAppCases: TTVisual.ITTGrid;
    TraditionalMedAppRegion: TTVisual.ITTGrid;
    ttlabel1: TTVisual.ITTLabel;
    ttlabel2: TTVisual.ITTLabel;
    public TraditionalMedAppCasesColumns = [];
    public TraditionalMedAppRegionColumns = [];
    public getatExaminationFormViewModel: GetatExaminationFormViewModel = new GetatExaminationFormViewModel();
    public get _TraditionalMedicine(): TraditionalMedicine {
        return this._TTObject as TraditionalMedicine;
    }
    private GetatExaminationForm_DocumentUrl: string = '/api/TraditionalMedicineService/GetatExaminationForm';
    constructor(protected httpService: NeHttpService, protected messageService: MessageService) {
        super(httpService, messageService);
        this._DocumentServiceUrl = this.GetatExaminationForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }


    // ***** Method declarations start *****


    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new TraditionalMedicine();
        this.getatExaminationFormViewModel = new GetatExaminationFormViewModel();
        this._ViewModel = this.getatExaminationFormViewModel;
        this.getatExaminationFormViewModel._TraditionalMedicine = this._TTObject as TraditionalMedicine;
        this.getatExaminationFormViewModel._TraditionalMedicine.GetatApplicationType = new SKRSGETATUygulamaTuru();
        this.getatExaminationFormViewModel._TraditionalMedicine.TraditionalMedAppRegion = new Array<TraditionalMedAppRegion>();
        this.getatExaminationFormViewModel._TraditionalMedicine.TraditionalMedAppCases = new Array<TradititionalMedAppCases>();
        this.getatExaminationFormViewModel._TraditionalMedicine.GetatApplicationUnit = new SKRSGETATUygulamaBirimi();
        this.getatExaminationFormViewModel._TraditionalMedicine.GetatExaminationResult = new SKRSGETATTedaviSonucu();
    }

    protected loadViewModel() {
        let that = this;
        that.getatExaminationFormViewModel = this._ViewModel as GetatExaminationFormViewModel;
        that._TTObject = this.getatExaminationFormViewModel._TraditionalMedicine;
        if (this.getatExaminationFormViewModel == null)
            this.getatExaminationFormViewModel = new GetatExaminationFormViewModel();
        if (this.getatExaminationFormViewModel._TraditionalMedicine == null)
            this.getatExaminationFormViewModel._TraditionalMedicine = new TraditionalMedicine();
        let getatApplicationTypeObjectID = that.getatExaminationFormViewModel._TraditionalMedicine["GetatApplicationType"];
        if (getatApplicationTypeObjectID != null && (typeof getatApplicationTypeObjectID === "string")) {
            let getatApplicationType = that.getatExaminationFormViewModel.SKRSGETATUygulamaTurus.find(o => o.ObjectID.toString() === getatApplicationTypeObjectID.toString());
            if (getatApplicationType) {
                that.getatExaminationFormViewModel._TraditionalMedicine.GetatApplicationType = getatApplicationType;
            }
        }


        that.getatExaminationFormViewModel._TraditionalMedicine.TraditionalMedAppRegion = that.getatExaminationFormViewModel.TraditionalMedAppRegionGridList;
        for (let detailItem of that.getatExaminationFormViewModel.TraditionalMedAppRegionGridList) {
            let sKRSGetatApplicationRegionObjectID = detailItem["SKRSGetatApplicationRegion"];
            if (sKRSGetatApplicationRegionObjectID != null && (typeof sKRSGetatApplicationRegionObjectID === "string")) {
                let sKRSGetatApplicationRegion = that.getatExaminationFormViewModel.SKRSGETATUygulamaBolgesis.find(o => o.ObjectID.toString() === sKRSGetatApplicationRegionObjectID.toString());
                if (sKRSGetatApplicationRegion) {
                    detailItem.SKRSGetatApplicationRegion = sKRSGetatApplicationRegion;
                }
            }

        }

        that.getatExaminationFormViewModel._TraditionalMedicine.TraditionalMedAppCases = that.getatExaminationFormViewModel.TraditionalMedAppCasesGridList;
        for (let detailItem of that.getatExaminationFormViewModel.TraditionalMedAppCasesGridList) {
            let sKRSGetatAppliedCasesObjectID = detailItem["SKRSGetatAppliedCases"];
            if (sKRSGetatAppliedCasesObjectID != null && (typeof sKRSGetatAppliedCasesObjectID === "string")) {
                let sKRSGetatAppliedCases = that.getatExaminationFormViewModel.SKRSGETATUygulandigiDurumlars.find(o => o.ObjectID.toString() === sKRSGetatAppliedCasesObjectID.toString());
                if (sKRSGetatAppliedCases) {
                    detailItem.SKRSGetatAppliedCases = sKRSGetatAppliedCases;
                }
            }

        }

        let getatApplicationUnitObjectID = that.getatExaminationFormViewModel._TraditionalMedicine["GetatApplicationUnit"];
        if (getatApplicationUnitObjectID != null && (typeof getatApplicationUnitObjectID === "string")) {
            let getatApplicationUnit = that.getatExaminationFormViewModel.SKRSGETATUygulamaBirimis.find(o => o.ObjectID.toString() === getatApplicationUnitObjectID.toString());
            if (getatApplicationUnit) {
                that.getatExaminationFormViewModel._TraditionalMedicine.GetatApplicationUnit = getatApplicationUnit;
            }
        }


        let getatExaminationResultObjectID = that.getatExaminationFormViewModel._TraditionalMedicine["GetatExaminationResult"];
        if (getatExaminationResultObjectID != null && (typeof getatExaminationResultObjectID === "string")) {
            let getatExaminationResult = that.getatExaminationFormViewModel.SKRSGETATTedaviSonucus.find(o => o.ObjectID.toString() === getatExaminationResultObjectID.toString());
            if (getatExaminationResult) {
                that.getatExaminationFormViewModel._TraditionalMedicine.GetatExaminationResult = getatExaminationResult;
            }
        }

    }


    async ngOnInit() {
        await this.load(GetatExaminationFormViewModel);
    }

    public onGetatApplicationTypeChanged(event): void {
        if (this._TraditionalMedicine != null && this._TraditionalMedicine.GetatApplicationType != event) {
            this._TraditionalMedicine.GetatApplicationType = event;
        }
    }

    public onGetatApplicationUnitChanged(event): void {
        if (this._TraditionalMedicine != null && this._TraditionalMedicine.GetatApplicationUnit != event) {
            this._TraditionalMedicine.GetatApplicationUnit = event;
        }
    }

    public onGetatExaminationResultChanged(event): void {
        if (this._TraditionalMedicine != null && this._TraditionalMedicine.GetatExaminationResult != event) {
            this._TraditionalMedicine.GetatExaminationResult = event;
        }
    }



    protected redirectProperties(): void {

    }

    public initFormControls(): void {
        this.labelGetatApplicationType = new TTVisual.TTLabel();
        this.labelGetatApplicationType.Text = "Uygulama Türü";
        this.labelGetatApplicationType.Name = "labelGetatApplicationType";
        this.labelGetatApplicationType.TabIndex = 7;

        this.GetatApplicationType = new TTVisual.TTObjectListBox();
        this.GetatApplicationType.ListDefName = "SKRSGETATUygulamaTuruList";
        this.GetatApplicationType.Name = "GetatApplicationType";
        this.GetatApplicationType.TabIndex = 6;


        this.TraditionalMedAppRegion = new TTVisual.TTGrid();
        this.TraditionalMedAppRegion.Name = "TraditionalMedAppRegion";
        this.TraditionalMedAppRegion.TabIndex = 4;
        this.TraditionalMedAppRegion.ReadOnly = true;
        this.TraditionalMedAppRegion.Height = "200px";
        this.TraditionalMedAppRegion.ShowFilterCombo = true;
        this.TraditionalMedAppRegion.FilterColumnName = "SKRSGetatApplicationRegionTraditionalMedAppRegion";
        this.TraditionalMedAppRegion.Filter = { ListDefName: "SKRSGETATUygulamaBolgesiList" };
        this.TraditionalMedAppRegion.FilterLabel = i18n("M23785", "Uygulama Bölgesi");
        this.TraditionalMedAppRegion.AllowUserToAddRows = false;
        this.TraditionalMedAppRegion.DeleteButtonWidth = "5%";
        this.TraditionalMedAppRegion.AllowUserToDeleteRows = true;
        this.TraditionalMedAppRegion.IsFilterLabelSingleLine = true;

        this.SKRSGetatApplicationRegionTraditionalMedAppRegion = new TTVisual.TTListBoxColumn();
        this.SKRSGetatApplicationRegionTraditionalMedAppRegion.ListDefName = "SKRSGETATUygulamaBolgesiList";
        this.SKRSGetatApplicationRegionTraditionalMedAppRegion.DataMember = "SKRSGetatApplicationRegion";
        this.SKRSGetatApplicationRegionTraditionalMedAppRegion.DisplayIndex = 0;
        this.SKRSGetatApplicationRegionTraditionalMedAppRegion.HeaderText = "Uygulama Bölgesi";
        this.SKRSGetatApplicationRegionTraditionalMedAppRegion.Name = "SKRSGetatApplicationRegionTraditionalMedAppRegion";
        this.SKRSGetatApplicationRegionTraditionalMedAppRegion.Width = 300;

        this.TraditionalMedAppCases = new TTVisual.TTGrid();
        this.TraditionalMedAppCases.Name = "TraditionalMedAppCases";
        this.TraditionalMedAppCases.TabIndex = 4;
        this.TraditionalMedAppCases.ReadOnly = true;
        this.TraditionalMedAppCases.Height = "200px";
        this.TraditionalMedAppCases.ShowFilterCombo = true;
        this.TraditionalMedAppCases.FilterColumnName = "SKRSGetatAppliedCasesTradititionalMedAppCases";
        this.TraditionalMedAppCases.Filter = { ListDefName: "SKRSGETATUygulandigiDurumlarList" };
        this.TraditionalMedAppCases.FilterLabel = i18n("M23785", "Uygulandığı Durumlar");
        this.TraditionalMedAppCases.AllowUserToAddRows = false;
        this.TraditionalMedAppCases.DeleteButtonWidth = "5%";
        this.TraditionalMedAppCases.AllowUserToDeleteRows = true;
        this.TraditionalMedAppCases.IsFilterLabelSingleLine = true;


        this.SKRSGetatAppliedCasesTradititionalMedAppCases = new TTVisual.TTListBoxColumn();
        this.SKRSGetatAppliedCasesTradititionalMedAppCases.ListDefName = "SKRSGETATUygulandigiDurumlarList";
        this.SKRSGetatAppliedCasesTradititionalMedAppCases.DataMember = "SKRSGetatAppliedCases";
        this.SKRSGetatAppliedCasesTradititionalMedAppCases.DisplayIndex = 0;
        this.SKRSGetatAppliedCasesTradititionalMedAppCases.HeaderText = "Uygulandığı Durumlar";
        this.SKRSGetatAppliedCasesTradititionalMedAppCases.Name = "SKRSGetatAppliedCasesTradititionalMedAppCases";
        this.SKRSGetatAppliedCasesTradititionalMedAppCases.Width = 300;
        



        this.labelGetatApplicationUnit = new TTVisual.TTLabel();
        this.labelGetatApplicationUnit.Text = "Uygulama Birimi";
        this.labelGetatApplicationUnit.Name = "labelGetatApplicationUnit";
        this.labelGetatApplicationUnit.TabIndex = 3;

        this.GetatApplicationUnit = new TTVisual.TTObjectListBox();
        this.GetatApplicationUnit.ListDefName = "SKRSGETATUygulamaBirimiList";
        this.GetatApplicationUnit.Name = "GetatApplicationUnit";
        this.GetatApplicationUnit.TabIndex = 2;

        this.labelGetatExaminationResult = new TTVisual.TTLabel();
        this.labelGetatExaminationResult.Text = "Muayene Sonucu";
        this.labelGetatExaminationResult.Name = "labelGetatExaminationResult";
        this.labelGetatExaminationResult.TabIndex = 1;

        this.GetatExaminationResult = new TTVisual.TTObjectListBox();
        this.GetatExaminationResult.ListDefName = "SKRSGETATTedaviSonucuList";
        this.GetatExaminationResult.Name = "GetatExaminationResult";
        this.GetatExaminationResult.TabIndex = 0;

        this.ttlabel1 = new TTVisual.TTLabel();
        this.ttlabel1.Text = "Uygulandığı Durumlar";
        this.ttlabel1.Name = "ttlabel1";
        this.ttlabel1.TabIndex = 1;

        this.ttlabel2 = new TTVisual.TTLabel();
        this.ttlabel2.Text = "Uygulama Bölgesi";
        this.ttlabel2.Name = "ttlabel2";
        this.ttlabel2.TabIndex = 1;

        this.TraditionalMedAppRegionColumns = [this.SKRSGetatApplicationRegionTraditionalMedAppRegion];
        this.TraditionalMedAppCasesColumns = [this.SKRSGetatAppliedCasesTradititionalMedAppCases];
        this.Controls = [this.labelGetatApplicationType, this.GetatApplicationType, this.TraditionalMedAppRegion, this.SKRSGetatApplicationRegionTraditionalMedAppRegion, this.TraditionalMedAppCases, this.SKRSGetatAppliedCasesTradititionalMedAppCases, this.labelGetatApplicationUnit, this.GetatApplicationUnit, this.labelGetatExaminationResult, this.GetatExaminationResult, this.ttlabel1, this.ttlabel2];

    }


}
