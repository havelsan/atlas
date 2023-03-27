import { IThemeService } from './IThemeService';
import { BehaviorSubject } from 'rxjs';
import { refreshTheme } from 'devextreme/viz/themes';
import { Injectable } from '@angular/core';
@Injectable()
export class ThemeService implements IThemeService {

    themeChanged = new BehaviorSubject("");

    private themeList = [
        { show: true, src: 'theme.css', name: 'Default', },
        { show: true, src: 'dx.old.light.css', name: 'Eski', },
        { show: true, src: 'dx.light.css', name: 'Light', },
        { show: true, src: 'dx.softblue.compact.css', name: 'SoftBlue Compact', },
        { show: true, src: 'dx.carmine.compact.css', name: 'Carmine Compact', },
        { show: true, src: 'dx.greenmist.compact.css', name: 'Green Compact', },
        { show: true, src: 'dx.softblue.css', name: 'SoftBlue', },
        { show: true, src: 'dx.win10.white.css', name: 'Windows 10', },
        { show: false, src: 'dx.win8.white.css', name: 'Windows 8', },
        { show: true, src: 'dx.ios7.default.css', name: 'iOS', },
        { show: true, src: 'dx.android5.light.css', name: 'Android', },
        { show: true, src: 'dx.carmine.css', name: 'Carmine', },
        { show: true, src: 'dx.greenmist.css', name: 'Green', },
        { show: true, src: 'dx.material.blue.light.css', name: 'Material Blue', },
        { show: true, src: 'dx.material.lime.light.css', name: 'Material Lime', },
        { show: true, src: 'dx.material.orange.light.css', name: 'Material Orange', },
        { show: true, src: 'dx.material.purple.light.css', name: 'Material Purple', },
        { show: true, src: 'dx.material.teal.light.css', name: 'Material Teal', },
        { show: true, src: 'dx.contrast.compact.css', name: 'dx.contrast.compact', },
        { show: true, src: 'dx.contrast.css', name: 'dx.contrast', },
        { show: true, src: 'dx.dark.compact.css', name: 'dx.dark.compact', },
        { show: true, src: 'dx.dark.css', name: 'dx.dark', },
        { show: true, src: 'dx.darkmoon.compact.css', name: 'dx.darkmoon.compact', },
        { show: true, src: 'dx.darkmoon.css', name: 'dx.darkmoon', },
        { show: true, src: 'dx.darkviolet.compact.css', name: 'dx.darkviolet.compact', },
        { show: true, src: 'dx.darkviolet.css', name: 'dx.darkviolet', },
        { show: true, src: 'dx.material.blue.dark.css', name: 'dx.material.blue.dark', },
        { show: true, src: 'dx.material.lime.dark.css', name: 'dx.material.lime.dark', },
        { show: true, src: 'dx.material.orange.dark.css', name: 'dx.material.orange.dark', },
        { show: true, src: 'dx.material.purple.dark.css', name: 'dx.material.purple.dark', },
        { show: true, src: 'dx.material.teal.dark.css', name: 'dx.material.teal.dark', },
        { show: false, src: 'dx.win8.black.css', name: 'dx.win8.black', },
        { show: true, src: 'dx.win10.black.css', name: 'dx.win10.black', },

    ];


    public getThemes() {
        return this.themeList.filter(x => x.show == true);

    }

    private basePath = '/assets/devextreme/css/';

    setTheme(theme: string) {

        let item = this.themeList.filter(x => x.name == theme);

        if (item.length < 1){
            console.log('Theme Not Found');
            return;
        }

        let element = document.getElementById('themecss');
        if (element == null) {
            let elements = document.getElementsByTagName('link');
            for (let i = 0; i < elements.length; i++) {

                if (elements[i].attributes['href'].value.indexOf('theme.') > -1) {
                    elements[i].setAttribute('id', 'themecss');
                    element = elements[i];
                    break;
                }
            }
        }
        if (element) {
            element.setAttribute('href', this.basePath + item[0].src);
            refreshTheme();
            this.themeChanged.next(theme);
        } else {
            console.log("theme not found");
        }


    }
}