import { Component, Input, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { BankAccountService } from 'src/app/services/bankacountService.service';

@Component({
  selector: 'app-bank-account',
  templateUrl: './bank-account.component.html',
  styleUrls: ['./bank-account.component.css']
})
export class BankAccountComponent implements OnInit {
  userId: any;
  bankAccountForm!: FormGroup;
  initialBalance: number = 0;
  constructor(
    private formBuilder: FormBuilder,
    private bankAccountService: BankAccountService
  ) { }

  ngOnInit(): void {
    this.bankAccountForm = this.formBuilder.group({
      userId: ['',],
      initialBalance: ['', [Validators.required, Validators.min(0)]]
    });
    this.userId = sessionStorage.getItem('userId');
    console.log('test user id ' + this.userId);
  }
   
  onSubmit() {
    if (this.bankAccountForm.invalid) {
      return;
    }

    const userId = this.bankAccountForm.value.userId;

    const initialBalance = this.bankAccountForm.value.initialBalance;

    this.bankAccountService.createBankAccount(this.userId , this.initialBalance)
      .subscribe(
        response => {
          // Handle success response
          console.log('Bank account created successfully:', response);
          alert('Bank account created successfully');
        },
        error => {
          // Handle error response
          console.error('Failed to create bank account:', error);
          alert('Failed to create bank account');
        }
      );
  }
}
