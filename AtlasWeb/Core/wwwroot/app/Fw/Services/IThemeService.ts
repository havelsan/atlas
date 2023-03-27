import { BehaviorSubject } from "rxjs";

export abstract class IThemeService {
    setTheme: (name: string) => void;
    themeChanged: BehaviorSubject<string>;
}