export class Color {

    private id: string;

    constructor(id: string) {
        this.id = id.toLowerCase();
    }

    public static FromArgb(argb: number): string;
    public static FromArgb(alpha: number, baseColor: Color): string;
    public static FromArgb(red: number, green: number, blue: number): string;
    public static FromArgb(alpha: number, red: number, green: number, blue: number): string;
    public static FromArgb(...prms): string {
        if (prms.length == 3 && (typeof prms[0] == "number") &&
            (typeof prms[1] == "number") && (typeof prms[2] == "number")) {
            let r: number = <number>prms[0];
            let g: number = <number>prms[1];
            let b: number = <number>prms[2];
            let colorTemp = "#" + ((1 << 24) + (r << 16) + (g << 8) + b).toString(16).slice(1);
            return colorTemp;
        }

        return null;
    }

    public static White: string = "#FFFFFF";

    public static Red: string = "#FFFF0000";

    public static Yellow: string = "#FFFFFF00";

    public static Green: string = "#FF008000";
    valueOf() {
        return this.id;
    }
}