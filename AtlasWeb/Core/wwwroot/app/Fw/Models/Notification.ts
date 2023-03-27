
export class Notification {
    constructor(public message: string,
        public type: string,
        public displayTime:
            Number = 3000) { }
}