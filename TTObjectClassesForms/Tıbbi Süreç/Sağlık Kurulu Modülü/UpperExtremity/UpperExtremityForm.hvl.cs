
using System;
using System.Xml;
using System.Data;
using System.Text;
using System.Drawing;
using System.Reflection;
using System.Collections;
using System.Linq;
using System.ComponentModel;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Collections.ObjectModel;
using System.Runtime.InteropServices;

using TTUtils;
using TTObjectClasses;
using TTDataDictionary;
using TTCoreDefinitions;
using TTConnectionManager;
using TTInstanceManagement;
using TTDefinitionManagement;
using TTStorageManager.Security;

using TTStorageManager;
using System.Runtime.Versioning;
using System.Windows.Forms;
using TTVisual;
namespace TTFormClasses
{
    /// <summary>
    /// Üst Ektremite Protez
    /// </summary>
    public partial class UpperExtremityForm : BaseHCExaminationDynamicObjectForm
    {
    /// <summary>
    /// Üst Ekstremite Protez
    /// </summary>
        protected TTObjectClasses.UpperExtremity _UpperExtremity
        {
            get { return (TTObjectClasses.UpperExtremity)_ttObject; }
        }

        protected ITTGroupBox ttgroupbox1;
        protected ITTCheckBox HeadDoctorApprove;
        protected ITTCheckBox PsychiatricExpertApprove;
        protected ITTCheckBox OrthopedicExpertApprove;
        protected ITTCheckBox FTRExpertApprove;
        protected ITTCheckBox ThirdStepHealthInst;
        protected ITTCheckBox sEMG;
        protected ITTCheckBox MedicalReason;
        override protected void InitializeControls()
        {
            ttgroupbox1 = (ITTGroupBox)AddControl(new Guid("80edf9f5-009a-44d9-ba4b-95ce4f34aaa8"));
            HeadDoctorApprove = (ITTCheckBox)AddControl(new Guid("ca4da2f6-471d-49c9-bdea-ccc6bcdcdbb5"));
            PsychiatricExpertApprove = (ITTCheckBox)AddControl(new Guid("2290cbbe-8497-492a-b263-06a01bd7e1dc"));
            OrthopedicExpertApprove = (ITTCheckBox)AddControl(new Guid("8144ca4b-d3d4-47e7-b96d-a957eee38d4c"));
            FTRExpertApprove = (ITTCheckBox)AddControl(new Guid("4e3df068-4371-47be-a92f-6e5cf9a87644"));
            ThirdStepHealthInst = (ITTCheckBox)AddControl(new Guid("2646a7ab-daf7-4c15-b2d7-836b8749a390"));
            sEMG = (ITTCheckBox)AddControl(new Guid("f90d102d-bbfc-4c58-a27d-b7fba19fb9c5"));
            MedicalReason = (ITTCheckBox)AddControl(new Guid("61dcb8bb-9068-4155-bb89-35e98d4d5c17"));
            base.InitializeControls();
        }

        public UpperExtremityForm() : base("UPPEREXTREMITY", "UpperExtremityForm")
        {
        }

        protected UpperExtremityForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}