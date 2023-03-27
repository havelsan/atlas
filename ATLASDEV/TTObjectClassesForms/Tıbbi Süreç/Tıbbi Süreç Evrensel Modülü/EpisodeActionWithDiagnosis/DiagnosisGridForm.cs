
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
    public partial class DiagnosisGridForm : TTForm
    {
        override protected void BindControlEvents()
        {
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            base.UnBindControlEvents();
        }

        /// <summary>
        /// Kullanýcýnýn uzmanlýk dalýna göre taný listelerine filtre konulup konulmayacaðýný belirler.
        /// </summary>
        /// <param name="treatmentMaterialDef"></param>
        /// <param name="treatmentMaterialMaterialColumn"></param>
        public virtual void SetDiagnosisListFilter()
        {
            UserOption uo = Common.CurrentResource.GetUserOption(UserOptionType.ICDFilter);
            if (uo != null && uo.Value != null && uo.Value.ToString() == "OPEN")
            {
                ArrayList specialityList = new ArrayList();
                string filterString = "";
                string parentGroupIDs = "";
                foreach (UserResource uRes in Common.CurrentResource.UserResources)
                {
                    foreach (ResourceSpecialityGrid specGrid in uRes.Resource.ResourceSpecialities)
                    {
                        if (specialityList.Contains(specGrid.Speciality) == false)
                            specialityList.Add(specGrid.Speciality);
                    }
                }

                foreach (SpecialityDefinition speciality in specialityList)
                {
                    IList matchingList = DiagnoseSpecialityMatching.GetBySpeciality(this._EpisodeActionWithDiagnosis.ObjectContext, speciality.ObjectID.ToString());
                    foreach (DiagnoseSpecialityMatching dsm in matchingList)
                    {
                        foreach (DiagnosisGridForMatching dgm in dsm.Diagnosis)
                        {
                            parentGroupIDs += "'" + dgm.DiagnosisDefinition.ObjectID + "',";
                        }
                    }
                }

                if (parentGroupIDs != "")
                {
                    filterString = " (OBJECTID IN (" + parentGroupIDs.Substring(0, parentGroupIDs.Length - 1) + "))";
                    //filterString += " OR PARENTGROUP IN (" + parentGroupIDs.Substring(0,parentGroupIDs.Length-1) + "))";
                }
                else
                    filterString = " 1=0";

                ((ITTListBoxColumn)this.GridDiagnosis.Columns["Diagnose"]).ListFilterExpression = filterString;

            }
        }



        protected override void ClientSidePreScript()
        {
            #region DiagnosisGridForm_ClientSidePreScript
            base.ClientSidePreScript();
            this.SetDiagnosisListFilter();
            #endregion DiagnosisGridForm_ClientSidePreScript

        }
    }
}