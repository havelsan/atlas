
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
    /// Stok Kart Bilgileri
    /// </summary>
    public partial class NewStockCardDefinitionForm : TTUnboundForm
    {
        protected ITTPictureBoxControl StockCardPicture;
        protected ITTListView StockCardMaterials;
        protected ITTTextBox EnglishName;
        protected ITTTextBox Name;
        protected ITTTextBox NATOStockNO;
        protected ITTButton EscButton;
        protected ITTLabel labelEnglishName;
        protected ITTLabel labelName;
        protected ITTLabel labelNATOStockNO;
        protected ITTEnumComboBox Status;
        protected ITTLabel labelStatus;
        protected ITTLabel labelDistributionType;
        protected ITTObjectListBox DistributionType;
        protected ITTEnumComboBox StockMethod;
        protected ITTLabel labelStockMethod;
        protected ITTObjectListBox CardDrawer;
        protected ITTLabel labelCardDrawer;
        protected ITTButton SaveButton;
        protected ITTLabel labelCreationDate;
        protected ITTDateTimePicker CreationDate;
        protected ITTLabel ttlabel1;
        protected ITTLabel ttlabel2;
        override protected void InitializeControls()
        {
            StockCardPicture = (ITTPictureBoxControl)AddControl(new Guid("6cc9dfd9-8858-44d1-9ad6-b8efc9f858f4"));
            StockCardMaterials = (ITTListView)AddControl(new Guid("593c8c0d-cdc5-4b63-9100-4c61f6aae51e"));
            EnglishName = (ITTTextBox)AddControl(new Guid("61ed52dc-9408-416e-b265-880f1cee161e"));
            Name = (ITTTextBox)AddControl(new Guid("5341fa4e-2723-40c3-b50a-813cfbe2984d"));
            NATOStockNO = (ITTTextBox)AddControl(new Guid("018f9396-6654-483f-883d-e73df22f528b"));
            EscButton = (ITTButton)AddControl(new Guid("7a6a485c-ed6d-4590-9a72-9ecaf264f28d"));
            labelEnglishName = (ITTLabel)AddControl(new Guid("ac8698c3-c72e-474e-8504-de990f5c3b77"));
            labelName = (ITTLabel)AddControl(new Guid("876eb717-e56a-4f2f-bece-87642cde1aaf"));
            labelNATOStockNO = (ITTLabel)AddControl(new Guid("66a65920-5ea8-4d52-819f-7e0e97465783"));
            Status = (ITTEnumComboBox)AddControl(new Guid("9fad7f7d-32c7-46c4-8cca-8d4b4cc0bcbe"));
            labelStatus = (ITTLabel)AddControl(new Guid("85889402-b6d2-4075-8559-345e8a7fb259"));
            labelDistributionType = (ITTLabel)AddControl(new Guid("f7ef2137-2cc6-49a8-acf7-81250274ff75"));
            DistributionType = (ITTObjectListBox)AddControl(new Guid("97abfc1c-b60d-4fb0-9afe-81529b650fe1"));
            StockMethod = (ITTEnumComboBox)AddControl(new Guid("e6498cb4-3fb8-41a6-ae7e-04679a6c0207"));
            labelStockMethod = (ITTLabel)AddControl(new Guid("0224a43d-ebe5-40b9-8296-488b3ac321d7"));
            CardDrawer = (ITTObjectListBox)AddControl(new Guid("a6c6706a-986a-43cd-9d3e-2894806045fd"));
            labelCardDrawer = (ITTLabel)AddControl(new Guid("dd6ddd21-3829-485a-939c-fb643231ceb3"));
            SaveButton = (ITTButton)AddControl(new Guid("d13d8ebb-0632-42aa-9ac9-20206d9a979e"));
            labelCreationDate = (ITTLabel)AddControl(new Guid("c18c4797-42a1-4852-998a-b39be17d5ce8"));
            CreationDate = (ITTDateTimePicker)AddControl(new Guid("61047f4a-2421-4606-9a63-282771b9334b"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("25b98a5a-3edf-48f7-9aba-038bd3d51b11"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("3e653054-e8d8-43bb-9792-0769aafeec3e"));
            base.InitializeControls();
        }

        public NewStockCardDefinitionForm() : base("NewStockCardDefinitionForm")
        {
        }

        protected NewStockCardDefinitionForm(string formDefName) : base(formDefName)
        {
        }
    }
}