
export class Util {

    public static ResolvePropertyCaseInsensitive(propertyString: String, object: any): any {
        let properties = propertyString.split(".");
        for (let i = 0; i < properties.length; i++) {
            properties[i] = properties[i].toLowerCase();
        }
        return this.GetPropertyCaseInsensitive(properties, object, 0);
    }

    public static ResolveProperty(propertyString: String, object: any): any {
        let properties = propertyString.split(".");
        return this.GetProperty(properties, object, 0);
    }

    public static SetPropertyValue(propertyString: String, object: any, value: any): any {
        let properties = propertyString.split(".");
        return this.SetProperty(properties, object, 0, value);
    }

    private static GetProperty(properties: string[],
        object: any,
        index: number): any {
        if (index == properties.length - 1) {
            return object[properties[index]];
        }
        else if (!object[properties[index]]) {
            //object[properties[index]] = {};
            //return this.GetProperty(properties, object[properties[index]], index + 1);
            return undefined;
        }
        else {
            return this.GetProperty(properties, object[properties[index]], index + 1);
        }
    }

    private static GetPropertyCaseInsensitive(properties: string[],
        obj: any,
        index: number): any {
        let returnVal: any;
        let keys: Array<any>;
        let lowerPropName: string;
        let propName: string;
        let found: Boolean = false;
        for (let key in obj) {
            lowerPropName = key.toLowerCase();
            propName = key;
            if (lowerPropName == properties[index]) {
                found = true;
                break;
            }
        }
        if (found) {
            if (index == properties.length - 1) {
                return obj[propName];
            }
            else if (!obj[propName]) {
                return undefined;
            }
            else {
                return this.GetProperty(properties, obj[propName], index + 1);
            }
        }
        return undefined;
    }

    private static SetProperty(properties: string[],
        object: any,
        index: number,
        value: any) {
        if (index == properties.length - 1) {
            object[properties[index]] = value;
        }
        else if (!object[properties[index]]) {
            object[properties[index]] = {};
            return this.SetProperty(properties, object[properties[index]], index + 1, value);
        }
        else {
            return this.SetProperty(properties, object[properties[index]], index + 1, value);
        }
    }

    public static turkishToUpper(string) {
        if (string as string == null)
            return string;
        string = string.toString();
        let letters = { "i": "İ", "ş": "Ş", "ğ": "Ğ", "ü": "Ü", "ö": "Ö", "ç": "Ç", "ı": "I" };
        string = string.replace(/(([iışğüçö]))/g, function (letter) { return letters[letter]; });
        return string.toUpperCase();
    }

    public static turkishToLower(string) {
        if (string as string == null)
            return string;
        string = string.toString();
        let letters = { "İ": "i", "I": "ı", "Ş": "ş", "Ğ": "ğ", "Ü": "ü", "Ö": "ö", "Ç": "ç" };
        string = string.replace(/(([İIŞĞÜÇÖ]))/g, function (letter) { return letters[letter]; });
        return string.toLowerCase();
    }

    public static ContainsElement(parent, child): Boolean {
        let node = child.parentNode;
        while (node != null) {
            if (node == parent) {
                return true;
            }
            node = node.parentNode;
        }
        return false;
    }

    public static MoveProperty(source: any, sourcePropertyName: string, target: any, targetPropertyName: string): void {
        delete source[sourcePropertyName];
        Object.defineProperty(source, sourcePropertyName, {
            get: function () {
                return Util.ResolveProperty(targetPropertyName, target);
            },
            set: function (value) {
                Util.SetPropertyValue(targetPropertyName, target, value);
            }
        });
    }

    public static ResolveListDefProperty(data: any, DisplayExpression: String): String {
        if (data && data.GeneratedDisplayExpression != undefined)
            return data.GeneratedDisplayExpression;
        if (!DisplayExpression || DisplayExpression.includes('Common') || !data) {
            return '';
        }
        try {
            let o;
            if (data.TTObject) {
                o = data.TTObject;
            }
            else {
                o = data;
            }
            let result = eval(DisplayExpression.toString());
            if (!result) {
                return '';
            }
            return result.includes("undefined") ? '' : result.toUpperCase();
        }
        catch (e) {
            console.error('listbox bind error: ' + e.toString());
            return '';
        }
    }

    public static IsBrowserChrome() {
        // please note,
        // that IE11 now returns undefined again for window.chrome
        // and new Opera 30 outputs true for window.chrome
        // and new IE Edge outputs to true now for window.chrome
        // and if not iOS Chrome check
        // so use the below updated condition
        let isChromium = window['chrome'],
            winNav = window.navigator,
            vendorName = winNav.vendor,
            isOpera = winNav.userAgent.indexOf("OPR") > -1,
            isIEedge = winNav.userAgent.indexOf("Edge") > -1,
            isIOSChrome = winNav.userAgent.match("CriOS");

        if (isIOSChrome) {
            // is Google Chrome on IOS
            return true;
        } else if (isChromium !== null && isChromium !== undefined && vendorName === "Google Inc." && isOpera == false && isIEedge == false) {
            // is Google Chrome
            return true;
        } else {
            // not Google Chrome
            return false;
        }
    }
}