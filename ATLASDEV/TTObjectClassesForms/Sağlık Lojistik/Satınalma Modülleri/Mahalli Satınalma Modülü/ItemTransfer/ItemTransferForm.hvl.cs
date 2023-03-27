
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
    /// Tertip Emri
    /// </summary>
    public partial class ItemTransferForm : TTForm
    {
    /// <summary>
    /// Lojistik Dairenin Yaptığı Muvazene Bilgilerini Tutan Sınıftır
    /// </summary>
        protected TTObjectClasses.ItemTransfer _ItemTransfer
        {
            get { return (TTObjectClasses.ItemTransfer)_ttObject; }
        }

        protected ITTRichTextBoxControl ttrichtextboxcontrol1;
        protected ITTLabel labelWriter;
        protected ITTObjectListBox Writer;
        protected ITTLabel labelGroupFrontAddition;
        protected ITTTextBox GroupFrontAddition;
        protected ITTLabel labelMsgOrder;
        protected ITTTextBox MsgOrder;
        protected ITTLabel labelFileNo;
        protected ITTTextBox FileNo;
        protected ITTLabel labelPrivacyLevel;
        protected ITTTextBox PrivacyLevel;
        protected ITTLabel labelDateTimeGroup;
        protected ITTTextBox DateTimeGroup;
        protected ITTLabel labelInfo;
        protected ITTTextBox Info;
        protected ITTLabel labelNeed;
        protected ITTTextBox Need;
        override protected void InitializeControls()
        {
            ttrichtextboxcontrol1 = (ITTRichTextBoxControl)AddControl(new Guid("c141542c-9b24-448e-a144-0b1b05cc6b65"));
            labelWriter = (ITTLabel)AddControl(new Guid("f6281355-2c4a-424a-bb18-3c5de7dc1207"));
            Writer = (ITTObjectListBox)AddControl(new Guid("c81fdca6-062d-4761-a11a-7199426239fe"));
            labelGroupFrontAddition = (ITTLabel)AddControl(new Guid("71b92885-ffcc-47d7-82be-be3e3b938ccf"));
            GroupFrontAddition = (ITTTextBox)AddControl(new Guid("b9f15a14-cb79-4a4a-bc7b-c49258d69b20"));
            labelMsgOrder = (ITTLabel)AddControl(new Guid("ccbeae41-8b00-4509-8711-c8fe39371a77"));
            MsgOrder = (ITTTextBox)AddControl(new Guid("92d1839a-3939-40be-bdf2-588b77c1fa75"));
            labelFileNo = (ITTLabel)AddControl(new Guid("bebe203d-0fca-4156-ac9a-25ba646429ff"));
            FileNo = (ITTTextBox)AddControl(new Guid("b5ecf561-3d9e-433a-9e67-1b7769f3bbc6"));
            labelPrivacyLevel = (ITTLabel)AddControl(new Guid("6ac16138-99ad-479f-8fac-f4f846019bfc"));
            PrivacyLevel = (ITTTextBox)AddControl(new Guid("849cc0a4-a77a-44f2-8a95-a0c447a81b6a"));
            labelDateTimeGroup = (ITTLabel)AddControl(new Guid("aa7469ee-3548-4c65-9553-fb1c7ac86f7a"));
            DateTimeGroup = (ITTTextBox)AddControl(new Guid("eb66f404-7ed5-40d5-82f5-082306e80c1c"));
            labelInfo = (ITTLabel)AddControl(new Guid("e8039d1b-a339-4491-b605-43f238f9bcf4"));
            Info = (ITTTextBox)AddControl(new Guid("32e3bb48-8fe8-4629-adba-efcd93c39cd9"));
            labelNeed = (ITTLabel)AddControl(new Guid("f382a01d-d084-40cd-a7a1-1cd24ce41352"));
            Need = (ITTTextBox)AddControl(new Guid("d681913d-7bcf-41d3-83e2-ec2306cf3d19"));
            base.InitializeControls();
        }

        public ItemTransferForm() : base("ITEMTRANSFER", "ItemTransferForm")
        {
        }

        protected ItemTransferForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}