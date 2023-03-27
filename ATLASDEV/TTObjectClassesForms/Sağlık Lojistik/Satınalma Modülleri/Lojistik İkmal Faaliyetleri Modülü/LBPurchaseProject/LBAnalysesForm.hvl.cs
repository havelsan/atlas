
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
    /// İnceleme
    /// </summary>
    public partial class LBAnalysesForm : LBBaseForm
    {
    /// <summary>
    /// Lojistik İkmal Faliyetleri modülü temel sınıfıdır
    /// </summary>
        protected TTObjectClasses.LBPurchaseProject _LBPurchaseProject
        {
            get { return (TTObjectClasses.LBPurchaseProject)_ttObject; }
        }

        protected ITTGroupBox ttgroupbox2;
        protected ITTLabel ttlabel1;
        protected ITTLabel labelPurchaseProjectNO;
        protected ITTEnumComboBox IBFType;
        protected ITTButton cmdList;
        protected ITTMaskedTextBox IBFYear;
        protected ITTTextBox tttextbox1;
        protected ITTLabel IBFYearLabel;
        protected ITTTextBox PurchaseProjectNO;
        protected ITTLabel IBFTypeLabel;
        override protected void InitializeControls()
        {
            ttgroupbox2 = (ITTGroupBox)AddControl(new Guid("ef35520b-772f-40db-a379-e40c3f04ef75"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("e5de73f0-8e9e-4bce-a371-40f6f1674c7f"));
            labelPurchaseProjectNO = (ITTLabel)AddControl(new Guid("a7460534-5c2f-45f5-a3bb-54450598f0bc"));
            IBFType = (ITTEnumComboBox)AddControl(new Guid("12b70465-a928-4b42-bd65-255a1599cf2e"));
            cmdList = (ITTButton)AddControl(new Guid("7f481cdf-5802-41e2-92a2-a66961238eb4"));
            IBFYear = (ITTMaskedTextBox)AddControl(new Guid("ddd039be-53e8-4f6b-89ed-a9d9b5d08d04"));
            tttextbox1 = (ITTTextBox)AddControl(new Guid("3ab0f910-82f7-46f1-bc66-739992cfb8d5"));
            IBFYearLabel = (ITTLabel)AddControl(new Guid("7555ae55-10c4-405a-9243-f6c112f0dcaf"));
            PurchaseProjectNO = (ITTTextBox)AddControl(new Guid("a459b456-088f-4e5e-bbe1-afc28f7114cf"));
            IBFTypeLabel = (ITTLabel)AddControl(new Guid("133ba044-e028-43d3-8c76-688322e17c88"));
            base.InitializeControls();
        }

        public LBAnalysesForm() : base("LBPURCHASEPROJECT", "LBAnalysesForm")
        {
        }

        protected LBAnalysesForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}