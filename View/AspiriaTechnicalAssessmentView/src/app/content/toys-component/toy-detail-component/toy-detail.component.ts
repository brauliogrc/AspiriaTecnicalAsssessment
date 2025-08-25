import { Component, Inject, OnDestroy, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { Subscription } from 'rxjs';
import { IToy } from '../../../interfaces/IToy';
import { ToyService } from '../../../services/toy-service/toy.service';



@Component({
  selector: 'app-toy-detail-component',
  templateUrl: './toy-detail.component.html',
  styleUrl: './toy-detail.component.scss',
  imports: [ReactiveFormsModule]
})
export class ToyDetailComponent implements OnInit, OnDestroy{
  
  public toyFormGroup: FormGroup;

  private _subscriptions: Subscription = new Subscription();

  constructor(
    private _matDialogRef: MatDialogRef<ToyDetailComponent>,
    @Inject(MAT_DIALOG_DATA) public data: IToy,
    private _formBuilder: FormBuilder,
    private _toyService: ToyService
  ) {
    this.toyFormGroup = this._formBuilder.group({
      id: [this.data.id ?? 0],
      name: [this.data.name ?? '', [Validators.required]],
      description: [this.data.description ?? '', [Validators.required]],
      ageRestriction: [this.data.ageRestriction ?? 0, [Validators.required]],
      company: [this.data.company ?? '', [Validators.required]],
      price: [this.data.price ?? 0, [Validators.required]]
    });
  }

  ngOnInit(): void {
    this.toyFormGroup.valueChanges.subscribe(value => { console.log(value) });
  }

  handleSubmit(): void {
    if (!this.toyFormGroup.valid) {
      
      return;
    }
    (!this.isEmptyObject(this.data)) ? this.update() : this.create();
  }

  create(): void {
    console.log(this.toyFormGroup.value)
    this._subscriptions.add(
      this._toyService.create(this.toyFormGroup.value).subscribe(
        res => {
          if (res.isSuccess)
            this._matDialogRef.close(res.data);
        }
      )
    );
  }

  update(): void {
    console.log(this.toyFormGroup.value)
    this._subscriptions.add(
      this._toyService.update(this.toyFormGroup.value).subscribe(
        res => {
          if (res.isSuccess)
            this._matDialogRef.close(res.data);
        }
      )
    );
  }

  close(): void {
    this._matDialogRef.close(false);
  }

  ngOnDestroy(): void {
      this._subscriptions.unsubscribe();
  }

  private isEmptyObject = (obj: object): boolean => Object.keys(obj).length === 0;
}
