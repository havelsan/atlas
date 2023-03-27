
export enum FontStyle {
    Regular = 0,
    Bold = 1,
    Italic = 2,
    Underline = 4,
    Strikeout = 8
}

export class Font {
    public Bold: boolean;
    public Italic: boolean;
    public Name: string;
    public Size: number;
    public Strikeout: boolean;
    public Style: FontStyle;
    public Underline: boolean;
}