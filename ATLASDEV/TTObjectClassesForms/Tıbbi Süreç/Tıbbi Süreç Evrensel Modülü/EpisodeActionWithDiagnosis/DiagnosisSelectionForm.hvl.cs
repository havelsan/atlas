
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
    public partial class DiagnosisSelectionForm : TTForm
    {
        protected TTObjectClasses.EpisodeActionWithDiagnosis _EpisodeActionWithDiagnosis
        {
            get { return (TTObjectClasses.EpisodeActionWithDiagnosis)_ttObject; }
        }

        protected ITTGrid GridFavoriteDiagnosis;
        protected ITTButtonColumn SelectFavorite;
        protected ITTListBoxColumn ttlistboxcolumn1;
        protected ITTGrid GridTop10DiagnosisOfUser;
        protected ITTButtonColumn SelectTo10OfUser;
        protected ITTListBoxColumn ttlistboxcolumn2;
        protected ITTGrid GridLast10DiagnosisOfPatientBySpeciality;
        protected ITTButtonColumn Selectlast10OfPatient;
        protected ITTListBoxColumn Last10OfPatient;
        protected ITTTextBoxColumn tttextboxcolumn3;
        override protected void InitializeControls()
        {
            GridFavoriteDiagnosis = (ITTGrid)AddControl(new Guid("9afec4d3-2fcf-4a63-aa57-85228bed6ed0"));
            SelectFavorite = (ITTButtonColumn)AddControl(new Guid("58eb84c4-43e0-43ec-b854-19696ba2b802"));
            ttlistboxcolumn1 = (ITTListBoxColumn)AddControl(new Guid("4dba5bdf-63cb-41a0-af03-1ac6a820bbbb"));
            GridTop10DiagnosisOfUser = (ITTGrid)AddControl(new Guid("2980cf6f-6925-4ab4-a710-dce6ad28eaad"));
            SelectTo10OfUser = (ITTButtonColumn)AddControl(new Guid("662c6ba3-fb10-4a5e-a370-b87c856f8d1b"));
            ttlistboxcolumn2 = (ITTListBoxColumn)AddControl(new Guid("27b074bc-1b56-46f8-8249-e4fd354c5a4f"));
            GridLast10DiagnosisOfPatientBySpeciality = (ITTGrid)AddControl(new Guid("2e48f94f-9d3a-4c53-bc09-388b92754861"));
            Selectlast10OfPatient = (ITTButtonColumn)AddControl(new Guid("93153e6c-e3f7-4e71-960b-b43fe6f57d74"));
            Last10OfPatient = (ITTListBoxColumn)AddControl(new Guid("7343caff-83cb-4dd8-b904-6a0097bda06c"));
            tttextboxcolumn3 = (ITTTextBoxColumn)AddControl(new Guid("a109bdf2-29e6-435b-9500-7676e03ab9ac"));
            base.InitializeControls();
        }

        public DiagnosisSelectionForm() : base("EPISODEACTIONWITHDIAGNOSIS", "DiagnosisSelectionForm")
        {
        }

        protected DiagnosisSelectionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}