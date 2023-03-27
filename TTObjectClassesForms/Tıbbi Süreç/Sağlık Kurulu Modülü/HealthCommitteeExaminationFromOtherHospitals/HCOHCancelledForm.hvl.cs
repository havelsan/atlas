
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
    /// Diğer XXXXXX(ler)den Sağlık Kurulu Muayenesi 
    /// </summary>
    public partial class HCOHCancelledForm : EpisodeActionForm
    {
    /// <summary>
    /// Diğer XXXXXX(ler)den Sağlık Kurulu Muayenesi
    /// </summary>
        protected TTObjectClasses.HealthCommitteeExaminationFromOtherHospitals _HealthCommitteeExaminationFromOtherHospitals
        {
            get { return (TTObjectClasses.HealthCommitteeExaminationFromOtherHospitals)_ttObject; }
        }

        protected ITTLabel ttlabel8;
        protected ITTLabel labelHospital;
        protected ITTObjectListBox Unit;
        protected ITTTextBox DocumentNumber;
        protected ITTTextBox ExplanationOfRequest;
        protected ITTObjectListBox Hospital;
        protected ITTLabel labelUnit;
        protected ITTLabel labelExplanationOfRequest;
        protected ITTObjectListBox Speciality;
        protected ITTLabel lblSpeciality;
        override protected void InitializeControls()
        {
            ttlabel8 = (ITTLabel)AddControl(new Guid("c5536001-5d0e-4056-9b1b-f87a4590d386"));
            labelHospital = (ITTLabel)AddControl(new Guid("2a9e47fb-e243-44a8-a1f9-6a62c43da755"));
            Unit = (ITTObjectListBox)AddControl(new Guid("f90f3faf-e6c4-4eef-bcfc-9449fcd03667"));
            DocumentNumber = (ITTTextBox)AddControl(new Guid("bc2600a6-7994-44a0-90b1-5fe9f853e35c"));
            ExplanationOfRequest = (ITTTextBox)AddControl(new Guid("08840de2-c9a6-46db-91d5-33772cfb2304"));
            Hospital = (ITTObjectListBox)AddControl(new Guid("e1bce8a6-b6f8-47bc-8df6-3d4cfa15b51d"));
            labelUnit = (ITTLabel)AddControl(new Guid("fb53113c-0576-474e-a0a7-7ddb7c6b75db"));
            labelExplanationOfRequest = (ITTLabel)AddControl(new Guid("2e81ca3d-9a55-4901-8242-e400c07fb560"));
            Speciality = (ITTObjectListBox)AddControl(new Guid("1dbc87a8-abb1-4d19-bd1a-fbbeb049139f"));
            lblSpeciality = (ITTLabel)AddControl(new Guid("437862a5-d372-46f0-b835-45397981f732"));
            base.InitializeControls();
        }

        public HCOHCancelledForm() : base("HEALTHCOMMITTEEEXAMINATIONFROMOTHERHOSPITALS", "HCOHCancelledForm")
        {
        }

        protected HCOHCancelledForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}