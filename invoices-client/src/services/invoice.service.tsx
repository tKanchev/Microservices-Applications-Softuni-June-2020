import { get, post } from './crud';
import { ApiRoutes } from './config/apiRoutes';

class InvoiceService {
    public static all(): Promise<any> {
        return get(ApiRoutes.invoices.all);
    }

    // public static allClients(): Promise<any> {
    //     return get(ApiRoutes.invoicesAllClientsApiUrl);
    // }

    public static create(invoice: any): Promise<any> {
        return post(ApiRoutes.invoices.create, invoice);
    }
}

export default InvoiceService;