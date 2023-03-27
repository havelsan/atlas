using System;
using System.Collections.Generic;
using System.Linq;
using TTObjectClasses;

namespace Core.Modules.Tibbi_Surec.Danisma_Modulu.SearchingModel
{
    public class AppointmentSearchingResultModel
    {
        public Guid ObjectID;
        public String UniqueRefNo;
        public String MotherName;
        public String FatherName;
        public String PatientFullName;
        public String AppointmentObjectFullName;
        public DateTime AppointmentDate;
        public String AppointmentSection;
        public String AppointmentSectionPhone;
        public String AppointmentSectionLocation;
        public String AppointmentDefinition;
        public AppointmentTypeEnum AppointmentType;

        public AppointmentSearchingResultModel(Appointment appointment)
        {
            this.ObjectID = appointment.ObjectID;
            if (appointment.Patient != null)
            {
                UniqueRefNo = appointment.Patient.UniqueRefNo.ToString();
                PatientFullName = appointment.Patient.Name + " " + appointment.Patient.Surname;
                MotherName = appointment.Patient.MotherName;
                FatherName = appointment.Patient.FatherName;
            }

            if (appointment.MasterResource != null)
            {
                AppointmentSection = appointment.MasterResource.Name;
            }

            if (appointment.Resource != null)
            {
                AppointmentSectionPhone = appointment.Resource.DeskPhoneNumber;
                AppointmentSectionLocation = appointment.Resource.Location;
                AppointmentObjectFullName = appointment.Resource.Name;
            }

            if (appointment.AppDate != null)
            {
                AppointmentDate = (DateTime)appointment.AppDate;
            }

            if (appointment.AppointmentDefinition != null)
            {
                AppointmentDefinition = appointment.AppointmentDefinition.AppDefNameDisplayText;
            }

            if (appointment.AppointmentType != null)
            {
                AppointmentType = (AppointmentTypeEnum)appointment.AppointmentType;
            }
        }
    }
}