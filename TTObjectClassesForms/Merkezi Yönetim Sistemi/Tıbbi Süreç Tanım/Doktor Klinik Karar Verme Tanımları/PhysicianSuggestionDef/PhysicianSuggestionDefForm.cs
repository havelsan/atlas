
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

using SmartCardWrapper;

using TTStorageManager;
using System.Runtime.Versioning;
using System.Windows.Forms;
using TTVisual;
namespace TTFormClasses
{
    public partial class PhysicianSuggestionDefForm : TerminologyManagerDefForm
    {
        override protected void BindControlEvents()
        {
            DiagnosisDefinition.SelectedObjectChanged += new TTControlEventDelegate(DiagnosisDefinition_SelectedObjectChanged);
            ParentPhysicianSuggestionDef.SelectedObjectChanged += new TTControlEventDelegate(ParentPhysicianSuggestionDef_SelectedObjectChanged);
            ProcedureDefinition.SelectedObjectChanged += new TTControlEventDelegate(ProcedureDefinition_SelectedObjectChanged);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            DiagnosisDefinition.SelectedObjectChanged -= new TTControlEventDelegate(DiagnosisDefinition_SelectedObjectChanged);
            ParentPhysicianSuggestionDef.SelectedObjectChanged -= new TTControlEventDelegate(ParentPhysicianSuggestionDef_SelectedObjectChanged);
            ProcedureDefinition.SelectedObjectChanged -= new TTControlEventDelegate(ProcedureDefinition_SelectedObjectChanged);
            base.UnBindControlEvents();
        }

        private void DiagnosisDefinition_SelectedObjectChanged()
        {
            var  selectedDiagnosisDefinition = this.DiagnosisDefinition.SelectedObject;
            // <-- Automatically generated part.

            if (selectedDiagnosisDefinition != null)
            {
                DiagnosisDefinition diagnosisDefinition = (DiagnosisDefinition)selectedDiagnosisDefinition;
                int count = diagnosisDefinition.PhysicianSuggestionDefs.Select("ISACTIVE = 1").Count();
                this._PhysicianSuggestionDef.GrupName = diagnosisDefinition.Code + "__" + count.ToString();
                this._PhysicianSuggestionDef.ParentPhysicianSuggestionDef = null;
                this._PhysicianSuggestionDef.ReturnValueOfParent = null;
                this.ParentPhysicianSuggestionDef.ReadOnly = true;
                this.ReturnValueOfParent.ReadOnly = true;
            }
            else
            {
                this.ParentPhysicianSuggestionDef.ReadOnly = false;
                this.ReturnValueOfParent.ReadOnly = false;
            }

            // Automatically generated part. -->
        }
        private void ParentPhysicianSuggestionDef_SelectedObjectChanged()
        {
            var selectedParentPhysicianSuggestionDef = this.ParentPhysicianSuggestionDef.SelectedObject;
            // <-- Automatically generated part.

            if (selectedParentPhysicianSuggestionDef != null)
            {
                PhysicianSuggestionDef parentPhysicianSuggestionDef = (PhysicianSuggestionDef)selectedParentPhysicianSuggestionDef;
                this._PhysicianSuggestionDef.GrupName = parentPhysicianSuggestionDef.GrupName;
                this._PhysicianSuggestionDef.DiagnosisDefinition = null;
                this.DiagnosisDefinition.ReadOnly = true; 
            }
            else
            {
                this.DiagnosisDefinition.ReadOnly = false;
                this._PhysicianSuggestionDef.ReturnValueOfParent = null;
            }

            // Automatically generated part. -->
        }

        private void ProcedureDefinition_SelectedObjectChanged()
        {
            var selectedProcedureDefinition = this.ProcedureDefinition.SelectedObject;
            // <-- Automatically generated part.

            if (selectedProcedureDefinition != null)
            {
                ProcedureDefinition procedureDefinition = (ProcedureDefinition)selectedProcedureDefinition;
                this._PhysicianSuggestionDef.Message = procedureDefinition.Code + "-" + procedureDefinition.Name;

            }

            // Automatically generated part. -->
        }

        protected override void PreScript()
        {
            // <-- Automatically generated part.
            base.PreScript();
            if (((ITTObject)this._PhysicianSuggestionDef).IsNew == true)
                this._PhysicianSuggestionDef.IsActive = true;
            if (this._PhysicianSuggestionDef.ParentPhysicianSuggestionDef != null )
            {
                this.DiagnosisDefinition.ReadOnly = true;
            }
            else
            {
                this.DiagnosisDefinition.ReadOnly = false;
            }
            if (this._PhysicianSuggestionDef.DiagnosisDefinition != null)
            {
                this.ParentPhysicianSuggestionDef.ReadOnly = true;
                this.ReturnValueOfParent.ReadOnly = true;
            }
            else
            {
                this.ParentPhysicianSuggestionDef.ReadOnly = false;
                this.ReturnValueOfParent.ReadOnly = false;
            }
            // Automatically generated part. -->
        }

        protected override void PostScript(TTObjectStateTransitionDef transDef)
        {
            // <-- Automatically generated part.
            base.PostScript(transDef);

            if(this._PhysicianSuggestionDef.ParentPhysicianSuggestionDef!= null && this._PhysicianSuggestionDef.ReturnValueOfParent == null)
            {
                throw new Exception("Bir �nceki sorunun Cevap De�eri Bo� olamaz ");
            }

            if (this._PhysicianSuggestionDef.ParentPhysicianSuggestionDef == null && this._PhysicianSuggestionDef.DiagnosisDefinition == null)
            {
                throw new Exception("Tan� ya da Bir �nceki soru se�meden tan�m kaydedilemez ");
            }

            if (this._PhysicianSuggestionDef.ButtonCaptions != null && this._PhysicianSuggestionDef.ReturnValues == null)
            {
                throw new Exception("Cevap Ba�l�klar�na ait Cevap De�erleri Bo� olamaz ");
            }

            if (this._PhysicianSuggestionDef.ButtonCaptions == null && this._PhysicianSuggestionDef.ReturnValues != null)
            {
                throw new Exception("Cevap De�erlerine ait Cevap Ba�l�klar� Bo� olamaz ");
            }

            if (this._PhysicianSuggestionDef.ButtonCaptions != null && this._PhysicianSuggestionDef.ProcedureDefinition != null)
            {
                throw new Exception("Ayn� anda Hem soru /uyar� ( Cevap Ba�l�k ve de�erleri)  hem �nerilecek Hizmet se�ilemez . ");
            }

            if (this._PhysicianSuggestionDef.ButtonCaptions == null && this._PhysicianSuggestionDef.ProcedureDefinition == null)
            {
                throw new Exception("Soru/ Uyar� (Mesaj Metni , Cevap Ba�l�k ve de�erleri)  ya da �nerilecek Hizmet  se�meden tan�m kaydedilemez ");
            }

            if (this._PhysicianSuggestionDef.ButtonCaptions != null && this._PhysicianSuggestionDef.Message == null)
            {
                throw new Exception("Mesaj Metni Bo� olamaz ");
            }
            // Automatically generated part. -->
        }

    }
}