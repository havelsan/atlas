import { ITTControlBase } from './ITTControlBase';
import { ITTDataMember } from './ITTDataMember';
import { ITTErrorChecker } from './ITTErrorChecker';

/*[TTBrowsableInterface]*/
export interface ITTControl extends ITTControlBase, ITTDataMember, ITTErrorChecker {
    /*[Browsable(false)]*/
    ControlValue?: any;
    /*[Browsable(false)]*/
    //ErrorProvider: ErrorProvider;
    Required?: boolean;
    CaptionLabel?: string;
    //InitializeAsUnbound(): void;
}