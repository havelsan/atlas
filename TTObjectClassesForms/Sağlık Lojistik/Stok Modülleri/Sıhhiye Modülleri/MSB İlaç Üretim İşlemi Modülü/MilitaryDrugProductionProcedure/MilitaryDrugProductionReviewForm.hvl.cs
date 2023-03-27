
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
    /// Mevcut İnceleme ve Yeterli Miktar Tespit Etme
    /// </summary>
    public partial class MilitaryDrugProductionReviewForm : TTForm
    {
    /// <summary>
    /// MSB İlaç Üretim İşlemi için kullanılan temel sınıftır
    /// </summary>
        protected TTObjectClasses.MilitaryDrugProductionProcedure _MilitaryDrugProductionProcedure
        {
            get { return (TTObjectClasses.MilitaryDrugProductionProcedure)_ttObject; }
        }

        protected ITTTabControl tttabcontrol1;
        protected ITTTabPage tttabpage1;
        protected ITTGrid ProductTreeDetails;
        protected ITTListBoxColumn ConsumableMaterial;
        protected ITTListBoxColumn DistributionType;
        protected ITTTextBoxColumn RequiredAmount;
        protected ITTTextBoxColumn StoreInheld;
        protected ITTTextBoxColumn ProducedAmount;
        protected ITTTextBox ProducedMaterialAmount;
        protected ITTTextBox RequirementAmount;
        protected ITTLabel ttlabel1;
        protected ITTLabel ttlabel2;
        protected ITTObjectListBox ProducedMaterial;
        protected ITTLabel labelOrderDecisionDate;
        protected ITTObjectListBox ProductAnnualReqDet;
        protected ITTLabel labelRequirementAmount;
        protected ITTObjectListBox DestinationStore;
        protected ITTLabel labelStore;
        override protected void InitializeControls()
        {
            tttabcontrol1 = (ITTTabControl)AddControl(new Guid("67c704ce-1163-4bdd-a60c-acb82a1d5aa7"));
            tttabpage1 = (ITTTabPage)AddControl(new Guid("4011a276-d539-4a2d-b683-3c641c61c4a9"));
            ProductTreeDetails = (ITTGrid)AddControl(new Guid("89e06e81-394c-4ceb-8418-480a2fd13304"));
            ConsumableMaterial = (ITTListBoxColumn)AddControl(new Guid("6f9ede21-64ef-4bbc-9da4-457251dee647"));
            DistributionType = (ITTListBoxColumn)AddControl(new Guid("e7766916-88c6-4e36-be07-8d1b4cbb4aa8"));
            RequiredAmount = (ITTTextBoxColumn)AddControl(new Guid("2cea3d83-636e-4a70-be0e-aab6bdfba24e"));
            StoreInheld = (ITTTextBoxColumn)AddControl(new Guid("19e81976-0dd2-4fe7-91d4-d2547ab56767"));
            ProducedAmount = (ITTTextBoxColumn)AddControl(new Guid("a8698b67-20cf-49cf-bda6-78d8d146a7bf"));
            ProducedMaterialAmount = (ITTTextBox)AddControl(new Guid("d2e8e92d-6492-4996-b908-0a9f7ebf5621"));
            RequirementAmount = (ITTTextBox)AddControl(new Guid("f55d4d7f-7487-491d-8eab-ccf40f97cb55"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("d7f614a6-0fd9-4320-b226-64188bc7d92d"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("e03236c3-bdef-47f9-aa19-7716fe875a7f"));
            ProducedMaterial = (ITTObjectListBox)AddControl(new Guid("be819c6f-eab3-4385-8184-55783c5d350c"));
            labelOrderDecisionDate = (ITTLabel)AddControl(new Guid("ce3ac8e7-68c1-4d34-8d9a-e40312fc2ccf"));
            ProductAnnualReqDet = (ITTObjectListBox)AddControl(new Guid("9adc5caf-efe2-4b99-bb04-4c7f8234aa8d"));
            labelRequirementAmount = (ITTLabel)AddControl(new Guid("143b9513-073d-445d-bcfa-0e2c4171d199"));
            DestinationStore = (ITTObjectListBox)AddControl(new Guid("652f496f-cfe8-4967-a04d-d6bbf559a47e"));
            labelStore = (ITTLabel)AddControl(new Guid("ea94b9f9-fa71-494a-98a6-6ae85d1c9338"));
            base.InitializeControls();
        }

        public MilitaryDrugProductionReviewForm() : base("MILITARYDRUGPRODUCTIONPROCEDURE", "MilitaryDrugProductionReviewForm")
        {
        }

        protected MilitaryDrugProductionReviewForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}