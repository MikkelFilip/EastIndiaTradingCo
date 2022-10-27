import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';

@Component({
  selector: 'app-information-page',
  templateUrl: './information-page.component.html',
  styleUrls: ['./information-page.component.scss'],
  host: {
    class: 'd-flex flex-column flex-grow-1'
  }
})
export class InformationPageComponent implements OnInit {
  public form!: FormGroup;

  constructor(
    private router: Router,
    private fb: FormBuilder,
  ) {}

  ngOnInit(): void {
    this.form = this.fb.group({
      name: [null, Validators.required],
      email: [null, {
        validators: [Validators.required, Validators.email],
        updateOn: 'blur'
      }],
    });
  }

  public submit() {
    this.router.navigateByUrl("/confirmation");
  }

  public isFormControlInvalid(formControlName: string): boolean {
    return this.form.controls[formControlName].invalid
      && (this.form.controls[formControlName].dirty
        || this.form.controls[formControlName].touched);
  }

  public isFormControlHasError(formControlName: string, errorName: string): boolean {
    return this.form.controls[formControlName].errors?.[errorName];
  }
}
