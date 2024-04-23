import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { UserDashboardComponent } from './pages/user-dashboard/user-dashboard.component';
import { BankAccountComponent } from './pages/bank-account/bank-account.component';
import { ReedemToBankComponent } from './pages/reedem-to-bank/reedem-to-bank.component';
import { ReedemToUserComponent } from './pages/reedem-to-user/reedem-to-user.component';
import { TransactionsComponent } from './pages/transactions/transactions.component';
import { PurchaseComponent } from './pages/purchase/purchase.component';

const routes: Routes = [
  {
    path: '', component: UserDashboardComponent,
    children:[
      { path: 'bank-account', component: BankAccountComponent},
      { path: 'reedembank', component: ReedemToBankComponent},
      { path: 'reedemuser',  component: ReedemToUserComponent},
      { path: 'transactions', component: TransactionsComponent},
      { path: 'purchase', component: PurchaseComponent}
    ]
  }
  
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class UserRoutingModule { }
