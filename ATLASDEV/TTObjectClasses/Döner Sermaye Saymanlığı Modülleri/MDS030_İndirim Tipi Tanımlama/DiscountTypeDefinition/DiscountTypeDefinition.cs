
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
    /// İndirim Tipi Tanımlama
    /// </summary>
    public  partial class DiscountTypeDefinition : TerminologyManagerDef
    {
        public partial class GetDiscountTypeDefinitions_Class : TTReportNqlObject 
        {
        }

#region Methods
        public int GetExceptionDiscountPercent(TTObject pObject)
        {
            if (pObject.ObjectDef.IsOfType("PROCEDUREDEFINITION") == true)
            {   
                ProcedureDefinition pDef = (ProcedureDefinition)pObject;
                foreach (DiscountTypeProcedureExceptionDefinition pExc in ProcedureExceptions)
                {
                    if (pExc.ProcedureDefinion == pDef)
                    {
                        if (pExc.IsPercentageDiscount == true)
                            return (int)pExc.DiscountPercentage;
                        else
                            return 0;
                    }
                }
            }
            else if (pObject.ObjectDef.IsOfType("MATERIAL") == true)
            {   
                Material mDef = (Material)pObject;
                foreach (DiscountTypeMaterialExceptionDefinition pExc in MaterialExceptions)
                {
                    if (pExc.Material == mDef)
                    {
                        if (pExc.IsPercentageDiscount == true)
                            return (int)pExc.DiscountPercentage;
                        else
                            return 0;
                    }
                }
            }
            return 0;
        }
        
        public int GetGroupDiscountPercent(TTObject pObject)
        {
            if (pObject.ObjectDef.IsOfType("PROCEDURETREEDEFINITION") == true)
            {   
                ProcedureTreeDefinition pTreeDef = (ProcedureTreeDefinition)pObject;
                foreach (DiscountTypeProcedureGroupDefinition pGrp in ProcedureGroups)
                {
                    if (pGrp.ProcedureTree == pTreeDef)
                    {
                        if (pGrp.IsPercentageDiscount == true)
                            return (int)pGrp.DiscountPercentage;
                        else
                            return 0;
                    }
                }
            }
            else if (pObject.ObjectDef.IsOfType("MATERIALTREEDEFINITION") == true)
            {   
                MaterialTreeDefinition mTreeDef = (MaterialTreeDefinition)pObject;
                foreach (DiscountTypeMaterialGroupDefinition mGrp in MaterialGroups )
                {
                    if (mGrp.MaterialTree == mTreeDef)
                    {
                        if (mGrp.IsPercentageDiscount == true)
                            return (int)mGrp.DiscountPercentage;
                        else
                            return 0;
                    }
                }
            }
            return 0;
        }
           public override SendDataTypesEnum?  GetMySendDataTypesEnum()
        {
            return SendDataTypesEnum.DiscountTypeDefinitionInfo;
        }
        
#endregion Methods

    }
}