import { Component } from '@angular/core';
import { URLService } from './services/urlservice.service'
import { URLModel } from '../app/models/urlmodel'

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss'],
  providers: [URLService]
})
export class AppComponent {

  public urls: URLModel[] = []

  constructor(private urlService: URLService){
    this.urlService.getAllBooks()
      .subscribe((data: URLModel[]) => this.urls = data);
  }

  title = 'Table';
}
