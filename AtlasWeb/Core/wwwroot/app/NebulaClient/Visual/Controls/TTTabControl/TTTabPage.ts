import { TTControl } from "../TTControl";
import { ITTTabPage } from "../../ControlInterfaces/TTTabControl/ITTTabPage";

export class TTTabPage extends TTControl implements ITTTabPage {
    /*[Browsable(false)]*/
    public DisplayIndex: number;
   // public Bounds: Rectangle;
}