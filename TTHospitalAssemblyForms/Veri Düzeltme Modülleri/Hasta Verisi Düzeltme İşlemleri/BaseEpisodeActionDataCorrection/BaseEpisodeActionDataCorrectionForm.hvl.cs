
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
    public partial class BaseEpisodeActionDataCorrectionForm : BaseEpisodeDataCorrectionForm
    {
        protected TTObjectClasses.BaseEpisodeActionDataCorrection _BaseEpisodeActionDataCorrection
        {
            get { return (TTObjectClasses.BaseEpisodeActionDataCorrection)_ttObject; }
        }

        protected ITTButton ShowEpisodeActionButton;
        protected ITTLabel labelEpisodeAction;
        protected ITTObjectListBox EpisodeAction;
        override protected void InitializeControls()
        {
            ShowEpisodeActionButton = (ITTButton)AddControl(new Guid("2779c12e-f565-4cef-90cd-af3bfeed32d7"));
            labelEpisodeAction = (ITTLabel)AddControl(new Guid("3625446d-77c7-4a18-9a05-829e9e0c9ae6"));
            EpisodeAction = (ITTObjectListBox)AddControl(new Guid("4bbf7a2e-c6b7-45e9-b904-9904ad2019ee"));
            base.InitializeControls();
        }

        public BaseEpisodeActionDataCorrectionForm() : base("BASEEPISODEACTIONDATACORRECTION", "BaseEpisodeActionDataCorrectionForm")
        {
        }

        protected BaseEpisodeActionDataCorrectionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}