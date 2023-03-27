//import { Component, Input,KeyValueDiffers } from '@angular/core';
//import { ValidationConfig } from '../Validation/ValidationConfig';
//import { Validation } from '../Validation/Validation';
//import { RequiredValidation } from '../Validation/RequiredValidation';
//import { LengthValidation } from '../Validation/LengthValidation';
//import { BaseInputControl } from './BaseInputControl';

//export class ValidationFactory {
//    public static GetValidation(data: ValidationConfig): Validation {
//        if (data.Type == "Required") {
//            return new RequiredValidation(data.Message);
//        }
//        else if (data.Type == "Length") {
//            return new LengthValidation(data.Message, data.Min, data.Max);
//        }
//    }
//}
////'ValidationConfiguration','Required'
//@Component({ template: "" })
//export class ValidationComponent extends BaseInputControl {
//    isValid: any;
//    validationError: any;

//     ValidationConfiguration: Array<ValidationConfig>;
//     Required: Boolean;

//    //protected static MetaData = Object.assign({@Input()@Input()
//    //    inputs: ['ValidationConfiguration', 'Required']
//    //}, BaseInputControl.MetaData);

//    constructor(differs: KeyValueDiffers) {
//        super(differs);
//        this.isValid = true;
//        this.validationError = { message: "" };
//    }

//    checkValidation() {
//        let that = this;
//        this.isValid = true;
//        let validation: Validation;
//        this.validationError.message = "";
//        if (this.Required.valueOf().toString().toLowerCase() == "true" &&
//           ((this.Text && this.Text.toString().trim().length == 0) || !this.Text)) {
//            this.isValid = false;
//            this.validationError = { message: "Bu alan zorunludur" };
//            return false;
//        }

//        if (this.ValidationConfiguration && this.ValidationConfiguration.length > 0) {
//            for (let i = 0; i < this.ValidationConfiguration.length; i++) {
//                let config = this.ValidationConfiguration[i];
//                validation = ValidationFactory.GetValidation(config);
//                if (!validation.IsValid(that.Text)) {
//                    that.isValid = false;
//                    that.validationError = { message: validation.Message };
//                    return false;
//                }
//            }
//        }
//        return this.isValid;
//    }

//}