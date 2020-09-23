import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import {ServerMessage} from '../shared/server-message';
import { Server } from '../shared/server';

@Component({
  selector: 'app-server',
  templateUrl: './server.component.html',
  styleUrls: ['./server.component.css']
})
export class ServerComponent implements OnInit {

  constructor() { }

  color: string;
  buttonText: string;
  serverStatus: string;
  isLoading: boolean;

  @Input() server: Server;
  @Output() serverAction = new EventEmitter<ServerMessage>();

  ngOnInit(): void {
    this.setServeAction(this.server.isOnline);
  }

  setServeAction(isOnline: boolean){
    if (isOnline){
      this.server.isOnline = true;
      this.serverStatus = 'Online';
      this.color = '#b3ffd9';
      this.buttonText = 'Shut Down';
    }
    else {
      this.server.isOnline = false;
      this.serverStatus = 'Offline';
      this.color = '#ffb3b3';
      this.buttonText = 'Start';
    }
  }

  makeLoading(){
    this.color = '#FFCA28';
    this.buttonText = 'Pending...';
    this.isLoading = true;
    this.serverStatus = 'Loading';

  }

  toggleStatus(onlineStatus: boolean){
    this.setServeAction(!onlineStatus);
  }

  sendServerAction(isOnline: boolean){
    console.log('teste');
    this.makeLoading();
    const payload = this.buildPayload(isOnline);
    this.serverAction.emit(payload);
  }

  buildPayload(isOnline: boolean): ServerMessage {
      return {
        id: this.server.id,
        payload: !isOnline
      };
  }
}
