
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
    /// Fototerapi Değer Tanımları Formu
    /// </summary>
    public partial class PhototherapyDefinitionForm : TTDefinitionForm
    {
        protected TTObjectClasses.PhototherapyDefinition _PhototherapyDefinition
        {
            get { return (TTObjectClasses.PhototherapyDefinition)_ttObject; }
        }

        protected ITTLabel labelComplicatedExcTrans;
        protected ITTTextBox ComplicatedExcTrans;
        protected ITTTextBox UncomplicatedExcTrans;
        protected ITTTextBox ComplicatedPhototherapy;
        protected ITTTextBox UncomplicatedPhototherapy;
        protected ITTTextBox FinishTime;
        protected ITTTextBox StartTime;
        protected ITTTextBox MaxWeight;
        protected ITTTextBox MinWeight;
        protected ITTLabel labelUncomplicatedExcTrans;
        protected ITTLabel labelComplicatedPhototherapy;
        protected ITTLabel labelUncomplicatedPhototherapy;
        protected ITTLabel labelFinishTime;
        protected ITTLabel labelStartTime;
        protected ITTLabel labelMaxWeight;
        protected ITTLabel labelMinWeight;
        override protected void InitializeControls()
        {
            labelComplicatedExcTrans = (ITTLabel)AddControl(new Guid("b90056b8-088d-4074-8e38-540b7369b0a5"));
            ComplicatedExcTrans = (ITTTextBox)AddControl(new Guid("08ea535e-67a5-4cbd-aaee-2f53df520018"));
            UncomplicatedExcTrans = (ITTTextBox)AddControl(new Guid("702199c8-2eef-47c4-8b80-b2463818d805"));
            ComplicatedPhototherapy = (ITTTextBox)AddControl(new Guid("71f874a8-3108-4258-903b-dd2f27c0fda7"));
            UncomplicatedPhototherapy = (ITTTextBox)AddControl(new Guid("51174c6b-7bb5-49a1-86d2-fb3cf58c67a2"));
            FinishTime = (ITTTextBox)AddControl(new Guid("642490dd-76eb-4329-9de8-8915c8ef3b65"));
            StartTime = (ITTTextBox)AddControl(new Guid("7041adcd-c96b-453d-b270-adc29324126f"));
            MaxWeight = (ITTTextBox)AddControl(new Guid("ecb42e1d-cf7b-42a7-8f0a-c9ca2ee27991"));
            MinWeight = (ITTTextBox)AddControl(new Guid("e049f8de-98b1-43c8-b87b-82a05e4e1277"));
            labelUncomplicatedExcTrans = (ITTLabel)AddControl(new Guid("b7549df8-a297-420a-bc3e-434c3129c5d0"));
            labelComplicatedPhototherapy = (ITTLabel)AddControl(new Guid("3268a636-d35a-47ea-b041-511586c18898"));
            labelUncomplicatedPhototherapy = (ITTLabel)AddControl(new Guid("a033d8df-9ed5-4aaf-b6cf-46377c3aa7f8"));
            labelFinishTime = (ITTLabel)AddControl(new Guid("0a91860e-f06d-4c67-ae68-a1df32274f8d"));
            labelStartTime = (ITTLabel)AddControl(new Guid("cb8319b8-4fc8-48fa-a932-ad56d06b20b9"));
            labelMaxWeight = (ITTLabel)AddControl(new Guid("3c9a41cf-2cc4-4802-9b7b-f576d1c7472d"));
            labelMinWeight = (ITTLabel)AddControl(new Guid("2226e0dd-94b1-4e19-89eb-6bc494071d04"));
            base.InitializeControls();
        }

        public PhototherapyDefinitionForm() : base("PHOTOTHERAPYDEFINITION", "PhototherapyDefinitionForm")
        {
        }

        protected PhototherapyDefinitionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}