import { get, remove } from './crud';
import { ApiRoutes } from './config/apiRoutes';

class UserService {
    public static all(): Promise<any> {
        return get(ApiRoutes.users.all);
    }

    public static delete(id: string): Promise<any> {
        return remove(ApiRoutes.users.delete, id);
    }
}

export default UserService;