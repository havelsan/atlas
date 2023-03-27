
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


namespace TTObjectClasses
{
    /// <summary>
    /// Fatura dahillik işlemleri ana tanım ekranı
    /// </summary>
    public partial class InvoiceInclusionMaster : TTDefinitionSet
    {
        public partial class GetInvoiceInclusionMaster_Class : TTReportNqlObject
        {
        }

        public InvoiceInclusionResultEnum GetResultForSingleTrx(TTObject pObject)
        {
            ProcedureDefinition pd;
            List<IIMNQLProcedureMaterial> orderedListOfGroups;
            if (pObject.ObjectDef.IsOfType("PROCEDUREDEFINITION") == true)
            {
                pd = (ProcedureDefinition)pObject;

                BindingList<IIMNQLProcedureMaterial> allDetails = IIMNQLProcedureMaterials.Select(" PROCEDUREDEFINITION = '" + pd.ObjectID + "'");

                foreach (var item in allDetails)
                {
                    if (item.Result.HasValue)
                        return item.Result.Value;
                }
            }

            ProcedureMaterialEnum type;
            Guid objectID;
            if (pObject.ObjectDef.IsOfType("PROCEDUREDEFINITION") == true)
            {
                type = ProcedureMaterialEnum.Procedure;
                objectID = ((ProcedureDefinition)pObject).ObjectID;
            }
            else
            {
                type = ProcedureMaterialEnum.Material;
                objectID = ((Material)pObject).ObjectID;
            }

            orderedListOfGroups = IIMNQLProcedureMaterials.ToList();

            if (orderedListOfGroups.Count > 0)
            {
                orderedListOfGroups = orderedListOfGroups.Where(x => x.InvoiceInclusionNQL != null && x.InvoiceInclusionNQL.ProcedureMaterialType == type).ToList();
                IEnumerable<int?> distinctList = orderedListOfGroups.Select(x => x.InvoiceInclusionNQL.OrderNo).Distinct().OrderByDescending(x => x.Value);

                foreach (var item in distinctList)
                {
                    int countOfObjectList = GetCountOfNql(item, orderedListOfGroups, InvoiceInclusionResultEnum.Included, objectID, type);

                    if (countOfObjectList > 0)
                        return InvoiceInclusionResultEnum.Included;

                    countOfObjectList = GetCountOfNql(item, orderedListOfGroups, InvoiceInclusionResultEnum.ForInfo, objectID, type);

                    if (countOfObjectList > 0)
                        return InvoiceInclusionResultEnum.ForInfo;

                    countOfObjectList = GetCountOfNql(item, orderedListOfGroups, InvoiceInclusionResultEnum.DoNotSendToMedula, objectID, type);

                    if (countOfObjectList > 0)
                        return InvoiceInclusionResultEnum.DoNotSendToMedula;
                }
            }

            return InvoiceInclusionResultEnum.Included;
        }

        private int GetCountOfNql(int? item, List<IIMNQLProcedureMaterial> orderedListOfGroups, InvoiceInclusionResultEnum type, Guid objectID, ProcedureMaterialEnum proOrMaterial)
        {
            string nql = "WHERE ( 1 <> 1 ";
            IEnumerable<IIMNQLProcedureMaterial> innerDoNotSendToMedulaList = orderedListOfGroups.Where(i => i.InvoiceInclusionNQL.OrderNo == item && i.Result.Value == type);

            foreach (var lastItem in innerDoNotSendToMedulaList)
            {
                if(!lastItem.InvoiceInclusionNQL.NQL.Contains("[Exception]"))
                    nql += " OR " + lastItem.InvoiceInclusionNQL.NQL.Replace('@',' ');
            }

            if (!nql.Equals("WHERE ( 1 <> 1 "))
            {
                nql += " ) AND OBJECTID = '" + objectID.ToString() + "' ";


                if (proOrMaterial == ProcedureMaterialEnum.Procedure)
                {
                    BindingList<ProcedureDefinition> resultList = ProcedureDefinition.GetAllProcedureDefinitions(ObjectContext, nql);
                    return resultList.Count;
                }
                else
                {
                    BindingList<Material> resultList = Material.GetMaterial(ObjectContext, nql);
                    return resultList.Count;
                }
            }
            else
                return 0;
        }

    }
}