
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
    /// İlaç Türü Tanımlama
    /// </summary>
    public partial class IlacTuruDefinitionForm : BaseMedulaDefinitionForm
    {
    /// <summary>
    /// İlaç Türü
    /// </summary>
        protected TTObjectClasses.IlacTuru _IlacTuru
        {
            get { return (TTObjectClasses.IlacTuru)_ttObject; }
        }

        protected ITTLabel labelilacTuruKodu;
        protected ITTTextBox ilacTuruKodu;
        protected ITTLabel labelilacTuruAdi;
        protected ITTTextBox ilacTuruAdi;
        override protected void InitializeControls()
        {
            labelilacTuruKodu = (ITTLabel)AddControl(new Guid("c87a8c3b-d952-4d8e-82b0-1db40c9c2f21"));
            ilacTuruKodu = (ITTTextBox)AddControl(new Guid("0c3e00c7-19e4-4bc1-bdd8-a18a5f7c8cf7"));
            labelilacTuruAdi = (ITTLabel)AddControl(new Guid("67735646-6c21-421f-8a9e-7bd948e341e5"));
            ilacTuruAdi = (ITTTextBox)AddControl(new Guid("47eee3f9-65da-4834-8f7b-95c0b7f3fc08"));
            base.InitializeControls();
        }

        public IlacTuruDefinitionForm() : base("ILACTURU", "IlacTuruDefinitionForm")
        {
        }

        protected IlacTuruDefinitionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}