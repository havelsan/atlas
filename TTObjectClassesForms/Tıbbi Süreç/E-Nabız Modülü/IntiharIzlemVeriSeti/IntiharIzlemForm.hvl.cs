
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
    public partial class IntiharIzlemForm : TTForm
    {
        protected TTObjectClasses.IntiharIzlemVeriSeti _IntiharIzlemVeriSeti
        {
            get { return (TTObjectClasses.IntiharIzlemVeriSeti)_ttObject; }
        }

        protected ITTLabel labelSKRSIntiharKrizVakaTuru;
        protected ITTObjectListBox SKRSIntiharKrizVakaTuru;
        protected ITTGrid IntiharIzlemYontemi;
        protected ITTListBoxColumn SKRSICDIntiharIzlemYontemi;
        protected ITTGrid IntiharIzlemVakaSonucu;
        protected ITTListBoxColumn SKRSIntiharKrizVakaSonucuIntiharIzlemVakaSonucu;
        protected ITTGrid IntiharIzlemNedeni;
        protected ITTListBoxColumn SKRSIntiharGirisimiNedenleriIntiharIzlemNedeni;
        override protected void InitializeControls()
        {
            labelSKRSIntiharKrizVakaTuru = (ITTLabel)AddControl(new Guid("c643dc2a-8b5e-4e84-8ce6-323157a757a0"));
            SKRSIntiharKrizVakaTuru = (ITTObjectListBox)AddControl(new Guid("bb61729a-11c2-48c7-8c83-12cf051169b7"));
            IntiharIzlemYontemi = (ITTGrid)AddControl(new Guid("b0b1c95d-fe61-4839-8be7-b291993c3446"));
            SKRSICDIntiharIzlemYontemi = (ITTListBoxColumn)AddControl(new Guid("0a44eddd-384b-49ec-a299-7617e85dfaee"));
            IntiharIzlemVakaSonucu = (ITTGrid)AddControl(new Guid("cd9c7e64-8f2e-45d5-ae2a-ef87c9a67470"));
            SKRSIntiharKrizVakaSonucuIntiharIzlemVakaSonucu = (ITTListBoxColumn)AddControl(new Guid("139696e8-8ea0-4f11-97e4-7f880700c249"));
            IntiharIzlemNedeni = (ITTGrid)AddControl(new Guid("2903ce6e-20a2-4cac-b819-9575c262804f"));
            SKRSIntiharGirisimiNedenleriIntiharIzlemNedeni = (ITTListBoxColumn)AddControl(new Guid("41777b02-f47a-45cb-babe-fe5e328296e6"));
            base.InitializeControls();
        }

        public IntiharIzlemForm() : base("INTIHARIZLEMVERISETI", "IntiharIzlemForm")
        {
        }

        protected IntiharIzlemForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}