import { Component, inject } from '@angular/core';
import { Feedback } from '../../Feedback';
import { ServiceFeedbackService } from '../../feedback_service.service';
import { ActivatedRoute } from '@angular/router';
import { MatChipsModule } from '@angular/material/chips'
import {MatCardModule} from '@angular/material/card';
import { NgFor } from '@angular/common';
import { MatIcon } from '@angular/material/icon';
//13519

@Component({
  selector: 'app-details',
  standalone: true,
  imports: [MatChipsModule,MatCardModule, NgFor, MatIcon],
  templateUrl: './details.component.html',
  styleUrl: './details.component.css'
})
export class DetailsComponent {
  detailsFeedback:Feedback={
    id: 0,
    content: "",
    username: "",
    rating: "",
    createdAt: "",
    productId: 0,
    product: {
      id: 0,
      name: ""
    }
  
  }
  serviceFeedback = inject(ServiceFeedbackService)
  activatedRoute = inject(ActivatedRoute)
  ngOnInit(){
    
    
    this.serviceFeedback.getByID(this.activatedRoute.snapshot.params["id"]).subscribe((resultedItem)=>{
    this.detailsFeedback=resultedItem  
    });
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
