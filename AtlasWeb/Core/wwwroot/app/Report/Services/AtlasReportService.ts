//$61ECA1FF
import { Guid } from 'NebulaClient/Mscorlib/Guid';
import { Injectable } from '@angular/core';
import { Headers, ResponseContentType, RequestOptions } from '@angular/http';
import { ReportDefinition } from '../Models/ReportDefinition';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { AtlasHttpService } from 'Fw/Services/AtlasHttpService';
import { NeSerializer } from 'NebulaClient/ClassTransformer/NeSerializer';
import { DynamicComponentInfo } from 'Fw/Models/DynamicComponentInfo';
import { ModalInfo, ModalActionResult } from 'Fw/Models/ModalInfo';
import { IModalService } from 'Fw/Services/IModalService';
import { DialogResult } from 'NebulaClient/Utils/Enums/DialogResult';
import { AtlasFormFieldConfig } from '../../DynamicForm/Models/AtlasFormFieldConfig';
import { ValidatorFn, Validators } from '@angular/forms';
import { ReportParameter } from '../Models/ReportParameter';
import { DateParam } from 'NebulaClient/Mscorlib/DateParam';
import { IntegerParam } from 'NebulaClient/Mscorlib/IntegerParam';
import { BooleanParam } from 'NebulaClient/Mscorlib/BooleanParam';
import { StringParam } from 'NebulaClient/Mscorlib/StringParam';
import { GuidParam } from 'NebulaClient/Mscorlib/GuidParam';
import { NullValueParam } from 'NebulaClient/Mscorlib/NullValueParam';
import { ReportExportTargetType } from 'NebulaClient/Utils/Enums/ReportExportTargetType';
import { IActiveUserService } from 'Fw/Services/IActiveUserService';
import { map } from 'rxjs/operators';
import { EnumItem } from 'app/NebulaClient/Mscorlib/EnumItem';
import { EnumLookupItem } from 'app/NebulaClient/Mscorlib/EnumLookupItem';
import { ReportParameters } from '../Models/ReportParameters';

@Injectable()
export class AtlasReportService {
    constructor(private http: NeHttpService
        , private http2: AtlasHttpService
        , private modalService: IModalService
        , private activeUserService: IActiveUserService) {
    }

    private getFieldType(parameter: ReportParameter) {
        if (parameter.IsEnum) {
            return 'enum';
        } else if (parameter.ListDefID != null && parameter.ListDefID.toString() !== '') {
            return 'list';
        } else if (parameter.DataTypeName.endsWith('_Seq')) {
            return 'numeric';
        } else if (parameter.DataTypeName === 'DateTime') {
            return 'date';
        } else if (parameter.DataTypeName === 'Boolean') {
            return 'check';
        }
        return 'text';
    }

    public buildReportParameterFormConfig(reportDefinition: ReportDefinition, ttObjectID?: string): Array<AtlasFormFieldConfig> {

        let reportFilterDialog = new Array<AtlasFormFieldConfig>();

        if (reportDefinition.Parameters == null) {
            return reportFilterDialog;
        }
        if (reportDefinition.Parameters.List == null) {
            return reportFilterDialog;
        }

        for (let parameter of reportDefinition.Parameters.List) {
            if (parameter.Name === 'TTOBJECTID') {
                continue;
            }

            let formField: any = {};
            let validators = new Array<ValidatorFn>();
            formField.label = parameter.Caption;
            formField.name = parameter.Name;
            formField.visible = parameter.Visible;
            formField.listDefID = parameter.ListDefID;
            formField.linkedParameterName = parameter.LinkedParameterName;
            formField.linkedRelationDefID = parameter.LinkedRelationDefID;
            if (parameter.Required) {
                validators.push(Validators.required);
            }
            formField.validation = validators;
            if (parameter.IsEnum) {
                formField.enumList = parameter.EnumList;
            }
            formField.type = this.getFieldType(parameter);
            reportFilterDialog.push(formField);

        }

        return reportFilterDialog;
    }


    public getReportParam(formValues: any, parameter: ReportParameter) {
        const parameterValue: any = formValues[parameter.Name];
        if (parameterValue == null) {
            return new NullValueParam();
        } else if (parameter.IsEnum) {
            return new IntegerParam(parameterValue);
        } else if (parameter.ListDefID != null && parameter.ListDefID.toString() !== '') {
            if (!parameterValue) {
                return new GuidParam(Guid.empty());
            }
            return new GuidParam(parameterValue);
        } else if (parameter.DataTypeName.endsWith('_Seq')) {
            return new IntegerParam(parameterValue);
        } else if (parameter.DataTypeName === 'DateTime') {
            return new DateParam(parameterValue);
        } else if (parameter.DataTypeName === 'Boolean') {
            return new BooleanParam(parameterValue);
        }

        return new StringParam(parameterValue);
    }

    public buildReportParameters(reportDefinition: ReportDefinition, formValues: any, ttObjectID?: string): any {

        if (reportDefinition == null) {
            return null;
        }
        if (reportDefinition.Parameters == null) {
            return null;
        }
        if (reportDefinition.Parameters.List == null) {
            return null;
        }
        if (reportDefinition.Parameters.List.length === 0) {
            return null;
        }

        const reportParametersDictionary = {};
        for (let parameter of reportDefinition.Parameters.List) {
            if (parameter.Name === 'TTOBJECTID' && ttObjectID) {
                reportParametersDictionary[parameter.Name] = new GuidParam(ttObjectID);
            } else {
                const reportParam = this.getReportParam(formValues, parameter);
                reportParametersDictionary[parameter.Name] = reportParam;
            }
        }

        return reportParametersDictionary;
    }

    public getAllReportDefinitions(): Promise<Array<ReportDefinition>> {
        return new Promise<Array<ReportDefinition>>((resolve, reject) => {
            let url = `/api/ObjectDef/GetReportDefList`;
            this.http.get<Array<ReportDefinition>>(url).then(res => {
                let defList: Array<ReportDefinition> = res as Array<ReportDefinition>;
                resolve(defList);
            }).catch(err => {
                reject(err);
            });
        });
    }

    public getReportDefinition(reportDefName: string): Promise<ReportDefinition> {
        return new Promise<ReportDefinition>((resolve, reject) => {
            let url = `/api/ObjectDef/GetReportDefinition?reportDefName=${reportDefName}`;
            this.http.get<ReportDefinition>(url).then(res => {
                let defList: ReportDefinition = res as ReportDefinition;
                resolve(defList);
            }).catch(err => {
                reject(err);
            });
        });
    }

    public renderReport(reportDefName: string, exportType: ReportExportTargetType, parameters: any): Promise<any> {
        let apiUrl = '/api/Report/RenderReportWithReportNameAndFileType';
        let input = { ReportName: reportDefName, ExportTargetType: exportType, Parameters: parameters };
        let body = NeSerializer.stringify(input);

        let headers = new Headers();
        headers.set('Content-Type', 'application/json');
        let options = new RequestOptions();
        options.headers = headers;
        options.responseType = ResponseContentType.Blob;

        return this.http2.post(apiUrl, body, options).pipe(map(
            (res) => {
                return new Blob([res.blob()], { type: ReportExportTargetType.GetMIMEType(exportType) });
            })).toPromise();
    }

    public showReport(reportDefName: string, parameters: any): Promise<any> {
        return this.renderReport(reportDefName, ReportExportTargetType.Pdf, parameters).then(
            (res) => {
                const fileURL = URL.createObjectURL(res);
                window.open(fileURL);
            }
        );
    }

    public showReportParameters(reportDefName: string): Promise<ModalActionResult> {
        let dynamicComponentInfo = new DynamicComponentInfo();
        dynamicComponentInfo.ModuleName = 'AtlasReportModule';
        dynamicComponentInfo.ModulePath = '/app/Report/AtlasReportModule';
        dynamicComponentInfo.ComponentName = 'AtlasModalReportComponent';
        dynamicComponentInfo.InputParam = reportDefName;
        let modalInfo = new ModalInfo();
        modalInfo.Width = 600;
        modalInfo.Height = 500;
        modalInfo.Title = i18n("M20834", "Rapor Parametreleri");
        return this.modalService.create(dynamicComponentInfo, modalInfo);
    }

    public showReportModal(reportDefName: string, parameters: any): Promise<any> {
        let that = this;
        return new Promise<any>((resolve, reject) => {
            this.showReportParameters(reportDefName).then(res => {
                if (res && res.Param && res.Result === DialogResult.OK) {
                    let reportParameters = {};
                    Object.assign(reportParameters, res.Param, parameters);
                    const promiseResult = that.showReport(reportDefName, reportParameters);
                    resolve(promiseResult);
                } else {
                    resolve(null);
                }
            }).catch(error => {
                reject(error);
            });
        });
    }

    public GenerateEnumLookup(enumItems: Array<EnumItem>): Array<EnumLookupItem> {
        let lookupItems: Array<EnumLookupItem> = new Array<EnumLookupItem>();
        enumItems.forEach(x => {
            let lookupItem = new EnumLookupItem();
            lookupItem.Value = x.ordinal;
            lookupItem.Name = x.description;
            lookupItems.push(lookupItem);
        });

        return lookupItems;
    }


    public GenerateClientSideReportDefinition(reportName: string, caption: string, params: Array<ReportParameter>): ReportDefinition {

        //#region ReportDefinition

        //Devextreme rapor tool'u ile yapılan rapor için ReportDefinition oluştur.
        let reportDef = new ReportDefinition();
        //Çağırılacak raporun Code olarak verdiğimiz ismi
        reportDef.Name = reportName;
        //Raporun combobox ta görünecek adı.
        reportDef.Caption = caption;
        reportDef.Parameters = new ReportParameters();
        reportDef.Parameters.List = new Array<ReportParameter>();

        params.forEach(element => {
            reportDef.Parameters.List.push(element);
        });
        return reportDef;

        //#endregion ReportDefinition

    }


}