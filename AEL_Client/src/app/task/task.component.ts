import { Component, OnInit, ViewChild, viewChild } from '@angular/core';
import { TodoService } from '../service/todo.service';
import { Tasks } from '../_model/task-list';
import { MaterialModule } from '../_module/material.module';
import { FormsModule } from '@angular/forms';
import { MatTableDataSource } from '@angular/material/table';
import { CommonModule } from '@angular/common';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatDialog } from '@angular/material/dialog';
import { TaskAddEditComponent } from '../task-add-edit/task-add-edit.component';
import { SelectionModel } from '@angular/cdk/collections';
import { MatSnackBar } from '@angular/material/snack-bar';

@Component({
  selector: 'app-task',
  standalone: true,
  imports: [
    MaterialModule,
    FormsModule,
    CommonModule
  ],
  templateUrl: './task.component.html',
  styleUrl: './task.component.css'
})
export class TaskComponent implements OnInit{


  constructor(private taskService : TodoService,private dialog: MatDialog,private _snackBar: MatSnackBar,) { }
  taskList: Tasks[] = [];
  selection = new SelectionModel<Tasks>(true, []);
  data = Object.assign(this.taskList);
  dataSources: any;
  displayCols = ['select','id', 'title', 'description', 'dueDate', 'status','actions'];
  @ViewChild(MatPaginator) paginator!: MatPaginator;
  @ViewChild(MatSort) sort!: MatSort;
  


  ngOnInit(): void {
    this.loadData();

  }

  loadData(){
    this.taskService.getTaskList().subscribe((res: any) => {
      this.taskList = res;
      console.log(this.taskList);
      this.dataSources = new MatTableDataSource(this.taskList);
      this.dataSources.paginator = this.paginator;
      this.dataSources.sort = this.sort;
    })
  }
  getStatusColor(status: string): string {
    switch (status) {
      case 'InProgress':
        return 'primary';
      case 'Completed':
        return 'accent';
      default:
        return 'warn';
    }
  }
  getStatusIcon(arg0: any) {
    switch (arg0) {
      case 'InProgress':
        return 'hourglass_top';
      case 'Completed':
        return 'done';
      default:
        return 'hourglass_bottom';
    
    }
  }
  openAddEditTaskDialog() {
    const dialogRef = this.dialog.open(TaskAddEditComponent);
    dialogRef.afterClosed().subscribe({
      next: (val) => {
        if (val) {
          this.loadData();
        }
      },
    });
  }
    isAllSelected() {
      const numSelected = this.selection.selected.length;
      const numRows = this.dataSources.data.length;
      return numSelected === numRows;
    }


    removeSelectedRows() {
      const idsToDelete = this.selection.selected.map(item => item.id);
      
      if (idsToDelete.length > 0) {
        this.taskService.bulkDeleteTask(idsToDelete).subscribe({
          next: (res) => {
            this._snackBar.open('Tasks Deleted Successfully', 'Close', {
              duration: 2000,
            });
            this.loadData();
          },
          error: (err) => {
            console.log(err);
          }
        });
      }
      this.selection = new SelectionModel<Tasks>(true, []);
    }
    

   masterToggle() {
    this.isAllSelected() ?
      this.selection.clear() :
      this.dataSources.data.forEach((row: Tasks) => this.selection.select(row));
  }



  deleteTask(id: number) {
    let confirm = window.confirm("Are you sure you want to delete this task?");
    if(confirm) {
      this.taskService.deleteTask(id).subscribe({
        next: (res) => {
          this._snackBar.open('Task Deleted Successfully', 'Close', {
            duration: 2000,
          });
          this.loadData();
        },
        error: (err) => {
          console.log(err);
        },
      });
    }
  }


  openEditForm(data: any) {
    const dialogRef = this.dialog.open(TaskAddEditComponent, {
      data,
    });

    dialogRef.afterClosed().subscribe({
      next: (val) => {
        if (val) {
          this.loadData();
        }
      }
    });
  }

  applyFilter(event: any) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSources.filter = filterValue.trim().toLowerCase();
  }

}
