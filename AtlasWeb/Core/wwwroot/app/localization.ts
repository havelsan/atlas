// DevExtreme Globalize integration
import 'devextreme/localization/globalize/number';
import 'devextreme/localization/globalize/date';
import 'devextreme/localization/globalize/currency';
import 'devextreme/localization/globalize/message';

// DevExtreme messages (en messages already included)
import trMessages = require('app/localization/tr.json');

// CLDR data
import trCaGregorian = require('cldr-data/main/tr/ca-gregorian.json');
import trNumbers = require('cldr-data/main/tr/numbers.json');
import trCurrencies = require('cldr-data/main/tr/currencies.json');

import likelySubtags = require('cldr-data/supplemental/likelySubtags.json');
import timeData = require('cldr-data/supplemental/timeData.json');
import weekData = require('cldr-data/supplemental/weekData.json');
import currencyData = require('cldr-data/supplemental/currencyData.json');
import numberingSystems = require('cldr-data/supplemental/numberingSystems.json');

import Globalize = require('globalize');

Globalize.load(
    trCaGregorian,
    trNumbers,
    trCurrencies,

    likelySubtags,
    timeData,
    weekData,
    currencyData,
    numberingSystems
);

Globalize.loadMessages(trMessages);
Globalize.locale('tr');