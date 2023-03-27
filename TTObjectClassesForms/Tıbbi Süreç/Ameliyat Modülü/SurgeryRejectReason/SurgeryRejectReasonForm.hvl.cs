
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
    public partial class SurgeryRejectReasonForm : TTForm
    {
        protected TTObjectClasses.SurgeryRejectReason _SurgeryRejectReason
        {
            get { return (TTObjectClasses.SurgeryRejectReason)_ttObject; }
        }

        protected ITTLabel labelOtherReasonExplanation;
        protected ITTTextBox OtherReasonExplanation;
        protected ITTCheckBox OtherReason;
        protected ITTCheckBox ProlongSurgery;
        protected ITTCheckBox PatientNotCome;
        protected ITTCheckBox PreopPreparation;
        protected ITTCheckBox LackOfMaterial;
        override protected void InitializeControls()
        {
            labelOtherReasonExplanation = (ITTLabel)AddControl(new Guid("d31d9ab9-a9af-42d2-9979-2d06eb73dd4c"));
            OtherReasonExplanation = (ITTTextBox)AddControl(new Guid("bd3cacd5-d824-4bbb-93fa-f99099c0e375"));
            OtherReason = (ITTCheckBox)AddControl(new Guid("f6b2b390-5a6d-4ff8-99fd-3553796d8406"));
            ProlongSurgery = (ITTCheckBox)AddControl(new Guid("ff34980e-fef9-4744-a9b8-928aa766d056"));
            PatientNotCome = (ITTCheckBox)AddControl(new Guid("a5bf4cf5-ec0f-4d36-96d2-e5cd5f28d3e7"));
            PreopPreparation = (ITTCheckBox)AddControl(new Guid("83142caa-db52-4a20-b7e6-f81d58647722"));
            LackOfMaterial = (ITTCheckBox)AddControl(new Guid("444b0162-1d4e-4bca-9acc-45383c090ccc"));
            base.InitializeControls();
        }

        public SurgeryRejectReasonForm() : base("SURGERYREJECTREASON", "SurgeryRejectReasonForm")
        {
        }

        protected SurgeryRejectReasonForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}