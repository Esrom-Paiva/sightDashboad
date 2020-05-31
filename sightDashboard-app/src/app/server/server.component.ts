import { Component, OnInit, Input } from '@angular/core';
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

  @Input() server: Server;

  ngOnInit(): void {
    this.setServeAction(this.server.isOnline);
  }

  setServeAction(isOnline: boolean){
    if (isOnline){
      this.server.isOnline = true;
      this.color = '#b3ffd9';
      this.buttonText = 'Shut Down';
    }
    else {
      this.server.isOnline = false;
      this.color = '#ffb3b3';
      this.buttonText = 'Start';
    }
  }

  toggleStatus(onlineStatus: boolean){
    this.setServeAction(!onlineStatus);
  }

}
