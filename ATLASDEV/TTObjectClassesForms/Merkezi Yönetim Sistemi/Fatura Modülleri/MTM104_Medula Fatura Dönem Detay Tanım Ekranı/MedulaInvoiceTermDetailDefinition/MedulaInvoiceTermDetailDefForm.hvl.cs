
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
    /// Medula Fatura Dönem Detay Tanım Ekranı
    /// </summary>
    public partial class MedulaInvoiceTermDetailDefForm : TerminologyManagerDefForm
    {
    /// <summary>
    /// Medula Fatura Dönem Detay Tanım Ekranı
    /// </summary>
        protected TTObjectClasses.MedulaInvoiceTermDetailDefinition _MedulaInvoiceTermDetailDefinition
        {
            get { return (TTObjectClasses.MedulaInvoiceTermDetailDefinition)_ttObject; }
        }

        protected ITTObjectListBox MedulaInvoiceType;
        protected ITTLabel ttlabel4;
        protected ITTLabel ttlabel3;
        protected ITTObjectListBox MedulaInvoiceTerm;
        override protected void InitializeControls()
        {
            MedulaInvoiceType = (ITTObjectListBox)AddControl(new Guid("fe389f91-8feb-4666-851d-6a26fdcc2477"));
            ttlabel4 = (ITTLabel)AddControl(new Guid("cbe9ce05-3ede-4dbf-beff-02dc34b774f7"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("c0560f67-a2a9-480a-8d31-a823de773339"));
            MedulaInvoiceTerm = (ITTObjectListBox)AddControl(new Guid("7ae2064f-175d-47bb-9f5e-a6d2341041a3"));
            base.InitializeControls();
        }

        public MedulaInvoiceTermDetailDefForm() : base("MEDULAINVOICETERMDETAILDEFINITION", "MedulaInvoiceTermDetailDefForm")
        {
        }

        protected MedulaInvoiceTermDetailDefForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}