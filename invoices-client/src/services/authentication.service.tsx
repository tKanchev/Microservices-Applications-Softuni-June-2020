import { post, get } from './crud';
import { ApiRoutes } from './config/apiRoutes';

class AuthenticationService {
    public static login(user: any): Promise<any> {
        return post(ApiRoutes.identity.login, user);
    }

    public static register(user: any): Promise<any> {
        return post(ApiRoutes.identity.register, user);
    }

    public static isAdmin(): Promise<any> {
        return get(ApiRoutes.identity.isAdmin);
    }

    public static getLoggedUserId(): string {
        const userId = localStorage.getItem('userId')
        if (userId && userId.length) {
            return userId
        }

        return '';
    }
}

export default AuthenticationService;