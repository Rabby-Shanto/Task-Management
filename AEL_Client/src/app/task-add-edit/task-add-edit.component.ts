import { Component, Inject, OnInit, inject } from '@angular/core';
import { MaterialModule } from '../_module/material.module';
import {  FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { TodoService } from '../service/todo.service';
import {  MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { MatSnackBar } from '@angular/material/snack-bar';

@Component({
  selector: 'app-task-add-edit',
  standalone: true,
  imports: [
    MaterialModule,
    ReactiveFormsModule,
    CommonModule,
    
  ],
  templateUrl: './task-add-edit.component.html',
  styleUrl: './task-add-edit.component.css'
})
export class TaskAddEditComponent implements OnInit {
  taskForm : FormGroup;
  constructor(private taskService:TodoService,
    private dialogRef:MatDialogRef<TaskAddEditComponent>,
    private formBuilder: FormBuilder,
    private _snackBar: MatSnackBar,
    @Inject(MAT_DIALOG_DATA) public data: any) {

      this.taskForm = this.formBuilder.group({
        title: ['',Validators.required],
        description: ['',Validators.required],
        dueDate: ['',Validators.required],
        userId: [1],
      });
      if (this.data) {
        this.taskForm.addControl('taskId', this.formBuilder.control('', Validators.required));
        this.taskForm.addControl('status', this.formBuilder.control('', Validators.required));
      }
     }


  ngOnInit(): void {
    if (this.data) {
      this.taskForm.patchValue({
        taskId: this.data.id,
        title: this.data.title,
        description: this.data.description,
        dueDate: this.data.dueDate,
        status: this.data.status
      });
    }
  }

  OnSubmit() {
    console.log(this.taskForm?.value);
    if (this.taskForm?.valid) {
      if (this.data) {
        this.taskService.updateTask(this.taskForm?.value).subscribe({
          next: (res: any) => {
            this._snackBar.open('Task Updated Successfully', 'Close', {
              duration: 2000,
            });
            this.dialogRef.close(true);
          },
          error: (err: any) => {
            this._snackBar.open('Error Occurred While Updating Task', 'Close', {
              duration: 2000,
            });
          }
        });
      } else {
        this.taskService.addTask(this.taskForm?.value).subscribe({
          next: (res: any) => {
            this._snackBar.open('Task Added Successfully', 'Close', {
              duration: 2000,
            });
            this.dialogRef.close(res);
          },
          error: (err: any) => {
            this.taskForm?.reset();
            this._snackBar.open('Error Occurred While Adding Task', 'Close', {
              duration: 2000,
            });
          }
        });
      }
    }
  }
}
