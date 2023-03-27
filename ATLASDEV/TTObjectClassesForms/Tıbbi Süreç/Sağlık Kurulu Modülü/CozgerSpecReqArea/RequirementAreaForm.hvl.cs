
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
    public partial class RequirementAreaForm : TTDefinitionForm
    {
    /// <summary>
    /// Çözger Special Requirement Area (Özel Gereksinim Alanı)
    /// </summary>
        protected TTObjectClasses.CozgerSpecReqArea _CozgerSpecReqArea
        {
            get { return (TTObjectClasses.CozgerSpecReqArea)_ttObject; }
        }

        protected ITTLabel labelAciklama;
        protected ITTTextBox Aciklama;
        protected ITTTextBox Id;
        protected ITTLabel labelId;
        override protected void InitializeControls()
        {
            labelAciklama = (ITTLabel)AddControl(new Guid("12e6d1db-ec40-495f-8195-c4927f379dfc"));
            Aciklama = (ITTTextBox)AddControl(new Guid("cfbbc3a8-aaca-418c-9417-4066cb03de6f"));
            Id = (ITTTextBox)AddControl(new Guid("2d23b423-545d-4faa-ad00-21df7d3d6494"));
            labelId = (ITTLabel)AddControl(new Guid("4adda56d-f688-4d87-a572-436783146849"));
            base.InitializeControls();
        }

        public RequirementAreaForm() : base("COZGERSPECREQAREA", "RequirementAreaForm")
        {
        }

        protected RequirementAreaForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}