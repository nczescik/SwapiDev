import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { EpisodeDetailsComponent } from './episode-details/episode-details.component';
import { EpisodesListComponent } from './episodes-list/episodes-list.component';


const routes: Routes = [
  { path: '', component: EpisodesListComponent },
  { path: 'Episodes', component: EpisodesListComponent },
  { path: 'Episodes/:id', component: EpisodeDetailsComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
