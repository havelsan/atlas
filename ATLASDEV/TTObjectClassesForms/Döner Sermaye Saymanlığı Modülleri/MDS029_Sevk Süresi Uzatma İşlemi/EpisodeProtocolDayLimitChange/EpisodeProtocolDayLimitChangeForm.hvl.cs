
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
    /// Sevk Süresi Uzatma
    /// </summary>
    public partial class EpisodeProtocolDayLimitChangeForm : TTForm
    {
    /// <summary>
    /// Sevk Süresi Uzatma
    /// </summary>
        protected TTObjectClasses.EpisodeProtocolDayLimitChange _EpisodeProtocolDayLimitChange
        {
            get { return (TTObjectClasses.EpisodeProtocolDayLimitChange)_ttObject; }
        }

        protected ITTLabel ttlabel1;
        protected ITTGrid GridEpisodeProtocolDayLimits;
        protected ITTTextBoxColumn PAYERNAME;
        protected ITTTextBoxColumn PROTOCOLNAME;
        protected ITTTextBoxColumn PROTOCOLSTATUS;
        protected ITTTextBoxColumn DAYLIMIT;
        protected ITTDateTimePickerColumn POSTPONEDATE;
        protected ITTTextBoxColumn REASONOFCHANGE;
        protected ITTTextBoxColumn EPOBJECTID;
        override protected void InitializeControls()
        {
            ttlabel1 = (ITTLabel)AddControl(new Guid("b5e01ec1-242b-498f-9ca5-76ca38f908f2"));
            GridEpisodeProtocolDayLimits = (ITTGrid)AddControl(new Guid("5a39da05-f002-4210-88b6-0d28c0a6634b"));
            PAYERNAME = (ITTTextBoxColumn)AddControl(new Guid("ea8e757f-d58b-42a2-92b2-dbd9c28ecf67"));
            PROTOCOLNAME = (ITTTextBoxColumn)AddControl(new Guid("59a31390-2f88-4d6f-a7db-45357e79d9c5"));
            PROTOCOLSTATUS = (ITTTextBoxColumn)AddControl(new Guid("7b2cc16c-d7e5-4f14-8c02-262934644ba5"));
            DAYLIMIT = (ITTTextBoxColumn)AddControl(new Guid("50b59d7b-3947-4ecc-a3c1-d57e83a25c13"));
            POSTPONEDATE = (ITTDateTimePickerColumn)AddControl(new Guid("949b0c25-cb7a-46f3-b6e2-bf9f1115cd44"));
            REASONOFCHANGE = (ITTTextBoxColumn)AddControl(new Guid("51f7e589-bb51-4a83-b233-4bca1efdb8b7"));
            EPOBJECTID = (ITTTextBoxColumn)AddControl(new Guid("08bcf913-cd5a-41ab-aa06-f2474c4a826d"));
            base.InitializeControls();
        }

        public EpisodeProtocolDayLimitChangeForm() : base("EPISODEPROTOCOLDAYLIMITCHANGE", "EpisodeProtocolDayLimitChangeForm")
        {
        }

        protected EpisodeProtocolDayLimitChangeForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}