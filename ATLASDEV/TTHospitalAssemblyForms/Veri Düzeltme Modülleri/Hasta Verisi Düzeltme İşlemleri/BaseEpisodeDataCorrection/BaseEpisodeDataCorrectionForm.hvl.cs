
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
    public partial class BaseEpisodeDataCorrectionForm : BasePatientDataCorrectionForm
    {
        protected TTObjectClasses.BaseEpisodeDataCorrection _BaseEpisodeDataCorrection
        {
            get { return (TTObjectClasses.BaseEpisodeDataCorrection)_ttObject; }
        }

        protected ITTLabel labelEpisode;
        protected ITTObjectListBox Episode;
        override protected void InitializeControls()
        {
            labelEpisode = (ITTLabel)AddControl(new Guid("44b70e20-0c12-4a32-bd14-d9d6175f1ac0"));
            Episode = (ITTObjectListBox)AddControl(new Guid("41e952a2-bd5e-4c9b-8d57-a83ee2215482"));
            base.InitializeControls();
        }

        public BaseEpisodeDataCorrectionForm() : base("BASEEPISODEDATACORRECTION", "BaseEpisodeDataCorrectionForm")
        {
        }

        protected BaseEpisodeDataCorrectionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}