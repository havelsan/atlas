export class CustomShowBoxModel {
    buttons: Array<CustomButtons> = new Array<CustomButtons>();
    public title: string;
    public value: string;
}
export class CustomButtons {
    buttonCaption: string;
    buttonValue: string;
}