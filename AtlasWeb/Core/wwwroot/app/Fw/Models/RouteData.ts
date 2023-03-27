export class RouteData {
    constructor(
        public ModulePath: string,
        public Path: string,
        public Params: any,
        public Caller: String,
        public IsPopup: Boolean = false
    ) {
    }
}