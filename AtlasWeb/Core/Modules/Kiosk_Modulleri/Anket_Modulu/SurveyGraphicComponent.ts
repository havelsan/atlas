import { Component, Input, OnInit } from '@angular/core';
import { IModal, ModalInfo, ModalStateService } from 'Fw/Models/ModalInfo';
import { DynamicComponentInfo } from 'Fw/Models/DynamicComponentInfo';
import { Guid } from 'app/NebulaClient/Mscorlib/Guid';
import { NeHttpService } from "Fw/Services/NeHttpService";

@Component({
    selector: 'surveyGraphic-component',
    templateUrl: './SurveyGraphicComponent.html',
})
export class SurveyGraphicComponent implements IModal, OnInit {
    
    public _SurveyDefinition: string;
    public componentInfo: DynamicComponentInfo;
    public surveyObjectID: string;
    private _modalInfo: ModalInfo;

    TotalParticipation: number;
    Questions: any[];
    Desciptions:any[];
    AnwerChartList:Array<AnwerChart>;
    constructor(private modalStateService: ModalStateService, protected http: NeHttpService) {
       
    }


   
   
    async ngOnInit() {
       this.getSurveyQuestion();
    }

    public async setInputParam(value: string) {
       this._SurveyDefinition= value as string;

    }

    public setModalInfo(value: ModalInfo) {
        this._modalInfo = value;
    }


    getSurveyQuestion() {
        let that = this;
        let input: InputDTO = new InputDTO();
        input.SurveyObjectID = this._SurveyDefinition;
        let fullApiUrl: string = 'api/KioskSurveyDefinition/getSurveyQuestion';
        this.http.post<OutputDTO>(fullApiUrl, input)
            .then((res) => {
                that.Questions = res.questionLists;
                that.TotalParticipation = res.TotalParticipation; 
            })
            .catch(error => {

            });
    }



    customizeLabel(arg) {
        return arg.valueText + " (" + arg.percentText + ")";
    }

    async selectGridRow(value: any): Promise<void> {
       this.AnwerChartList = value.data.AnswersList;
       if(!this.Desciptions){
        let that = this;
        let input: InputDTO = new InputDTO();
        input.SurveyObjectID = this._SurveyDefinition;
        let fullApiUrl: string = 'api/KioskSurveyDefinition/getSurveyQuestionDesciption';
        this.http.post<Array<DesciptionOutput>>(fullApiUrl, input)
            .then((res) => {
                that.Desciptions = res;
            })
            .catch(error => {
 
            });
       }
    }

   
    pointClickHandler(e) {
        this.toggleVisibility(e.target);
    }

    legendClickHandler (e) {
        let arg = e.target,
            item = e.component.getAllSeries()[0].getPointsByArg(arg)[0];

        this.toggleVisibility(item);
    }

    toggleVisibility(item) {
        if(item.isVisible()) {
           // item.hide();
        } else { 
           // item.show();
        }
    }
}

export class InputDTO {
    public SurveyObjectID: string;
}

export class OutputDTO {
    public TotalParticipation: number;
    public questionLists: Array<QuestionList>
}

export class QuestionList {
    public Question: string
    public ObjectId: Guid
    public AnswersList:Array<AnwerChart>;
}
export class AnwerChart{
    public AnswerName:string;
    public AnswerObjectId:Guid;
    public Point:number;
    public TotalSelect:number;
}

export class DesciptionOutput
{
    public  Desciption:string
    public Count:number;
}