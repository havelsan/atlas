/*!
 * @author electricessence / http://xxxxxx.com/electricessence/
 * Licensing: MIT http://xxxxxx.com/electricessence/TypeScript.NET/blob/master/LICENSE.md
 */

export module Hours {
    export enum Per {
        Day = 24
    }
}

export module Minutes {
    export enum Per {
        Hour = 60,
        Day = Hour * Hours.Per.Day
    }

}

export module Seconds {
    export enum Per {
        Minute = 60,
        Hour = Minute * Minutes.Per.Hour,
        Day = Hour * Hours.Per.Day
    }

}

export module Milliseconds {
    export enum Per {
        Second = 1000,
        Minute = Second * Seconds.Per.Minute,
        Hour = Minute * Minutes.Per.Hour,
        Day = Hour * Hours.Per.Day
    }

}

export module Ticks {
    export enum Per {
        Millisecond = 10000,
        Second = Millisecond * Milliseconds.Per.Second,
        Minute = Second * Seconds.Per.Minute,
        Hour = Minute * Minutes.Per.Hour,
        Day = Hour * Hours.Per.Day
    }
}