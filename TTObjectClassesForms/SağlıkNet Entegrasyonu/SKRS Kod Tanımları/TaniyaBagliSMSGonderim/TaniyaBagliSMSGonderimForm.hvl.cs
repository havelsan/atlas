
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
    /// Tanıya Göre SMS Gönderilecek Kullanıcı Tanımlama
    /// </summary>
    public partial class TaniyaBagliSMSGonderimForm : TTDefinitionForm
    {
    /// <summary>
    /// Seçilen tanılar için seçilen kullanıcılara SMS göndermek için
    /// </summary>
        protected TTObjectClasses.TaniyaBagliSMSGonderim _TaniyaBagliSMSGonderim
        {
            get { return (TTObjectClasses.TaniyaBagliSMSGonderim)_ttObject; }
        }

        protected ITTCheckBox Inpatient;
        protected ITTCheckBox Outpatient;
        protected ITTLabel labelDiagnosis;
        protected ITTObjectListBox Diagnosis;
        protected ITTLabel labelResUser;
        protected ITTObjectListBox ResUser;
        protected ITTLabel ttlabel1;
        protected ITTLabel ttlabel2;
        override protected void InitializeControls()
        {
            Inpatient = (ITTCheckBox)AddControl(new Guid("4659546b-df31-42f6-8aaa-f43cf2a3d9dc"));
            Outpatient = (ITTCheckBox)AddControl(new Guid("d3bad27d-a732-4e86-9e42-35c131a17866"));
            labelDiagnosis = (ITTLabel)AddControl(new Guid("e20f8263-2cea-424e-80d8-c33b160056fd"));
            Diagnosis = (ITTObjectListBox)AddControl(new Guid("77c40d90-78ca-486e-8255-07b1a98cab9c"));
            labelResUser = (ITTLabel)AddControl(new Guid("235d59dc-c52b-4501-9df2-051a7b98102f"));
            ResUser = (ITTObjectListBox)AddControl(new Guid("b13dab4a-f06b-4b18-a72c-6bd24508758c"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("e388da2f-d5d1-46f1-96d0-d82b8e6d44fa"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("5a4836af-0808-43d5-bb73-59ea7b527041"));
            base.InitializeControls();
        }

        public TaniyaBagliSMSGonderimForm() : base("TANIYABAGLISMSGONDERIM", "TaniyaBagliSMSGonderimForm")
        {
        }

        protected TaniyaBagliSMSGonderimForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}