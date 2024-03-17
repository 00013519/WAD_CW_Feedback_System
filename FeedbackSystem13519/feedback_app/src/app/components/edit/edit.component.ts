import { Component, OnInit, inject } from '@angular/core';
import { ServiceFeedbackService } from '../../feedback_service.service';
import { FormsModule } from '@angular/forms';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatSelectModule } from '@angular/material/select';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import { ActivatedRoute, Router } from '@angular/router';
import { Feedback } from '../../Feedback';
//13519

function findIndexByID(jsonArray: any[], indexToFind: number): number {
  return jsonArray.findIndex((item) => item.id === indexToFind);
}

@Component({
  selector: 'app-edit',
  standalone: true,
  imports: [FormsModule, MatFormFieldModule, MatSelectModule, MatInputModule, MatButtonModule],
  templateUrl: './edit.component.html',
  styleUrl: './edit.component.css'
})

export class EditComponent implements OnInit {
  feedbackService = inject(ServiceFeedbackService); 
  activatedRoute = inject(ActivatedRoute);
  router = inject(Router);
  editFeedback: Feedback = {
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
  };
  productObject: any; 
  selected: any
  pID: number = 0;
  ngOnInit() {
    this.feedbackService.getByID(this.activatedRoute.snapshot.params["id"]).subscribe(result => {
      this.editFeedback = result;
      this.selected = this.editFeedback.productId;
    });
    this.feedbackService.getAllProducts().subscribe((result) => {
      this.productObject = result;
    });
  }

  toHome() {
    this.router.navigateByUrl("home")
  }

  edit() {
    this.editFeedback.productId = this.pID;
    this.editFeedback.product = this.productObject[findIndexByID(this.productObject, this.pID)];
    this.feedbackService.edit(this.editFeedback).subscribe(res=>{
      alert("Changes has been updated")
      this.router.navigateByUrl("home");
    })
  }
}


