import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import { HubConnection, IHttpConnectionOptions, HubConnectionBuilder } from "@aspnet/signalr";
import { environment } from 'src/environments/environment';
import { tap } from "rxjs/operators";

@Injectable()
export class HubClient {
    constructor(
        private readonly _httpClient: HttpClient 

    ) { }

    private _connect: Promise<any>;
    private _connection: HubConnection;

    public connect() {

        if(this._connect) return this._connect;

        this._connect = new Promise((resolve,reject) => {

            this._httpClient.get(`${environment.hubUrl}api/signalrinfo/notificationsHub`)
            .pipe(tap(async (x:any) => {
                
                const options: IHttpConnectionOptions = {                    
                    accessTokenFactory: () => x.accessToken,
                    logMessageContent: true               
                  };
            
                this._connection = new HubConnectionBuilder()
                .withUrl(`${x.url}`, options)
                .build();  
                
                this._connection.on("commandCompleted", () => {
                    alert("Works?");
                });
                
                this._connection.start();
      
            }))
            .subscribe();    

        });

        return this._connect;
    }
}