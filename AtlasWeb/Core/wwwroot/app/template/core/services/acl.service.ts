import { AclModel } from '../models/acl';
import { Injectable } from '@angular/core';
import { ConfigData } from '../interfaces/config-data';

import {  BehaviorSubject } from 'rxjs';


@Injectable()
export class AclService implements ConfigData {
	public aclModel: AclModel;
	public onAclUpdated$: BehaviorSubject<AclModel>;

	constructor(

	) {

	}

	/**
	 * Set AclModel and fire off event that all subscribers will listen to
	 * @param aclModel
	 */
	setModel(aclModel: AclModel): any {
		aclModel = Object.assign({}, this.aclModel, aclModel);
		this.onAclUpdated$.next(aclModel);
	}

	setCurrrentUserRoles(roles: any): any {
		// update roles if the credential data has roles
		if (roles != null) {
			this.aclModel.currentUserRoles = {};
			roles.forEach(role => {
				this.aclModel.currentUserRoles[role] = this.aclModel.permissions[role];
			});
			// set updated acl model back to service
			this.setModel(this.aclModel);
		}
	}
}
