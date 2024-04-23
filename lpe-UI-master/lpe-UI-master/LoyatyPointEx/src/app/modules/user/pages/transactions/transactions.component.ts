import { Component, OnInit } from '@angular/core';
import { TransactionHistory } from 'src/app/models/historytransaction.model';
import { BankAccountService } from 'src/app/services/bankacountService.service';

@Component({
  selector: 'app-transactions',
  templateUrl: './transactions.component.html',
  styleUrls: ['./transactions.component.css']
})
export class TransactionsComponent implements OnInit{

  transactionHistory: TransactionHistory[] = [];

  constructor(private transactionHistoryService: BankAccountService)
  {}

  ngOnInit(): void {
    
    this.loadTransactionHistory();
  }

  loadTransactionHistory(): void {
    // Call the service method to fetch all transaction history
    this.transactionHistoryService.getAllTransactionHistory()
      .subscribe(
        (data: TransactionHistory[]) => {
          this.transactionHistory = data;
        },
        (error) => {
          console.error('Error fetching transaction history:', error);
        }
      );
  }
  
}
