
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
    /// Kan Bankası Kan Ürünü Hazırlama
    /// </summary>
    public partial class BloodProductPreparationForm : EpisodeActionForm
    {
    /// <summary>
    /// Kan Ürünü İstek
    /// </summary>
        protected TTObjectClasses.BloodProductRequest _BloodProductRequest
        {
            get { return (TTObjectClasses.BloodProductRequest)_ttObject; }
        }

        protected ITTLabel ttlabel3;
        protected ITTTextBox tttextbox2;
        protected ITTGroupBox ttgroupbox1;
        protected ITTButton btnSend;
        protected ITTPanel pnlUrgent;
        protected ITTCheckBox chkWithTest;
        protected ITTCheckBox chkWithoutTests;
        protected ITTCheckBox chkUrgentCross;
        protected ITTCheckBox chkWithoutCross;
        protected ITTCheckBox chkNormal;
        protected ITTDateTimePicker dtRequirement;
        protected ITTCheckBox ttcheckbox5;
        protected ITTLabel ttlabel1;
        protected ITTCheckBox ttcheckbox4;
        protected ITTDateTimePicker dtTransfused;
        protected ITTCheckBox chkUrgent;
        protected ITTDateTimePicker dtPregnancy;
        protected ITTLabel ttlabel2;
        protected ITTCheckBox chkBlock;
        protected ITTTextBox tttextbox1;
        protected ITTCheckBox chkOther;
        protected ITTLabel ttlabel4;
        protected ITTCheckBox chkHB;
        protected ITTCheckBox chkTransfused;
        protected ITTCheckBox chkPrepare;
        protected ITTLabel ttlabel5;
        protected ITTLabel ttlabel7;
        protected ITTCheckBox chkPregnancy;
        protected ITTCheckBox chkSurgery;
        protected ITTLabel ttlabel6;
        protected ITTTabControl tttabcontrol1;
        protected ITTTabPage tttabpage1;
        protected ITTGrid ttgrid1;
        protected ITTListBoxColumn ttlistbox1;
        protected ITTTextBoxColumn txtAmount;
        protected ITTCheckBoxColumn chkIsinlanmis;
        protected ITTCheckBoxColumn chkFiltrelenmis;
        override protected void InitializeControls()
        {
            ttlabel3 = (ITTLabel)AddControl(new Guid("856b6b99-ce23-43a8-9ed5-b46090418d09"));
            tttextbox2 = (ITTTextBox)AddControl(new Guid("123f0bca-da2b-4599-9d95-e87841792899"));
            ttgroupbox1 = (ITTGroupBox)AddControl(new Guid("256471a8-eaa5-4eb9-a510-5c64e613e3e5"));
            btnSend = (ITTButton)AddControl(new Guid("2f847242-3c9a-4b21-b60e-1aa71957ba6e"));
            pnlUrgent = (ITTPanel)AddControl(new Guid("03fe4c2d-4a30-4835-adae-b9608d38f136"));
            chkWithTest = (ITTCheckBox)AddControl(new Guid("02e8a4e3-4f12-4800-8151-ca8c915395b4"));
            chkWithoutTests = (ITTCheckBox)AddControl(new Guid("e65328a8-fb0a-4ffe-9831-3c7df53dfc0e"));
            chkUrgentCross = (ITTCheckBox)AddControl(new Guid("3f81fd6f-7183-41ca-9f18-5312e7810506"));
            chkWithoutCross = (ITTCheckBox)AddControl(new Guid("f2f79551-655c-42ce-bf19-88b284193e9e"));
            chkNormal = (ITTCheckBox)AddControl(new Guid("f469405c-444a-4674-8f90-b7be83358988"));
            dtRequirement = (ITTDateTimePicker)AddControl(new Guid("be3a2b93-5c93-409b-b570-9b229d2481fa"));
            ttcheckbox5 = (ITTCheckBox)AddControl(new Guid("8619fc9e-321d-475f-a2bc-8e151e0e673d"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("f5ba0aa0-5dd2-418b-9df4-056a384aa92a"));
            ttcheckbox4 = (ITTCheckBox)AddControl(new Guid("e59d4ef8-0b45-4f20-90ca-26376a48ad76"));
            dtTransfused = (ITTDateTimePicker)AddControl(new Guid("b86c6728-a35e-4146-b0ee-f35b8eb67b22"));
            chkUrgent = (ITTCheckBox)AddControl(new Guid("2dda8400-d07e-43ce-b52c-024f866bf2ef"));
            dtPregnancy = (ITTDateTimePicker)AddControl(new Guid("2241ec2d-df7d-47f9-b80b-87f56f97cb79"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("aef5606d-960f-4a62-81d5-885fe483597f"));
            chkBlock = (ITTCheckBox)AddControl(new Guid("88ae7bc8-bcfb-4ec2-87c2-9d6a40ac2700"));
            tttextbox1 = (ITTTextBox)AddControl(new Guid("076293d2-dec6-42e7-a8f0-83d878bf9114"));
            chkOther = (ITTCheckBox)AddControl(new Guid("f7c4adf2-b5eb-4cc4-8a9d-1ad2c44c6634"));
            ttlabel4 = (ITTLabel)AddControl(new Guid("2733fce7-7f41-4af4-b74f-2f07e3697631"));
            chkHB = (ITTCheckBox)AddControl(new Guid("a8237b7e-d1e3-4d00-9b60-2bee051d5fb2"));
            chkTransfused = (ITTCheckBox)AddControl(new Guid("1bdaf66b-f1ff-4dcb-a060-33f4e3e92641"));
            chkPrepare = (ITTCheckBox)AddControl(new Guid("bf7537a3-6c1a-4dc7-95ce-04340d7c3bf3"));
            ttlabel5 = (ITTLabel)AddControl(new Guid("39c91933-b25b-4c44-8be3-9ca14f87aabd"));
            ttlabel7 = (ITTLabel)AddControl(new Guid("0c38f51f-a6b1-4d1e-849a-204327533715"));
            chkPregnancy = (ITTCheckBox)AddControl(new Guid("65bb308a-52af-456a-8cfb-b8e11ea46cdd"));
            chkSurgery = (ITTCheckBox)AddControl(new Guid("c20564b1-bdf9-47b6-8b1c-932dcadd5087"));
            ttlabel6 = (ITTLabel)AddControl(new Guid("b5ef1b28-a08d-4f98-927f-050e6a056600"));
            tttabcontrol1 = (ITTTabControl)AddControl(new Guid("02904ffc-adfc-4042-a2bf-2875ae2977d3"));
            tttabpage1 = (ITTTabPage)AddControl(new Guid("f481df0c-44c2-4c4d-b95c-e505ec5d1dde"));
            ttgrid1 = (ITTGrid)AddControl(new Guid("d0633994-c1f5-4165-8a89-26fbdebf5d95"));
            ttlistbox1 = (ITTListBoxColumn)AddControl(new Guid("119617d4-88b1-4853-a0c5-d68557be0ee1"));
            txtAmount = (ITTTextBoxColumn)AddControl(new Guid("194375e7-d817-4357-b949-9bd1ba4c3804"));
            chkIsinlanmis = (ITTCheckBoxColumn)AddControl(new Guid("698dac1b-3301-4077-b948-7297904a5745"));
            chkFiltrelenmis = (ITTCheckBoxColumn)AddControl(new Guid("94bf54db-2502-49a0-ae80-39f48a673790"));
            base.InitializeControls();
        }

        public BloodProductPreparationForm() : base("BLOODPRODUCTREQUEST", "BloodProductPreparationForm")
        {
        }

        protected BloodProductPreparationForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}