
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
    /// E1 Belgesi
    /// </summary>
    public partial class E1Form : TTForm
    {
    /// <summary>
    /// E1 Çizelgesi
    /// </summary>
        protected TTObjectClasses.E1 _E1
        {
            get { return (TTObjectClasses.E1)_ttObject; }
        }

        protected ITTTabControl tttabcontrol1;
        protected ITTTabPage ConsumableMaterialTabPage;
        protected ITTGrid StockActionOutDetails;
        protected ITTListBoxColumn Material;
        protected ITTTextBoxColumn Amount;
        protected ITTTextBoxColumn Inheld;
        protected ITTTextBoxColumn QuarantineNO;
        protected ITTListDefComboBoxColumn StockLevelTypeList;
        protected ITTTextBox StockActionID;
        protected ITTTextBox Description;
        protected ITTLabel labelProcessNO;
        protected ITTDateTimePicker StartDate;
        protected ITTLabel labelEndDate;
        protected ITTLabel labelStartDate;
        protected ITTLabel labelDescription;
        protected ITTDateTimePicker TransactionDate;
        protected ITTDateTimePicker EndDate;
        protected ITTLabel labelProcessDate;
        protected ITTLabel ttlabel1;
        protected ITTObjectListBox Store;
        override protected void InitializeControls()
        {
            tttabcontrol1 = (ITTTabControl)AddControl(new Guid("cc3f26e7-e7ad-4d22-9ed2-ee2d1f4e7a60"));
            ConsumableMaterialTabPage = (ITTTabPage)AddControl(new Guid("da4d2aea-14d7-43a0-a884-019cddda1559"));
            StockActionOutDetails = (ITTGrid)AddControl(new Guid("5ffaf3e6-67d6-496a-9e18-072475ab2498"));
            Material = (ITTListBoxColumn)AddControl(new Guid("91bde64a-3a25-4c6e-8704-775c27a21a20"));
            Amount = (ITTTextBoxColumn)AddControl(new Guid("667d4061-f620-4f68-b48e-e99f68b6ee09"));
            Inheld = (ITTTextBoxColumn)AddControl(new Guid("3a97999c-ebe8-46a4-9109-2a53a92aa99f"));
            QuarantineNO = (ITTTextBoxColumn)AddControl(new Guid("d2d8415d-7e72-4bd0-844a-2aa3ebd6aa99"));
            StockLevelTypeList = (ITTListDefComboBoxColumn)AddControl(new Guid("f77af2da-00fa-4ba2-b4f8-011a11261cfc"));
            StockActionID = (ITTTextBox)AddControl(new Guid("0537a699-6199-418a-a77b-e1570d0879df"));
            Description = (ITTTextBox)AddControl(new Guid("8f5154ea-febf-4c9e-9a0a-ec75255645c4"));
            labelProcessNO = (ITTLabel)AddControl(new Guid("e7908ec5-4395-471f-bb6a-1ead71365be6"));
            StartDate = (ITTDateTimePicker)AddControl(new Guid("946db7f9-a569-4b6e-8ec2-406cd28b3e69"));
            labelEndDate = (ITTLabel)AddControl(new Guid("4dc6eb38-f0b2-43cf-bf08-42f6f135d301"));
            labelStartDate = (ITTLabel)AddControl(new Guid("9c6a0500-031c-4ef2-b8ac-4f617c5e6b20"));
            labelDescription = (ITTLabel)AddControl(new Guid("190f0c91-7c8e-4836-93ca-7c35896ff611"));
            TransactionDate = (ITTDateTimePicker)AddControl(new Guid("fe7d39ba-a3af-4ffb-8aa3-beb3d9304f2b"));
            EndDate = (ITTDateTimePicker)AddControl(new Guid("125ae4cb-22fa-478c-9e4a-bf14a00bd889"));
            labelProcessDate = (ITTLabel)AddControl(new Guid("852621e1-a0df-4096-8c83-eb4b2c1d24d2"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("f438e841-c98a-4ad8-9f08-6ea9f974e76c"));
            Store = (ITTObjectListBox)AddControl(new Guid("78888c2f-6c73-4637-9447-1725ce68380d"));
            base.InitializeControls();
        }

        public E1Form() : base("E1", "E1Form")
        {
        }

        protected E1Form(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}