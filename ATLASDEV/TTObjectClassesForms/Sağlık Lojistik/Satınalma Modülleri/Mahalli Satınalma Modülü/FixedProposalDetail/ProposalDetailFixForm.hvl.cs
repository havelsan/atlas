
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
    /// Teklif Düzeltme
    /// </summary>
    public partial class ProposalDetailFixForm : TTForm
    {
    /// <summary>
    /// Karar Düzeltme Yapılmış İhale Kalemlerinde, Düzeltme Bilgilerinin Tutulduğu Sınıftır
    /// </summary>
        protected TTObjectClasses.FixedProposalDetail _FixedProposalDetail
        {
            get { return (TTObjectClasses.FixedProposalDetail)_ttObject; }
        }

        protected ITTTextBox tttextbox1;
        protected ITTObjectListBox Supplier;
        protected ITTLabel labelPurchaseItemDef;
        protected ITTObjectListBox PurchaseItemDef;
        protected ITTLabel labelOldPrice;
        protected ITTTextBox OldPrice;
        protected ITTLabel labelFixedPrice;
        protected ITTTextBox FixedPrice;
        protected ITTLabel labelDescription;
        protected ITTCheckBox Deny;
        protected ITTLabel ttlabel1;
        override protected void InitializeControls()
        {
            tttextbox1 = (ITTTextBox)AddControl(new Guid("b73c36bf-d751-4b4e-8068-95a28c103ad3"));
            Supplier = (ITTObjectListBox)AddControl(new Guid("f5001d52-79da-4020-9dfa-1d53b8e68401"));
            labelPurchaseItemDef = (ITTLabel)AddControl(new Guid("e3adaf02-b704-4541-8cf8-749e277aa469"));
            PurchaseItemDef = (ITTObjectListBox)AddControl(new Guid("ecc24434-29d7-4940-b5f7-13e23011a819"));
            labelOldPrice = (ITTLabel)AddControl(new Guid("d47f11ed-c066-41ca-ab7c-52a5f0c51dd4"));
            OldPrice = (ITTTextBox)AddControl(new Guid("2c99a7b5-1db5-492b-ac86-fc7e8f1067ba"));
            labelFixedPrice = (ITTLabel)AddControl(new Guid("b1b9db74-2750-4af8-b247-54da8c89b83b"));
            FixedPrice = (ITTTextBox)AddControl(new Guid("ee8e03e7-e766-4a79-987e-6431b1b6e2aa"));
            labelDescription = (ITTLabel)AddControl(new Guid("de17e4e9-67fe-42fb-9b3f-e2d1b62806ad"));
            Deny = (ITTCheckBox)AddControl(new Guid("e39111f8-b859-405a-885e-2834082699a2"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("9792a7c2-0503-4651-8303-022bf49f9557"));
            base.InitializeControls();
        }

        public ProposalDetailFixForm() : base("FIXEDPROPOSALDETAIL", "ProposalDetailFixForm")
        {
        }

        protected ProposalDetailFixForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}