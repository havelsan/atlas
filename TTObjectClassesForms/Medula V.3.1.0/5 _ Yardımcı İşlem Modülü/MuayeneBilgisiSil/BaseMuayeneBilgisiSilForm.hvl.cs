
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
    public partial class BaseMuayeneBilgisiSilForm : BaseMedulaActionForm
    {
        protected TTObjectClasses.MuayeneBilgisiSil _MuayeneBilgisiSil
        {
            get { return (TTObjectClasses.MuayeneBilgisiSil)_ttObject; }
        }

        protected ITTLabel labelmuayeneGiris;
        protected ITTObjectListBox muayeneGiris;
        protected ITTLabel labelreferansNoMuayeneSilGirisDVO;
        protected ITTTextBox referansNoMuayeneSilGirisDVO;
        protected ITTValueListBox saglikTesisKodu;
        protected ITTLabel labelsaglikTesisKodu;
        override protected void InitializeControls()
        {
            labelmuayeneGiris = (ITTLabel)AddControl(new Guid("d6fda4d4-e1f5-4bb0-a0f5-1dfbe1d496cb"));
            muayeneGiris = (ITTObjectListBox)AddControl(new Guid("051545c7-31f5-4da7-81ee-774d33e8da94"));
            labelreferansNoMuayeneSilGirisDVO = (ITTLabel)AddControl(new Guid("65999397-bc50-484a-8ab5-08dc64beccfd"));
            referansNoMuayeneSilGirisDVO = (ITTTextBox)AddControl(new Guid("c2a65433-3ccb-46d1-9f7d-6ea981b95a11"));
            saglikTesisKodu = (ITTValueListBox)AddControl(new Guid("90435b45-41b2-4cf9-b395-02ed6b3ff2f8"));
            labelsaglikTesisKodu = (ITTLabel)AddControl(new Guid("fa9bd534-c077-4e56-816c-1e54c2578cb8"));
            base.InitializeControls();
        }

        public BaseMuayeneBilgisiSilForm() : base("MUAYENEBILGISISIL", "BaseMuayeneBilgisiSilForm")
        {
        }

        protected BaseMuayeneBilgisiSilForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}