import { Injectable, OnInit } from '@angular/core';
import { factory } from './factory';
import { HttpClient } from '@angular/common/http';
import * as signalR from '@aspnet/signalr';

@Injectable({
  providedIn: 'root'
})
export class FactoryService {
  factories: factory[] = [];
  _hubConnection: signalR.HubConnection;
  baseUrl = "api/factory/"

  constructor(private http: HttpClient) { 
    http.get(
      this.baseUrl
    ).subscribe(
        (data: factory[]) => this.factories = data,
        error => console.log(error)
    )

    this._hubConnection = new signalR.HubConnectionBuilder().withUrl("/notify").build();
    this._hubConnection
      .start()
      .then(() => console.log('Connection started!'))
      .catch(err => console.log('Error while establishing connection :('));

      this._hubConnection.on('BroadcastMessage', (type: string, payload: factory) => {
        console.log(type, payload)

        switch (type) {
          case "Create":
            this.factories.push(payload);
            break;
          case "Update":
            var index = this.factories.findIndex(e => e.factoryId == payload.factoryId);
            this.factories[index] = payload;
            break;
          case "Delete":
            var index = this.factories.findIndex(e => e.factoryId == payload.factoryId);
            this.factories.splice(index, 1);
            break;
          default:
            console.error("Factory not found");
        }
      });
  }

  AddFactory() {
    this.http.post(
      this.baseUrl,
      new factory()
    ).subscribe();
  }

  DeleteFactory(factory) {
    this.http.delete(
      this.baseUrl + factory.factoryId
    ).subscribe();
  }

  GetFactories() {
    return this.factories;
  }

  UpdateFactory(factory: factory) {
    this.http.put(
      this.baseUrl + factory.factoryId,
      factory
    ).subscribe()
  }
}
