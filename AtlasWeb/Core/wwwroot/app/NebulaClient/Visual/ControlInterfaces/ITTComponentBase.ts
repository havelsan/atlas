
/*[TTBrowsableInterface]*/
export interface ITTComponentBase {
    Name?: string;
    Text?: string;
    ReadOnly?: boolean;
    /*[Browsable(false)]*/
    Tag?: Object;
    //WriteDifferenceXml(writer: XmlWriter, inheritedComponent: ITTComponentBase): void;
    //IsDifferentFrom(component: ITTComponentBase): boolean;
    //SetSecurityInvisible(): void;
}