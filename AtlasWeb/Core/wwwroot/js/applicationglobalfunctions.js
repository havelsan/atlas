
String.isNullOrEmpty = function (text) {
    return (text == null || text === '');
};
String.prototype.Equals = function (target) {
    var compareResult = (this.valueOf() === target);
    return compareResult;
};
String.prototype.Length = function () {
    return this.length;
};
String.prototype.Contains = function (value) {
    if (this.indexOf(value) !== -1) {
        return false;
    }
    return true;
};
function firstData(item) {
    if (Array.isArray(item)) {
        if (item.length > 0) {
            return item[0];
        }
        else {
            return item;
        }
    }
    else if(item.toArray){
        var el = item.toArray();
        if (el.length > 0) {
            return el[0];
        }
        else {
            return el;
        }
    }
    else {
        return item;
    }
}
Array.prototype.firstItem = function () {
    return firstData(this);
};
Element.prototype.firstItem = function () {
    return firstData(this);
};
HTMLElement.prototype.firstItem = function () {
    return firstData(this);
};
if(window.jQuery){
  jQuery.prototype.firstItem = function () {
    return firstData(this);
  };
}

String.prototype.hashCode = function () {
    var hash = 0, i, chr;
    if (this.length === 0) return hash;
    for (i = 0; i < this.length; i++) {
        chr = this.charCodeAt(i);
        hash = ((hash << 5) - hash) + chr;
        hash |= 0; // Convert to 32bit integer
    }
    return hash;
};
// tslint:disable-next-line:no-unused-variable
function pad(number) {
    if (number < 10) {
        return '0' + number;
    }
    return number;
};
self.pad = pad;
var DateUtil;
(function (DateUtil) {
    function Now() {
        return new Date();
    }
    DateUtil.Now = Now;
    function date() {
        return new Date();
    }
    DateUtil.date = date;
    function totalDays(first, second) {
        var diff = second - first;
        return Math.round(diff / (1000 * 60 * 60 * 24));
    }
    DateUtil.totalDays = totalDays;
    function toLocalString(value) {
        var tzoffset = value.getTimezoneOffset() * 60000; //offset in milliseconds
        var localISOTime = (new Date(value.valueOf() - tzoffset)).toISOString().slice(0, -1);
        return localISOTime;
    }
    DateUtil.toLocalString = toLocalString;
    function parseISOLocal(value) {
        var b = value.split(/\D/);
        return new Date(b[0], b[1] - 1, b[2], b[3], b[4], b[5]);
    }
    DateUtil.parseISOLocal = parseISOLocal;
    ;
})(DateUtil || (DateUtil = {}));

self.DateUtil = DateUtil;

Date.prototype.daysinMonth = function () {
    var d = new Date(this.getFullYear(), this.getMonth() + 1, 0);
    return d.getDate();
};
Date.prototype.HasValue = function () {
    if (this.valueOf() == null || this.valueOf() === '') {
        return false;
    }
    return true;
};
Date.prototype.getWeekNumber = function () {
    // Create a copy of this date object
    var target = new Date(this.valueOf());
    // ISO week date weeks start on Monday, so correct the day number
    var dayNr = (this.getDay() + 6) % 7;
    // ISO 8601 states that week 1 is the week with the first Thursday of that year
    // Set the target date to the Thursday in the target week
    target.setDate(target.getDate() - dayNr + 3);
    // Store the millisecond value of the target date
    var firstThursday = target.valueOf();
    // Set the target to the first Thursday of the year
    // First, set the target to January 1st
    target.setMonth(0, 1);
    // Not a Thursday? Correct the date to the next Thursday
    if (target.getDay() !== 4) {
        target.setMonth(0, 1 + ((4 - target.getDay()) + 7) % 7);
    }
    // The week number is the number of weeks between the first Thursday of the year
    // and the Thursday in the target week (604800000 = 7 * 24 * 3600 * 1000)
    return 1 + Math.ceil((firstThursday - target) / 604800000);
};
Date.prototype.Equals = function (target) {
    var compareResult = (this.valueOf() === target);
    return compareResult;
};
Date.prototype.AddDays = function (numDays) {
    var dat = new Date(this.valueOf());
    dat.setDate(dat.getDate() + numDays);
    return dat;
};
Date.prototype.AddMonths = function (m) {
    var d = new Date(this);
    var years = Math.floor(m / 12);
    var months = m - (years * 12);
    if (years) {
        d.setFullYear(d.getFullYear() + years);
    }
    if (months) {
        d.setMonth(d.getMonth() + months);
    }
    return d;
};
Date.prototype.AddHours = function (h) {
    this.setTime(this.getTime() + (h * 60 * 60 * 1000));
    return this;
};
Date.prototype.AddYears = function (value) {
    var n = new Date(this);
    n.setFullYear(n.getFullYear() + value);
    return n;
};

Date.prototype.AddMinutes = function (minutes) {
    var n = new Date(this);
    return new Date(n.getTime() + minutes * 60000);
};
Date.prototype.DayOfYear = function () {
    var dayCount = [0, 31, 59, 90, 120, 151, 181, 212, 243, 273, 304, 334];
    var mn = this.getMonth();
    var dn = this.getDate();
    var dayOfYear = dayCount[mn] + dn;
    if (mn > 1 && this.isLeapYear()) {
        dayOfYear++;
    }
    return dayOfYear;
};
Date.prototype.ToShortDateString = function () {
    return (this.getMonth() + 1) +
        '/' + this.getDate() +
        '/' + this.getFullYear();
};
Date.prototype.ToShortDateStringddmmyyyy = function () {
    return (this.getDate()) +
        '/' + (this.getMonth() + 1) +
        '/' + this.getFullYear();
};
Date.prototype.DayOfWeek = function () {
    return ['Sunday', 'Monday', 'Tuesday', 'Wednesday', 'Thursday', 'Friday', 'Saturday'][this.getDay()];
};
Date.prototype.Subtract = function (val) {
    var d = new Date();
    d.setDate(d.getDate() - val);
    return d;
};
Date.prototype.DayOfYear = function (value) {
    var n = this.getDate();
    this.setDate(1);
    this.setYear(this.getYear() + value);
    this.setDate(Math.min(n, this.getDaysInYear()));
    return this;
};
Math.Round = function (value, radix) {
    var val = value.toString() + 'e' + radix.toString();
    return Number(Math.round(Number(val)) + 'e-' + radix);
};
Math.Floor = function (value) {
    return Math.floor(value);
};
Math.Abs = function (value) {
    return Math.abs(value);
};
Math.Truncate = function (value) {
    return Math.trunc(value);
};
Math.Ceiling = function (value) {
    return Math.ceil(value);
};
Number.prototype.HasValue = function () {
    if (this.valueOf() == null || this.valueOf() === '') {
        return false;
    }
    return true;
};
Array.prototype.Contains = function (value) {
    if (this.indexOf(value) !== -1) {
        return false;
    }
    return true;
};
Array.prototype.Clear = function () {
    this.splice(0, this.length);
};
// tslint:disable-next-line:no-unused-variable
self.ApplicationGlobals = (function () {
    // tslint:disable-next-line:no-var-keyword
    var instance;
    function createInstance() {
        var object = new Object();
        return object;
    }
    return {
        getInstance: function () {
            if (!instance) {
                instance = createInstance();
            }
            return instance;
        }
    };
})();
// tslint:disable-next-line:no-unused-variable
self.redirectProperty = function (source, sourcePropertyName, target, targetPropertyName) {
    delete source[sourcePropertyName];
    Object.defineProperty(source, sourcePropertyName, {
        get: function () {
            return _.get(target, targetPropertyName);
        },
        set: function (value) {
            _.set(target, targetPropertyName, value);
        }
    });
}
Object.defineProperty(Number.prototype, 'Value', {
    get: function () {
        return this.valueOf();
    }
});
Object.defineProperty(String.prototype, 'Value', {
    get: function () {
        return this.valueOf();
    }
});

function i18nTargetLang(id, defaultLiteral) {
    var locale = document.locale;
    var localeFromStorage = sessionStorage.getItem('localeId');
    if (localeFromStorage)
        locale = localeFromStorage;

    if (!locale || locale == 'tr')
        return defaultLiteral;

    const transDictionary = self['translations'];
    if (transDictionary) {
        var targetTranslationDictionary = transDictionary[locale];
        if (targetTranslationDictionary) {
            var translation = targetTranslationDictionary[id];
            if (translation != null) {
                return translation;
            }
        }
    }
    return defaultLiteral;
}
self.i18n = i18nTargetLang;


function isPropertyChanged(obj, propName) {
    var orginalValues = obj.ServerValues;
    var originalValue = undefined;
    if (orginalValues) {
        originalValue = orginalValues[propName];
    }

    var currentValue = obj[propName];
    if (currentValue instanceof Date && typeof originalValue === 'string') {
        originalValue = DateUtil.parseISOLocal(orginalValues[propName]).toISOString();
        currentValue = obj[propName].toISOString();
    }
    if (currentValue && currentValue.constructor.name === 'Guid' && typeof originalValue === 'string') {
        currentValue = obj[propName].toString();
    }
    if (currentValue === null && originalValue === undefined) {
        return false;
    }
    if (currentValue === undefined && originalValue === null) {
        return false;
    }
    if (currentValue === originalValue) {
        return false;
    }
    return true;
}

self.isPropertyChanged = isPropertyChanged;

function isParentChanged(obj, propName) {
    var orginalValues = obj.ServerValues;
    var originalValue = undefined;
    if (orginalValues) {
        originalValue = orginalValues[propName];
    }
    var currentValue = obj[propName];
    var objectID = currentValue;

    if (currentValue && typeof currentValue !== 'string') {
        objectID = currentValue['ObjectID'];
    }
    if (objectID === null && originalValue === undefined) {
        return false;
    }
    if (objectID === undefined && originalValue === null) {
        return false;
    }
    if (objectID === originalValue) {
        return false;
    }
    return true;
}

self.isParentChanged = isParentChanged;

/* Event leak tespiti için yazılmış fonksiyon 
/* window veya document üzerinde abone olunup uygulama çalıştığı sürece aktif olan event'lar hariç sayı çok olmamalı  
/* totalEvents değeri sürekli olarak artıyorsa hafıza sızıntısı var anlamına gelir
    08.09.2017 A.Ş.
 
(function () {
    var totalEvents = 0;
    var totalEventOp = 0;
    var addEventListenerFunc = EventTarget.prototype.addEventListener; // store original
    EventTarget.prototype.addEventListener = function (type, fn, capture) {
        this.originalFunc = addEventListenerFunc;
        this.originalFunc(type, fn, capture); // call original method
        // console.log('Added Event Listener: on' + type);
        ++totalEvents;
        ++totalEventOp;
        if (totalEventOp % 100 === 0) {
            console.log('Total events: ' + totalEvents);
        }
    }
    var removeEventListenerFunc = EventTarget.prototype.removeEventListener; // store original
    EventTarget.prototype.removeEventListener = function (type, fn, capture) {
        this.originalFunc = removeEventListenerFunc;
        this.originalFunc(type, fn, capture); // call original method
        // console.log('Removed Event Listener: on' + type);
        --totalEvents;
        ++totalEventOp;
        if (totalEventOp % 100 === 0) {
            console.log('Total events: ' + totalEvents);
        }
    }
})();

*/