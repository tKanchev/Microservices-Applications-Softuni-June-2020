export const baseRouteDev = {
    identity: 'https://localhost:5001/identity',
    roles: 'https://localhost:5001/roles',
    users: 'https://localhost:5001/users'
}

export const ApiRoutes = {
    identity: {
        login: `${baseRouteDev.identity}/login`,
        register: `${baseRouteDev.identity}/register`,
        isAdmin: `${baseRouteDev.identity}/isAdmin`,
    },
    roles: {
        createRole: `${baseRouteDev.roles}/create`
    },
    users: {
        all: `${baseRouteDev.users}/all`,
        delete: `${baseRouteDev.users}/delete`
    },
    allInvoicesApiUrl: 'https://localhost:5007/invoices/all',
    invoicesAllClientsApiUrl: 'https://localhost:5007/invoices/allClients',
    invoicesCreateApiUrl: 'https://localhost:5007/invoices/create'
}