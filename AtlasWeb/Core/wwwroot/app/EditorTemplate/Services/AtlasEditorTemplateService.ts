//$4368175B
import { Injectable } from '@angular/core';
import { ModalActionResult, ModalInfo } from 'Fw/Models/ModalInfo';
import { DynamicComponentInfo } from 'Fw/Models/DynamicComponentInfo';
import { AtlasEditorTemplateList } from '../Views/AtlasEditorTemplateList';
import { AtlasEditorTemplate } from '../Views/AtlasEditorTemplate';
import { IModalService } from 'Fw/Services/IModalService';

@Injectable()
export class AtlasEditorTemplateService {

    constructor(private modalService: IModalService) {
    }

    public selectEditorTemplate(templateGroupName: string): Promise<ModalActionResult> {
        let dynamicComponentInfo = new DynamicComponentInfo();
        dynamicComponentInfo.ComponentType = AtlasEditorTemplateList;
        dynamicComponentInfo.InputParam = templateGroupName;
        let modalInfo = new ModalInfo();
        modalInfo.Width = 600;
        modalInfo.Height = 500;
        modalInfo.Title = 'Lütfen listeden kullanacağınız şablonu seçiniz';
        return this.modalService.create(dynamicComponentInfo, modalInfo);
    }

    public makeEditorTemplate(templateGroupName: string): Promise<ModalActionResult> {
        let dynamicComponentInfo = new DynamicComponentInfo();
        dynamicComponentInfo.ComponentType = AtlasEditorTemplate;
        dynamicComponentInfo.InputParam = { templateGroupName :templateGroupName , isUpdate:false };
        let modalInfo = new ModalInfo();
        modalInfo.Width = 600;
        modalInfo.Height = 300;
        modalInfo.Title = i18n("M24593", "Yeni şablon oluşturma");
        return this.modalService.create(dynamicComponentInfo, modalInfo);
    }

    public updateEditorTemplate(templateGroupName: string): Promise<ModalActionResult> {
        let dynamicComponentInfo = new DynamicComponentInfo();
        dynamicComponentInfo.ComponentType = AtlasEditorTemplate;
        dynamicComponentInfo.InputParam = { templateGroupName :templateGroupName , isUpdate:true };
        let modalInfo = new ModalInfo();
        modalInfo.Width = 600;
        modalInfo.Height = 300;
        modalInfo.Title = i18n("M24593", "Yeni şablon oluşturma");
        return this.modalService.create(dynamicComponentInfo, modalInfo);
    }
}