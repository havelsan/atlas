import { Component, OnInit } from '@angular/core';
import { NeHttpService } from 'app/Fw/Services/NeHttpService';
import {
    TestComponentViewModel, EpisodeInfoDto, EpisodeList, EpisodeRequestDetailInfo,
    ProcedureDto, ProcedureList, DataSourceParams, DoctorDto, DoctorList, EpisodeRequestInfo
} from '../Models/TestComponentViewModel';
import { Guid } from 'app/NebulaClient/Mscorlib/Guid';
import DataSource from 'devextreme/data/data_source';
import CustomStore from 'devextreme/data/custom_store';
import { MessageService } from 'Fw/Services/MessageService';
import { PatientInfoDto } from 'app/TestPad/Models/PatientInfoDto';

@Component({
    selector: 'atlas-hizmet-test',
    templateUrl: './hizmet-test.component.html',
})
export class HizmetTestComponent implements OnInit {

    private readonly ActionUrl = 'api/test/';
    private readonly SamplePatientID = '3b6b4081-e39d-4de0-ae05-9d918355a597';

    private viewModel: TestComponentViewModel;
    public requestList: Array<EpisodeRequestDetailInfo>;
    public procedureList: Array<ProcedureDto>;
    public doctorList: Array<DoctorDto>;

    public episodeGridBoxValue: string;
    public procedureGridBoxValue: string;
    public cellProcedureGridBoxValue: string;

    public procedureListDataSource: DataSource;
    public episodeListDataSource: DataSource;
    public autoCompleteDataSource: DataSource;
    public lookupDataSource: DataSource;
    private patientUniqueRefNo: number;

    constructor(private httpService: NeHttpService, private messageService: MessageService) {
        this.viewModel = new TestComponentViewModel();
        this.requestList = new Array<EpisodeRequestDetailInfo>();
        this.patientUniqueRefNo = 10000000000;
    }

    private createLookupDataSource(): DataSource {
        const that = this;
        return new DataSource({
            store: new CustomStore({
                key: 'Code',
                byKey: function (key: any) {
                    return that.loadProcedures(key);
                },
                load: function (loadOptions: any) {
                    if (loadOptions.searchValue) {
                        return that.loadProcedures(loadOptions.searchValue);
                    }
                    return that.loadProcedures();
                },
            }),
        });
    }

    private createEpisodeListDataSource(): DataSource {

        const that = this;
        return new DataSource({
            searchExpr: ["MainSpeciality"],
            store: new CustomStore({
                loadMode: 'raw',
                key: 'ObjectID',
                load: function (loadOptions: any) {
                    return that.loadEpisodes(that.SamplePatientID);
                }
            })
        });
    }

    private createProcedureListDataSource(): DataSource {

        const that = this;
        return new DataSource({
            searchExpr: ["Code", "Name"],
            store: new CustomStore({
                loadMode: 'raw',
                key: 'Code',
                load: function (loadOptions: any) {
                    const dataSourceParams = new DataSourceParams();
                    if (loadOptions.filter) {
                        dataSourceParams.Filter = loadOptions.filter;
                    }
                    if (loadOptions.sort) {
                        dataSourceParams.Sort = loadOptions.sort;
                    }
                    if (loadOptions.group) {
                        dataSourceParams.Group = loadOptions.group;
                    }
                    dataSourceParams.Skip = loadOptions.skip;
                    dataSourceParams.Take = loadOptions.take;
                    if (loadOptions.Select) {
                        dataSourceParams.Select = loadOptions.select;
                    }
                    if (loadOptions.searchValue) {
                        dataSourceParams.SearchValue = loadOptions.searchValue;
                        dataSourceParams.SearchOperation = loadOptions.searchOperation;
                        dataSourceParams.SearchExpr = loadOptions.searchExpr;
                    }
                    return that.loadProceduresWithParams(dataSourceParams);
                }
            })
        });
    }

    private createDataSourceForLookup(): DataSource {
        const that = this;
        return new DataSource({
            store: new CustomStore({
                key: 'Code',
                load: function (loadOptions: any) {
                    const dataSourceParams = new DataSourceParams();
                    if (loadOptions.filter) {
                        dataSourceParams.Filter = loadOptions.filter;
                    }
                    if (loadOptions.sort) {
                        dataSourceParams.Sort = loadOptions.sort;
                    }
                    if (loadOptions.group) {
                        dataSourceParams.Group = loadOptions.group;
                    }
                    dataSourceParams.Skip = loadOptions.skip;
                    dataSourceParams.Take = loadOptions.take;
                    if (loadOptions.Select) {
                        dataSourceParams.Select = loadOptions.select;
                    }
                    if (loadOptions.searchValue) {
                        dataSourceParams.SearchValue = loadOptions.searchValue;
                        dataSourceParams.SearchOperation = loadOptions.searchOperation;
                        dataSourceParams.SearchExpr = loadOptions.searchExpr;
                    }
                    return that.loadProceduresForLookup(dataSourceParams);
                }
            })
        });
    }

    procedureBox_displayExpr(item: ProcedureDto) {
        return item && `${item.Code} - ${item.Name}`;
    }

    episodeBox_displayExpr(item: EpisodeInfoDto) {
        return item && `${item.OpeningDate} - ${item.MainSpeciality}`;
    }

    onEpisodeSelectionChanged(e: any, dropDownBoxInstance: any) {
        const keys = e.selectedRowKeys;
        if (keys) {
            dropDownBoxInstance.option('value', keys.length > 0 ? keys[0] : null);
        }
    }

    onProcSelectionChanged(e: any, dropDownBoxInstance: any) {
        const keys = e.selectedRowKeys;
        if (keys) {
            dropDownBoxInstance.option('value', keys.length > 0 ? keys[0] : null);
        }
    }

    onCellProcSelectionChanged(e: any, dropDownBoxInstance: any) {
        const keys = e.selectedRowKeys;
        if (keys) {
            dropDownBoxInstance.option('value', keys.length > 0 ? keys[0] : null);
        }
    }

    onEpisodeValueChanged(args: any) {
        if (args && args.value) {
            this.episodeGridBoxValue = args.value;
        }
        if (args.component) {
            args.component.close();
        }
    }

    onProcValueChanged(args: any) {
        if (args && args.value) {
            this.procedureGridBoxValue = args.value;
        }
        if (args.component) {
            args.component.close();
        }
    }

    onCellProcValueChanged(args: any, requestGridInstance: any) {
        if (args && args.value) {
            this.cellProcedureGridBoxValue = args.value;
        }
        if (args.component) {
            args.component.close();
        }
    }

    loadEpisodes(patientID: string): Promise<Array<EpisodeInfoDto>> {
        const apiUrl = `${this.ActionUrl}/getepisodelist/?patientID=${patientID}`;
        const that = this;
        return this.httpService.get<EpisodeList>(apiUrl).then(e => {
            return e.Episodes;
        });
    }

    loadProcedures(code?: string): Promise<Array<ProcedureDto>> {
        let procedureListUrl = `${this.ActionUrl}/getprocedurelist`;
        if (code) {
            procedureListUrl = `${procedureListUrl}?procedureCode=${code}`;
        }
        return this.httpService.get<ProcedureList>(procedureListUrl).then(e => {
            return e.Procedures;
        });
    }

    loadProceduresForLookup(dataSourceParams: DataSourceParams): Promise<Array<ProcedureDto>> {
        let procedureListUrl = `${this.ActionUrl}/getprocedurelistforlookup`;
        return this.httpService.post<ProcedureList>(procedureListUrl, dataSourceParams).then(e => {
            return e.Procedures;
        });
    }

    loadProceduresWithParams(dataSourceParams: DataSourceParams): Promise<Array<ProcedureDto>> {
        let procedureListUrl = `${this.ActionUrl}/getprocedurelistwithparams`;
        return this.httpService.post<ProcedureList>(procedureListUrl, dataSourceParams).then(e => {
            return e.Procedures;
        });
    }

    ngOnInit() {

        this.procedureListDataSource = this.createProcedureListDataSource();
        this.episodeListDataSource = this.createEpisodeListDataSource();
        this.autoCompleteDataSource = this.createProcedureListDataSource();
        this.lookupDataSource = this.createDataSourceForLookup();

        const that = this;
        const doctorListUrl = `${this.ActionUrl}/getdoctorlist`;
        this.httpService.get(doctorListUrl, DoctorList).then((e: DoctorList) => {
            that.doctorList = e.Doctors;
        });
    }

    onValueChanged(evt: any, data: any): void {
        if (evt.value && data) {
            const displayExprArr = evt.value.split(' - ');
            if (displayExprArr && displayExprArr[0]) {
                data.setValue(displayExprArr[0]);
                const detailItem = data.data as EpisodeRequestDetailInfo;
                if (detailItem && displayExprArr[1]) {
                    detailItem.ProcedureName = displayExprArr[1];
                }
            }
        }
    }

    writeChanges(evt: any) {
        const that = this;
        const requestInfo = new EpisodeRequestInfo();
        requestInfo.EpisodeID = new Guid(this.episodeGridBoxValue);
        requestInfo.RequestDetails = this.requestList;

        let writeRequestUrl = `${this.ActionUrl}/writeepisoderequest`;
        this.httpService.post(writeRequestUrl, requestInfo).then(x => {
            that.messageService.showInfo('Değişiklikler kaydedildi');
        }).catch(err => {
            that.messageService.showError(`Kayıt işlemi başarısız: ${err}`);
        });

    }

    closeProcedureBoxClicked(eve: any, dropDownBoxInstance: any) {
        if (dropDownBoxInstance && dropDownBoxInstance.close) {
            dropDownBoxInstance.close();
        }
    }

    patientFound(ev?: PatientInfoDto) {
        if (ev != null)
            return;
        ev.UniqueIdentifier;
    }


}