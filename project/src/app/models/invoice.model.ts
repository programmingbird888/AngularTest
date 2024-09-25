export interface Invoice {
    invoiceId: number;
    invoiceNumber: string;
    invoiceAmount: number;
    invoiceCurrencyId: number;
    invoiceReceivedDate: Date;
    invoiceDueDate: Date;
    isActive: boolean;
    vendorId: number;
  }
  