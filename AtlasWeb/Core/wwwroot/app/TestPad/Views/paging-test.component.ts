import { Component, OnInit, ViewChild } from '@angular/core';
import { environment } from 'app/environments/environment';
import CustomStore from 'devextreme/data/custom_store';
import { NeHttpService } from 'app/Fw/Services/NeHttpService';
import { DxDataGridComponent, DxTagBoxComponent } from 'devextreme-angular';
import DataSource from "devextreme/data/data_source";

@Component({
    selector: 'paging-test',
    templateUrl: './paging-test.component.html',
})
export class PagingTestComponent implements OnInit {

    dataSource: any;
    diagnosisSearchDataSource: any;
    diagnosisSearchText: string;
    @ViewChild("grid") gridInstance: DxDataGridComponent;

    test : any = [];

    deneme(){
        console.log(this.test);
    }

test123(item){
        return item.CODE + " " + item.NAME
}

    constructor(protected httpService: NeHttpService) {


        this.dataSource = new DataSource({
            store: new CustomStore({
                key: "Code",

                load: (loadOptions: any) => {
                    loadOptions.Params = {
                        searchText: loadOptions.searchValue,
                        definitionName: 'SurgeryListForWL'
                    }

                    if (loadOptions.take == null || loadOptions.take == 0) {
                        loadOptions.take = 10;
                    }

                    return this.httpService.post<any>("/api/Test/PagingTest", loadOptions);

                },
            }),
            paginate: true,
            pageSize: 10
        });

        this.diagnosisSearchDataSource = new CustomStore({
            key: "Code",
            load: (loadOptions: any) => {
                loadOptions.Params = {
                    searchText: this.diagnosisSearchText,
                    definitionName: 'DiagnosisListDefinition'
                }

                return this.httpService.post<any>("/api/Test/Query2", loadOptions);

            },
        });


        //TTQUERY EXAMPLE
        

        //TTLIST EXAMPLE
        // this.diagnosisSearchDataSource = new CustomStore({
        //    key: "CODE",
        //    load: (loadOptions: any) => {
        //        loadOptions.Params = {
        //            searchText: this.diagnosisSearchText,
        //            definitionName: 'DiagnosisListDefinition'
        //        }
                
        //        return this.httpService.post<any>("/api/Test/Query", loadOptions);
                
        //    },
        // });
    }

    focusIn(e: any) {
        this.diagnosisSearchText = e.srcElement.value;
        this.refreshGrid();
    }
    change(e: any) {
        this.diagnosisSearchText = e.srcElement.value;
        this.refreshGrid();
    }

    refreshGrid() {
        this.gridInstance.instance.refresh();
    }
    ngOnInit(): void {
    }
}