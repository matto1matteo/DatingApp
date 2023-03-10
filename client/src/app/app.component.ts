import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'Some title';
  users: any;

  constructor(private http: HttpClient) {

  }

  public ngOnInit(): void {
    this.http.get(
      "https://localhost:5000/api/users"
    ).subscribe({
      next: (response) => {
        this.users = response;
      },
      error: (error) => {
        console.error(error);
      },
      complete: () => {
        console.log("Completed");
      }
    });
  }
  
}
