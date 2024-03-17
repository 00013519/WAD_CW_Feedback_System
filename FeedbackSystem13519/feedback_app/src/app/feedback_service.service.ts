import { HttpClient } from '@angular/common/http';
import { Injectable, inject } from '@angular/core';
import { Feedback } from './Feedback';

//13519

@Injectable({
    providedIn: 'root'
  })
  export class ServiceFeedbackService {
    httpClient = inject(HttpClient);
    constructor() { }
    create(item:Feedback){
      return this.httpClient.post<Feedback>("http://localhost:7083/api/Feedback/Create", item);
    };

    getAllFeedbackItems(){
      return this.httpClient.get<Feedback[]>("http://localhost:7083/api/Feedback/GetAll")
    };
  
    getByID(id:number){
      return this.httpClient.get<Feedback>("http://localhost:7083/api/Feedback/GetByID/id?id="+id);
    };

    edit(item:Feedback){
      return this.httpClient.put("http://localhost:7083/api/Feedback/Update", item);  
    };
    
    delete(id:number){
      return this.httpClient.delete("http://localhost:7083/api/Feedback/Delete/"+id);
    };
   
    getAllProducts(){
      return this.httpClient.get<Feedback[]>("http://localhost:7083/api/Products/Get")
    };
  }