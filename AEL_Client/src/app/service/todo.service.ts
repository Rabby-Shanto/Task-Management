import { Injectable } from '@angular/core';
import { environment } from '../../environment/environment';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, map } from 'rxjs';
import { Tasks } from '../_model/task-list';

@Injectable({
  providedIn: 'root'
})
export class TodoService {
  private baseUrl = environment.API_Base_URL;

  constructor(private httpClient: HttpClient) { }

  addTask(data: any) : Observable<any> {
    return this.httpClient.post(`${this.baseUrl}/TaskManagement`, data);
  }
  updateTask(data: any) : Observable<any> {
    return this.httpClient.put(`${this.baseUrl}/TaskManagement`, data);
  }
  getTaskList() : Observable<Tasks[]> {
    return this.httpClient.get(`${this.baseUrl}/TaskManagement/GetAllTasks`).pipe(
      map((res: any) => res.data));
  }
  getFilteredTaskList(data: any) : Observable<any> {
    return this.httpClient.get(`${this.baseUrl}/todo/list/${data}`);
  }
  
  deleteTask(id: any): Observable<any> {
    const options = {
        headers: new HttpHeaders({
            'Content-Type': 'application/json'
        }),
        body: { id: Number(id) }
    };
    return this.httpClient.request('delete', `${this.baseUrl}/TaskManagement`, options);
}

  bulkDeleteTask(taskIds: number[]) : Observable<any> {

    return this.httpClient.post(`${this.baseUrl}/TaskManagement/BulkDelete`, {taskIds});
  }
}
