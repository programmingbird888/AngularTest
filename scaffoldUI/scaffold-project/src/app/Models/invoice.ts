export interface Invoice {
    invoiceId: number;
    invoiceNumber: number;
    invoiceCurrencyId: number;
    vendorId: number;
    invoiceAmount: number;
    invoiceReceivedDate: Date;
    invoiceDueDate: Date;
    isActive: boolean;
  }
  