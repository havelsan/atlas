
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
    public partial class PresChaDocInputDetWithAccountancyForm : BaseStockActionDetailInForm
    {
        protected TTObjectClasses.PresChaDocInputDetWithAccountancy _PresChaDocInputDetWithAccountancy
        {
            get { return (TTObjectClasses.PresChaDocInputDetWithAccountancy)_ttObject; }
        }

        protected ITTTabPage PrescriptionPaperTabPage;
        protected ITTGrid PrescriptionPaperInDetails;
        protected ITTTextBoxColumn SerialNoPrescriptionPaperInDetail;
        protected ITTTextBoxColumn VolumeNoPrescriptionPaperInDetail;
        protected ITTGroupBox ttgroupbox1;
        protected ITTTextBox bitNo;
        protected ITTTextBox basNo;
        protected ITTLabel ttlabel11;
        protected ITTLabel ttlabel9;
        protected ITTButton ttbuttonSorgula;
        protected ITTTextBox seriNo;
        protected ITTLabel ttCiltno;
        override protected void InitializeControls()
        {
            PrescriptionPaperTabPage = (ITTTabPage)AddControl(new Guid("427f0a60-62d2-4549-b02c-9c33aef79e44"));
            PrescriptionPaperInDetails = (ITTGrid)AddControl(new Guid("332551d0-53dc-4a72-b18f-2ab4f748ef42"));
            SerialNoPrescriptionPaperInDetail = (ITTTextBoxColumn)AddControl(new Guid("863dfadb-04ee-4a6d-a995-a4117d83e0a5"));
            VolumeNoPrescriptionPaperInDetail = (ITTTextBoxColumn)AddControl(new Guid("6d98e485-dcd2-4dbc-b706-f46ff400feeb"));
            ttgroupbox1 = (ITTGroupBox)AddControl(new Guid("bfe41d6f-8fec-446b-8be1-f86fc03bbe24"));
            bitNo = (ITTTextBox)AddControl(new Guid("abcaf1f2-e30b-43be-92db-b06c7b3ad05a"));
            basNo = (ITTTextBox)AddControl(new Guid("45e90271-b325-47f6-8af3-a0c9c607fa74"));
            ttlabel11 = (ITTLabel)AddControl(new Guid("e492c517-6d63-4e84-b419-24cfda869f26"));
            ttlabel9 = (ITTLabel)AddControl(new Guid("239cb258-2ffe-4755-bbaa-26edaa4b83b5"));
            ttbuttonSorgula = (ITTButton)AddControl(new Guid("93497b44-18d0-4a8b-bd1c-899ef24ce332"));
            seriNo = (ITTTextBox)AddControl(new Guid("3dbe9c9e-9017-4fef-9cb5-1c0709f66b7d"));
            ttCiltno = (ITTLabel)AddControl(new Guid("3dccca02-eeee-4a9f-9902-008a0a652ba4"));
            base.InitializeControls();
        }

        public PresChaDocInputDetWithAccountancyForm() : base("PRESCHADOCINPUTDETWITHACCOUNTANCY", "PresChaDocInputDetWithAccountancyForm")
        {
        }

        protected PresChaDocInputDetWithAccountancyForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}