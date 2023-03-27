//$17DD9027
export enum PaneType {
    Left,
    Top,
    Right,
    Bottom,
    Center
}

export class DockPanelPaneModel {
    constructor(
        public Type: PaneType
        , public size: string = '250'
        , public initClosed: boolean = true
        , public spacing_closed: Number = 15			// wider space when closed
        , public togglerLength_closed: Number = 15			// make toggler 'square' - 21x21
        , public togglerAlign_closed: string = "middle"		// align to top of resizer
        , public togglerLength_open: Number = 15			// NONE - using custom togglers INSIDE west-pane
        , public togglerTip_open: string = i18n("M17252", "Kapat")
        , public togglerTip_closed: string = "Aç"
        , public resizerTip_open: string = "Yeniden Boyutlandır"
        //, slideTrigger_open: "click" 	// default
    ) { }
}