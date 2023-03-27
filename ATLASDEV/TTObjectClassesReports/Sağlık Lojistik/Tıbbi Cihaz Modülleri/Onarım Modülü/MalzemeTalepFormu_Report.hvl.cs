
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

using TTReportTool;
using TTVisual;
namespace TTReportClasses
{
    /// <summary>
    /// Malzeme Talep Formu
    /// </summary>
    public partial class MalzemeTalepFormu : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public Guid? TTOBJECTID = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue("00000000-0000-0000-0000-000000000000");
        }

        public partial class Part1Group : TTReportGroup
        {
            public MalzemeTalepFormu MyParentReport
            {
                get { return (MalzemeTalepFormu)ParentReport; }
            }

            new public Part1GroupHeader Header()
            {
                return (Part1GroupHeader)_header;
            }

            new public Part1GroupFooter Footer()
            {
                return (Part1GroupFooter)_footer;
            }

            public TTReportField ISTEKTARIHI { get {return Header().ISTEKTARIHI;} }
            public TTReportField NewField { get {return Header().NewField;} }
            public TTReportField NewField5 { get {return Header().NewField5;} }
            public TTReportField NewField9 { get {return Header().NewField9;} }
            public TTReportField NewField16 { get {return Header().NewField16;} }
            public TTReportField NewField17 { get {return Header().NewField17;} }
            public TTReportField SIPARISNO { get {return Header().SIPARISNO;} }
            public TTReportField ONARIMDANSORUMLUKISIM { get {return Header().ONARIMDANSORUMLUKISIM;} }
            public TTReportField NewField81 { get {return Header().NewField81;} }
            public TTReportField NewField72 { get {return Header().NewField72;} }
            public TTReportField NewField73 { get {return Header().NewField73;} }
            public TTReportField AITOLDUGUANAMALZEME { get {return Header().AITOLDUGUANAMALZEME;} }
            public TTReportField NewField15 { get {return Header().NewField15;} }
            public TTReportField NewField151 { get {return Header().NewField151;} }
            public TTReportField NewField1151 { get {return Header().NewField1151;} }
            public TTReportField NewField11511 { get {return Header().NewField11511;} }
            public TTReportField ONARIMDANSORUMLUPERSONEL { get {return Header().ONARIMDANSORUMLUPERSONEL;} }
            public TTReportField NewField18 { get {return Footer().NewField18;} }
            public TTReportField NewField19 { get {return Footer().NewField19;} }
            public TTReportField NewField20 { get {return Footer().NewField20;} }
            public Part1Group(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public Part1Group(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _body = null;
                _header = new Part1GroupHeader(this);
                _footer = new Part1GroupFooter(this);

            }

            public partial class Part1GroupHeader : TTReportSection
            {
                public MalzemeTalepFormu MyParentReport
                {
                    get { return (MalzemeTalepFormu)ParentReport; }
                }
                
                public TTReportField ISTEKTARIHI;
                public TTReportField NewField;
                public TTReportField NewField5;
                public TTReportField NewField9;
                public TTReportField NewField16;
                public TTReportField NewField17;
                public TTReportField SIPARISNO;
                public TTReportField ONARIMDANSORUMLUKISIM;
                public TTReportField NewField81;
                public TTReportField NewField72;
                public TTReportField NewField73;
                public TTReportField AITOLDUGUANAMALZEME;
                public TTReportField NewField15;
                public TTReportField NewField151;
                public TTReportField NewField1151;
                public TTReportField NewField11511;
                public TTReportField ONARIMDANSORUMLUPERSONEL; 
                public Part1GroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 104;
                    IsAligned = EvetHayirEnum.ehEvet;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    ISTEKTARIHI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 38, 50, 201, 60, false);
                    ISTEKTARIHI.Name = "ISTEKTARIHI";
                    ISTEKTARIHI.FieldType = ReportFieldTypeEnum.ftVariable;
                    ISTEKTARIHI.TextFormat = @"dd/MM/yyyy";
                    ISTEKTARIHI.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ISTEKTARIHI.TextFont.Name = "Arial";
                    ISTEKTARIHI.TextFont.CharSet = 162;
                    ISTEKTARIHI.Value = @"";

                    NewField = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 17, 202, 28, false);
                    NewField.Name = "NewField";
                    NewField.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField.TextFont.Name = "Arial";
                    NewField.TextFont.Size = 12;
                    NewField.TextFont.Bold = true;
                    NewField.TextFont.CharSet = 162;
                    NewField.Value = @"MALZEME TALEP FORMU";

                    NewField5 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 30, 91, 40, false);
                    NewField5.Name = "NewField5";
                    NewField5.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField5.TextFont.Name = "Arial";
                    NewField5.TextFont.Bold = true;
                    NewField5.TextFont.CharSet = 162;
                    NewField5.Value = @"Bakım-Onarım-Kalibrasyon İstek Formu No.: ";

                    NewField9 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 25, 90, 54, 103, false);
                    NewField9.Name = "NewField9";
                    NewField9.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField9.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField9.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField9.TextFont.Name = "Arial";
                    NewField9.TextFont.Bold = true;
                    NewField9.TextFont.CharSet = 162;
                    NewField9.Value = @"Stok / Parça No";

                    NewField16 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 54, 90, 142, 103, false);
                    NewField16.Name = "NewField16";
                    NewField16.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField16.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField16.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField16.TextFont.Name = "Arial";
                    NewField16.TextFont.Bold = true;
                    NewField16.TextFont.CharSet = 162;
                    NewField16.Value = @"Malzeme Adı ve Tarifi";

                    NewField17 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 142, 90, 162, 103, false);
                    NewField17.Name = "NewField17";
                    NewField17.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField17.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField17.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField17.TextFont.Name = "Arial";
                    NewField17.TextFont.Bold = true;
                    NewField17.TextFont.CharSet = 162;
                    NewField17.Value = @"İstenen";

                    SIPARISNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 91, 30, 202, 40, false);
                    SIPARISNO.Name = "SIPARISNO";
                    SIPARISNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    SIPARISNO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    SIPARISNO.TextFont.Name = "Arial";
                    SIPARISNO.TextFont.CharSet = 162;
                    SIPARISNO.Value = @"";

                    ONARIMDANSORUMLUKISIM = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 67, 60, 202, 70, false);
                    ONARIMDANSORUMLUKISIM.Name = "ONARIMDANSORUMLUKISIM";
                    ONARIMDANSORUMLUKISIM.FieldType = ReportFieldTypeEnum.ftVariable;
                    ONARIMDANSORUMLUKISIM.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ONARIMDANSORUMLUKISIM.TextFont.Name = "Arial";
                    ONARIMDANSORUMLUKISIM.TextFont.CharSet = 162;
                    ONARIMDANSORUMLUKISIM.Value = @"";

                    NewField81 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 14, 90, 25, 103, false);
                    NewField81.Name = "NewField81";
                    NewField81.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField81.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField81.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField81.TextFont.Name = "Arial";
                    NewField81.TextFont.Bold = true;
                    NewField81.TextFont.CharSet = 162;
                    NewField81.Value = @"S.No.";

                    NewField72 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 162, 90, 182, 103, false);
                    NewField72.Name = "NewField72";
                    NewField72.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField72.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField72.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField72.TextFont.Name = "Arial";
                    NewField72.TextFont.Bold = true;
                    NewField72.TextFont.CharSet = 162;
                    NewField72.Value = @"Harcanan";

                    NewField73 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 182, 90, 202, 103, false);
                    NewField73.Name = "NewField73";
                    NewField73.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField73.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField73.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField73.TextFont.Name = "Arial";
                    NewField73.TextFont.Bold = true;
                    NewField73.TextFont.CharSet = 162;
                    NewField73.Value = @"İade";

                    AITOLDUGUANAMALZEME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 39, 40, 202, 50, false);
                    AITOLDUGUANAMALZEME.Name = "AITOLDUGUANAMALZEME";
                    AITOLDUGUANAMALZEME.FieldType = ReportFieldTypeEnum.ftVariable;
                    AITOLDUGUANAMALZEME.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    AITOLDUGUANAMALZEME.TextFont.Name = "Arial";
                    AITOLDUGUANAMALZEME.TextFont.CharSet = 162;
                    AITOLDUGUANAMALZEME.Value = @"";

                    NewField15 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 40, 39, 50, false);
                    NewField15.Name = "NewField15";
                    NewField15.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField15.TextFont.Name = "Arial";
                    NewField15.TextFont.Bold = true;
                    NewField15.TextFont.CharSet = 162;
                    NewField15.Value = @"Cihazın Adı :";

                    NewField151 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 50, 39, 60, false);
                    NewField151.Name = "NewField151";
                    NewField151.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField151.TextFont.Name = "Arial";
                    NewField151.TextFont.Bold = true;
                    NewField151.TextFont.CharSet = 162;
                    NewField151.Value = @"İstek Tarihi :";

                    NewField1151 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 60, 67, 70, false);
                    NewField1151.Name = "NewField1151";
                    NewField1151.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1151.TextFont.Name = "Arial";
                    NewField1151.TextFont.Bold = true;
                    NewField1151.TextFont.CharSet = 162;
                    NewField1151.Value = @"Malzemeyi Kullanacak Kısım	:";

                    NewField11511 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 70, 97, 80, false);
                    NewField11511.Name = "NewField11511";
                    NewField11511.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11511.TextFont.Name = "Arial";
                    NewField11511.TextFont.Bold = true;
                    NewField11511.TextFont.CharSet = 162;
                    NewField11511.Value = @"Malzemeyi Talep Eden Personelin Adı Soyadı: ";

                    ONARIMDANSORUMLUPERSONEL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 97, 70, 202, 80, false);
                    ONARIMDANSORUMLUPERSONEL.Name = "ONARIMDANSORUMLUPERSONEL";
                    ONARIMDANSORUMLUPERSONEL.FieldType = ReportFieldTypeEnum.ftVariable;
                    ONARIMDANSORUMLUPERSONEL.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ONARIMDANSORUMLUPERSONEL.TextFont.Name = "Arial";
                    ONARIMDANSORUMLUPERSONEL.TextFont.CharSet = 162;
                    ONARIMDANSORUMLUPERSONEL.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    ISTEKTARIHI.CalcValue = @"";
                    NewField.CalcValue = NewField.Value;
                    NewField5.CalcValue = NewField5.Value;
                    NewField9.CalcValue = NewField9.Value;
                    NewField16.CalcValue = NewField16.Value;
                    NewField17.CalcValue = NewField17.Value;
                    SIPARISNO.CalcValue = @"";
                    ONARIMDANSORUMLUKISIM.CalcValue = @"";
                    NewField81.CalcValue = NewField81.Value;
                    NewField72.CalcValue = NewField72.Value;
                    NewField73.CalcValue = NewField73.Value;
                    AITOLDUGUANAMALZEME.CalcValue = @"";
                    NewField15.CalcValue = NewField15.Value;
                    NewField151.CalcValue = NewField151.Value;
                    NewField1151.CalcValue = NewField1151.Value;
                    NewField11511.CalcValue = NewField11511.Value;
                    ONARIMDANSORUMLUPERSONEL.CalcValue = @"";
                    return new TTReportObject[] { ISTEKTARIHI,NewField,NewField5,NewField9,NewField16,NewField17,SIPARISNO,ONARIMDANSORUMLUKISIM,NewField81,NewField72,NewField73,AITOLDUGUANAMALZEME,NewField15,NewField151,NewField1151,NewField11511,ONARIMDANSORUMLUPERSONEL};
                }

                public override void RunScript()
                {
#region PART1 HEADER_Script
                    CMRAction cmrAction = (CMRAction)MyParentReport.ReportObjectContext.GetObject(MyParentReport.RuntimeParameters.TTOBJECTID.Value, typeof(CMRAction));

            
            if (cmrAction is MaterialRepair)
            {
                MaterialRepair mRepair = (MaterialRepair)cmrAction;
                
                ONARIMDANSORUMLUKISIM.CalcValue = mRepair.WorkShop.Name ;
                SIPARISNO.CalcValue = mRepair.RequestNo.ToString();
                ISTEKTARIHI.CalcValue = ((DateTime)mRepair.RequestDate).ToShortDateString ();
                AITOLDUGUANAMALZEME.CalcValue = mRepair.FixedAssetDefinition.Name ;
                ONARIMDANSORUMLUPERSONEL.CalcValue = mRepair.ResponsibleUser.Name;
            }
            else
            {
                Repair repair = (Repair)cmrAction;
                ONARIMDANSORUMLUKISIM.CalcValue = repair.WorkShop.Name ;
                SIPARISNO.CalcValue = repair.RequestNo.ToString();
                ISTEKTARIHI.CalcValue = ((DateTime)repair.RequestDate).ToShortDateString ();
                AITOLDUGUANAMALZEME.CalcValue = repair.FixedAssetMaterialDefinition.Description.ToString() ;
                ONARIMDANSORUMLUPERSONEL.CalcValue = repair.ResponsibleUser.Name;
            }
#endregion PART1 HEADER_Script
                }
            }
            public partial class Part1GroupFooter : TTReportSection
            {
                public MalzemeTalepFormu MyParentReport
                {
                    get { return (MalzemeTalepFormu)ParentReport; }
                }
                
                public TTReportField NewField18;
                public TTReportField NewField19;
                public TTReportField NewField20; 
                public Part1GroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 43;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    NewField18 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 14, 3, 76, 13, false);
                    NewField18.Name = "NewField18";
                    NewField18.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField18.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField18.TextFont.Name = "Arial";
                    NewField18.TextFont.Bold = true;
                    NewField18.TextFont.CharSet = 162;
                    NewField18.Value = @"İstek Yapan Personel";

                    NewField19 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 140, 3, 202, 13, false);
                    NewField19.Name = "NewField19";
                    NewField19.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField19.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField19.TextFont.Name = "Arial";
                    NewField19.TextFont.Bold = true;
                    NewField19.TextFont.CharSet = 162;
                    NewField19.Value = @"İkmal Ks.A.";

                    NewField20 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 77, 3, 139, 13, false);
                    NewField20.Name = "NewField20";
                    NewField20.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField20.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField20.TextFont.Name = "Arial";
                    NewField20.TextFont.Bold = true;
                    NewField20.TextFont.CharSet = 162;
                    NewField20.Value = @"Atölye Ks.A.";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField18.CalcValue = NewField18.Value;
                    NewField19.CalcValue = NewField19.Value;
                    NewField20.CalcValue = NewField20.Value;
                    return new TTReportObject[] { NewField18,NewField19,NewField20};
                }
            }

        }

        public Part1Group Part1;

        public partial class MAINGroup : TTReportGroup
        {
            public MalzemeTalepFormu MyParentReport
            {
                get { return (MalzemeTalepFormu)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField SNO { get {return Body().SNO;} }
            public TTReportField STOKNO { get {return Body().STOKNO;} }
            public TTReportField MALZEMENINADI { get {return Body().MALZEMENINADI;} }
            public TTReportField ATOLYEIHTIYACIMIKTAR { get {return Body().ATOLYEIHTIYACIMIKTAR;} }
            public TTReportField HARCANAN { get {return Body().HARCANAN;} }
            public TTReportField IADE { get {return Body().IADE;} }
            public MAINGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public MAINGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

             
            protected override TTReportNqlDataSet GetReportNqlDataSet()
            {
                TTBaseReportNqlData[] list = new TTBaseReportNqlData[1];
                list[0] = new TTReportNqlData<RepairConsumedMaterial.RepairConsumableMaterialNQL_Class>("RepairConsumableMaterialNQL", RepairConsumedMaterial.RepairConsumableMaterialNQL((Guid)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
                return new TTReportNqlDataSet(ParentGroup, list);
            }

            private void onConstruct()
            {
                _header = null;
                _footer = null;
                _body = new MAINGroupBody(this);
                DataSourceType = DataSourceTypeEnum.dstSelfRS;
            }

            public partial class MAINGroupBody : TTReportSection
            {
                public MalzemeTalepFormu MyParentReport
                {
                    get { return (MalzemeTalepFormu)ParentReport; }
                }
                
                public TTReportField SNO;
                public TTReportField STOKNO;
                public TTReportField MALZEMENINADI;
                public TTReportField ATOLYEIHTIYACIMIKTAR;
                public TTReportField HARCANAN;
                public TTReportField IADE; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 13;
                    RepeatCount = 0;
                    
                    SNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 14, 0, 25, 13, false);
                    SNO.Name = "SNO";
                    SNO.DrawStyle = DrawStyleConstants.vbSolid;
                    SNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    SNO.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    SNO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    SNO.TextFont.Name = "Arial";
                    SNO.TextFont.CharSet = 162;
                    SNO.Value = @"{@counter@}";

                    STOKNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 25, 0, 54, 13, false);
                    STOKNO.Name = "STOKNO";
                    STOKNO.DrawStyle = DrawStyleConstants.vbSolid;
                    STOKNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    STOKNO.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    STOKNO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    STOKNO.TextFont.Name = "Arial";
                    STOKNO.TextFont.CharSet = 162;
                    STOKNO.Value = @"{#NATOSTOCKNO#}";

                    MALZEMENINADI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 54, 0, 142, 13, false);
                    MALZEMENINADI.Name = "MALZEMENINADI";
                    MALZEMENINADI.DrawStyle = DrawStyleConstants.vbSolid;
                    MALZEMENINADI.FieldType = ReportFieldTypeEnum.ftVariable;
                    MALZEMENINADI.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    MALZEMENINADI.TextFont.Name = "Arial";
                    MALZEMENINADI.TextFont.CharSet = 162;
                    MALZEMENINADI.Value = @"{#NAME#}";

                    ATOLYEIHTIYACIMIKTAR = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 142, 0, 162, 13, false);
                    ATOLYEIHTIYACIMIKTAR.Name = "ATOLYEIHTIYACIMIKTAR";
                    ATOLYEIHTIYACIMIKTAR.DrawStyle = DrawStyleConstants.vbSolid;
                    ATOLYEIHTIYACIMIKTAR.FieldType = ReportFieldTypeEnum.ftVariable;
                    ATOLYEIHTIYACIMIKTAR.TextFormat = @"#,###";
                    ATOLYEIHTIYACIMIKTAR.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    ATOLYEIHTIYACIMIKTAR.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ATOLYEIHTIYACIMIKTAR.TextFont.Name = "Arial";
                    ATOLYEIHTIYACIMIKTAR.TextFont.CharSet = 162;
                    ATOLYEIHTIYACIMIKTAR.Value = @"{#REQUESTAMOUNT#}";

                    HARCANAN = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 162, 0, 182, 13, false);
                    HARCANAN.Name = "HARCANAN";
                    HARCANAN.DrawStyle = DrawStyleConstants.vbSolid;
                    HARCANAN.FieldType = ReportFieldTypeEnum.ftVariable;
                    HARCANAN.TextFormat = @"#,###";
                    HARCANAN.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    HARCANAN.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    HARCANAN.TextFont.Name = "Arial";
                    HARCANAN.TextFont.CharSet = 162;
                    HARCANAN.Value = @"{#SUPPLIEDAMOUNT#}";

                    IADE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 182, 0, 202, 13, false);
                    IADE.Name = "IADE";
                    IADE.DrawStyle = DrawStyleConstants.vbSolid;
                    IADE.FieldType = ReportFieldTypeEnum.ftVariable;
                    IADE.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    IADE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    IADE.TextFont.Name = "Arial";
                    IADE.TextFont.CharSet = 162;
                    IADE.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    RepairConsumedMaterial.RepairConsumableMaterialNQL_Class dataset_RepairConsumableMaterialNQL = ParentGroup.rsGroup.GetCurrentRecord<RepairConsumedMaterial.RepairConsumableMaterialNQL_Class>(0);
                    SNO.CalcValue = ParentGroup.Counter.ToString();
                    STOKNO.CalcValue = (dataset_RepairConsumableMaterialNQL != null ? Globals.ToStringCore(dataset_RepairConsumableMaterialNQL.NATOStockNO) : "");
                    MALZEMENINADI.CalcValue = (dataset_RepairConsumableMaterialNQL != null ? Globals.ToStringCore(dataset_RepairConsumableMaterialNQL.Name) : "");
                    ATOLYEIHTIYACIMIKTAR.CalcValue = (dataset_RepairConsumableMaterialNQL != null ? Globals.ToStringCore(dataset_RepairConsumableMaterialNQL.RequestAmount) : "");
                    HARCANAN.CalcValue = (dataset_RepairConsumableMaterialNQL != null ? Globals.ToStringCore(dataset_RepairConsumableMaterialNQL.SuppliedAmount) : "");
                    IADE.CalcValue = @"";
                    return new TTReportObject[] { SNO,STOKNO,MALZEMENINADI,ATOLYEIHTIYACIMIKTAR,HARCANAN,IADE};
                }
            }

        }

        public MAINGroup MAIN;

        private ReportRuntimeParameters _runtimeParameters;
        public ReportRuntimeParameters RuntimeParameters
        {
            get { return _runtimeParameters; }
        }

        public MalzemeTalepFormu()
        {
            Part1 = new Part1Group(this,"Part1");
            MAIN = new MAINGroup(Part1,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("TTOBJECTID", "00000000-0000-0000-0000-000000000000", "", @"", true, true, false, new Guid("b91c9866-f2fe-44bc-9d36-ae524ee4d2ef"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("TTOBJECTID"))
                _runtimeParameters.TTOBJECTID = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(parameters["TTOBJECTID"]);
            Name = "MALZEMETALEPFORMU";
            Caption = "Malzeme Talep Formu";
            FieldDefaults = SetFieldDefaultProperties();
            RTFDefaults = SetRTFDefaultProperties();
            HTMLDefaults = SetHTMLDefaultProperties();
            ShapeDefaults = SetShapeDefaultProperties();
            Orientation = OrientationEnum.oePortrait;
        }

        protected TTReportField SetFieldDefaultProperties()
        {
            TTReportField fd = new TTReportField();

            fd.Visible = EvetHayirEnum.ehEvet;
            fd.ForeColor = System.Drawing.Color.Black;
            fd.FillColor = System.Drawing.Color.White;
            fd.DrawStyle = DrawStyleConstants.vbInvisible;
            fd.FillStyle = FillStyleConstants.vbFSSolid;
            fd.DrawWidth = 1;

            fd.FieldType = ReportFieldTypeEnum.ftConstant;
            fd.CaseFormat = CaseFormatEnum.fcNoChange;
            fd.TextFormat = "";
            fd.TextColor = System.Drawing.Color.Black;
            fd.FontAngle = 0;
            fd.HorzAlign = HorizontalAlignmentEnum.haleft;
            fd.VertAlign = VerticalAlignmentEnum.vaTop;
            fd.MultiLine = EvetHayirEnum.ehHayir;
            fd.NoClip = EvetHayirEnum.ehHayir;
            fd.WordBreak = EvetHayirEnum.ehHayir;
            fd.ExpandTabs = EvetHayirEnum.ehHayir;
            fd.CrossTabRole = CrosstabRoleEnum.ctrNone;
            fd.CrossTabValues = "";
            fd.ExcelCol = 0;
            fd.ObjectDefName = "";
            fd.DataMember = "";
            fd.TextFont.Name = "Arial Narrow";
            fd.TextFont.Size = 10;
            fd.TextFont.Bold = false;
            fd.TextFont.Italic = false;
            fd.TextFont.Underline = false;
            fd.TextFont.Strikethrough = false;
            fd.TextFont.CharSet = 1;
            return fd;
        }

        protected TTReportRTF SetRTFDefaultProperties()
        {
            TTReportRTF fd = new TTReportRTF();

            fd.Visible = EvetHayirEnum.ehEvet;
            fd.ForeColor = System.Drawing.Color.Black;
            fd.FillColor = System.Drawing.Color.White;
            fd.DrawStyle = DrawStyleConstants.vbInvisible;
            fd.FillStyle = FillStyleConstants.vbFSSolid;
            fd.DrawWidth = 1;

            fd.CanExpand = EvetHayirEnum.ehEvet;
            fd.CanShrink = EvetHayirEnum.ehEvet;
            fd.CanSplit = EvetHayirEnum.ehEvet;
            fd.EvaluateValue = EvetHayirEnum.ehHayir;
            return fd;
        }

        protected TTReportHTML SetHTMLDefaultProperties()
        {
            TTReportHTML fd = new TTReportHTML();

            fd.Visible = EvetHayirEnum.ehEvet;
            fd.ForeColor = System.Drawing.Color.Black;
            fd.FillColor = System.Drawing.Color.White;
            fd.DrawStyle = DrawStyleConstants.vbInvisible;
            fd.FillStyle = FillStyleConstants.vbFSSolid;
            fd.DrawWidth = 1;

            fd.CanExpand = EvetHayirEnum.ehEvet;
            fd.CanShrink = EvetHayirEnum.ehEvet;
            fd.CanSplit = EvetHayirEnum.ehEvet;
            fd.EvaluateValue = EvetHayirEnum.ehHayir;
            return fd;
        }

        protected TTReportShape SetShapeDefaultProperties()
        {
            TTReportShape fd = new TTReportShape();

            fd.Visible = EvetHayirEnum.ehEvet;
            fd.ForeColor = System.Drawing.Color.Black;
            fd.FillColor = System.Drawing.Color.White;
            fd.DrawStyle = DrawStyleConstants.vbSolid;
            fd.FillStyle = FillStyleConstants.vbFSSolid;
            fd.DrawWidth = 1;
            return fd;
        }

    }
}