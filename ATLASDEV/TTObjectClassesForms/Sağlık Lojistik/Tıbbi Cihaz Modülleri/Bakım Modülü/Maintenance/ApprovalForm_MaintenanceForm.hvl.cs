
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
    /// Bakım Onay
    /// </summary>
    public partial class ApprovalForm_Maintenance : MaintenanceBaseForm
    {
    /// <summary>
    /// Bakım
    /// </summary>
        protected TTObjectClasses.Maintenance _Maintenance
        {
            get { return (TTObjectClasses.Maintenance)_ttObject; }
        }

        protected ITTObjectListBox WorkShop;
        protected ITTLabel ttlabel1;
        protected ITTObjectListBox ResponsibleResource;
        protected ITTLabel labelRequestNO;
        protected ITTObjectListBox FixedAsset;
        protected ITTLabel labelToResource;
        protected ITTLabel labelDescription;
        protected ITTTextBox Description;
        protected ITTObjectListBox ToResource;
        protected ITTTextBox RequestNO;
        protected ITTObjectListBox FromResource;
        protected ITTLabel labelFixedAsset;
        protected ITTLabel labelResponsibleResource;
        protected ITTLabel labelFromResource;
        protected ITTObjectListBox Stage;
        override protected void InitializeControls()
        {
            WorkShop = (ITTObjectListBox)AddControl(new Guid("81aef193-1578-4a15-b749-50a2a2523dcd"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("e0eb4519-a5f4-47f0-9f9c-cd33cd460fef"));
            ResponsibleResource = (ITTObjectListBox)AddControl(new Guid("090d6370-7733-470f-80ad-cff61dde3946"));
            labelRequestNO = (ITTLabel)AddControl(new Guid("1aa9ba16-c724-4b66-a3d9-d96648a6db06"));
            FixedAsset = (ITTObjectListBox)AddControl(new Guid("16536444-75a5-4384-b726-c73029ecc65b"));
            labelToResource = (ITTLabel)AddControl(new Guid("131717f5-b842-40b5-a62c-a60556b1f15e"));
            labelDescription = (ITTLabel)AddControl(new Guid("ae58fb8e-4cb1-4781-b89b-165894705a76"));
            Description = (ITTTextBox)AddControl(new Guid("aad43f70-c2db-402c-8f5a-d131919789f3"));
            ToResource = (ITTObjectListBox)AddControl(new Guid("7e4c9e1e-2223-4f31-b657-185f537cc1f7"));
            RequestNO = (ITTTextBox)AddControl(new Guid("50157046-f514-4907-96f0-a93698b6b5ab"));
            FromResource = (ITTObjectListBox)AddControl(new Guid("37284d84-b9a8-4a2d-8c69-64ab33d07dc2"));
            labelFixedAsset = (ITTLabel)AddControl(new Guid("179e3c84-ba3d-425a-b0f4-10ce2bd4d6f0"));
            labelResponsibleResource = (ITTLabel)AddControl(new Guid("97452b67-fb92-481f-a1ed-3c5ebe67f32b"));
            labelFromResource = (ITTLabel)AddControl(new Guid("2b0af380-afd2-4262-81f0-a2f75df88d24"));
            Stage = (ITTObjectListBox)AddControl(new Guid("93fc3f01-cee1-4d87-94eb-71c035e5cb2d"));
            base.InitializeControls();
        }

        public ApprovalForm_Maintenance() : base("MAINTENANCE", "ApprovalForm_Maintenance")
        {
        }

        protected ApprovalForm_Maintenance(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}