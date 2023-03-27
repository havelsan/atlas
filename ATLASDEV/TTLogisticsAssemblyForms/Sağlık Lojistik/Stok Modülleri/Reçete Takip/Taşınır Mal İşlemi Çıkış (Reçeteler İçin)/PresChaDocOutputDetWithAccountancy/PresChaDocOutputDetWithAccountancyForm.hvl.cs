
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
    /// Malzeme Detayları
    /// </summary>
    public partial class PresChaDocOutputDetWithAccountancyForm : BaseStockActionDetailOutForm
    {
        protected TTObjectClasses.PresChaDocOutputDetWithAccountancy _PresChaDocOutputDetWithAccountancy
        {
            get { return (TTObjectClasses.PresChaDocOutputDetWithAccountancy)_ttObject; }
        }

        protected ITTTabPage PrescriptionPaperTabPage;
        protected ITTGrid PrescriptionPaperOutDetails;
        protected ITTListBoxColumn PrescriptionPaperPrescriptionPaperOutDetail;
        protected ITTGroupBox ttgroupbox1;
        protected ITTLabel ttlabel1;
        protected ITTLabel ttlabel2;
        protected ITTTextBox basNo;
        protected ITTTextBox bitNo;
        protected ITTLabel ttlabel3;
        protected ITTTextBox seriNo;
        protected ITTButton ttbutton1;
        override protected void InitializeControls()
        {
            PrescriptionPaperTabPage = (ITTTabPage)AddControl(new Guid("bdc5e943-229d-40d0-a7e3-c62776d8cc04"));
            PrescriptionPaperOutDetails = (ITTGrid)AddControl(new Guid("7e8fdfa2-a394-4962-94fa-114b593a7a6b"));
            PrescriptionPaperPrescriptionPaperOutDetail = (ITTListBoxColumn)AddControl(new Guid("12060b39-9dcb-41ba-8585-7e7f1ad30edc"));
            ttgroupbox1 = (ITTGroupBox)AddControl(new Guid("693d29fc-737e-4d4a-963a-222c9f37446a"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("aa222ef2-a525-46dc-9057-c23eb2018a90"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("6b2603aa-e54d-49ac-83e6-72822f6f4e3f"));
            basNo = (ITTTextBox)AddControl(new Guid("6e0737da-0a8c-47fe-b9ba-040747ccf17e"));
            bitNo = (ITTTextBox)AddControl(new Guid("a34ebe9b-8bf1-446c-a5ba-d21a5db220bb"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("cde79a6f-d433-45e9-a3ae-4f4e6361c431"));
            seriNo = (ITTTextBox)AddControl(new Guid("cf1653dc-ee6f-4d9b-bb25-c5e5cae539b8"));
            ttbutton1 = (ITTButton)AddControl(new Guid("e6674e1a-66ce-429a-b095-3986dd83191d"));
            base.InitializeControls();
        }

        public PresChaDocOutputDetWithAccountancyForm() : base("PRESCHADOCOUTPUTDETWITHACCOUNTANCY", "PresChaDocOutputDetWithAccountancyForm")
        {
        }

        protected PresChaDocOutputDetWithAccountancyForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}