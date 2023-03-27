//$85C465CE
using System;
using System.Linq;
using Core.Models;
using Infrastructure.Filters;
using Infrastructure.Models;
using TTInstanceManagement;
using TTObjectClasses;
using TTDefinitionManagement;
using TTUtils;
using System.Collections;

namespace Core.Controllers
{
    public partial class NuclearMedicineServiceController
    {
        partial void PreScript_NuclearMedicineRequestAcceptionForm(NuclearMedicineRequestAcceptionFormViewModel viewModel, NuclearMedicine nuclearMedicine, TTObjectContext objectContext)
        {
            //nuclearMedicine.SetProcedureDoctorAsCurrentResource();
            //bool hasInitialObjectIDForAdmissionAppointment = false;
            //if (nuclearMedicine.Episode.PatientAdmission != null)
            //{
            //    if (nuclearMedicine.Episode.PatientAdmission.AdmissionAppointment != null)
            //    {
            //        if (this._NuclearMedicine.Episode.PatientAdmission.AdmissionAppointment.Appointments.Count > 0)
            //        {
            //            if (this._NuclearMedicine.Episode.PatientAdmission.AdmissionAppointment.Appointments[0].InitialObjectID != null)
            //                hasInitialObjectIDForAdmissionAppointment = true;
            //        }
            //    }
            //}

            //if (this._NuclearMedicine.NuclearMedicineTests.Count > 0)
            //{
            //    if (this._NuclearMedicine.NuclearMedicineTests[0].ProcedureObject != null)
            //    {
            //        nucMedSelectedTesttxt.Text = this._NuclearMedicine.NuclearMedicineTests[0].ProcedureObject.Name;
            //    }
            //}
            //if ((bool)_NuclearMedicine.IsEmergency || hasInitialObjectIDForAdmissionAppointment)
            //{
            //    this.DropStateButton(NuclearMedicine.States.AppointmentInfo);
            //}
            //else
            //{
            //    this.DropStateButton(NuclearMedicine.States.Preparation);
            //}

            //if (this._NuclearMedicine.MyNotApprovedAppointments.Count > 0)
            //    DropStateButton(NuclearMedicine.States.AppointmentInfo);

        }

        partial void PostScript_NuclearMedicineRequestAcceptionForm(NuclearMedicineRequestAcceptionFormViewModel viewModel, NuclearMedicine nuclearMedicine, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext)
        {
            //base.PostScript(transDef);
            //if (transDef.ToStateDefID == NuclearMedicine.States.Cancelled) //Bu koddaki amaç ne ola ki? Anlamadým.
            //    return;

            if (String.IsNullOrEmpty(nuclearMedicine.NuclearMedicineTests[0].AccessionNo))
            {
                Guid AccessionNumber = new Guid("a40495b0-9265-432c-9467-f2b14f3b020c");
                nuclearMedicine.NuclearMedicineTests[0].AccessionNo = TTSequence.GetNextSequenceValueFromDatabase(TTObjectDefManager.Instance.DataTypes[AccessionNumber], null, null).ToString();
            }
        }

        //partial void AfterContextSaveScript_NuclearMedicineRequestAcceptionForm(NuclearMedicineRequestAcceptionFormViewModel viewModel, NuclearMedicine nuclearMedicine, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext)
        //{
        //    if (transDef != null)
        //    {
        //        if (transDef.ToStateDefID == NuclearMedicine.States.AppointmentInfo)
        //        {

        //            NuclearMedicine nucTest = (NuclearMedicine)objectContext.GetObject(nuclearMedicine.ObjectID, "NUCLEARMEDICINE");
        //            if (nucTest != null)
        //            {
        //                string injectionStr = "WHERE INITIALOBJECTID = '" + nucTest.ObjectID + "'";
        //                IList appList = Appointment.GetByInjection(objectContext, injectionStr);
        //                if (appList.Count > 0)
        //                {
        //                    nucTest.CurrentStateDefID = NuclearMedicine.States.AdmissionAppointment;
        //                    objectContext.Save();
        //                }
        //            }
        //        }
        //    }
        //}
    }
}


namespace Core.Models
{
    public partial class NuclearMedicineRequestAcceptionFormViewModel : BaseViewModel
    {
    }
}
