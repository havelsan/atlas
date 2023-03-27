
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
    /// Anlaşmalar Arası Aktarma
    /// </summary>
    public partial class ProtocolTransferForm : TTForm
    {
    /// <summary>
    /// Anlaşmalar Arası Aktarma
    /// </summary>
        protected TTObjectClasses.ProtocolTransfer _ProtocolTransfer
        {
            get { return (TTObjectClasses.ProtocolTransfer)_ttObject; }
        }

        protected ITTLabel ttlabel4;
        protected ITTDateTimePicker StartDate;
        protected ITTLabel EpisodeProtocols;
        protected ITTLabel GridSubActions;
        protected ITTGrid GridProtocolSubActions;
        protected ITTDateTimePickerColumn TRXDATE;
        protected ITTTextBoxColumn EXTERNALCODE;
        protected ITTTextBoxColumn DESC;
        protected ITTTextBoxColumn STATUS;
        protected ITTCheckBoxColumn ISPACKAGEPROCEDURE;
        protected ITTTextBoxColumn PACKAGEINFO;
        protected ITTCheckBoxColumn TRANSFER;
        protected ITTTextBoxColumn SUBACTIONID;
        protected ITTGrid GridEpisodeProtocols;
        protected ITTTextBoxColumn PAYERNAME;
        protected ITTTextBoxColumn PROTOCOLNAME;
        protected ITTDateTimePickerColumn OPENINGDATE;
        protected ITTTextBoxColumn PROTOCOLSTATUS;
        protected ITTButtonColumn LISTSUBACTION;
        protected ITTTextBoxColumn EPOBJECTID;
        protected ITTObjectListBox TARGETEPISODE;
        protected ITTLabel ttlabel2;
        protected ITTObjectListBox TARGETEPISODEPROTOCOL;
        protected ITTLabel ttlabel3;
        protected ITTButton UnSelectAllButton;
        protected ITTButton SelectAllButton;
        protected ITTObjectListBox TARGETSUBEPISODE;
        protected ITTLabel ttlabel1;
        protected ITTDateTimePicker EndDate;
        protected ITTButton ApplyButton;
        protected ITTLabel ttlabel5;
        override protected void InitializeControls()
        {
            ttlabel4 = (ITTLabel)AddControl(new Guid("28d8bce3-8a97-4966-93bb-ffc6d2df08fb"));
            StartDate = (ITTDateTimePicker)AddControl(new Guid("1338e028-2c32-41cf-8cd7-d694d139e804"));
            EpisodeProtocols = (ITTLabel)AddControl(new Guid("6aba9bfc-d20e-4e2c-84d8-9a56d8fbf37f"));
            GridSubActions = (ITTLabel)AddControl(new Guid("5c217704-f8c4-4f1f-b11b-a1fc5e0f41de"));
            GridProtocolSubActions = (ITTGrid)AddControl(new Guid("85ba381a-be3f-47cd-aef1-b6f3502ad960"));
            TRXDATE = (ITTDateTimePickerColumn)AddControl(new Guid("6cc0a486-1e4d-4512-bee7-84dbb7012c08"));
            EXTERNALCODE = (ITTTextBoxColumn)AddControl(new Guid("c896267e-4d08-4623-9fc6-68a893f7e806"));
            DESC = (ITTTextBoxColumn)AddControl(new Guid("be4cf6d6-de89-4c44-abc4-d3b607c151e8"));
            STATUS = (ITTTextBoxColumn)AddControl(new Guid("105bbc66-12a9-464a-8ccb-ddeaf3cad48a"));
            ISPACKAGEPROCEDURE = (ITTCheckBoxColumn)AddControl(new Guid("e0981d70-536f-4d4f-bdbb-ca605ec87fb2"));
            PACKAGEINFO = (ITTTextBoxColumn)AddControl(new Guid("17341a80-038f-42d5-ad7c-0c6e2e6cb09b"));
            TRANSFER = (ITTCheckBoxColumn)AddControl(new Guid("f51d3720-76e3-40fb-8b3a-ee8511b4a3a8"));
            SUBACTIONID = (ITTTextBoxColumn)AddControl(new Guid("663f9ffa-1762-4dd8-b186-a054fe1ffa7f"));
            GridEpisodeProtocols = (ITTGrid)AddControl(new Guid("e64d0e4d-b9eb-4605-b8c1-c437b47b45b4"));
            PAYERNAME = (ITTTextBoxColumn)AddControl(new Guid("9ae3e53d-ae3d-411c-b5b4-2ac54ff189c7"));
            PROTOCOLNAME = (ITTTextBoxColumn)AddControl(new Guid("9b7b0cf8-2ab4-4137-9a51-81b8a791fda9"));
            OPENINGDATE = (ITTDateTimePickerColumn)AddControl(new Guid("99ad971c-52be-41a6-a8da-0d011aec93df"));
            PROTOCOLSTATUS = (ITTTextBoxColumn)AddControl(new Guid("73a10440-bf0a-4906-a647-7cb5e11b3244"));
            LISTSUBACTION = (ITTButtonColumn)AddControl(new Guid("dcf0e3a8-497b-4bbc-842e-fd85a8d2515e"));
            EPOBJECTID = (ITTTextBoxColumn)AddControl(new Guid("7a206462-f976-4464-8c3f-227a6d5df6ca"));
            TARGETEPISODE = (ITTObjectListBox)AddControl(new Guid("c3a27918-2ee5-412f-b2f4-48503774dd24"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("9f39b465-bdfb-4d48-917d-8d873fd04846"));
            TARGETEPISODEPROTOCOL = (ITTObjectListBox)AddControl(new Guid("b8d3eb41-fea5-472b-82de-c4e922f3dc23"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("253a9c11-ae92-4a0a-a84e-c055a9b28997"));
            UnSelectAllButton = (ITTButton)AddControl(new Guid("52c1f427-f661-43cf-9e48-0ca4772e8ce8"));
            SelectAllButton = (ITTButton)AddControl(new Guid("c670013f-8b60-4501-b4ba-bc5c55d757e4"));
            TARGETSUBEPISODE = (ITTObjectListBox)AddControl(new Guid("ce93b810-5903-466b-bb67-d3e5bdc5bc80"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("682a7a92-3e5d-4723-b9b3-eb8f3f507415"));
            EndDate = (ITTDateTimePicker)AddControl(new Guid("5dd712c6-22be-434f-9a35-f53c80f2cfb9"));
            ApplyButton = (ITTButton)AddControl(new Guid("dee007df-f05b-4327-befc-435cb5bbdbf6"));
            ttlabel5 = (ITTLabel)AddControl(new Guid("0a86f52d-0580-4afd-a2d4-e4236f3bd9b7"));
            base.InitializeControls();
        }

        public ProtocolTransferForm() : base("PROTOCOLTRANSFER", "ProtocolTransferForm")
        {
        }

        protected ProtocolTransferForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}