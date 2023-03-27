import { ValidatorFn } from '@angular/forms';
import { EnumLookupItem } from 'NebulaClient/Mscorlib/EnumLookupItem';
import { Guid } from 'NebulaClient/Mscorlib/Guid';

export interface AtlasFormFieldConfig {
  disabled?: boolean;
  label?: string;
  name: string;
  options?: string[];
  placeholder?: string;
  type: string;
  validation?: ValidatorFn[];
  value?: any;
  enumList?: EnumLookupItem[];
  listDefID?: string;
  linkedParameterName?: string;
  linkedRelationDefID?: Guid;
  userFilterExpression?: string;
  visible?: boolean;
}