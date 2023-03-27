//$A0C4A122
import { DockPanelPaneModel } from './DockPanelPaneModel';
import { TileLayoutConfig } from './Layout/TileLayoutConfig';

export enum LayoutType {
    Free,
    Tile,
    Single
}

export class DockPanelModel {

    public LeftPaneModel: DockPanelPaneModel;
    public TopPaneModel: DockPanelPaneModel;
    public RightPaneModel: DockPanelPaneModel;
    public BottomPaneModel: DockPanelPaneModel;

    TileLayout: TileLayoutConfig;

    constructor(
        public LayoutType: LayoutType
        , public size: string = 'auto'
        , public applyDefaultStyles: boolean = true
        , public minSize: Number = 20
        , public paneClass: string = 'ui-layout-pane'		// default = 'ui-layout-pane'
        , public resizerClass: string = "ui-layout-resizer"	// default = 'ui-layout-resizer'
        , public togglerClass: string = "ui-layout-toggler"	// default = 'ui-layout-toggler'
        , public buttonClass: string = "ui-layout-button"	// default = 'ui-layout-button'
        , public togglerLength_open: Number = 15			// WIDTH of toggler on north/south edges - HEIGHT on east/west edges
        , public togglerLength_closed: Number = 20			// "100%" OR -1 = full height
        , public hideTogglerOnSlide: Boolean = false		// hide the toggler when pane is 'slid open'
        , public togglerTip_open: string = i18n("M17252", "Kapat")
        , public togglerTip_closed: string = "Aç"
        , public resizerTip: string = "Yeniden Boyutlandır"
        //	effect defaults - overridden on some panes
        , public fxName: string = "slide"		// none, slide, drop, scale
        , public fxSpeed_open: Number = 750
        , public fxSpeed_close: Number = 1500
        , public fxSettings_open: any = { easing: "easeInQuint" }
        , public fxSettings_close: any = { easing: "easeOutQuint" }) {
    }
}