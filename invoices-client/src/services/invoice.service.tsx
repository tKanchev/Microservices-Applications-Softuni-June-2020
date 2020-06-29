import { get, post } from './crud';
import { ApiRoutes } from './config/apiRoutes';

class InvoiceService {
    public static all(): Promise<any> {
        return get(ApiRoutes.allInvoicesApiUrl);
    }

    public static allClients(): Promise<any> {
        return get(ApiRoutes.invoicesAllClientsApiUrl);
    }

    public static create(invoice: any): Promise<any> {
        return post(ApiRoutes.invoicesCreateApiUrl, invoice);
    }
}

export default InvoiceService;