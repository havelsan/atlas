import { TRANSLATIONS, TRANSLATIONS_FORMAT, LOCALE_ID } from '@angular/core';

export function getTranslationProviders(): Promise<Object[]> {
    // Get the locale id from the global
    let locale = document['locale'] as string;
     /* const navigatorLang = navigator.language.split('-');
    if ( navigatorLang) {
        locale = navigatorLang[0];
    } */
    let localeFromStorage = sessionStorage.getItem('localeId');
    if ( localeFromStorage)
        locale = localeFromStorage;
    // return no providers if fail to get translation file for locale
    const noProviders: Object[] = [];
    // No locale or U.S. English: no translation providers
    if (!locale || locale === 'tr') {
        return Promise.resolve(noProviders);
    }
    // Ex: 'locale/messages.fr.xlf`
    const translationFile = `/app/localization/messages.${locale}.xlf`;
    return getTranslationsWithSystemJs(translationFile)
        .then((translations: string) => [
            { provide: TRANSLATIONS, useValue: translations },
            { provide: TRANSLATIONS_FORMAT, useValue: 'xlf' },
            { provide: LOCALE_ID, useValue: locale }
        ])
        .catch(() => noProviders); // ignore if file not found
}

function getTranslationsWithSystemJs(file: string) {
    return import(file + '!text'); // relies on text plugin
}
