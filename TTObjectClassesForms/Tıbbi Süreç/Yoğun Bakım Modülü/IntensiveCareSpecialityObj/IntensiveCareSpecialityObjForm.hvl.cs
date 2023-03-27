
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
    public partial class IntensiveCareSpecialityObjForm : SpecialityBasedObjectForm
    {
        protected TTObjectClasses.IntensiveCareSpecialityObj _IntensiveCareSpecialityObj
        {
            get { return (TTObjectClasses.IntensiveCareSpecialityObj)_ttObject; }
        }

        protected ITTLabel labelSepticShock;
        protected ITTObjectListBox SepticShock;
        protected ITTLabel labelSepsisStatus;
        protected ITTObjectListBox SepsisStatus;
        protected ITTLabel labelIntensiveCareStep;
        protected ITTEnumComboBox IntensiveCareStep;
        override protected void InitializeControls()
        {
            labelSepticShock = (ITTLabel)AddControl(new Guid("3c7b82d8-ac03-49f2-b415-1ae008fe61b9"));
            SepticShock = (ITTObjectListBox)AddControl(new Guid("8f3a1fc3-41be-4b95-862a-df178d44ebbc"));
            labelSepsisStatus = (ITTLabel)AddControl(new Guid("c1e5580e-f2ab-41df-a6ff-2d38014f8922"));
            SepsisStatus = (ITTObjectListBox)AddControl(new Guid("36971e11-cddf-42ea-a0c2-963ce93b15f5"));
            labelIntensiveCareStep = (ITTLabel)AddControl(new Guid("bf16dad7-8316-445b-857a-a7b960483a91"));
            IntensiveCareStep = (ITTEnumComboBox)AddControl(new Guid("83cf2613-c41a-46b4-9c34-9231fb9adbbb"));
            base.InitializeControls();
        }

        public IntensiveCareSpecialityObjForm() : base("INTENSIVECARESPECIALITYOBJ", "IntensiveCareSpecialityObjForm")
        {
        }

        protected IntensiveCareSpecialityObjForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}