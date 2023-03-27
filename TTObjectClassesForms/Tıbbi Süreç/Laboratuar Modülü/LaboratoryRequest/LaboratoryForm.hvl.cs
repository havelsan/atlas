
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
    /// Laboratuvar Tetkik İnceleme Formu
    /// </summary>
    public partial class LaboratoryForm : EpisodeActionForm
    {
    /// <summary>
    /// Laboratuvar
    /// </summary>
        protected TTObjectClasses.LaboratoryRequest _LaboratoryRequest
        {
            get { return (TTObjectClasses.LaboratoryRequest)_ttObject; }
        }

        protected ITTLabel ttlabel3;
        protected ITTGrid ttgrid1;
        protected ITTTextBoxColumn BarcodeOrderNo;
        protected ITTTextBoxColumn Barcode;
        protected ITTTextBoxColumn BarcodeAmount;
        protected ITTCheckBoxColumn BarcodeSelect;
        protected ITTTabControl tttabcontrol1;
        protected ITTTabPage tttpSampleAccept;
        protected ITTButton ttbSampleControl;
        protected ITTGrid ttgSampleAccept;
        protected ITTTextBoxColumn SampleAcceptTestName;
        protected ITTTextBoxColumn SampleAcceptDepartment;
        protected ITTTextBoxColumn SampleAcceptSampleEnvir;
        protected ITTTextBoxColumn SampleAcceptSampleTube;
        protected ITTCheckBoxColumn SampleAcceptSelect;
        protected ITTTextBoxColumn SampleAcceptobjId;
        protected ITTTabPage tttpSampleControl;
        protected ITTButton ttbProcedure;
        protected ITTButton ttbGetListSamCont;
        protected ITTGrid ttgSampleControl;
        protected ITTTextBoxColumn SampleControlTestName;
        protected ITTTextBoxColumn SampleControlDepartment;
        protected ITTTextBoxColumn SampleControlSampleEnv;
        protected ITTTextBoxColumn SampleControlSampleTube;
        protected ITTCheckBoxColumn SampleControlSelect;
        protected ITTTextBoxColumn SampleControlobjId;
        protected ITTTabPage tttpProcedure;
        protected ITTButton ttbApprove;
        protected ITTButton ttbSaveProcedure;
        protected ITTButton ttbGetListProcedure;
        protected ITTGrid ttgProcedure;
        protected ITTTextBoxColumn ProcedureTestName;
        protected ITTTextBoxColumn ProcedureResult;
        protected ITTTextBoxColumn ProcedureUnit;
        protected ITTTextBoxColumn ProcedureReferenceVal;
        protected ITTTextBoxColumn ProcedureNotes;
        protected ITTCheckBoxColumn ProcedureSelect;
        protected ITTTextBoxColumn Procedureobjid;
        protected ITTTabPage tttpApprove;
        protected ITTTabPage tttpComplete;
        protected ITTGroupBox ttgroupbox1;
        protected ITTListView ttlistview1;
        protected ITTDateTimePicker dtActionDate;
        protected ITTLabel ttlabel2;
        protected ITTObjectListBox ttobjectlistbox1;
        protected ITTTextBox tttextbox2;
        protected ITTLabel ttlabel4;
        protected ITTTextBox tttextbox1;
        protected ITTLabel labelPreInformation;
        protected ITTLabel ttlabel1;
        override protected void InitializeControls()
        {
            ttlabel3 = (ITTLabel)AddControl(new Guid("80f293b0-0740-49d2-ab31-73469d0039c3"));
            ttgrid1 = (ITTGrid)AddControl(new Guid("ef0b544e-fdda-449b-948c-5a46eecfd818"));
            BarcodeOrderNo = (ITTTextBoxColumn)AddControl(new Guid("cbb66445-a48b-4265-b815-d492a0e2e1d5"));
            Barcode = (ITTTextBoxColumn)AddControl(new Guid("bbeac0ac-e706-4c27-b2e4-ceee7143a019"));
            BarcodeAmount = (ITTTextBoxColumn)AddControl(new Guid("155a584c-5439-4d0a-baa4-7c421b2a40b3"));
            BarcodeSelect = (ITTCheckBoxColumn)AddControl(new Guid("e7b72cc7-8779-4eb1-adb3-6f4fef759f8a"));
            tttabcontrol1 = (ITTTabControl)AddControl(new Guid("066ea38f-c14d-4452-a208-47ce03303bff"));
            tttpSampleAccept = (ITTTabPage)AddControl(new Guid("c53cf3ca-72bd-4391-ad2e-2f5b206bb05d"));
            ttbSampleControl = (ITTButton)AddControl(new Guid("a9b769f8-3080-4d15-b114-2a8936776fd6"));
            ttgSampleAccept = (ITTGrid)AddControl(new Guid("4c1eef25-86c0-4987-9419-bc7a0cf62722"));
            SampleAcceptTestName = (ITTTextBoxColumn)AddControl(new Guid("927f0328-03bf-4a79-be87-68fb7719d44f"));
            SampleAcceptDepartment = (ITTTextBoxColumn)AddControl(new Guid("796fcb6d-736b-40b9-b1b9-161558a5ff61"));
            SampleAcceptSampleEnvir = (ITTTextBoxColumn)AddControl(new Guid("12a64432-9a7a-4f36-adf4-387c18af18bd"));
            SampleAcceptSampleTube = (ITTTextBoxColumn)AddControl(new Guid("e7bd3588-6789-4985-b3e3-8e4cfa9ae555"));
            SampleAcceptSelect = (ITTCheckBoxColumn)AddControl(new Guid("19c21abd-9a3e-4ff8-b952-1aba74bbc208"));
            SampleAcceptobjId = (ITTTextBoxColumn)AddControl(new Guid("a2315973-5e7b-45ac-b1c0-b72a1038f710"));
            tttpSampleControl = (ITTTabPage)AddControl(new Guid("11e3ed88-3075-4c72-85cf-695f24c94473"));
            ttbProcedure = (ITTButton)AddControl(new Guid("503e693a-58ec-463f-ba83-897cfa50f82f"));
            ttbGetListSamCont = (ITTButton)AddControl(new Guid("5c9315b1-2b86-4beb-b515-c5ae9521676d"));
            ttgSampleControl = (ITTGrid)AddControl(new Guid("607d50f1-fb9a-423c-9e8e-d9f0e5edd206"));
            SampleControlTestName = (ITTTextBoxColumn)AddControl(new Guid("9e7bb2a5-2052-4f87-89d1-6f932edcc43b"));
            SampleControlDepartment = (ITTTextBoxColumn)AddControl(new Guid("e4973e72-b1a0-494a-9c91-dc1230a9c070"));
            SampleControlSampleEnv = (ITTTextBoxColumn)AddControl(new Guid("222edfe4-2ce6-464c-bd8d-d27b773aae27"));
            SampleControlSampleTube = (ITTTextBoxColumn)AddControl(new Guid("ad98db0b-0ea1-4ead-8f60-7765c0fc0a89"));
            SampleControlSelect = (ITTCheckBoxColumn)AddControl(new Guid("ee77a37f-6d88-4c06-ad17-25e86d2d1d92"));
            SampleControlobjId = (ITTTextBoxColumn)AddControl(new Guid("37af50f9-2cd3-4636-b699-95d54bbe8f25"));
            tttpProcedure = (ITTTabPage)AddControl(new Guid("34a479ed-da4e-4d3a-abd4-f8bd54dac013"));
            ttbApprove = (ITTButton)AddControl(new Guid("bbc20027-0387-4690-9b63-35d96fc5e025"));
            ttbSaveProcedure = (ITTButton)AddControl(new Guid("bcdc796e-4953-4fbc-9c0f-70aa6f2f8f7a"));
            ttbGetListProcedure = (ITTButton)AddControl(new Guid("5b641eee-a829-4740-a643-642da72e7d38"));
            ttgProcedure = (ITTGrid)AddControl(new Guid("493b034b-fffa-4ec5-bbae-c571bcf7a663"));
            ProcedureTestName = (ITTTextBoxColumn)AddControl(new Guid("beefcd8a-4a7d-474c-bdd8-505463bc38cf"));
            ProcedureResult = (ITTTextBoxColumn)AddControl(new Guid("eef500cb-d9c1-4460-858f-9ff249f82b76"));
            ProcedureUnit = (ITTTextBoxColumn)AddControl(new Guid("456ca2a2-7010-44dd-9597-b32043326533"));
            ProcedureReferenceVal = (ITTTextBoxColumn)AddControl(new Guid("cbb72643-a7e5-4bf1-91ec-00c56468dd7b"));
            ProcedureNotes = (ITTTextBoxColumn)AddControl(new Guid("3da57547-c63a-4849-a584-1814232ba8a4"));
            ProcedureSelect = (ITTCheckBoxColumn)AddControl(new Guid("873d10e6-72aa-41f5-870e-c20b6fba4d12"));
            Procedureobjid = (ITTTextBoxColumn)AddControl(new Guid("193b2728-8f92-4f6d-af64-400bf8154dd0"));
            tttpApprove = (ITTTabPage)AddControl(new Guid("63ce1eac-a578-4bda-ba4d-200b8daa7546"));
            tttpComplete = (ITTTabPage)AddControl(new Guid("987ef5f8-1327-4b38-bb2c-222f3ace4680"));
            ttgroupbox1 = (ITTGroupBox)AddControl(new Guid("584bed04-b276-49d5-a87c-c35fd8030127"));
            ttlistview1 = (ITTListView)AddControl(new Guid("7a0726fe-66c9-4112-9675-f15d6817bd1f"));
            dtActionDate = (ITTDateTimePicker)AddControl(new Guid("ae3660e8-b4de-48ee-9572-5ca2232282d2"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("3a1ead3b-8194-4260-b3a6-a03a855ecab0"));
            ttobjectlistbox1 = (ITTObjectListBox)AddControl(new Guid("8694161f-d3d1-4ea4-a998-1b9952896ca3"));
            tttextbox2 = (ITTTextBox)AddControl(new Guid("cdbcab99-77a1-457b-a705-c0a12e9a954e"));
            ttlabel4 = (ITTLabel)AddControl(new Guid("2978163a-7ad8-4010-8a27-73f20fb9ede5"));
            tttextbox1 = (ITTTextBox)AddControl(new Guid("fe864aca-a67c-4dae-9a97-02a99f764a88"));
            labelPreInformation = (ITTLabel)AddControl(new Guid("4160d351-40e9-4e0f-b001-28670e2bcc2f"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("714a3796-c3b1-4542-a981-aeff6ce1539f"));
            base.InitializeControls();
        }

        public LaboratoryForm() : base("LABORATORYREQUEST", "LaboratoryForm")
        {
        }

        protected LaboratoryForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}