
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
    /// Fatura Engeli Tanımlama
    /// </summary>
    public  partial class InvoiceBlockingDefinition : TTDefinitionSet
    {
        public partial class GetInvoiceBlockingDefinition_Class : TTReportNqlObject 
        {

        }
        protected override void PostInsert()
        {
            ControlSameStateDefId();
        }

        protected override void PostUpdate()
        {
            ControlSameStateDefId();
        }

        private void ControlSameStateDefId()
        {
            if (StateDefId.HasValue)
            {
                BindingList<InvoiceBlockingDefinition> IBDList = ObjectContext.QueryObjects<InvoiceBlockingDefinition>("OBJECTID <> '" + ObjectID.ToString() + "' AND STATEDEFID = '" + StateDefId.ToString() + "'");
                if (IBDList.Count > 0)
                    throw new TTException("Aynı Durum ID li kayıt bulundu. Her Durum ID için tek tanım olabilir. Kontrol ediniz.");
            }
        }

        public static List<InvoiceBlockingDefinition> GetInvoiceBlockDef()
        {
            using (var objectContext = new TTObjectContext(true))
            {
                List<InvoiceBlockingDefinition> blockDefs = objectContext.QueryObjects<InvoiceBlockingDefinition>(" ISACTIVE = 1 AND INVOICEBLOCK = 1 ").ToList();
                return blockDefs;
            }
        }

        public static List<Guid> GetBlockStateIDs(int APRType, TTObjectContext objectContext)
        {
            List<InvoiceBlockingDefinition> blockDefs = new List<InvoiceBlockingDefinition>();
            blockDefs = objectContext.QueryObjects<InvoiceBlockingDefinition>(" ISACTIVE = 1 ").ToList();
            List<Guid> blockDefGuid = blockDefs.Select(x => x.StateDefId.Value).ToList();
            List<Guid> blockStates = new List<Guid>();


            if (APRType == (int)APRTypeEnum.PATIENT)
                blockDefs = blockDefs.Where(x => x.CashOfficeBlock == true).ToList();
            else
            {
                blockDefs = blockDefs.Where(x => x.InvoiceBlock == true).ToList();
                string objectDefNames = TTObjectClasses.SystemParameter.GetParameterValue("INVOICEBLOCKINGOBJECTDEFNAMES", "");
                objectDefNames = objectDefNames.Trim().ToUpperInvariant();
                List<string> objectDefNameList = objectDefNames.Split(',').ToList();

                foreach (TTObjectDef objDef in TTObjectDefManager.Instance.ObjectDefs.Values.Where(x => objectDefNameList.Contains(x.Name.ToUpperInvariant())).OrderBy(x => x.DisplayText))
                {
                    foreach (TTObjectStateDef stateDef in objDef.StateDefs.Values.OrderBy(x => x.DisplayText))
                    {
                        if (!blockDefGuid.Contains(stateDef.StateDefID))
                            blockStates.Add(stateDef.StateDefID);
                    }
                }
            }
            blockStates.AddRange(blockDefs.Select(x => x.StateDefId.Value).ToList());
            if (blockStates.Count == 0)
                blockStates.Add(Guid.Empty);

            return blockStates;
        }

        public static string GetCashOfficeBlockStateIDs(TTObjectContext objectContext)
        {
            string blockStates = string.Empty;

            if (TTObjectClasses.SystemParameter.GetParameterValue("CASHOFFICEBLOCKINGACTIVE", "FALSE") == "TRUE")
            {
                List<Guid> blockStateList = InvoiceBlockingDefinition.GetBlockStateIDs((int)APRTypeEnum.PATIENT, objectContext);
                foreach (Guid stateID in blockStateList)
                    blockStates += "'" + stateID + "',";
            }

            if (blockStates.Equals(string.Empty))
                blockStates = "'" + Guid.Empty + "'";
            else
                blockStates = blockStates.Substring(0, blockStates.Length - 1);

            return blockStates;
        }
    }
}