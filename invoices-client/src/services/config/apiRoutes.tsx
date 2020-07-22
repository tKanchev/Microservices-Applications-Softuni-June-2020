export const baseRouteDev = {
    identity: 'https://localhost:5001/identity',
    roles: 'https://localhost:5001/roles',
    users: 'https://localhost:5001/users',
    invoices: 'https://localhost:5006/invoices',
    notifications: 'https://localhost:5008/notifications'
}

export const baseRouteDevDocker = {
    identity: 'http://localhost:5000/identity',
    roles: 'http://localhost:5000/roles',
    users: 'http://localhost:5000/users',
    invoices: 'http://localhost:5005/invoices',
    notifications: 'http://localhost:5007/notifications'
}

//Docker routes
export const ApiRoutes = {
    identity: {
        login: `${baseRouteDevDocker.identity}/login`,
        register: `${baseRouteDevDocker.identity}/register`,
        isAdmin: `${baseRouteDevDocker.identity}/isAdmin`,
    },
    roles: {
        createRole: `${baseRouteDevDocker.roles}/create`
    },
    users: {
        all: `${baseRouteDevDocker.users}/all`,
        delete: `${baseRouteDevDocker.users}/delete`,
        changePassword: `${baseRouteDevDocker.users}/changePassword`
    },
    invoices: {
        all: `${baseRouteDevDocker.invoices}/all`,
        create: `${baseRouteDevDocker.invoices}/create`
    },
    notifications: baseRouteDevDocker.notifications
}

export const ApiRoutesDev = {
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
    }
}