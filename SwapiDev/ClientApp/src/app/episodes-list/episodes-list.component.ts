import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-episodes-list',
  templateUrl: './episodes-list.component.html',
  styleUrls: ['./episodes-list.component.css']
})
export class EpisodesListComponent implements OnInit {
  title = 'ClientApp';
  episodes: any;

  constructor(private httpClient: HttpClient,
    private router: Router) {}
    

  ngOnInit() {
    this.fetchEpisodes()
  }

  fetchEpisodes() {
    this.httpClient.get('https://localhost:44379/Episodes/GetEpisodes').subscribe(res => {
      this.episodes = res;
    })
  }

  showEpisodeDetails(id: number) {
    this.router.navigate([`/Episodes/${id.toString()}`]);
  }
}