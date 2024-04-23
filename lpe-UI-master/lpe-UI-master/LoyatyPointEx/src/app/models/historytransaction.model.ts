export enum TransactionType {
    EarnPoints = 'EarnPoints',
    RedeemPoints = 'RedeemPoints',
    TransferToBank = 'TransferToBank',
    TransferToUser = 'TransferToUser',
    PurchaseItem = 'PurchaseItem'
  }
  
  export class TransactionHistory {
    id!: number;
    registerUserId!: number;
    type!: TransactionType;
    pointsChanged!: number;
    amountChanged!: number;
    transactionDate!: Date;
  }
  