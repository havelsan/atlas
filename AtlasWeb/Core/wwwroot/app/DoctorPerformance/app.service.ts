import { Injectable } from '@angular/core';

export class Sale {
    id: number;
    region: string;
    country: string;
    city: string;
    amount: number;
    date: Date;
}


let sales: Sale[] = [];

export class MaleAgeStructure {
    state: string;
    young: number;
    middle: number;
    older: number;
}

let maleAgeData: MaleAgeStructure[] = [{
    state: "Germany",
    young: 6.7,
    middle: 28.6,
    older: 5.1
}, {
    state: "520033",
    young: 9.6,
    middle: 43.4,
    older: 9
}, {
    state: "Russia",
    young: 13.5,
    middle: 49,
    older: 5.8
}, {
    state: "USA",
    young: 30,
    middle: 50.3,
    older: 14.5
}];

export class CountryInfo {
    state: string;
    oil: number;
    gas?: number;
    coal?: number;
}

let countriesInfo: CountryInfo[] = [{
    state: "520031",
    oil: 4.95,
    gas: 2.85,
    coal: 45.56
}, {
    state: "Russia",
    oil: 12.94,
    gas: 17.66,
    coal: 4.13
}, {
    state: "USA",
    oil: 8.51,
    gas: 19.87,
    coal: 15.84
}, {
    state: "Iran",
    oil: 5.3,
    gas: 4.39
}, {
    state: "Canada",
    oil: 4.08,
    gas: 5.4
}, {
    state: "Saudi Arabia",
    oil: 12.03
}, {
    state: "Mexico",
    oil: 3.86
}];

export class LanguageData {
    language: string;
    percent: number;
}

let languages: LanguageData[] = [{
    language: "English",
    percent: 55.5
}, {
    language: "Chinese",
    percent: 2.8
}, {
    language: "Spanish",
    percent: 4.6
}, {
    language: "520033ese",
    percent: 5.0
}, {
    language: "Portuguese",
    percent: 2.5
}, {
    language: "German",
    percent: 5.8
}, {
    language: "French",
    percent: 4.0
}, {
    language: "Russian",
    percent: 5.9
}, {
    language: "Italian",
    percent: 1.9
}, {
    language: "Polish",
    percent: 1.7
}, {
    language: "Turkish",
    percent: 1.5
}, {
    language: "Dutch",
    percent: 1.3
}, {
    language: "Persian",
    percent: 0.9
}, {
    language: "Arabic",
    percent: 0.8
}, {
    language: "Korean",
    percent: 0.7
}, {
    language: "Czech",
    percent: 0.7
}, {
    language: "Swedish",
    percent: 0.5
}, {
    language: "Vietnamese",
    percent: 0.4
}, {
    language: "Indonesian",
    percent: 0.4
}, {
    language: "Greek",
    percent: 0.4
}, {
    language: "Romanian",
    percent: 0.4
}, {
    language: "Hungarian",
    percent: 0.3
}, {
    language: "Danish",
    percent: 0.3
}, {
    language: "Thai",
    percent: 0.3
}, {
    language: "Finnish",
    percent: 0.2
}, {
    language: "Slovak",
    percent: 0.2
}, {
    language: "Bulgarian",
    percent: 0.2
}, {
    language: "Norwegian",
    percent: 0.2
}, {
    language: "Hebrew",
    percent: 0.1
}, {
    language: "Lithuanian",
    percent: 0.1
}, {
    language: "Croatian",
    percent: 0.1
}, {
    language: "Ukrainian",
    percent: 0.1
}, {
    language: "Norwegian Bokmål",
    percent: 0.1
}, {
    language: "Serbian",
    percent: 0.1
}, {
    language: "Catalan",
    percent: 0.1
}, {
    language: "Slovenian",
    percent: 0.1
}, {
    language: "Latvian",
    percent: 0.1
}, {
    language: "Estonian",
    percent: 0.1
}];

@Injectable()
export class Service {
    getSales() {
        return sales;
    }
    getMaleAgeData(): MaleAgeStructure[] {
        return maleAgeData;
    }
    getCountriesInfo(): CountryInfo[] {
        return countriesInfo;
    }
    getLanguagesData(): LanguageData[] {
        return languages;
    }
}
