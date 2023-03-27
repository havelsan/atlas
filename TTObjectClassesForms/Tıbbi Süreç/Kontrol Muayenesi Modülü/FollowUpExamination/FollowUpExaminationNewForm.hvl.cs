
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
    /// Kontrol Muayenesi
    /// </summary>
    public partial class FollowUpExaminationNewForm : EpisodeActionForm
    {
    /// <summary>
    /// Hasta Kontrol Muayenesi İşlemlerinin Gerçekleştirildiği Temel Nesnedir
    /// </summary>
        protected TTObjectClasses.FollowUpExamination _FollowUpExamination
        {
            get { return (TTObjectClasses.FollowUpExamination)_ttObject; }
        }

        protected ITTLabel LabelProtocolNo;
        protected ITTTextBox ProtocolNo;
        protected ITTDateTimePicker RequestDate;
        protected ITTLabel LabelDateTime;
        protected ITTObjectListBox Doktor;
        protected ITTLabel ttlabel1;
        protected ITTLabel labelMasterResource;
        protected ITTObjectListBox MasterResource;
        override protected void InitializeControls()
        {
            LabelProtocolNo = (ITTLabel)AddControl(new Guid("778f1c61-121b-4208-9259-01c50489c318"));
            ProtocolNo = (ITTTextBox)AddControl(new Guid("8b2ae73a-ce2f-4c3d-947f-177f3477cdf5"));
            RequestDate = (ITTDateTimePicker)AddControl(new Guid("c7ca1cc6-2471-4c23-b4a7-95d12c3c366c"));
            LabelDateTime = (ITTLabel)AddControl(new Guid("377667d3-1652-489f-b78c-fb986598d334"));
            Doktor = (ITTObjectListBox)AddControl(new Guid("fbab20a6-fb1d-4fb8-8b63-b69c6a21d748"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("58a77dd5-d83d-4253-a23b-45cecd679961"));
            labelMasterResource = (ITTLabel)AddControl(new Guid("bce7a9d5-efdd-48a0-81f0-c55ed23bbfee"));
            MasterResource = (ITTObjectListBox)AddControl(new Guid("ca9e4849-9f69-4612-b7a8-c6b748605b2e"));
            base.InitializeControls();
        }

        public FollowUpExaminationNewForm() : base("FOLLOWUPEXAMINATION", "FollowUpExaminationNewForm")
        {
        }

        protected FollowUpExaminationNewForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}