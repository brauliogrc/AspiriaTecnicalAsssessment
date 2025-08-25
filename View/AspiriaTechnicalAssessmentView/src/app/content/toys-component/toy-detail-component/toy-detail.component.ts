import { Component, Inject, OnDestroy } from '@angular/core';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { ToastrService } from 'ngx-toastr';
import { Subscription } from 'rxjs';
import { IToy } from '../../../interfaces/IToy';
import { ToyService } from '../../../services/toy-service/toy.service';

@Component({
  selector: 'ata-toy-detail-component',
  templateUrl: './toy-detail.component.html',
  styleUrl: './toy-detail.component.scss',
  imports: [ReactiveFormsModule]
})
export class ToyDetailComponent implements OnDestroy{
  
  public toyFormGroup: FormGroup;

  private _subscriptions: Subscription = new Subscription();

  constructor(
    private _matDialogRef: MatDialogRef<ToyDetailComponent>,
    @Inject(MAT_DIALOG_DATA) public data: IToy,
    private _formBuilder: FormBuilder,
    private _toyService: ToyService,
    private _toastrService: ToastrService
  ) {
    this.toyFormGroup = this._formBuilder.group({
      id: [this.data.id ?? 0],
      name: [this.data.name ?? '', [Validators.required, Validators.maxLength(50)]],
      description: [this.data.description ?? '', [Validators.maxLength(100)]],
      ageRestriction: [this.data.ageRestriction ?? '', [Validators.min(0), Validators.max(100)]],
      company: [this.data.company ?? '', [Validators.required, Validators.maxLength(50)]],
      price: [this.data.price ?? '', [Validators.required, Validators.min(1), Validators.max(1000)]]
    });
  }

  handleSubmit(): void {
    if (!this.toyFormGroup.valid) {
      
      return;
    }
    (!this.isEmptyObject(this.data)) ? this.update() : this.create();
  }
  
  create(): void {
    this._subscriptions.add(
      this._toyService.create(this.toyFormGroup.value).subscribe(
        res => {
          if (res.isSuccess) {
            this._toastrService.success(res.message);
            this._matDialogRef.close(res.data);
          }
          else {
            this._toastrService.error(
              this.handleErrors(res.errors),
              res.message
            );
          }
        }
      )
    );
  }

  update(): void {
    this._subscriptions.add(
      this._toyService.update(this.toyFormGroup.value).subscribe(
        res => {
          if (res.isSuccess) {
            this._toastrService.success(res.message);
            this._matDialogRef.close(res.data);
          }
          else {
            this._toastrService.error(
              this.handleErrors(res.errors),
              res.message
            );
          }
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

  private handleErrors(errors: Array<any>) {
    let errorStr: string = '';
    errors.forEach(err => {
      errorStr += `-${err.propertyName}: ${err.errorMessage}`
    });
    return errorStr;
  }
}