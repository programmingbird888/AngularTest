export interface Invoice {
    invoiceId: string;
    invoiceNumber: string;
    invoiceAmount: number;
    invoiceCurrencyCode: string;
    invoiceReceivedDate: Date;
    invoiceDueDate: Date;
    isActive: boolean;
    vendorCode: string;
  }
  