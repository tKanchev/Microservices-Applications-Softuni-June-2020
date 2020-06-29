import { post } from './crud';
import { ApiRoutes } from './config/apiRoutes';

class RoleService {
    public static create(role: any): Promise<any> {
        return post(ApiRoutes.roles.createRole, role);
    }
}

export default RoleService;