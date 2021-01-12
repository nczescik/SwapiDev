import { HttpClient } from '@angular/common/http';
import { Component, OnDestroy, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup } from '@angular/forms';
import { ActivatedRoute} from '@angular/router';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-episode-details',
  templateUrl: './episode-details.component.html',
  styleUrls: ['./episode-details.component.css']
})
export class EpisodeDetailsComponent implements OnInit, OnDestroy {
  episode: any;
  sub: Subscription;
  id: any;
  EpisodeRatingModel: FormGroup;

  constructor(private fb: FormBuilder,
    private httpClient: HttpClient,
    private route: ActivatedRoute) { 
    }

  ngOnInit(): void {

    this.EpisodeRatingModel = this.fb.group({
      'Rating': ''
    });

    this.sub = this.route.params.subscribe(params => {
      this.id = Number(params['id']);
   });
    
    this.httpClient.get(`https://localhost:44379/Episodes/GetEpisode/${this.id}`).subscribe(res => {
       this.episode = res;
    })

  }

  ngOnDestroy() {
    this.sub.unsubscribe();
  }

  rateEpisode(): void {
    var body = {
      EpisodeId: this.id,
      Rating: this.EpisodeRatingModel.value.Rating != '' ? Number(this.EpisodeRatingModel.value.Rating) : null
    }
    this.httpClient.post('https://localhost:44379/Episodes/RateEpisode', body).subscribe();
  }

}
