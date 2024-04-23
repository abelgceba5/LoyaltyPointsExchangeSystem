import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { TransferToUser } from 'src/app/models/transfertouser.model';
import { RegisterUsers } from 'src/app/modules/registerusers.model';
import { BankAccountService } from 'src/app/services/bankacountService.service';

@Component({
  selector: 'app-reedem-to-user',
  templateUrl: './reedem-to-user.component.html',
  styleUrls: ['./reedem-to-user.component.css']
})
export class ReedemToUserComponent implements OnInit {


  users: RegisterUsers[] = [];
  userId: any;
  userto : any;
  sendtoUserForm!: FormGroup;
  pointsToSender: number = 0;
  sentToUser : TransferToUser = new TransferToUser();

  constructor(private registeruser: BankAccountService)
  {

  }

  ngOnInit(): void {
    this.sendtoUserForm = new FormGroup({
      sendToUser: new FormControl('',),
      pointsToSender: new FormControl('',),
    });
    this.userId = sessionStorage.getItem('userId');
    this.loadUsers();
  }
  loadUsers(): void {
    this.registeruser.getAllUsers()
      .subscribe(
        (data: RegisterUsers[]) => {
          this.users = data;
        },
        (error) => {
          console.error('Error fetching users:', error);
        }
      );
  }

  submitForm(): void {

    if (this.sendtoUserForm.invalid) {
      return;
    }
 

    const userId = this.sendtoUserForm.value.userId;
    const pointsToSender = this.sendtoUserForm.get('points')?.value;
    this.userto = this.sendtoUserForm.get('sendToUser')?.value;

    this.registeruser.transfertoUser(this.userId,this.userto, this.pointsToSender)
      .subscribe(
        (touser: TransferToUser) => {
          console.log('Points transferred successfully to User :', touser);
          alert('Points transferred successfully to User');
        },
        (error) => {
          console.error('Error transferring points to user:', error);
          alert('Error transferring points to user');
        }
      );
  }
}

