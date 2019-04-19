import { Component } from '@angular/core';
import { HubClient } from './core/hub-client.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {

  constructor(
    private readonly _hubClient: HubClient
  ) { }

  title = 'Driver App';

  ngOnInit() {
    this._hubClient.connect();

  }
}
