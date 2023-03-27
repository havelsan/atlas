using System;
using System.Collections.Generic;
using System.Linq;
using TTObjectClasses;

namespace Core.Modules.Tibbi_Surec.Danisma_Modulu.SearchingModel
{
    public class PatientVisitorResultModel
    {
        public string PatientFullName
        {
            get;
            set;
        }

        public string PatientPhoneNumber
        {
            get;
            set;
        }

        public string PatientCitizenID
        {
            get;
            set;
        }

        public string VisitorFullName
        {
            get;
            set;
        }

        public string VisitorCitizenID
        {
            get;
            set;
        }

        public string VisitorPhoneNumber
        {
            get;
            set;
        }

        public string VisitorRelationState
        {
            get;
            set;
        }

        public string Note
        {
            get;
            set;
        }

        public PatientVisitorResultModel(PatientVisitor pv)
        {
            if (pv.Patient != null)
            {
                this.PatientFullName = pv.Patient.Name + " " + pv.Patient.Surname;
                this.PatientPhoneNumber = pv.Patient.MobilePhone;
                this.PatientCitizenID = pv.Patient.UniqueRefNo + "";
            }

            this.VisitorFullName = pv.VisitorName + " " + pv.VisitorSurname;
            this.VisitorCitizenID = pv.VisitorUnicRefId;
            this.VisitorPhoneNumber = pv.VisitorPhoneNumber;
            this.VisitorRelationState = pv.VisitorRelationState;
            this.Note = pv.VisitorNote;
        }
    }
}