import { Component, OnInit } from '@angular/core';
import { UserDetails } from '../../models';
import {FormGroup, FormControl, Validators, FormBuilder} from '@angular/forms';
import { AuthService } from 'src/app/_services/auth.service';
import { DropDownModel } from 'src/app/models/DropDownModel';
import { BsDatepickerModule } from 'ngx-bootstrap';


@Component({
  selector: 'app-form',
  templateUrl: './form.component.html',
  styleUrls: ['./form.component.css']
})

export class FormComponent implements OnInit {

  registerForm: FormGroup;
  model: any;
  public dropDownModel: any[] = [];
  public premimumAmt: string;
  todayDate: Date = new Date();

  constructor(private fb: FormBuilder, private authservice: AuthService) {
    this.model = new UserDetails();
    this.todayDate.setDate(this.todayDate.getDate());
  }

  userDetails: UserDetails;

  ngOnInit() {
    this.createUserForm();
    this.authservice.getDDValues()
        .subscribe(data => {
          this.dropDownModel = data['occupationList'];
          console.log(this.dropDownModel);
        });
      }



  createUserForm() {
    this.registerForm = this.fb.group({
      name: ['', [Validators.required, Validators.minLength(3), Validators.maxLength(25)]],
      dateOfBirth: [null, Validators.required],
      sumInsured: ['', [Validators.required, Validators.minLength(3), Validators.maxLength(9),
        Validators.pattern('(?=.*?\\d)^\\$?(([1-9]\\d{0,2}(,\\d{3})*)|\\d+)?(\\.\\d{1,2})?$')]],
        occupation: ['', Validators.required],
        premimumAmt: ['']
    }, );
  }

  dateOfBirthValidator(g: FormGroup) {
  }


  dropdownChange = ( values: any) => {
   if (this.registerForm.valid) {
    this.authservice.calculatePremium(this.registerForm.value)
          .subscribe(data => {
          this.registerForm.patchValue({
          premimumAmt: data['premiumValue']
        });
    });
  }
}
}


