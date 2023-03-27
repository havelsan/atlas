
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
    /// Kan Bankası Kan Ürünü İptal
    /// </summary>
    public partial class BloodProductRejectForm : EpisodeActionForm
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
        protected ITTTextBoxColumn txtBloodProductState;
        protected ITTTextBoxColumn txtAmount;
        protected ITTCheckBoxColumn chkIsinlanmis;
        protected ITTCheckBoxColumn chkFiltrelenmis;
        override protected void InitializeControls()
        {
            ttlabel3 = (ITTLabel)AddControl(new Guid("58c7d0f2-7e1b-4ab5-b217-9683ea95ce09"));
            tttextbox2 = (ITTTextBox)AddControl(new Guid("e396d7a6-699e-455d-8b6c-7ccc09b9ba6f"));
            ttgroupbox1 = (ITTGroupBox)AddControl(new Guid("469b4a47-a347-4b73-976b-5f114515d2c9"));
            btnSend = (ITTButton)AddControl(new Guid("79905463-6f03-469c-b077-8e5ea0bf7d0c"));
            pnlUrgent = (ITTPanel)AddControl(new Guid("141ebab4-9590-41f7-a3be-8e61bdbc06c6"));
            chkWithTest = (ITTCheckBox)AddControl(new Guid("775775c3-de35-462e-9a3e-9ca127965c0e"));
            chkWithoutTests = (ITTCheckBox)AddControl(new Guid("5f206f4c-3ee2-4616-b017-62d70d1293a5"));
            chkUrgentCross = (ITTCheckBox)AddControl(new Guid("4710b9bf-b576-42c2-a67c-d1218f19332f"));
            chkWithoutCross = (ITTCheckBox)AddControl(new Guid("7ef2e7a3-f727-4158-bffd-543c03c51c68"));
            chkNormal = (ITTCheckBox)AddControl(new Guid("08c80c2e-5e7c-4b42-a2db-46a3ce4cc49c"));
            dtRequirement = (ITTDateTimePicker)AddControl(new Guid("79322206-b76a-48e3-9108-c546c9366e61"));
            ttcheckbox5 = (ITTCheckBox)AddControl(new Guid("661b04c8-eddd-439d-aaaa-3f8e19b94ae5"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("1b9a7e11-ecd4-4561-8b2c-cfbbb0df4805"));
            ttcheckbox4 = (ITTCheckBox)AddControl(new Guid("c16fdfe0-d993-4105-99c6-aeac42709280"));
            dtTransfused = (ITTDateTimePicker)AddControl(new Guid("c3572d2f-fc36-464b-8ddb-4b215117ef78"));
            chkUrgent = (ITTCheckBox)AddControl(new Guid("6a0c0d5b-79e3-4d9d-9ae6-b8937c9eca1e"));
            dtPregnancy = (ITTDateTimePicker)AddControl(new Guid("83bdb3b4-b753-4c20-8960-09174cbacac5"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("1ab14c23-2107-42ef-adda-50542e401d2f"));
            chkBlock = (ITTCheckBox)AddControl(new Guid("7a41e9f2-656e-40a5-b0c9-ca9a0c2df6a0"));
            tttextbox1 = (ITTTextBox)AddControl(new Guid("0b218467-925d-4ab3-9fd3-2007424c0450"));
            chkOther = (ITTCheckBox)AddControl(new Guid("423b5711-3dd8-41b8-a740-d380df93620b"));
            ttlabel4 = (ITTLabel)AddControl(new Guid("cff705d8-e651-44ac-a987-1ad5f8d1f827"));
            chkHB = (ITTCheckBox)AddControl(new Guid("2af3ca8f-0986-4db1-8858-5187fc643544"));
            chkTransfused = (ITTCheckBox)AddControl(new Guid("3aa27da0-d534-47b8-9f9d-9b69acd6b55c"));
            chkPrepare = (ITTCheckBox)AddControl(new Guid("4ced4a6f-4171-451a-a8e4-d149beb5a701"));
            ttlabel5 = (ITTLabel)AddControl(new Guid("36720c9f-1379-436b-b24a-68011c19f510"));
            ttlabel7 = (ITTLabel)AddControl(new Guid("2c78bc03-bbf1-4491-b4f5-33912911e5d5"));
            chkPregnancy = (ITTCheckBox)AddControl(new Guid("94ed7701-f045-410f-9170-6c5df68f5281"));
            chkSurgery = (ITTCheckBox)AddControl(new Guid("2d8afd30-4d83-4415-ae98-c3993bcff887"));
            ttlabel6 = (ITTLabel)AddControl(new Guid("3e70649d-ac2b-4b68-af9e-7a6c4007c237"));
            tttabcontrol1 = (ITTTabControl)AddControl(new Guid("c3332f1d-60d0-45fa-b5c2-f0637148f169"));
            tttabpage1 = (ITTTabPage)AddControl(new Guid("acaf3fe1-5a3f-4a50-a59b-186d9ab4b42a"));
            ttgrid1 = (ITTGrid)AddControl(new Guid("d8245af9-35b7-4634-99ba-c6b7b529e2a2"));
            ttlistbox1 = (ITTListBoxColumn)AddControl(new Guid("0a563a01-1abe-4aa5-b3f2-7a38e48ae119"));
            txtBloodProductState = (ITTTextBoxColumn)AddControl(new Guid("47a098aa-e4d2-4bfd-a875-e9dbdfb9f944"));
            txtAmount = (ITTTextBoxColumn)AddControl(new Guid("94c95477-cd49-4837-8262-634c6ed551ce"));
            chkIsinlanmis = (ITTCheckBoxColumn)AddControl(new Guid("579003a9-29fa-40f2-8f57-5083c1827f9b"));
            chkFiltrelenmis = (ITTCheckBoxColumn)AddControl(new Guid("b772fa2a-846d-47a0-9401-0e8124d840ea"));
            base.InitializeControls();
        }

        public BloodProductRejectForm() : base("BLOODPRODUCTREQUEST", "BloodProductRejectForm")
        {
        }

        protected BloodProductRejectForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}