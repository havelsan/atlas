
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
    /// TITUBB Malzeme Eşleştirememe Nedenleri
    /// </summary>
    public partial class MatchReasonDefinitionForm : TerminologyManagerDefForm
    {
    /// <summary>
    /// TITUBB Malzeme Eşleştirememe Nedenleri
    /// </summary>
        protected TTObjectClasses.MatchReasonDefinition _MatchReasonDefinition
        {
            get { return (TTObjectClasses.MatchReasonDefinition)_ttObject; }
        }

        protected ITTCheckBox WithBarcode;
        protected ITTLabel labelReason;
        protected ITTTextBox Reason;
        override protected void InitializeControls()
        {
            WithBarcode = (ITTCheckBox)AddControl(new Guid("6c7323fc-5876-43e4-abc1-d64e46aa55b5"));
            labelReason = (ITTLabel)AddControl(new Guid("00da062d-fa14-496a-8316-b52d720b83d8"));
            Reason = (ITTTextBox)AddControl(new Guid("5c7943ae-4844-4f7d-a778-4e8b49a4ef7c"));
            base.InitializeControls();
        }

        public MatchReasonDefinitionForm() : base("MATCHREASONDEFINITION", "MatchReasonDefinitionForm")
        {
        }

        protected MatchReasonDefinitionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}