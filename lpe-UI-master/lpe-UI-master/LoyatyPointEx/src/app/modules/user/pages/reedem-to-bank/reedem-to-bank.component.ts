import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { BankAccount } from 'src/app/models/BankAccount.model';
import { TransferToBank } from 'src/app/models/tranfertobank.model';
import { BankAccountService } from 'src/app/services/bankacountService.service';

@Component({
  selector: 'app-reedem-to-bank',
  templateUrl: './reedem-to-bank.component.html',
  styleUrls: ['./reedem-to-bank.component.css']
})
export class ReedemToBankComponent implements OnInit {
  bankAccounts: BankAccount[] = [];
  transferToBank : TransferToBank = new TransferToBank();
  userId: any;
  sendtoBankForm!: FormGroup;
  pointsToSender: number = 0;
  
  constructor( private bankAccountService: BankAccountService)
  {}

  ngOnInit(): void {
    
    this.sendtoBankForm = new FormGroup({
      sendToBankAccount: new FormControl('',),
      pointsToSender: new FormControl('',)
    });
    this.loadBankAccounts();
    this.userId = sessionStorage.getItem('userId');
  }

  loadBankAccounts(): void {
    this.bankAccountService.getAllBankAccount()
      .subscribe(
        (data: BankAccount[]) => {
          this.bankAccounts = data;
        },
        (error) => {
          console.error('Error fetching bank accounts:', error);
        }
      );
  }
  submitForm(): void {

    if (this.sendtoBankForm.invalid) {
      return;
    }

    const userId = this.sendtoBankForm.value.userId;
    const pointsToSender = this.sendtoBankForm.get('points')?.value;

    this.bankAccountService.transferToBank(this.userId, this.pointsToSender)
      .subscribe(
        (transferToBank: TransferToBank) => {
          console.log('Points transferred to bank account:', transferToBank);
          alert('Points transferred successfully to bank account');
        },
        (error) => {
          console.error('Error transferring points to bank account:', error);
          alert('Error transferring points to bank account');
        }
      );
  }
}
 

