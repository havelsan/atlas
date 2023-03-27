
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
    /// Fatura Oku
    /// </summary>
    public partial class FaturaOkuForm : BaseMedulaActionForm
    {
    /// <summary>
    /// Fatura Oku
    /// </summary>
        protected TTObjectClasses.FaturaOku _FaturaOku
        {
            get { return (TTObjectClasses.FaturaOku)_ttObject; }
        }

        protected ITTLabel labelfaturaTarihiDateTimeFaturaOkuGirisDVO;
        protected ITTDateTimePicker faturaTarihiDateTimeFaturaOkuGirisDVO;
        protected ITTLabel labelsaglikTesisKoduFaturaOkuGirisDVO;
        protected ITTValueListBox saglikTesisKoduFaturaOkuGirisDVO;
        protected ITTLabel labelfaturaTeslimNoFaturaOkuGirisDVO;
        protected ITTTextBox faturaTeslimNoFaturaOkuGirisDVO;
        protected ITTTextBox faturaTarihiFaturaOkuGirisDVO;
        protected ITTLabel labelfaturaRefNoFaturaOkuGirisDVO;
        protected ITTTextBox faturaRefNoFaturaOkuGirisDVO;
        override protected void InitializeControls()
        {
            labelfaturaTarihiDateTimeFaturaOkuGirisDVO = (ITTLabel)AddControl(new Guid("f7255da8-1873-41b3-89d4-f09e92cbbf1c"));
            faturaTarihiDateTimeFaturaOkuGirisDVO = (ITTDateTimePicker)AddControl(new Guid("8257959a-319d-42a9-a5b3-97d77d6abe7a"));
            labelsaglikTesisKoduFaturaOkuGirisDVO = (ITTLabel)AddControl(new Guid("b97d6648-5b32-4f84-966d-d9b4db3cd465"));
            saglikTesisKoduFaturaOkuGirisDVO = (ITTValueListBox)AddControl(new Guid("071e7914-1b33-4b62-817e-177ff7a94b85"));
            labelfaturaTeslimNoFaturaOkuGirisDVO = (ITTLabel)AddControl(new Guid("e7ebc1bc-3160-42ef-b522-2b7c1670d298"));
            faturaTeslimNoFaturaOkuGirisDVO = (ITTTextBox)AddControl(new Guid("f2e7e5d6-807b-4d9c-952c-2cf5303f57e3"));
            faturaTarihiFaturaOkuGirisDVO = (ITTTextBox)AddControl(new Guid("2071c45a-0eef-46cd-b17c-f18601923304"));
            labelfaturaRefNoFaturaOkuGirisDVO = (ITTLabel)AddControl(new Guid("9ccc16df-024a-4cb5-ab71-a7e693a492d9"));
            faturaRefNoFaturaOkuGirisDVO = (ITTTextBox)AddControl(new Guid("2b361124-20fd-48c0-aa98-39ecea393a7c"));
            base.InitializeControls();
        }

        public FaturaOkuForm() : base("FATURAOKU", "FaturaOkuForm")
        {
        }

        protected FaturaOkuForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}