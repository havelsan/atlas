
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
    /// Medula Taburcu Tipi Eşleştirme
    /// </summary>
    public partial class MedulaDischargeTypeDefForm : BaseMedulaDefinitionForm
    {
    /// <summary>
    /// Medula Taburcu Tipi Eşleştirme
    /// </summary>
        protected TTObjectClasses.MedulaDischargeTypeDefinition _MedulaDischargeTypeDefinition
        {
            get { return (TTObjectClasses.MedulaDischargeTypeDefinition)_ttObject; }
        }

        protected ITTLabel labelSKRSCikisSekli;
        protected ITTObjectListBox SKRSCikisSekli;
        protected ITTLabel ttlabel2;
        protected ITTEnumComboBox XXXXXXDischargeName;
        protected ITTLabel MedulaDischargeName;
        protected ITTObjectListBox TTListBox;
        override protected void InitializeControls()
        {
            labelSKRSCikisSekli = (ITTLabel)AddControl(new Guid("ba567e9d-e53d-47fc-b964-bc30a4846350"));
            SKRSCikisSekli = (ITTObjectListBox)AddControl(new Guid("08d00b18-1432-4820-979b-7f0cdedcd35b"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("2040c8d7-bce3-497d-ad13-412657e47d78"));
            XXXXXXDischargeName = (ITTEnumComboBox)AddControl(new Guid("f7ef8455-8aa3-45fe-a2ae-e9dfe23182df"));
            MedulaDischargeName = (ITTLabel)AddControl(new Guid("b394c60b-e039-438f-bb60-047cefae1a6f"));
            TTListBox = (ITTObjectListBox)AddControl(new Guid("869532ac-b0fe-45c9-9b12-f130e143a5d9"));
            base.InitializeControls();
        }

        public MedulaDischargeTypeDefForm() : base("MEDULADISCHARGETYPEDEFINITION", "MedulaDischargeTypeDefForm")
        {
        }

        protected MedulaDischargeTypeDefForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}