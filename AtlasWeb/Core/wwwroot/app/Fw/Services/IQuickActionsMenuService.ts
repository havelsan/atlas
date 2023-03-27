import { Observable } from 'rxjs';
import { QuickActionsMenuItem } from 'app/template/content/layout/header/topbar/quick-action/QuickActionsMenuItem';

export abstract class IQuickActionsMenuService {
    public abstract OnInsert: Observable<any>;
    public abstract OnRemove: Observable<any>;
    public abstract addItem(item: QuickActionsMenuItem);
    public abstract removeItem(menuKey: string);
}