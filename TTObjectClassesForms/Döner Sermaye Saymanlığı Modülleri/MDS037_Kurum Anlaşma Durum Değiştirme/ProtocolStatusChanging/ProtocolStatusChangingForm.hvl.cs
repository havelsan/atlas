
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
    /// Kurum Anlaşma Durum Değiştirme
    /// </summary>
    public partial class ProtocolStatusChangingForm : TTForm
    {
    /// <summary>
    /// Kurum Anlaşma Durum Değiştirme
    /// </summary>
        protected TTObjectClasses.ProtocolStatusChanging _ProtocolStatusChanging
        {
            get { return (TTObjectClasses.ProtocolStatusChanging)_ttObject; }
        }

        protected ITTGrid GridEpisodeProtocols;
        protected ITTListBoxColumn SubEpisode;
        protected ITTTextBoxColumn PAYER;
        protected ITTTextBoxColumn PROTOCOL;
        protected ITTDateTimePickerColumn CREATIONDATE;
        protected ITTEnumComboBoxColumn INVOICESTATUS;
        protected ITTEnumComboBoxColumn PROTOCOLSTATUS;
        protected ITTLabel ttlabel1;
        override protected void InitializeControls()
        {
            GridEpisodeProtocols = (ITTGrid)AddControl(new Guid("5478117b-4b96-4d1d-a088-f5d6a35837ca"));
            SubEpisode = (ITTListBoxColumn)AddControl(new Guid("9030b62e-eae7-4c52-8c0b-c29affce17c4"));
            PAYER = (ITTTextBoxColumn)AddControl(new Guid("e1eefa61-8667-416d-be19-a5576f0f108b"));
            PROTOCOL = (ITTTextBoxColumn)AddControl(new Guid("9063c4a5-5f2a-4f2f-93c4-9391dfa2c71d"));
            CREATIONDATE = (ITTDateTimePickerColumn)AddControl(new Guid("31a9615a-b5fe-4574-a6e3-8fd56e92d539"));
            INVOICESTATUS = (ITTEnumComboBoxColumn)AddControl(new Guid("693ba665-462b-4d53-8d8e-750d17e51980"));
            PROTOCOLSTATUS = (ITTEnumComboBoxColumn)AddControl(new Guid("f92ee423-4dba-4592-b8e7-fdbe1728ab5a"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("4db9737d-66a6-40d2-ae1c-6ae397278b5c"));
            base.InitializeControls();
        }

        public ProtocolStatusChangingForm() : base("PROTOCOLSTATUSCHANGING", "ProtocolStatusChangingForm")
        {
        }

        protected ProtocolStatusChangingForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}