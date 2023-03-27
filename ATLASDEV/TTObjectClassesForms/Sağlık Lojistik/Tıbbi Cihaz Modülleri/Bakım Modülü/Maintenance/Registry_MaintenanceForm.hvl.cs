
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
    /// Bakım İstek
    /// </summary>
    public partial class Registry_Maintenance : MaintenanceBaseForm
    {
    /// <summary>
    /// Bakım
    /// </summary>
        protected TTObjectClasses.Maintenance _Maintenance
        {
            get { return (TTObjectClasses.Maintenance)_ttObject; }
        }

        protected ITTObjectListBox Stage;
        protected ITTLabel labelRequestNO;
        protected ITTObjectListBox FixedAsset;
        protected ITTLabel labelDescription;
        protected ITTTextBox Description;
        protected ITTTextBox RequestNO;
        protected ITTObjectListBox FromResource;
        protected ITTLabel labelFixedAsset;
        protected ITTLabel labelFromResource;
        override protected void InitializeControls()
        {
            Stage = (ITTObjectListBox)AddControl(new Guid("39a825f1-e708-4d16-914a-ca18418f594e"));
            labelRequestNO = (ITTLabel)AddControl(new Guid("717f019a-21af-457d-99c8-17a71814442e"));
            FixedAsset = (ITTObjectListBox)AddControl(new Guid("7636ba26-57ad-4905-974e-30f5dbb82326"));
            labelDescription = (ITTLabel)AddControl(new Guid("f68f5b4a-6a5d-495b-9d78-8e7ec2e4bf90"));
            Description = (ITTTextBox)AddControl(new Guid("d3806f2c-9a51-4a31-8f0f-92f596cb8ef5"));
            RequestNO = (ITTTextBox)AddControl(new Guid("033b0b7a-5dfb-4888-87c9-befca052d867"));
            FromResource = (ITTObjectListBox)AddControl(new Guid("3e05c747-ca05-4405-92ec-d77a68ee0b8b"));
            labelFixedAsset = (ITTLabel)AddControl(new Guid("ce1b9c18-f129-4951-8951-dd044f7e72ef"));
            labelFromResource = (ITTLabel)AddControl(new Guid("48db3b18-12a9-4754-be59-e393eb72f004"));
            base.InitializeControls();
        }

        public Registry_Maintenance() : base("MAINTENANCE", "Registry_Maintenance")
        {
        }

        protected Registry_Maintenance(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}