import { enableProdMode } from '@angular/core';
import { platformBrowserDynamic } from '@angular/platform-browser-dynamic';
import { getTranslationProviders } from './i18n-providers';
import { HvlAppModule } from './app.module';

enableProdMode();

if ((<any>self).webpackJsonp) {
    platformBrowserDynamic().bootstrapModule(HvlAppModule);
} else {

    getTranslationProviders().then(providers => {
        const options: any = { providers };
        platformBrowserDynamic().bootstrapModule(HvlAppModule, options);
    });
}