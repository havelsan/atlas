
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
    /// Amir Onayı
    /// </summary>
    public partial class LBApproveForm : LBBaseForm
    {
    /// <summary>
    /// Lojistik İkmal Faliyetleri modülü temel sınıfıdır
    /// </summary>
        protected TTObjectClasses.LBPurchaseProject _LBPurchaseProject
        {
            get { return (TTObjectClasses.LBPurchaseProject)_ttObject; }
        }

        protected ITTGroupBox ttgroupbox2;
        protected ITTTextBox tttextbox1;
        protected ITTTextBox PurchaseProjectNO;
        protected ITTMaskedTextBox IBFYear;
        protected ITTLabel ttlabel1;
        protected ITTEnumComboBox IBFType;
        protected ITTLabel labelPurchaseProjectNO;
        protected ITTLabel IBFYearLabel;
        protected ITTLabel IBFTypeLabel;
        override protected void InitializeControls()
        {
            ttgroupbox2 = (ITTGroupBox)AddControl(new Guid("6143c493-89e6-4963-9c05-c0d6a400b118"));
            tttextbox1 = (ITTTextBox)AddControl(new Guid("d45ee1cf-8559-4092-9f35-d1588e549bef"));
            PurchaseProjectNO = (ITTTextBox)AddControl(new Guid("415e49db-4747-41c5-aa86-06110e6db381"));
            IBFYear = (ITTMaskedTextBox)AddControl(new Guid("f9aacea8-614a-4eee-a27c-aaa1326c7f6a"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("916fbbe8-655a-478d-9237-931f74e41f2c"));
            IBFType = (ITTEnumComboBox)AddControl(new Guid("4c2667b2-38d3-4a63-a328-df18913dc4d0"));
            labelPurchaseProjectNO = (ITTLabel)AddControl(new Guid("aff8bacd-0b18-4ca2-a02f-95cd3b101542"));
            IBFYearLabel = (ITTLabel)AddControl(new Guid("056708e9-577b-4958-a260-790f30ae4665"));
            IBFTypeLabel = (ITTLabel)AddControl(new Guid("2a79120d-2979-4289-89fe-b46596bd330b"));
            base.InitializeControls();
        }

        public LBApproveForm() : base("LBPURCHASEPROJECT", "LBApproveForm")
        {
        }

        protected LBApproveForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}