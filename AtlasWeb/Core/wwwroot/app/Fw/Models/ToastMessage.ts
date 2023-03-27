
export class ToastMessage {

    public Message: string;
    public Time: Date;
    public Type: String;
    public ShowingTime: number;
    public ShowableTime: number;

    constructor(message: string, type: string, showingTime: number)
    {
        this.Message = message;
        this.Type = type;
        this.ShowingTime = showingTime;
        this.Time = new Date();
    }
    public Displayable(): boolean
    {
        let Now = new Date();
        let diff = Now.getTime() - this.Time.getTime();
        this.ShowableTime = this.ShowingTime - diff;

        if (this.ShowableTime > 0)
            return true;

        return false;
    }

}