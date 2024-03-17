import { Component, inject } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { MatInputModule } from '@angular/material/input';
import { MatFormFieldModule } from '@angular/material/form-field';
import { ServiceFeedbackService } from '../../feedback_service.service';
import { MatButtonModule } from '@angular/material/button';
import { MatChipsModule } from '@angular/material/chips';
import { MatSelectModule } from '@angular/material/select';
import { Router } from '@angular/router';
//13519

@Component({
  selector: 'app-create',
  standalone: true,
  imports: [FormsModule, MatFormFieldModule, MatSelectModule, MatInputModule, MatButtonModule, MatChipsModule],
  templateUrl: './create.component.html',
  styleUrl: './create.component.css'
})
export class CreateComponent {
  feedbackService = inject(ServiceFeedbackService);
  
  router = inject(Router);

  prod: any;

  pID: number = 0;

  createFeedback: any = {
    content: "",
    rating: "",
    username: "",
    productId: 0
  }

  ngOnInit() {
    this.feedbackService.getAllProducts().subscribe((result) => {
      this.prod = result
    });

  };
  create() {
    this.createFeedback.productId=this.pID
    this.feedbackService.create(this.createFeedback).subscribe(result=>{
      alert("Item Saved")
      this.router.navigateByUrl("home")
    });
  };


}
