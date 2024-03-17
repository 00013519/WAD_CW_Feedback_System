import { Component, inject } from '@angular/core';
import { Feedback } from '../../Feedback';
import { ServiceFeedbackService } from '../../feedback_service.service';
import { MatChipsModule } from '@angular/material/chips';
import { MatCardModule } from '@angular/material/card';
import { MatButtonModule } from '@angular/material/button';
import { ActivatedRoute, Router } from '@angular/router';
import { MatIcon } from '@angular/material/icon';
import { NgFor } from '@angular/common';
//13519

@Component({
  selector: 'app-delete',
  standalone: true,
  imports: [MatChipsModule, MatCardModule, MatButtonModule, MatIcon, NgFor],
  templateUrl: './delete.component.html',
  styleUrl: './delete.component.css'
})
export class DeleteComponent {
  deleteFeedback:Feedback={
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
  service = inject(ServiceFeedbackService)
  activateRote= inject(ActivatedRoute)
  router = inject(Router)

  ngOnInit(){
    this.service.getByID(this.activateRote.snapshot.params["id"]).subscribe((result)=>{
      this.deleteFeedback = result
    });
  }
  
  onHomeButtonClick(){
    this.router.navigateByUrl("home")
  }
  onDeleteButtonClick(id:number){
    console.log(this.deleteFeedback.id);
    this.service.delete(this.deleteFeedback.id).subscribe(
      () => {
        console.log('Item deleted successfully');
      },
      (error) => {
        console.error('Error deleting item:', error);
      });
    alert("Deleted  item with ID: "+id)    
    this.router.navigateByUrl("home")
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
