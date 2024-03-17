import { Component, Input, inject } from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import {MatTableModule} from '@angular/material/table';
import { ServiceFeedbackService } from '../../feedback_service.service';
import { Feedback } from '../../Feedback';
import { Router } from '@angular/router';
import { MatIcon } from '@angular/material/icon';
import { DatePipe, NgFor } from '@angular/common';
//13519

@Component({
  selector: 'app-home',
  standalone: true,
  imports: [MatTableModule, MatButtonModule, MatIcon, NgFor, DatePipe],
  templateUrl: './home.component.html',
  styleUrl: './home.component.css'
})

export class HomeComponent {

  
  todoService=inject(ServiceFeedbackService); 
  router = inject(Router)
  items:Feedback[]=[];
  ngOnInit(){
    this.todoService.getAllFeedbackItems().subscribe((result)=>{this.items = result}); 
    console.log(this.items)
  }
 
  displayedColumns: string[] = ['ID', 'Content', 'Username', 'Rating', 'Product Name', 'Actions'];
  
  EditClicked(itemID:number){
    console.log(itemID, "From Edit");
    this.router.navigateByUrl("/edit/"+itemID);
  };
  DetailsClicked(itemID:number){
    console.log(itemID, "From Details");
    this.router.navigateByUrl("/details/"+itemID);
  };
  DeleteClicked(itemID:number){
    console.log(itemID, "From Delete");
    this.router.navigateByUrl("/delete/"+itemID);
  }
  getStarIcons(rating: string): string[] {
    const ratingNumber = parseInt(rating, 10);
    const starIcons: string[] = [];
    for (let i = 0; i < 5; i++) {
      if (i < ratingNumber) {
        starIcons.push('star');
      } else {
        starIcons.push('star_border');
      }
    }
    return starIcons;
  }
  

  formatDatetime(datetimeString: string): string {
    const datetime = new Date(datetimeString);
    const options: Intl.DateTimeFormatOptions = {
      year: 'numeric',
      month: 'long',
      day: 'numeric',
      hour: 'numeric',
      minute: 'numeric'
    };
    return datetime.toLocaleString('en-US', options);
  }

}

