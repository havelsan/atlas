
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
    /// Senet Takip
    /// </summary>
    public partial class DebentureFollowForm : TTForm
    {
    /// <summary>
    /// Senet Takip İşlemi
    /// </summary>
        protected TTObjectClasses.DebentureFollow _DebentureFollow
        {
            get { return (TTObjectClasses.DebentureFollow)_ttObject; }
        }

        protected ITTLabel ttlabel3;
        protected ITTTextBox DEBENTUREAMOUNT;
        protected ITTDateTimePicker ENDDATE;
        protected ITTDateTimePicker STARTDATE;
        protected ITTButton UnSelectAllButton;
        protected ITTButton SelectAllButton;
        protected ITTButton ExecutionOrderListButton;
        protected ITTTabControl OrderInfos;
        protected ITTTabPage TabPaymentOrder;
        protected ITTGrid GRIDPaymentOrders;
        protected ITTTextBoxColumn DEBENTURENO;
        protected ITTDateTimePickerColumn DUEDATE;
        protected ITTDateTimePickerColumn PAYMENTORDERDATE;
        protected ITTTextBoxColumn DEBENTUREPRICE;
        protected ITTTextBoxColumn PATIENTNO;
        protected ITTTextBoxColumn PATIENTNAME;
        protected ITTTextBoxColumn PATIENTSURNAME;
        protected ITTCheckBoxColumn SELECT;
        protected ITTButtonColumn GUARANTORINFO;
        protected ITTTabPage TabExecutionOrder;
        protected ITTGrid GRIDExecutionOrders;
        protected ITTTextBoxColumn EDEBENTURENO;
        protected ITTDateTimePickerColumn EDUEDATE;
        protected ITTDateTimePickerColumn EXECUTIONDATE;
        protected ITTTextBoxColumn EDEBENTUREPRICE;
        protected ITTTextBoxColumn EPATIENTNO;
        protected ITTTextBoxColumn EPATIENTNAME;
        protected ITTTextBoxColumn EPATIENTSURNAME;
        protected ITTEnumComboBoxColumn MANAGEMENTOFFICE;
        protected ITTCheckBoxColumn ESELECT;
        protected ITTButtonColumn EGUARANTORINFO;
        protected ITTButton PaymentOrderListButton;
        protected ITTLabel labelEndDate;
        protected ITTLabel labelStartDate;
        override protected void InitializeControls()
        {
            ttlabel3 = (ITTLabel)AddControl(new Guid("c8e2923f-53cb-47b1-8ffc-989a757c6daf"));
            DEBENTUREAMOUNT = (ITTTextBox)AddControl(new Guid("28d6b09c-ab5d-44dc-a913-383a09b1c53d"));
            ENDDATE = (ITTDateTimePicker)AddControl(new Guid("62e7db5c-a334-44ef-aad7-d9482fbf3bad"));
            STARTDATE = (ITTDateTimePicker)AddControl(new Guid("c70ef867-9ab2-40c4-b91c-a1f89849f207"));
            UnSelectAllButton = (ITTButton)AddControl(new Guid("72dd0a3b-10aa-4d2e-8a10-c8830cc74385"));
            SelectAllButton = (ITTButton)AddControl(new Guid("3d196ef0-5cf0-4ca7-9d1d-41964fbc7601"));
            ExecutionOrderListButton = (ITTButton)AddControl(new Guid("60234d12-9221-477e-9737-06a63028933f"));
            OrderInfos = (ITTTabControl)AddControl(new Guid("f4a9a324-62b6-4131-a39f-f8b30411af80"));
            TabPaymentOrder = (ITTTabPage)AddControl(new Guid("80c19809-d499-4369-97b6-6aabdf6055b2"));
            GRIDPaymentOrders = (ITTGrid)AddControl(new Guid("ccdcafa3-6efa-499d-935b-87e508b7f01d"));
            DEBENTURENO = (ITTTextBoxColumn)AddControl(new Guid("9e01c3cc-491f-4f36-a3aa-52802cbbeee0"));
            DUEDATE = (ITTDateTimePickerColumn)AddControl(new Guid("389b05cf-2efd-4c04-83ee-908a5071eb7a"));
            PAYMENTORDERDATE = (ITTDateTimePickerColumn)AddControl(new Guid("f03b8c73-78c1-4e8f-b357-141e725f3ef2"));
            DEBENTUREPRICE = (ITTTextBoxColumn)AddControl(new Guid("eeaaa595-541e-4aa8-b797-be71b9da259a"));
            PATIENTNO = (ITTTextBoxColumn)AddControl(new Guid("cfa7ce24-ed68-468b-aa55-144324b37500"));
            PATIENTNAME = (ITTTextBoxColumn)AddControl(new Guid("99e9c488-27f3-46f6-83ee-dd43bc202c4e"));
            PATIENTSURNAME = (ITTTextBoxColumn)AddControl(new Guid("63175283-81a1-4ef1-aac4-418d8ad7c6af"));
            SELECT = (ITTCheckBoxColumn)AddControl(new Guid("2aa55f85-9173-4117-8d39-ff396373571b"));
            GUARANTORINFO = (ITTButtonColumn)AddControl(new Guid("b62a3b39-610b-434e-a416-1b89987fa2fc"));
            TabExecutionOrder = (ITTTabPage)AddControl(new Guid("8a49b836-3644-4cdc-a48e-ad7d1ddd816f"));
            GRIDExecutionOrders = (ITTGrid)AddControl(new Guid("030d2039-f74d-4f42-bbbf-087902f56bc8"));
            EDEBENTURENO = (ITTTextBoxColumn)AddControl(new Guid("16f2f5a3-3f32-4277-b28c-8a47b10098b3"));
            EDUEDATE = (ITTDateTimePickerColumn)AddControl(new Guid("90f5d724-6542-4592-a052-0713a735b515"));
            EXECUTIONDATE = (ITTDateTimePickerColumn)AddControl(new Guid("df637239-c032-4d23-8c3f-d585425ef060"));
            EDEBENTUREPRICE = (ITTTextBoxColumn)AddControl(new Guid("e778de7e-ab88-4468-bcbf-41b32ca9174c"));
            EPATIENTNO = (ITTTextBoxColumn)AddControl(new Guid("c96a26e7-c4fd-40ac-a0cd-ba19031454e4"));
            EPATIENTNAME = (ITTTextBoxColumn)AddControl(new Guid("e378142e-c921-44e6-8285-d67513b104c0"));
            EPATIENTSURNAME = (ITTTextBoxColumn)AddControl(new Guid("2d814c23-45c7-4508-b8a2-62d8e412c4ec"));
            MANAGEMENTOFFICE = (ITTEnumComboBoxColumn)AddControl(new Guid("bd61830f-d41b-4a74-a414-6ecba0693030"));
            ESELECT = (ITTCheckBoxColumn)AddControl(new Guid("e5ab6262-f161-4314-a139-246f986f84e5"));
            EGUARANTORINFO = (ITTButtonColumn)AddControl(new Guid("d1816719-92df-4645-a57e-d3dac2d52088"));
            PaymentOrderListButton = (ITTButton)AddControl(new Guid("d97095ed-6910-4fd2-8f49-caa7904415a1"));
            labelEndDate = (ITTLabel)AddControl(new Guid("223af653-d01a-4b81-8e3b-6e6a38a359ff"));
            labelStartDate = (ITTLabel)AddControl(new Guid("9fbdc9b3-3279-4cde-a264-3b782b3f91d2"));
            base.InitializeControls();
        }

        public DebentureFollowForm() : base("DEBENTUREFOLLOW", "DebentureFollowForm")
        {
        }

        protected DebentureFollowForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}