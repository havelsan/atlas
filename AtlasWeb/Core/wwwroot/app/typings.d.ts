// This file contains ambient module declarations

declare module 'globalize' {
    const value: any;
    export = value;
}

declare module 'cldr-data/*' {
    const value: any;
    export = value;
}

declare module 'devextreme/localization/messages/*' {
    const value: any;
    export = value;
}

declare module 'app/localization/*' {
    const value: any;
    export default value;
}

declare var DateUtil: {
    Now: Date;
    dayDiff(first: Date, second: Date);
    toLocalString(value: Date): string;
    parseISOLocal(value: string): Date;
    totalDays(first: Date, second: Date);
};

declare var ApplicationGlobals: any;
declare function redirectProperty(source: any, sourcePropertyName: string, target: any, targetPropertyName: string): void;

declare module 'webcam' {
    const value: any;
    export = value;
}

declare function i18n(id: string, defaultLiteral: string): string;
declare function isPropertyChanged(obj: any, propName: string): boolean;
declare function isParentChanged(obj: any, propName: string): boolean;

declare var mMenu: any;
declare var mOffcanvas: any;
declare var mScrollTop: any;
declare var mHeader: any;
declare var mToggle: any;
declare var mQuicksearch: any;
declare var mUtil: any;
declare var mPortlet: any;
declare var app : any;