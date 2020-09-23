import { ServerService } from './../../services/server.service';
import { Component, OnInit } from '@angular/core';
import { Server } from '../../shared/server';
import { ServerMessage } from 'src/app/shared/server-message';
import { Observable } from 'rxjs-compat';
import { AnonymousSubscription } from 'rxjs-compat/Subscription';
@Component({
  selector: 'app-section-health',
  templateUrl: './section-health.component.html',
  styleUrls: ['./section-health.component.css']
})
export class SectionHealthComponent implements OnInit {

  constructor(private serverService: ServerService) { }

  servers: Server[];
  timerSubscription: AnonymousSubscription;

  ngOnInit() {
    this.refreshData();
  }

  ngOnDestroy() {
    if (this.timerSubscription) {
      this.timerSubscription.unsubscribe();
    }
  }

  refreshData() {
    this.serverService.getServer().subscribe(res => {
      this.servers = res;
    });

    this.subscribeToData();
  }

  subscribeToData() {
    this.timerSubscription = Observable.timer(5000).first().subscribe(() => this.refreshData());
  }

  sendMessage(msg: ServerMessage) {
    this.serverService.handleServerMessage(msg)
      .subscribe(res => console.log('Message sent to server:', msg),
                 err => console.log('Error:', err));
  }

}
