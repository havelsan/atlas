import { FavoriteItem } from "./FavoriteItem";
import { IFavoriteService } from "./IFavoriteService";
import { Injectable } from "@angular/core";
import { DynamicComponentInfo } from "app/Fw/Models/DynamicComponentInfo";
import { ModalInfo } from "app/Fw/Models/ModalInfo";
import { IModalService } from "app/Fw/Services/IModalService";
import { Component, OnInit, EventEmitter } from '@angular/core';
import { NeHttpService } from "app/Fw/Services/NeHttpService";
@Injectable()
export class FavoriteService implements IFavoriteService {

    addToFavorites(key: string) {

        let index = this.userFavorites.findIndex(x => x == key);
        if (index > -1) {

        } else {
            this.userFavorites.push(key);
            sessionStorage.setItem('favorites', JSON.stringify(this.userFavorites));
        }
        return this.httpService.get<boolean>('/api/Account/AddToFavorites?key=' + key);

    }
    removeFromFavorites(key: string) {

        let index = this.userFavorites.findIndex(x => x == key);
        if (index > -1) {
            this.userFavorites.splice(index, 1);
            sessionStorage.setItem('favorites', JSON.stringify(this.userFavorites));
        }

        return this.httpService.get<boolean>('/api/Account/RemoveFromFavorites?key=' + key);
    }

    userFavorites: string[] = [];

    onUpdateEvent: EventEmitter<any> = new EventEmitter<any>();

    items: FavoriteItem[] = [];


    loadUserFavorites() {

        let sessionKey = 'favorites';
        let isLocalDataExist = sessionStorage.getItem(sessionKey);

        if (isLocalDataExist == null) {
            this.httpService.get<any>('/api/Account/GetFavorites').then(x => {

                if (x == null || x.length < 1) {
                    x = [];
                } 
                
                this.userFavorites = x;

                sessionStorage.setItem(sessionKey, JSON.stringify(x));
            });
        } else {
            let data = JSON.parse(isLocalDataExist);
            this.userFavorites = data;
        }




    }

    constructor(private httpService: NeHttpService) {

    }


    private _count: number;
    get count(): number {
        return this._count;
    }

    addItem(item: FavoriteItem): void {
        let index = this.items.findIndex(x => x.key == item.key);
        if (index == -1) {
            this.items.push(item);

            this.onUpdateEvent.emit();
        } else {
            //console.log("item already in favorites.");
            //console.log(item);
        }
    }
    removeItem(key: string): void {
        let index = this.items.findIndex(x => x.key == key);
        if (index > -1) {
            this.items.splice(index, 1);
            this.onUpdateEvent.emit();
            //console.log("item removed");
        } else {
            //console.log("item not found");
        }
    }

    removeAll() {
        this.items.splice(0, this.items.length);
        this.onUpdateEvent.emit();
    }
}