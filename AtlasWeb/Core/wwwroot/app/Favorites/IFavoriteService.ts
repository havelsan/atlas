import { FavoriteItem } from "./FavoriteItem";
import { EventEmitter } from "@angular/core";

export abstract class IFavoriteService {

    abstract userFavorites : Array<string>;
    abstract items: Array<FavoriteItem>;
    abstract get count() : number;
    abstract addItem(item: FavoriteItem): void;
    abstract removeItem(key: string) : void;

    abstract addToFavorites(key : string) : Promise<boolean>;
    abstract removeFromFavorites(key : string): Promise<boolean>;
    abstract loadUserFavorites();
    
    abstract onUpdateEvent : EventEmitter<any>;
}