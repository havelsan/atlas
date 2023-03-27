// DevExtreme messages (en messages already included)

Promise.all([
    System.import("devextreme/localization/globalize/number"),
    System.import("devextreme/localization/globalize/date"),
    System.import("devextreme/localization/globalize/currency"),
    System.import("devextreme/localization/globalize/message"),
    System.import('app/localization/tr.json!json'),
    System.import("cldr-data/main/tr/ca-gregorian.json!json"),
    System.import("cldr-data/main/tr/numbers.json!json"),
    System.import("cldr-data/main/tr/currencies.json!json"),
    System.import("cldr-data/supplemental/likelySubtags.json!json"),
    System.import("cldr-data/supplemental/timeData.json!json"),
    System.import("cldr-data/supplemental/weekData.json!json"),
    System.import("cldr-data/supplemental/currencyData.json!json"),
    System.import("cldr-data/supplemental/numberingSystems.json!json"),
    System.import("globalize")
]).then(function (res) {
    var trMessages = res[4];
    var trCaGregorian = res[5];
    var trNumbers = res[6];
    var trCurrencies = res[7];
    var likelySubtags = res[8];
    var timeData = res[9];
    var weekData = res[10];
    var currencyData = res[11];
    var numberingSystems = res[12];

    var Globalize = res[13];
    Globalize.load(trCaGregorian, trNumbers, trCurrencies, likelySubtags, timeData, weekData, currencyData, numberingSystems);
    Globalize.loadMessages(trMessages);
    Globalize.locale('tr');
});


