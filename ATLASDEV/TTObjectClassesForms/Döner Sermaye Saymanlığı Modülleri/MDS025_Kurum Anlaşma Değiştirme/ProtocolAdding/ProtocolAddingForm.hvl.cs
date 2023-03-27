
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
    /// Hasta Kurum Bilgisi Değiştirme
    /// </summary>
    public partial class ProtocolAddingForm : TTForm
    {
    /// <summary>
    /// Hasta Kurum Bilgisi Değiştirme
    /// </summary>
        protected TTObjectClasses.ProtocolAdding _ProtocolAdding
        {
            get { return (TTObjectClasses.ProtocolAdding)_ttObject; }
        }

        protected ITTLabel lblSE;
        protected ITTGrid ttgrid1;
        protected ITTListBoxColumn SubEpisode;
        protected ITTCheckBoxColumn ADD;
        protected ITTLabel ttlabel3;
        protected ITTObjectListBox NEWPROTOCOL;
        protected ITTGrid GridEpisodeProtocols;
        protected ITTTextBoxColumn SEPOBJECTID;
        protected ITTTextBoxColumn SUBEPISODENAME;
        protected ITTTextBoxColumn PAYERNAME;
        protected ITTTextBoxColumn PROTOCOLNAME;
        protected ITTEnumComboBoxColumn INVOICESTATUS;
        protected ITTTextBoxColumn PROTOCOLSTATUS;
        protected ITTLabel ttlabel2;
        protected ITTObjectListBox NEWPAYER;
        protected ITTLabel ttlabel1;
        override protected void InitializeControls()
        {
            lblSE = (ITTLabel)AddControl(new Guid("f26ffaa1-1040-40c2-953a-65fda488f5d2"));
            ttgrid1 = (ITTGrid)AddControl(new Guid("ff14c300-f81c-4dc1-986f-4db0a151150c"));
            SubEpisode = (ITTListBoxColumn)AddControl(new Guid("fe9d2371-e90f-461f-b9f0-7961af9de508"));
            ADD = (ITTCheckBoxColumn)AddControl(new Guid("d503dea5-197e-4d99-b1b8-6efc8861a105"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("ce16ec68-9876-4e47-a883-0d7e0ab0fec9"));
            NEWPROTOCOL = (ITTObjectListBox)AddControl(new Guid("889eed9d-d477-41d9-8764-1314bcbac15e"));
            GridEpisodeProtocols = (ITTGrid)AddControl(new Guid("822933ac-6f95-4e71-b7ca-1e52182efac1"));
            SEPOBJECTID = (ITTTextBoxColumn)AddControl(new Guid("c8b85483-30b2-4ffd-ba1c-b861e2a3708e"));
            SUBEPISODENAME = (ITTTextBoxColumn)AddControl(new Guid("6939640e-d649-4e1b-8aee-67cf6ca706a7"));
            PAYERNAME = (ITTTextBoxColumn)AddControl(new Guid("c72caa2e-1b0a-4a19-99a3-944429880ecf"));
            PROTOCOLNAME = (ITTTextBoxColumn)AddControl(new Guid("ba307dde-330c-4b9f-8c1c-bbd59d165f8a"));
            INVOICESTATUS = (ITTEnumComboBoxColumn)AddControl(new Guid("a2134347-8467-492d-a9e5-c6f06697ee03"));
            PROTOCOLSTATUS = (ITTTextBoxColumn)AddControl(new Guid("8679a8ce-7d76-408c-8c34-827e3f1cab71"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("0ea54a1d-f0d7-4b15-aeaf-61a2b76d25ea"));
            NEWPAYER = (ITTObjectListBox)AddControl(new Guid("2bf045ba-6389-4d21-95a2-a6fd0daba076"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("9c6d8cc6-53ff-4f99-8a69-f4268d242591"));
            base.InitializeControls();
        }

        public ProtocolAddingForm() : base("PROTOCOLADDING", "ProtocolAddingForm")
        {
        }

        protected ProtocolAddingForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}