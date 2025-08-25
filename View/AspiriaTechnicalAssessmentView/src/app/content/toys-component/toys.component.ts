import { CommonModule } from '@angular/common';
import { Component, OnDestroy, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { Subscription } from 'rxjs';
import { IToy } from '../../interfaces/IToy';
import { ToyService } from '../../services/toy-service/toy.service';
import { ToyDetailComponent } from './toy-detail-component/toy-detail.component';

@Component({
  selector: 'ata-toys-component',
  templateUrl: './toys.component.html',
  styleUrl: './toys.component.scss',
  imports: [CommonModule]
})
export class ToysComponent implements OnInit, OnDestroy{

  public toys: Array<IToy> = [];
  private _subscriptions: Subscription = new Subscription();

  constructor(
    private _toyService: ToyService,
    private _matDialog: MatDialog
  ) {}

  ngOnInit(): void {
      this.fillTable();
  }
  
  fillTable(): void {
    this._subscriptions.add(
      this._toyService.getAll().subscribe(
        res => {
          if (res.isSuccess)
            this.toys = res.data;
        }
      )
    )
  }

  addNewToy(): void {
    const dialog = this._matDialog.open(ToyDetailComponent, {
      width: '23rem',
      data: {}
    });

    dialog.afterClosed().subscribe(
      (res: boolean) => {
        if (res) this.fillTable();
      }
    );
  }

  updateToy(toy: IToy): void {
    const dialog = this._matDialog.open(ToyDetailComponent, {
      width: '23rem',
      data: toy
    });

    dialog.afterClosed().subscribe(
      (res: boolean) => {
        if (res) this.fillTable();
      }
    );
  }

  deleteToy(toyId: number): void {
    this._subscriptions.add(
      this._toyService.delete(toyId).subscribe(
        res => {
          if (res.isSuccess)
            this.fillTable();
        }
      )
    );
  }

  confirmDeletion(toy: IToy): void {
    if(confirm(`Are you sure you want to remove the toy ${toy.name}?`)) {
      this.deleteToy(toy.id);
    }
  }
  
  ngOnDestroy(): void {
      this._subscriptions.unsubscribe();
  }
}
