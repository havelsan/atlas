import { Component, Input, OnDestroy, OnInit, ViewChild } from "@angular/core";
import { Guid } from "app/NebulaClient/Mscorlib/Guid";
import { NeHttpService } from "app/Fw/Services/NeHttpService";
import { MessageService } from "app/Fw/Services/MessageService";
import List from "app/NebulaClient/System/Collections/List";
import { ServiceLocator } from "app/Fw/Services/ServiceLocator";
import { ResBuilding, ResBuildingWing, ResFloor } from "app/NebulaClient/Model/AtlasClientModel";
import { DxDataGridComponent } from 'devextreme-angular';
import { filter } from "rxjs/operators";
@Component({
    selector: "InpatientDepartmentsOccupancyRateForm",
    templateUrl: './InpatientDepartmentsOccupancyRateForm.html',
})
export class InpatientDepartmentsOccupancyRateForm {
    public DepartmentOccupancyRateViewModel = new DepartmentOccupancyRateViewModel();

    constructor(protected httpService: NeHttpService, protected messageService: MessageService) {  
    }


    async ngOnInit(): Promise<void> {
        await this.CreateViewModel();
        await this.CreatePieChartDataSource();
    //    this.ResetBuildingList();
    }

    public BuildingList : Array <ResBuilding> = new Array<ResBuilding>(); 
    public WingList : Array <ResBuildingWing> = new Array<ResBuildingWing>(); 
    public FloorList : Array <ResFloor> = new Array<ResFloor>(); 
    public BuildingModelDataList: Array <BuildingModel> = new Array <BuildingModel>();
    public WingModelDataList: Array <WingModel> = new Array <WingModel>();
    public FloorSectionModelDataList: Array <FloorSectionsModel> = new Array <FloorSectionsModel>();
    public FloorOccupancyModelDataList: Array <FloorOccupancyModel> = new Array <FloorOccupancyModel>();


    public selectedBuilding;
    public selectedWing;
    public selectedFloor;

    @ViewChild('OccupancyGrid') OccupancyGrid: DxDataGridComponent;


    async CreateViewModel() {
        try {

            let that = this;
            let apiUrlForPASearchUrl: string = '/api/InPatientPhysicianApplicationService/CreateViewModel';
            let body = "";
            let headers = new Headers({ 'Content-Type': 'application/json' });

            await this.httpService.post<any>(apiUrlForPASearchUrl, body).then(response => {
                let result = response;
                if (result) {
                    this.DepartmentOccupancyRateViewModel = result;
                    this.BuildingList = this.DepartmentOccupancyRateViewModel.BuildingList;
                    this.WingList = this.DepartmentOccupancyRateViewModel.WingList;
                    this.FloorList = this.DepartmentOccupancyRateViewModel.FloorList;
                    this.BuildingModelDataList = this.DepartmentOccupancyRateViewModel.BuildingModelList.slice(0);
                    this.WingModelDataList = this.DepartmentOccupancyRateViewModel.WingModelList.slice(0);
                    this.FloorOccupancyModelDataList = this.DepartmentOccupancyRateViewModel.FloorOccupancyDataList.slice(0); 
           /*          this.ResetFloorOccupancyList();
                    this.ResetWingModelList();
                    this.ResetBuildingList();
                    this.FloorOccupancyModelDataList = this.DepartmentOccupancyRateViewModel.FloorOccupancyDataList;*/

                    this.WingModelDataList.forEach(wing => {
                        wing.tempFloorOccupancyDataList = new Array <FloorOccupancyModel>();
                        wing.FloorOccupancyDataList.forEach(floor => {
                                let floorModel: FloorOccupancyModel = new FloorOccupancyModel();
                                floorModel.ObjectID = floor.ObjectID;
                                floorModel.WingObjectID = floor.WingObjectID;
                                floorModel.EmptyBed = floor.EmptyBed;
                                floorModel.UsedBed = floor.UsedBed;
                                floorModel.FloorName = floor.FloorName;
                                floorModel.ObjectID = floor.ObjectID;
                                floorModel.TotalNumberOfBeds = floor.TotalNumberOfBeds;
                                floorModel.OccupancyRate = floor.OccupancyRate;
            
                                wing.tempFloorOccupancyDataList.push(floorModel);
                            
                        })
                    });
                }
            }).catch(error => {
                ServiceLocator.MessageService.showError("Hata : " + error);
            });
        }

        catch (ex) {
            ServiceLocator.MessageService.showError(ex);
        }


    }

    public emptyBeds: number;
    public usedBeds: number;
    public dirtyBeds: number;
    public pieDataSource: any;

    public async CreatePieChartDataSource(){
        this.dirtyBeds = 0;
        this.usedBeds = 0;
        this.emptyBeds = 0;

        this.DepartmentOccupancyRateViewModel.BuildingModelList.forEach(building =>{
            building.Wings.forEach(wing => {
                wing.Floors.forEach(floor =>{
                    this.emptyBeds+= floor.EmptyBed;
                    this.usedBeds+= floor.UsedBed;
                    this.dirtyBeds += floor.DirtyBed;
                })
            })
        });
        this.pieDataSource =
        [
            {
                "id": 1,
                "arg": "Boş",
                "val": this.emptyBeds
                
            },
            {
                "id": 2,
                "arg": "Dolu",
                "val": this.usedBeds
            },
            {
                "id": 3,
                "arg": "Kirli",
                "val": this.dirtyBeds
            }
        ];
    }


    public customizePoint(point)
    {
        if(point.data.id == 1)
            return {
                color:'black'
            }
        else if(point.data.id == 2)
            return{
                color:'#3255d4'
            }
        else if (point.data.id == 3)
            return{
                color:'red'
            }
    }

    
    GetStyleForWingName(j: number){
        if(j == 0){
            return {
                'background-color': '#e8e6e6',
              //  'margin-left': '156px',
                'height': '22px',
                'margin-right': '0px',
                'margin-left': '0px'
           };        
        }
        
        else{
            return {
                'background-color': '#e8e6e6',
                'height': '22px',
                'margin-right': '0px',
                'margin-left': '0px'
           };  
        }
    }

    public async onBuildingChange(event) {
        this.WingList = new Array<ResBuildingWing>();
        this.FloorList = new Array<ResFloor>();
        this.BuildingModelDataList = this.DepartmentOccupancyRateViewModel.BuildingModelList.slice(0);
        this.WingModelDataList = this.DepartmentOccupancyRateViewModel.WingModelList.slice(0);
        this.FloorOccupancyModelDataList = this.DepartmentOccupancyRateViewModel.FloorOccupancyDataList.slice(0);


        //select-box data source guncellenmesi
        if(this.selectedBuilding != event.selectedItem.ObjectID){
            this.selectedBuilding = event.selectedItem.ObjectID;
        }
        this.DepartmentOccupancyRateViewModel.WingList.forEach(wing=>{
            if(this.selectedBuilding == wing.ResBuilding){
                this.WingList.push(wing);
            }
        });
        this.DepartmentOccupancyRateViewModel.FloorList.forEach(floor=>{
            if(this.selectedBuilding == floor.ResBuilding){
                this.FloorList.push(floor);
            }
        });

        //array pass value icerdeki arraylere uygulanamadigi olmadigi icin bu sekilde set edildi
        this.BuildingModelDataList = this.BuildingModelDataList.filter(building => building.BuildingID == this.selectedBuilding);
        this.WingModelDataList = this.WingModelDataList.filter(wing => wing.BuildingObjectID == this.selectedBuilding);
        this.FloorOccupancyModelDataList = this.FloorOccupancyModelDataList.filter(floor => floor.BuildingObjectID == this.selectedBuilding);

        this.OccupancyGrid.instance.refresh();

   
    }

    public async onWingChange(event) {
        this.FloorList = new Array<ResFloor>();

        this.WingModelDataList = this.DepartmentOccupancyRateViewModel.WingModelList.slice(0);
        this.FloorOccupancyModelDataList = this.DepartmentOccupancyRateViewModel.FloorOccupancyDataList.slice(0);


        if(this.selectedWing != event.selectedItem.ObjectID){
            this.selectedWing = event.selectedItem.ObjectID;
        }

        this.DepartmentOccupancyRateViewModel.FloorList.forEach(floor=>{
            if(this.selectedWing == floor.ResBuildingWing){
                this.FloorList.push(floor);
            }
        });

        this.WingModelDataList = this.WingModelDataList.filter(wing => wing.BuildingObjectID == this.selectedBuilding && wing.WingID == this.selectedWing);
        this.FloorOccupancyModelDataList = this.FloorOccupancyModelDataList.filter (floor => floor.BuildingObjectID == this.selectedBuilding && floor.WingObjectID == this.selectedWing);

        this.OccupancyGrid.instance.refresh();

    
    }


    public async onFloorChange(event) {
       // this.FloorOccupancyModelDataList = this.DepartmentOccupancyRateViewModel.FloorOccupancyDataList.slice(0);
      // this.WingModelDataList = this.DepartmentOccupancyRateViewModel.WingModelList.slice(0);
     //  this.WingModelDataList = this.WingModelDataList.filter(wing => wing.BuildingObjectID == this.selectedBuilding && wing.WingID == this.selectedWing);

        if(this.selectedFloor != event.selectedItem.ObjectID){
            this.selectedFloor = event.selectedItem.ObjectID;
        }
  
  
        this.WingModelDataList.forEach(wing => {
            wing.tempFloorOccupancyDataList = new Array <FloorOccupancyModel>();
            wing.FloorOccupancyDataList.forEach(floor => {
                if(floor.ObjectID == this.selectedFloor){
                    let floorModel: FloorOccupancyModel = new FloorOccupancyModel();
                    floorModel.ObjectID = floor.ObjectID;
                    floorModel.WingObjectID = floor.WingObjectID;
                    floorModel.EmptyBed = floor.EmptyBed;
                    floorModel.UsedBed = floor.UsedBed;
                    floorModel.FloorName = floor.FloorName;
                    floorModel.ObjectID = floor.ObjectID;
                    floorModel.TotalNumberOfBeds = floor.TotalNumberOfBeds;
                    floorModel.OccupancyRate = floor.OccupancyRate;

                    wing.tempFloorOccupancyDataList.push(floorModel);
                }
            })
        });
     /*   this.FloorOccupancyModelDataList = this.FloorOccupancyModelDataList.filter (floor => floor.BuildingObjectID == this.selectedBuilding 
            && floor.WingObjectID == this.selectedWing && floor.ObjectID == this.selectedFloor);*/

        this.OccupancyGrid.instance.refresh();

    
    }

  /*  public async ResetFloorOccupancyList(){
        this.FloorOccupancyModelDataList = new Array <FloorOccupancyModel>();

        for(let i:number = 0; i<this.DepartmentOccupancyRateViewModel.FloorOccupancyDataList.length; i++){
            let floorModel: FloorOccupancyModel = new FloorOccupancyModel();
            floorModel.ObjectID = this.DepartmentOccupancyRateViewModel.FloorOccupancyDataList[i].ObjectID;
            floorModel.WingObjectID = this.DepartmentOccupancyRateViewModel.FloorOccupancyDataList[i].WingObjectID;
            floorModel.EmptyBed = this.DepartmentOccupancyRateViewModel.FloorOccupancyDataList[i].EmptyBed;
            floorModel.UsedBed = this.DepartmentOccupancyRateViewModel.FloorOccupancyDataList[i].UsedBed;
            floorModel.FloorName = this.DepartmentOccupancyRateViewModel.FloorOccupancyDataList[i].FloorName;
            floorModel.ObjectID = this.DepartmentOccupancyRateViewModel.FloorOccupancyDataList[i].ObjectID;

            this.FloorOccupancyModelDataList.push(floorModel);
        }
    }

    public async ResetWingModelList(){
        this.WingModelDataList = new Array <WingModel>();
        for(let i:number =0; i<this.DepartmentOccupancyRateViewModel.WingModelList.length;i++){
            let wingModel: WingModel = new WingModel();
            wingModel.BuildingObjectID = this.DepartmentOccupancyRateViewModel.WingModelList[i].BuildingObjectID;
            wingModel.WingID = this.DepartmentOccupancyRateViewModel.WingModelList[i].WingID;
            wingModel.WingName = this.DepartmentOccupancyRateViewModel.WingModelList[i].WingName;
            wingModel.FloorOccupancyDataList = this.FloorOccupancyModelDataList.filter(floor=> floor.WingObjectID == this.DepartmentOccupancyRateViewModel.WingModelList[i].WingID).slice(0);

            this.WingModelDataList.push(wingModel);
        }
    }

    public async ResetBuildingList(){
        this.BuildingModelDataList = new Array <BuildingModel>();

        for(let i:number = 0; i<this.DepartmentOccupancyRateViewModel.BuildingModelList.length; i++){
            let model: BuildingModel = new BuildingModel();
            model.BuildingID = this.DepartmentOccupancyRateViewModel.BuildingModelList[i].BuildingID;
            model.BuildingName = this.DepartmentOccupancyRateViewModel.BuildingModelList[i].BuildingName;
            model.Wings = this.WingModelDataList.filter(wing => wing.BuildingObjectID == this.DepartmentOccupancyRateViewModel.BuildingModelList[i].BuildingID).slice(0);

            this.BuildingModelDataList.push(model);
        }
    } */

    public async Clear(){
        this.BuildingModelDataList = this.DepartmentOccupancyRateViewModel.BuildingModelList.slice(0);
        this.WingModelDataList = this.DepartmentOccupancyRateViewModel.WingModelList.slice(0);
        this.FloorOccupancyModelDataList = this.DepartmentOccupancyRateViewModel.FloorOccupancyDataList.slice(0); 

        this.WingModelDataList.forEach(wing => {
            wing.tempFloorOccupancyDataList = new Array <FloorOccupancyModel>();
            wing.FloorOccupancyDataList.forEach(floor => {
                    let floorModel: FloorOccupancyModel = new FloorOccupancyModel();
                    floorModel.ObjectID = floor.ObjectID;
                    floorModel.WingObjectID = floor.WingObjectID;
                    floorModel.EmptyBed = floor.EmptyBed;
                    floorModel.UsedBed = floor.UsedBed;
                    floorModel.FloorName = floor.FloorName;
                    floorModel.ObjectID = floor.ObjectID;
                    floorModel.TotalNumberOfBeds = floor.TotalNumberOfBeds;
                    floorModel.OccupancyRate = floor.OccupancyRate;

                    wing.tempFloorOccupancyDataList.push(floorModel);
                
            })
        });

        this.selectedBuilding = null;
        this.selectedWing = null;
        this.selectedFloor = null;
        
        this.OccupancyGrid.instance.refresh();

    }

}

export class DepartmentOccupancyRateViewModel
{
    public BuildingList : Array<ResBuilding>;
    public WingList: Array<ResBuildingWing>;
    public FloorList :  Array<ResFloor>;
    public FloorSectionModelList : Array<FloorSectionsModel>;
    public WingModelList : Array<WingModel>;
    public BuildingModelList : Array<BuildingModel>;
    public FloorOccupancyDataList : Array<FloorOccupancyModel>;

}

export class FloorSectionsModel
{
    public BuildingObjectID : Guid;
    public WingObjectID : Guid;
    public FloorObjectID : Guid;
    public FloorName : string;
    public SectionID : Guid;
    public SectionName : string;
    public EmptyBed : number;
    public UsedBed : number;
    public OccupancyRate : string;
    public FloorSectionName : string ;
    public TotalNumberOfBeds : number;
    public DirtyBed: number;
}

export class BuildingModel
{
    public BuildingID : Guid;
    public BuildingName : string;
    public  Wings : Array<WingModel>;

}

export class WingModel
{
    public WingID : Guid;
    public WingName: string; 
    public Floors : List <FloorSectionsModel>;
    public FloorOccupancyDataList : Array<FloorOccupancyModel>;
    public BuildingObjectID : Guid;
    public tempFloorOccupancyDataList : Array<FloorOccupancyModel>;

}

export class FloorOccupancyModel
{
    public FloorName : string;
    public WhichFloor : number;
    public ObjectID : Guid;
    public EmptyBed : number;
    public UsedBed : number;
    public OccupancyRate : string;
    public TotalNumberOfBeds : number;
    public WingObjectID : Guid; 
    public BuildingObjectID : Guid;

}
