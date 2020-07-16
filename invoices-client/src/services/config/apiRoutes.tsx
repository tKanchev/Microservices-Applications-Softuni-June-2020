export const baseRouteDev = {
    identity: 'https://localhost:5001/identity',
    roles: 'https://localhost:5001/roles',
    users: 'https://localhost:5001/users',
    invoices: 'https://localhost:5007/invoices',
    test: 'https://localhost:5005/test/hui',
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
        delete: `${baseRouteDev.users}/delete`,
        changePassword: `${baseRouteDev.users}/changePassword`
    },
    invoices: {
        all: `${baseRouteDev.invoices}/all`,
        create: `${baseRouteDev.invoices}/create`
    },
    test: baseRouteDev.test
}