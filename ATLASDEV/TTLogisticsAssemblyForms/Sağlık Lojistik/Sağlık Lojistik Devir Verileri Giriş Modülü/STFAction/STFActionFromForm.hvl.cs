
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
    /// Sayim Tarti Cizelgesi
    /// </summary>
    public partial class STFActionFrom : TTForm
    {
    /// <summary>
    /// Sayım Tartı Verilerinin Girilmesi 
    /// </summary>
        protected TTObjectClasses.STFAction _STFAction
        {
            get { return (TTObjectClasses.STFAction)_ttObject; }
        }

        protected ITTGrid STCActions;
        protected ITTTextBoxColumn SiraNuSTCAction;
        protected ITTListBoxColumn MaterialSTCAction;
        protected ITTListBoxColumn DistributType;
        protected ITTTextBoxColumn YeniMevcutSTCAction;
        protected ITTTextBoxColumn KullanilmisMevcutSTCAction;
        protected ITTTextBoxColumn HEKMevcutSTCAction;
        protected ITTTextBoxColumn MuvakkatenVerilenSTCAction;
        protected ITTDateTimePickerColumn SKTarihi;
        protected ITTTextBoxColumn ToplamSTCAction;
        protected ITTTextBoxColumn ToplamTutarSTCAction;
        protected ITTListBoxColumn ResCardDrawerSTCAction;
        protected ITTListBoxColumn MainStoreSTCAction;
        protected ITTLabel labelID;
        protected ITTTextBox ID;
        protected ITTLabel labelActionDate;
        protected ITTDateTimePicker ActionDate;
        override protected void InitializeControls()
        {
            STCActions = (ITTGrid)AddControl(new Guid("20c5ea99-f2ae-4298-b4ac-c9bd8d45e094"));
            SiraNuSTCAction = (ITTTextBoxColumn)AddControl(new Guid("a33c5ca4-b968-4cac-8c30-cad075eac21d"));
            MaterialSTCAction = (ITTListBoxColumn)AddControl(new Guid("ac29e200-d381-4468-bafa-f6d0d9312128"));
            DistributType = (ITTListBoxColumn)AddControl(new Guid("0237e270-8d15-4ea3-8bf7-ffea21ae2eb5"));
            YeniMevcutSTCAction = (ITTTextBoxColumn)AddControl(new Guid("238e40df-3d91-417f-9299-6fbf27e0237b"));
            KullanilmisMevcutSTCAction = (ITTTextBoxColumn)AddControl(new Guid("3f9fc677-8ada-425b-be54-45796dd76abd"));
            HEKMevcutSTCAction = (ITTTextBoxColumn)AddControl(new Guid("e31c3e65-c530-4c2b-8b12-4b11a0dc5dfa"));
            MuvakkatenVerilenSTCAction = (ITTTextBoxColumn)AddControl(new Guid("dd249b78-7264-4bf6-bbf3-931e3f171431"));
            SKTarihi = (ITTDateTimePickerColumn)AddControl(new Guid("6ca2e5c8-5b10-41e1-b4fb-3afe4b26fc2c"));
            ToplamSTCAction = (ITTTextBoxColumn)AddControl(new Guid("d0c34f6a-dde3-43e8-8732-968441a17391"));
            ToplamTutarSTCAction = (ITTTextBoxColumn)AddControl(new Guid("d5b95bbb-eb65-45b7-9ebc-7fa9ec26d5e3"));
            ResCardDrawerSTCAction = (ITTListBoxColumn)AddControl(new Guid("03ed8835-5fb0-462f-8856-4ffc56f77c4e"));
            MainStoreSTCAction = (ITTListBoxColumn)AddControl(new Guid("1772efe2-e5c8-4965-b042-d56d11b3e61f"));
            labelID = (ITTLabel)AddControl(new Guid("dd56bfa0-ef72-4ce5-a93f-05b53a7810e9"));
            ID = (ITTTextBox)AddControl(new Guid("d565784a-9cf3-4703-843e-18d7b2544e31"));
            labelActionDate = (ITTLabel)AddControl(new Guid("f99b909c-3f22-43af-a7f0-4201ca5adae9"));
            ActionDate = (ITTDateTimePicker)AddControl(new Guid("9e797057-a9cb-491c-84ee-76f5e342166a"));
            base.InitializeControls();
        }

        public STFActionFrom() : base("STFACTION", "STFActionFrom")
        {
        }

        protected STFActionFrom(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}