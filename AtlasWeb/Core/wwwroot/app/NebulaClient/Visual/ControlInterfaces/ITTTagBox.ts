import { ITTBindableControl } from "./ITTBindableControl";

export class TagBoxItemStyle {
    constructor(public Item: any, public BackColor: string) { }
}

export interface ITTTagBox extends ITTBindableControl  {
    DisplayMemberPath?: string;
    ValueMemberPath?: string;
    Styles?: Array<TagBoxItemStyle>;
}