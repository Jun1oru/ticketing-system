import { HttpClient } from '@angular/common/http';
import { Component, inject, OnInit, signal } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { HeaderComponent } from './layout/header/header.component';
import { Ticket } from './shared/models/ticket';

@Component({
  selector: 'app-root',
  imports: [RouterOutlet, HeaderComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css',
})
export class AppComponent implements OnInit {
  baseUrl = 'https://localhost:5001/api/';
  private http = inject(HttpClient);
  title = 'Ticketing System';
  tickets = signal<Ticket[]>([]);

  ngOnInit(): void {
    this.http.get<Ticket[]>(this.baseUrl + 'tickets').subscribe({
      next: (response) => {
        this.tickets.set(response);
        console.log(this.tickets());
      },
      error: (error) => console.log(error),
      complete: () => console.log('complete'),
    });
  }
}
