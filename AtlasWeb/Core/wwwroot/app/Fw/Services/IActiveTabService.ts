
export abstract class IActiveTabService {
    ActiveTabID: string;
    ActiveTabPage: string;
    ActiveTabSource: Map<string, string>;
    setActiveTab: (ActiveTabID: string, ActiveTabPage: string) => void;
    getActiveTab: (ActiveTabPage: string) => string;

}
