import { NgModule } from "@angular/core";
import { MatButtonModule } from "@angular/material/button";
import { MatCardModule } from "@angular/material/card";
import { MatFormFieldModule } from "@angular/material/form-field";
import { MatTableModule } from "@angular/material/table";
import { MatInputModule } from "@angular/material/input";
import { MatPaginatorModule } from "@angular/material/paginator";
import { MatSortModule } from "@angular/material/sort";
import { MatMenuModule } from "@angular/material/menu";
import { MatToolbarModule } from "@angular/material/toolbar";
import { MatIconModule } from "@angular/material/icon";
import { MatChipsModule } from "@angular/material/chips";
import { MatDialogModule } from "@angular/material/dialog";
import { MatDatepickerModule } from "@angular/material/datepicker";
import { MatNativeDateModule } from "@angular/material/core";
import { MatCheckboxModule } from "@angular/material/checkbox";
import { MatSnackBarModule } from "@angular/material/snack-bar";
import { MatSelectModule } from "@angular/material/select";


@NgModule(
    {
        exports: [
            MatCardModule,
            MatTableModule,
            MatButtonModule,
            MatFormFieldModule,
            MatInputModule,
            MatPaginatorModule,
            MatSortModule,
            MatMenuModule,
            MatToolbarModule,
            MatIconModule,
            MatChipsModule,
            MatPaginatorModule,
            MatSortModule,
            MatDialogModule,
            MatDatepickerModule,
            MatNativeDateModule,
            MatCheckboxModule,
            MatSnackBarModule,
            MatSelectModule,

        ]
    }
)
export class MaterialModule {}