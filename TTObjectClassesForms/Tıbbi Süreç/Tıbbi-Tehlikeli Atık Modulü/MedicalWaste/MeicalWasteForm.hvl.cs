
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
    public partial class MeicalWasteForm : TTForm
    {
    /// <summary>
    /// Tıbbi/Tehlikeli Atık
    /// </summary>
        protected TTObjectClasses.MedicalWaste _MedicalWaste
        {
            get { return (TTObjectClasses.MedicalWaste)_ttObject; }
        }

        protected ITTLabel labelMedicalWasteProduce;
        protected ITTObjectListBox MedicalWasteProduce;
        protected ITTLabel labelMedicalWasteType;
        protected ITTObjectListBox MedicalWasteType;
        protected ITTLabel labelAmount;
        protected ITTTextBox Amount;
        protected ITTLabel labelTransactionDate;
        protected ITTDateTimePicker TransactionDate;
        protected ITTObjectListBox ttobjectlistbox1;
        protected ITTLabel ttlabel1;
        protected ITTObjectListBox MedicalWasteContainer;
        protected ITTLabel labelMedicalWasteContainer;
        override protected void InitializeControls()
        {
            labelMedicalWasteProduce = (ITTLabel)AddControl(new Guid("6db89615-423d-4c61-94cf-2ce82e811a1a"));
            MedicalWasteProduce = (ITTObjectListBox)AddControl(new Guid("f796a672-9e95-4460-973b-186a6342d847"));
            labelMedicalWasteType = (ITTLabel)AddControl(new Guid("561423f2-0650-4705-b50e-cac831fdfeb5"));
            MedicalWasteType = (ITTObjectListBox)AddControl(new Guid("5b2c6409-4eaa-48e6-8a60-a90da49b40e3"));
            labelAmount = (ITTLabel)AddControl(new Guid("27930734-47cd-435b-a765-27d50e75556d"));
            Amount = (ITTTextBox)AddControl(new Guid("e02b5d2c-afff-4232-91ea-f891ee406aed"));
            labelTransactionDate = (ITTLabel)AddControl(new Guid("019ffa3d-51b2-4c3c-8034-7be5e9fb903c"));
            TransactionDate = (ITTDateTimePicker)AddControl(new Guid("123a4cc0-bf5e-4c64-8743-a1ed8bb71671"));
            ttobjectlistbox1 = (ITTObjectListBox)AddControl(new Guid("4a2f1482-3900-48f0-968d-6008d11fb77a"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("37a9eedf-ab8f-45d2-b103-f0793d72da95"));
            MedicalWasteContainer = (ITTObjectListBox)AddControl(new Guid("5b1127fd-a4bc-4635-844d-1d344cd5b36a"));
            labelMedicalWasteContainer = (ITTLabel)AddControl(new Guid("c1b055dc-ea9f-4b9f-b80a-9e7f4dbda6b2"));
            base.InitializeControls();
        }

        public MeicalWasteForm() : base("MEDICALWASTE", "MeicalWasteForm")
        {
        }

        protected MeicalWasteForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}