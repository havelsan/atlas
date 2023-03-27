
export class TTMultiSearchPanel {
    Configuration: Array<TTMultiSearchPanelConfig>;
    EnableAnimation: Boolean;
    //ProgressiveSearch: Boolean;
}

export class TTMultiSearchPanelConfig {
    PanelName: string;
    SelectedObjects?: Array<any>;
    FilterLabel: String;
    Filter?: String;
    //EnablePaging?: Boolean;
    //PageSize?: Number;
    DisplayMemberPath: String;
    Size: MultiSearchPanelSize;
    selectionMode: String; // selectionMode : single,multiple
    LinkedObject: any; // selectionMode : single ilgili  Obje, multiple ise ilgili Grid
    LinkedPropertyName: String; // Listviewlardan seçilen datanın LinkedObject 'in hangi propertysine set edileceği bilgisi
    RelatedPanelNameToLoad: String; // İlgili Panelin dolması için bir panelden seçim yapılması gerekiyorsa bu raya ilgili Panel

}

export class TTMultiSearchPanelDataLoadOptions {
    PanelName: String;
    //DataLoader: any;
    AllSelectedPanelObjects: any;
    SelectedObject: any;
    //RequireTotalCount: Boolean;
    //Take: number;
    //Skip: number;
}

export enum MultiSearchPanelSize {
    One = 1,
    Two = 2,
    Three = 3,
    Four = 4,
    Five = 5,
    Six = 6,
    Seven = 7,
    Eight = 8,
    Nine = 9,
    Ten = 10,
    Eleven = 11
}