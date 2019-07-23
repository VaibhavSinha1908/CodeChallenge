import { Component, OnInit } from '@angular/core';
import { UserDetails } from '../../models';
import {FormGroup, FormControl, Validators, FormBuilder} from '@angular/forms';
@Component({
  selector: 'app-form',
  templateUrl: './form.component.html',
  styleUrls: ['./form.component.css']
})
export class FormComponent implements OnInit {
registerForm: FormGroup;
model: any;

  constructor(private fb: FormBuilder) {
    this.model = new UserDetails();
     }
  userDetails: UserDetails;

  ngOnInit() {
    this.createUserForm();
  }

  createUserForm() {
    this.registerForm = this.fb.group({
      name: ['', [Validators.required, Validators.minLength(3), Validators.maxLength(25)]],
      dateOfBirth: [null, Validators.required],
      sumInsured: ['', [Validators.required, Validators.minLength(3), Validators.maxLength(9),
        Validators.pattern('(?=.*?\\d)^\\$?(([1-9]\\d{0,2}(,\\d{3})*)|\\d+)?(\\.\\d{1,2})?$')]],
        occupation: ['', Validators.required]
    });
  }

  dateOfBirthValidator(g: FormGroup) {
  }


  dropdownChange = ( values: any) => {
   console.log(this.registerForm.value);
  }
}


