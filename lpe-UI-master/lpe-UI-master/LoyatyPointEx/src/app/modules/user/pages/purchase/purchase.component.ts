import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { Item } from 'src/app/models/item.model';

import { BankAccountService } from 'src/app/services/bankacountService.service';


@Component({
  selector: 'app-purchase',
  templateUrl: './purchase.component.html',
  styleUrls: ['./purchase.component.css']
})
export class PurchaseComponent  implements OnInit{

  purchaseItemForm!: FormGroup;
  items : Item[] = [];
  userId: any;
  item: any;
  amount:number = 0;
  constructor(private itemService: BankAccountService)
  {

  }

  ngOnInit(): void {

    this.userId = sessionStorage.getItem('userId');
    console.log('User ID:', this.userId); 
    this.purchaseItemForm = new FormGroup({
      item: new FormControl('',),
      amount: new FormControl('',),
    });
    this.loadItems();
 
  }
  

  loadItems(): void {
    this.itemService.getAllItems() 
      .subscribe(
        (data: Item[]) => { 
          this.items = data;
        },
        (error) => {
          console.error('Error fetching items:', error);
        }
      );
  }


  submitForm(): void {

    if (this.purchaseItemForm.invalid) {
      return;
    }

    const itemId = this.purchaseItemForm.get('item')?.value;
    this.amount = this.purchaseItemForm.get('amount')?.value;

    this.itemService.itemPurchase(itemId, this.userId, this.amount)
      .subscribe(
        (data: Item[]) => {
          this.items = data;
          console.log('Item purchased successfully', data);
          alert('Item purchased successfully');
          
        },
        (error) => {
          console.error('Error purchasing item:', error);
          alert('Error purchasing item');
        }
      );
  }
}

