import { ModalActionResult } from 'Fw/Models/ModalInfo';

export abstract class IEditorTemplateService {
    abstract selectEditorTemplate(templateGroupName: string): Promise<ModalActionResult>;
    abstract makeEditorTemplate(templateGroupName: string): Promise<ModalActionResult>;
    abstract updateEditorTemplate(templateGroupName: string): Promise<ModalActionResult>;
}