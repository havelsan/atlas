
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
    /// Üretim Servisi Tanımı
    /// </summary>
    public partial class ProductionServiceDefinitionForm : TTForm
    {
    /// <summary>
    /// Üretim Servisi Tanımı
    /// </summary>
        protected TTObjectClasses.ResProductionService _ResProductionService
        {
            get { return (TTObjectClasses.ResProductionService)_ttObject; }
        }

        protected ITTObjectListBox ProductionCenter;
        protected ITTTextBox Name;
        protected ITTTextBox Qref;
        protected ITTTextBox Location;
        protected ITTTextBox DeskPhoneNumber;
        protected ITTLabel labelQref;
        protected ITTLabel labelName;
        protected ITTCheckBox Active;
        protected ITTEnumComboBox EnabledType;
        protected ITTLabel labelEnabledType;
        protected ITTLabel labelStore;
        protected ITTObjectListBox Store;
        protected ITTLabel labelProductionCenter;
        protected ITTLabel labelLocation;
        protected ITTLabel labelDeskPhoneNumber;
        override protected void InitializeControls()
        {
            ProductionCenter = (ITTObjectListBox)AddControl(new Guid("0eca53fc-3a7f-45e5-8d8e-02ad783f0088"));
            Name = (ITTTextBox)AddControl(new Guid("d1ea8d84-fbfc-4c4c-81f3-f247cb8aa907"));
            Qref = (ITTTextBox)AddControl(new Guid("2f295387-57a1-4f15-bb39-c4ca43c85b8a"));
            Location = (ITTTextBox)AddControl(new Guid("5009f9d2-ddd8-4f8e-bfae-c0e78a3b9d83"));
            DeskPhoneNumber = (ITTTextBox)AddControl(new Guid("e7dfa43f-363f-4d0c-8cea-e0907366874a"));
            labelQref = (ITTLabel)AddControl(new Guid("c2b054cb-fa8e-46d9-b814-3a4c7cabcfaf"));
            labelName = (ITTLabel)AddControl(new Guid("a2fbe55c-6a20-4679-ae01-22a07e1f2800"));
            Active = (ITTCheckBox)AddControl(new Guid("a2e53d5a-711a-4719-a611-5c944469f1d1"));
            EnabledType = (ITTEnumComboBox)AddControl(new Guid("467923d8-07fb-4c92-8cbe-7237ba5e3b6b"));
            labelEnabledType = (ITTLabel)AddControl(new Guid("bced3467-0ca1-4319-b6a2-6bd7ecb70a90"));
            labelStore = (ITTLabel)AddControl(new Guid("e9dee4a8-991d-440c-bb2d-2eec95ca34de"));
            Store = (ITTObjectListBox)AddControl(new Guid("810b9b65-1c1b-47e8-bb6e-4cf796af00aa"));
            labelProductionCenter = (ITTLabel)AddControl(new Guid("46fcf220-7f61-45fc-8c47-927a40d8fc1b"));
            labelLocation = (ITTLabel)AddControl(new Guid("bc7c716b-1910-43cf-8e3a-d62a7602155d"));
            labelDeskPhoneNumber = (ITTLabel)AddControl(new Guid("2f2498ca-754d-4126-a695-c048bc17405a"));
            base.InitializeControls();
        }

        public ProductionServiceDefinitionForm() : base("RESPRODUCTIONSERVICE", "ProductionServiceDefinitionForm")
        {
        }

        protected ProductionServiceDefinitionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}