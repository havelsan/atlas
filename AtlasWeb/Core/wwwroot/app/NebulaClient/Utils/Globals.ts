export class Globals {
        public static MakeVariableName(name: string): string {
        return name.replace(' ', '_');
    }
}