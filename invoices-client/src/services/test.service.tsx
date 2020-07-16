import { get } from './crud';
import { ApiRoutes } from './config/apiRoutes';

class TestService {
    public static test(): Promise<any> {
        return get(ApiRoutes.test);
    }
}

export default TestService;