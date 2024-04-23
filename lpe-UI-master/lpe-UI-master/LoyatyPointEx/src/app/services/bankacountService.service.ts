import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { BankAccount } from '../models/BankAccount.model';
import { environment } from 'src/environments/environments';
import { TransactionHistory } from '../models/historytransaction.model';
import { RegisterUsers } from '../modules/registerusers.model';
import { TransferToBank } from '../models/tranfertobank.model';
import { TransferToUser } from '../models/transfertouser.model';
//import { Item } from '../models/Item';
import { Item } from 'src/app/models/item.model'
  

@Injectable({
  providedIn: 'root'
})
export class BankAccountService {
 
    appUrl = 'api/';
    apiUrl = environment.apiUrl + this.appUrl;
  

  constructor(private http: HttpClient) { }

  
    createBankAccount(userId: number, initialBalance: number): Observable<BankAccount> {
        return this.http.post<BankAccount>(`${this.apiUrl}BankAccount/CreateBankAccount/${userId}/${initialBalance}`, {});
      }

      //PointsTransferToUser/TransferPointsToUser
      
      transferToBank(userId:number, points: number) : Observable<TransferToBank>
      {

        return this.http.post<TransferToBank>(`${this.apiUrl}TransferPointsToBank/TransferPoints/${userId}/${points}`, {});
      }
      
      transfertoUser(userId:number,userto:number, points: number) :Observable<TransferToUser>
      {

         return this.http.post<TransferToUser>(`${this.apiUrl}PointsTransferToUser/TransferPointsToUser/${userId}/${userto}/${points}`, {})
      }
      itemPurchase(itemId:number, userId:number, amount: number) : Observable<Item[]>
      {

         return this.http.post<Item[]>(`${this.apiUrl}Item/PurchaseIte/${itemId}/${userId}/${amount}`, {});
      }

     getAllBankAccounts(): Observable<BankAccount[]> {
    return this.http.get<BankAccount[]>(`${this.apiUrl}`);
  }

  getTransactionHistory(userId: number): Observable<TransactionHistory[]> {
    return this.http.get<TransactionHistory[]>(`${this.apiUrl}TransactionHistory/${userId}`);
  }

  // Method to get transaction history for all users
  getAllTransactionHistory(): Observable<TransactionHistory[]> {
    return this.http.get<TransactionHistory[]>(`${this.apiUrl}TransactionHistory`);
  }

  getAllUsers(): Observable<RegisterUsers[]> {
    return this.http.get<RegisterUsers[]>(`${this.apiUrl}RegisterUser`);

  }
  getAllItems(): Observable<Item[]>
  {
    return this.http.get<Item[]>(`${this.apiUrl}Item`);
  }
  getAllBankAccount(): Observable<BankAccount[]>
  {
    return this.http.get<BankAccount[]>(`${this.apiUrl}BankAccount`);
  }
}
