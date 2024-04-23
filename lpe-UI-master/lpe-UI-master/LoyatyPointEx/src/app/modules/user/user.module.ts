import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { UserRoutingModule } from './user-routing.module';
import { UserDashboardComponent } from './pages/user-dashboard/user-dashboard.component';
import { BankAccountComponent } from './pages/bank-account/bank-account.component';
import { TransactionsComponent } from './pages/transactions/transactions.component';
import { ReedemToUserComponent } from './pages/reedem-to-user/reedem-to-user.component';
import { ReedemToBankComponent } from './pages/reedem-to-bank/reedem-to-bank.component';
import { HeaderComponent } from '../user/components/header/header.component';
import { FooterComponent } from '../user/components/footer/footer.component';
import { PurchaseComponent } from './pages/purchase/purchase.component';



@NgModule({
  declarations: [
    UserDashboardComponent,
    //BankAccountComponent,
    TransactionsComponent,
   // ReedemToUserComponent,
    //ReedemToBankComponent,
    HeaderComponent,
    FooterComponent,
    //PurchaseComponent,
  ],
  imports: [
    CommonModule,
    UserRoutingModule
  ]
})
export class UserModule { }
