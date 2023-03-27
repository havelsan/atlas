
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
    /// İdari Husus Raporu
    /// </summary>
    public partial class ManagerialMatterReport : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public string TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue("");
        }

        public partial class PARTAGroup : TTReportGroup
        {
            public ManagerialMatterReport MyParentReport
            {
                get { return (ManagerialMatterReport)ParentReport; }
            }

            new public PARTAGroupHeader Header()
            {
                return (PARTAGroupHeader)_header;
            }

            new public PARTAGroupFooter Footer()
            {
                return (PARTAGroupFooter)_footer;
            }

            public TTReportField REPORTNAME1 { get {return Header().REPORTNAME1;} }
            public TTReportField NewField1131 { get {return Header().NewField1131;} }
            public TTReportField NewField1132 { get {return Header().NewField1132;} }
            public TTReportField NewField1133 { get {return Header().NewField1133;} }
            public TTReportField NewField1134 { get {return Header().NewField1134;} }
            public TTReportField NewField1135 { get {return Header().NewField1135;} }
            public TTReportField NewField1 { get {return Header().NewField1;} }
            public TTReportField NewField1136 { get {return Header().NewField1136;} }
            public TTReportField NewField1137 { get {return Header().NewField1137;} }
            public TTReportField NewField17311 { get {return Header().NewField17311;} }
            public TTReportField NewField17312 { get {return Header().NewField17312;} }
            public TTReportField NewField17313 { get {return Header().NewField17313;} }
            public TTReportField NewField17314 { get {return Header().NewField17314;} }
            public TTReportField NewField17315 { get {return Header().NewField17315;} }
            public TTReportField NewField17316 { get {return Header().NewField17316;} }
            public TTReportField NewField17317 { get {return Header().NewField17317;} }
            public TTReportField NewField171371 { get {return Header().NewField171371;} }
            public TTReportField NewField12311 { get {return Header().NewField12311;} }
            public TTReportField NewField111321 { get {return Header().NewField111321;} }
            public TTReportField NewField111322 { get {return Header().NewField111322;} }
            public TTReportField NewField111323 { get {return Header().NewField111323;} }
            public TTReportField NewField111324 { get {return Header().NewField111324;} }
            public TTReportField HOSPITALNAME { get {return Header().HOSPITALNAME;} }
            public TTReportField STORENAME { get {return Header().STORENAME;} }
            public TTReportField DEMANDDATE { get {return Header().DEMANDDATE;} }
            public TTReportField REQUESTNO { get {return Header().REQUESTNO;} }
            public TTReportField DEMANDTYPE { get {return Header().DEMANDTYPE;} }
            public TTReportField DESCRIPTION { get {return Header().DESCRIPTION;} }
            public PARTAGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public PARTAGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

             
            protected override TTReportNqlDataSet GetReportNqlDataSet()
            {
                TTBaseReportNqlData[] list = new TTBaseReportNqlData[1];
                list[0] = new TTReportNqlData<Demand.SatınalmaIstek_DemandQuery_Class>("SatınalmaIstek_DemandQuery", Demand.SatınalmaIstek_DemandQuery((string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
                return new TTReportNqlDataSet(ParentGroup, list);
            }

            private void onConstruct()
            {
                _body = null;
                _header = new PARTAGroupHeader(this);
                _footer = new PARTAGroupFooter(this);

                DataSourceType = DataSourceTypeEnum.dstSelfRS;
            }

            public partial class PARTAGroupHeader : TTReportSection
            {
                public ManagerialMatterReport MyParentReport
                {
                    get { return (ManagerialMatterReport)ParentReport; }
                }
                
                public TTReportField REPORTNAME1;
                public TTReportField NewField1131;
                public TTReportField NewField1132;
                public TTReportField NewField1133;
                public TTReportField NewField1134;
                public TTReportField NewField1135;
                public TTReportField NewField1;
                public TTReportField NewField1136;
                public TTReportField NewField1137;
                public TTReportField NewField17311;
                public TTReportField NewField17312;
                public TTReportField NewField17313;
                public TTReportField NewField17314;
                public TTReportField NewField17315;
                public TTReportField NewField17316;
                public TTReportField NewField17317;
                public TTReportField NewField171371;
                public TTReportField NewField12311;
                public TTReportField NewField111321;
                public TTReportField NewField111322;
                public TTReportField NewField111323;
                public TTReportField NewField111324;
                public TTReportField HOSPITALNAME;
                public TTReportField STORENAME;
                public TTReportField DEMANDDATE;
                public TTReportField REQUESTNO;
                public TTReportField DEMANDTYPE;
                public TTReportField DESCRIPTION; 
                public PARTAGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 78;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    REPORTNAME1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 1, 14, 269, 22, false);
                    REPORTNAME1.Name = "REPORTNAME1";
                    REPORTNAME1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    REPORTNAME1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    REPORTNAME1.TextFont.Name = "Arial";
                    REPORTNAME1.TextFont.Size = 12;
                    REPORTNAME1.TextFont.Bold = true;
                    REPORTNAME1.TextFont.CharSet = 162;
                    REPORTNAME1.Value = @"İDARİ HUSUS RAPORU";

                    NewField1131 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 1, 24, 19, 29, false);
                    NewField1131.Name = "NewField1131";
                    NewField1131.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1131.TextFont.Name = "Arial";
                    NewField1131.TextFont.Bold = true;
                    NewField1131.TextFont.CharSet = 162;
                    NewField1131.Value = @"Bölüm Adı";

                    NewField1132 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 1, 31, 19, 36, false);
                    NewField1132.Name = "NewField1132";
                    NewField1132.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1132.TextFont.Name = "Arial";
                    NewField1132.TextFont.Bold = true;
                    NewField1132.TextFont.CharSet = 162;
                    NewField1132.Value = @"Tarih";

                    NewField1133 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 1, 38, 19, 43, false);
                    NewField1133.Name = "NewField1133";
                    NewField1133.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1133.TextFont.Name = "Arial";
                    NewField1133.TextFont.Bold = true;
                    NewField1133.TextFont.CharSet = 162;
                    NewField1133.Value = @"İstek No";

                    NewField1134 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 1, 45, 19, 50, false);
                    NewField1134.Name = "NewField1134";
                    NewField1134.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1134.TextFont.Name = "Arial";
                    NewField1134.TextFont.Bold = true;
                    NewField1134.TextFont.CharSet = 162;
                    NewField1134.Value = @"İstek Türü";

                    NewField1135 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 1, 52, 19, 57, false);
                    NewField1135.Name = "NewField1135";
                    NewField1135.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1135.TextFont.Name = "Arial";
                    NewField1135.TextFont.Bold = true;
                    NewField1135.TextFont.CharSet = 162;
                    NewField1135.Value = @"Açıklama";

                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 1, 69, 10, 78, false);
                    NewField1.Name = "NewField1";
                    NewField1.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1.TextFont.Size = 9;
                    NewField1.TextFont.Bold = true;
                    NewField1.TextFont.CharSet = 162;
                    NewField1.Value = @"S.NO";

                    NewField1136 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 69, 74, 78, false);
                    NewField1136.Name = "NewField1136";
                    NewField1136.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1136.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1136.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1136.TextFont.Name = "Arial";
                    NewField1136.TextFont.Size = 9;
                    NewField1136.TextFont.Bold = true;
                    NewField1136.TextFont.CharSet = 162;
                    NewField1136.Value = @"MALZEME ADI";

                    NewField1137 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 74, 69, 97, 78, false);
                    NewField1137.Name = "NewField1137";
                    NewField1137.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1137.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1137.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1137.TextFont.Name = "Arial";
                    NewField1137.TextFont.Size = 9;
                    NewField1137.TextFont.Bold = true;
                    NewField1137.TextFont.CharSet = 162;
                    NewField1137.Value = @"NSN";

                    NewField17311 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 97, 69, 117, 78, false);
                    NewField17311.Name = "NewField17311";
                    NewField17311.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField17311.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField17311.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField17311.MultiLine = EvetHayirEnum.ehEvet;
                    NewField17311.WordBreak = EvetHayirEnum.ehEvet;
                    NewField17311.TextFont.Name = "Arial";
                    NewField17311.TextFont.Size = 9;
                    NewField17311.TextFont.Bold = true;
                    NewField17311.TextFont.CharSet = 162;
                    NewField17311.Value = @"AMBALAJ FORMU";

                    NewField17312 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 117, 69, 138, 78, false);
                    NewField17312.Name = "NewField17312";
                    NewField17312.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField17312.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField17312.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField17312.MultiLine = EvetHayirEnum.ehEvet;
                    NewField17312.WordBreak = EvetHayirEnum.ehEvet;
                    NewField17312.TextFont.Name = "Arial";
                    NewField17312.TextFont.Size = 9;
                    NewField17312.TextFont.Bold = true;
                    NewField17312.TextFont.CharSet = 162;
                    NewField17312.Value = @"İSTEK MİKTARI";

                    NewField17313 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 138, 69, 152, 78, false);
                    NewField17313.Name = "NewField17313";
                    NewField17313.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField17313.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField17313.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField17313.TextFont.Name = "Arial";
                    NewField17313.TextFont.Size = 9;
                    NewField17313.TextFont.Bold = true;
                    NewField17313.TextFont.CharSet = 162;
                    NewField17313.Value = @"BİRİMİ";

                    NewField17314 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 152, 69, 185, 78, false);
                    NewField17314.Name = "NewField17314";
                    NewField17314.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField17314.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField17314.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField17314.TextFont.Name = "Arial";
                    NewField17314.TextFont.Size = 9;
                    NewField17314.TextFont.Bold = true;
                    NewField17314.TextFont.CharSet = 162;
                    NewField17314.Value = @"TEKNİK ŞARTNAME";

                    NewField17315 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 185, 69, 209, 78, false);
                    NewField17315.Name = "NewField17315";
                    NewField17315.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField17315.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField17315.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField17315.TextFont.Name = "Arial";
                    NewField17315.TextFont.Size = 9;
                    NewField17315.TextFont.Bold = true;
                    NewField17315.TextFont.CharSet = 162;
                    NewField17315.Value = @"AÇIKLAMA";

                    NewField17316 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 209, 69, 239, 78, false);
                    NewField17316.Name = "NewField17316";
                    NewField17316.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField17316.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField17316.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField17316.TextFont.Name = "Arial";
                    NewField17316.TextFont.Size = 9;
                    NewField17316.TextFont.Bold = true;
                    NewField17316.TextFont.CharSet = 162;
                    NewField17316.Value = @"İDARİ HUSUSLAR";

                    NewField17317 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 239, 69, 254, 78, false);
                    NewField17317.Name = "NewField17317";
                    NewField17317.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField17317.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField17317.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField17317.MultiLine = EvetHayirEnum.ehEvet;
                    NewField17317.WordBreak = EvetHayirEnum.ehEvet;
                    NewField17317.TextFont.Name = "Arial";
                    NewField17317.TextFont.Size = 9;
                    NewField17317.TextFont.Bold = true;
                    NewField17317.TextFont.CharSet = 162;
                    NewField17317.Value = @"UBB KODU";

                    NewField171371 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 254, 69, 269, 78, false);
                    NewField171371.Name = "NewField171371";
                    NewField171371.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField171371.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField171371.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField171371.MultiLine = EvetHayirEnum.ehEvet;
                    NewField171371.WordBreak = EvetHayirEnum.ehEvet;
                    NewField171371.TextFont.Name = "Arial";
                    NewField171371.TextFont.Size = 9;
                    NewField171371.TextFont.Bold = true;
                    NewField171371.TextFont.CharSet = 162;
                    NewField171371.Value = @"SUT KODU";

                    NewField12311 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 20, 24, 22, 29, false);
                    NewField12311.Name = "NewField12311";
                    NewField12311.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField12311.TextFont.Name = "Arial";
                    NewField12311.TextFont.Bold = true;
                    NewField12311.TextFont.CharSet = 162;
                    NewField12311.Value = @":";

                    NewField111321 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 20, 31, 22, 36, false);
                    NewField111321.Name = "NewField111321";
                    NewField111321.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField111321.TextFont.Name = "Arial";
                    NewField111321.TextFont.Bold = true;
                    NewField111321.TextFont.CharSet = 162;
                    NewField111321.Value = @":";

                    NewField111322 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 20, 38, 22, 43, false);
                    NewField111322.Name = "NewField111322";
                    NewField111322.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField111322.TextFont.Name = "Arial";
                    NewField111322.TextFont.Bold = true;
                    NewField111322.TextFont.CharSet = 162;
                    NewField111322.Value = @":";

                    NewField111323 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 20, 45, 22, 50, false);
                    NewField111323.Name = "NewField111323";
                    NewField111323.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField111323.TextFont.Name = "Arial";
                    NewField111323.TextFont.Bold = true;
                    NewField111323.TextFont.CharSet = 162;
                    NewField111323.Value = @":";

                    NewField111324 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 20, 52, 22, 57, false);
                    NewField111324.Name = "NewField111324";
                    NewField111324.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField111324.TextFont.Name = "Arial";
                    NewField111324.TextFont.Bold = true;
                    NewField111324.TextFont.CharSet = 162;
                    NewField111324.Value = @":";

                    HOSPITALNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 1, 4, 269, 13, false);
                    HOSPITALNAME.Name = "HOSPITALNAME";
                    HOSPITALNAME.FieldType = ReportFieldTypeEnum.ftExpression;
                    HOSPITALNAME.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    HOSPITALNAME.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    HOSPITALNAME.TextFont.Size = 15;
                    HOSPITALNAME.TextFont.Bold = true;
                    HOSPITALNAME.TextFont.CharSet = 162;
                    HOSPITALNAME.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALNAME"", """")";

                    STORENAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 23, 24, 161, 29, false);
                    STORENAME.Name = "STORENAME";
                    STORENAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    STORENAME.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    STORENAME.TextFont.CharSet = 162;
                    STORENAME.Value = @"{#MASTERRESOURCE#}";

                    DEMANDDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 23, 31, 48, 36, false);
                    DEMANDDATE.Name = "DEMANDDATE";
                    DEMANDDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    DEMANDDATE.TextFormat = @"Short Date";
                    DEMANDDATE.TextFont.CharSet = 162;
                    DEMANDDATE.Value = @"{#DEMANDDATE#}";

                    REQUESTNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 23, 38, 48, 43, false);
                    REQUESTNO.Name = "REQUESTNO";
                    REQUESTNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    REQUESTNO.TextFont.CharSet = 162;
                    REQUESTNO.Value = @"{#REQUESTNO#}";

                    DEMANDTYPE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 23, 45, 48, 50, false);
                    DEMANDTYPE.Name = "DEMANDTYPE";
                    DEMANDTYPE.FieldType = ReportFieldTypeEnum.ftVariable;
                    DEMANDTYPE.ObjectDefName = "DemandTypeEnum";
                    DEMANDTYPE.DataMember = "DISPLAYTEXT";
                    DEMANDTYPE.TextFont.CharSet = 162;
                    DEMANDTYPE.Value = @"{#DEMANDTYPE#}";

                    DESCRIPTION = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 23, 52, 161, 64, false);
                    DESCRIPTION.Name = "DESCRIPTION";
                    DESCRIPTION.FieldType = ReportFieldTypeEnum.ftVariable;
                    DESCRIPTION.MultiLine = EvetHayirEnum.ehEvet;
                    DESCRIPTION.NoClip = EvetHayirEnum.ehEvet;
                    DESCRIPTION.WordBreak = EvetHayirEnum.ehEvet;
                    DESCRIPTION.TextFont.CharSet = 162;
                    DESCRIPTION.Value = @"{#DESCRIPTION#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    Demand.SatınalmaIstek_DemandQuery_Class dataset_SatınalmaIstek_DemandQuery = ParentGroup.rsGroup.GetCurrentRecord<Demand.SatınalmaIstek_DemandQuery_Class>(0);
                    REPORTNAME1.CalcValue = REPORTNAME1.Value;
                    NewField1131.CalcValue = NewField1131.Value;
                    NewField1132.CalcValue = NewField1132.Value;
                    NewField1133.CalcValue = NewField1133.Value;
                    NewField1134.CalcValue = NewField1134.Value;
                    NewField1135.CalcValue = NewField1135.Value;
                    NewField1.CalcValue = NewField1.Value;
                    NewField1136.CalcValue = NewField1136.Value;
                    NewField1137.CalcValue = NewField1137.Value;
                    NewField17311.CalcValue = NewField17311.Value;
                    NewField17312.CalcValue = NewField17312.Value;
                    NewField17313.CalcValue = NewField17313.Value;
                    NewField17314.CalcValue = NewField17314.Value;
                    NewField17315.CalcValue = NewField17315.Value;
                    NewField17316.CalcValue = NewField17316.Value;
                    NewField17317.CalcValue = NewField17317.Value;
                    NewField171371.CalcValue = NewField171371.Value;
                    NewField12311.CalcValue = NewField12311.Value;
                    NewField111321.CalcValue = NewField111321.Value;
                    NewField111322.CalcValue = NewField111322.Value;
                    NewField111323.CalcValue = NewField111323.Value;
                    NewField111324.CalcValue = NewField111324.Value;
                    STORENAME.CalcValue = (dataset_SatınalmaIstek_DemandQuery != null ? Globals.ToStringCore(dataset_SatınalmaIstek_DemandQuery.Masterresource) : "");
                    DEMANDDATE.CalcValue = (dataset_SatınalmaIstek_DemandQuery != null ? Globals.ToStringCore(dataset_SatınalmaIstek_DemandQuery.DemandDate) : "");
                    REQUESTNO.CalcValue = (dataset_SatınalmaIstek_DemandQuery != null ? Globals.ToStringCore(dataset_SatınalmaIstek_DemandQuery.RequestNo) : "");
                    DEMANDTYPE.CalcValue = (dataset_SatınalmaIstek_DemandQuery != null ? Globals.ToStringCore(dataset_SatınalmaIstek_DemandQuery.DemandType) : "");
                    DEMANDTYPE.PostFieldValueCalculation();
                    DESCRIPTION.CalcValue = (dataset_SatınalmaIstek_DemandQuery != null ? Globals.ToStringCore(dataset_SatınalmaIstek_DemandQuery.Description) : "");
                    HOSPITALNAME.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALNAME", "");
                    return new TTReportObject[] { REPORTNAME1,NewField1131,NewField1132,NewField1133,NewField1134,NewField1135,NewField1,NewField1136,NewField1137,NewField17311,NewField17312,NewField17313,NewField17314,NewField17315,NewField17316,NewField17317,NewField171371,NewField12311,NewField111321,NewField111322,NewField111323,NewField111324,STORENAME,DEMANDDATE,REQUESTNO,DEMANDTYPE,DESCRIPTION,HOSPITALNAME};
                }
            }
            public partial class PARTAGroupFooter : TTReportSection
            {
                public ManagerialMatterReport MyParentReport
                {
                    get { return (ManagerialMatterReport)ParentReport; }
                }
                 
                public PARTAGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 14;
                    RepeatCount = 0;
                    
                }
                
            }

        }

        public PARTAGroup PARTA;

        public partial class MAINGroup : TTReportGroup
        {
            public ManagerialMatterReport MyParentReport
            {
                get { return (ManagerialMatterReport)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField COUNTER { get {return Body().COUNTER;} }
            public TTReportField ITEMNAME { get {return Body().ITEMNAME;} }
            public TTReportField NSN { get {return Body().NSN;} }
            public TTReportField TYPENAME { get {return Body().TYPENAME;} }
            public TTReportField REQUESTAMOUNT { get {return Body().REQUESTAMOUNT;} }
            public TTReportField NewField131371 { get {return Body().NewField131371;} }
            public TTReportField TECHNICALSPECIFICATIONNO { get {return Body().TECHNICALSPECIFICATIONNO;} }
            public TTReportField DETAILDESCRIPTION { get {return Body().DETAILDESCRIPTION;} }
            public TTReportField SPREFTOADMATTERS { get {return Body().SPREFTOADMATTERS;} }
            public TTReportField NewField171371 { get {return Body().NewField171371;} }
            public TTReportField NewField1173171 { get {return Body().NewField1173171;} }
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
                list[0] = new TTReportNqlData<DemandDetail.GetManagerialMatterReportQuery_Class>("GetManagerialMatterReportQuery", DemandDetail.GetManagerialMatterReportQuery((string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
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
                public ManagerialMatterReport MyParentReport
                {
                    get { return (ManagerialMatterReport)ParentReport; }
                }
                
                public TTReportField COUNTER;
                public TTReportField ITEMNAME;
                public TTReportField NSN;
                public TTReportField TYPENAME;
                public TTReportField REQUESTAMOUNT;
                public TTReportField NewField131371;
                public TTReportField TECHNICALSPECIFICATIONNO;
                public TTReportField DETAILDESCRIPTION;
                public TTReportField SPREFTOADMATTERS;
                public TTReportField NewField171371;
                public TTReportField NewField1173171; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 5;
                    RepeatCount = 0;
                    
                    COUNTER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 1, 0, 10, 5, false);
                    COUNTER.Name = "COUNTER";
                    COUNTER.DrawStyle = DrawStyleConstants.vbSolid;
                    COUNTER.FieldType = ReportFieldTypeEnum.ftVariable;
                    COUNTER.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    COUNTER.TextFont.Size = 9;
                    COUNTER.TextFont.CharSet = 162;
                    COUNTER.Value = @"{@groupcounter@}";

                    ITEMNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 0, 74, 5, false);
                    ITEMNAME.Name = "ITEMNAME";
                    ITEMNAME.DrawStyle = DrawStyleConstants.vbSolid;
                    ITEMNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    ITEMNAME.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    ITEMNAME.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ITEMNAME.MultiLine = EvetHayirEnum.ehEvet;
                    ITEMNAME.WordBreak = EvetHayirEnum.ehEvet;
                    ITEMNAME.TextFont.Size = 9;
                    ITEMNAME.TextFont.CharSet = 162;
                    ITEMNAME.Value = @"{#ITEMNAME#}";

                    NSN = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 74, 0, 97, 5, false);
                    NSN.Name = "NSN";
                    NSN.DrawStyle = DrawStyleConstants.vbSolid;
                    NSN.FieldType = ReportFieldTypeEnum.ftVariable;
                    NSN.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NSN.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NSN.MultiLine = EvetHayirEnum.ehEvet;
                    NSN.WordBreak = EvetHayirEnum.ehEvet;
                    NSN.TextFont.Size = 9;
                    NSN.TextFont.CharSet = 162;
                    NSN.Value = @"{#NSN#}";

                    TYPENAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 97, 0, 117, 5, false);
                    TYPENAME.Name = "TYPENAME";
                    TYPENAME.DrawStyle = DrawStyleConstants.vbSolid;
                    TYPENAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    TYPENAME.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    TYPENAME.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    TYPENAME.MultiLine = EvetHayirEnum.ehEvet;
                    TYPENAME.WordBreak = EvetHayirEnum.ehEvet;
                    TYPENAME.TextFont.Size = 9;
                    TYPENAME.TextFont.CharSet = 162;
                    TYPENAME.Value = @"{#TYPENAME#}";

                    REQUESTAMOUNT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 117, 0, 138, 5, false);
                    REQUESTAMOUNT.Name = "REQUESTAMOUNT";
                    REQUESTAMOUNT.DrawStyle = DrawStyleConstants.vbSolid;
                    REQUESTAMOUNT.FieldType = ReportFieldTypeEnum.ftVariable;
                    REQUESTAMOUNT.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    REQUESTAMOUNT.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    REQUESTAMOUNT.MultiLine = EvetHayirEnum.ehEvet;
                    REQUESTAMOUNT.WordBreak = EvetHayirEnum.ehEvet;
                    REQUESTAMOUNT.TextFont.Size = 9;
                    REQUESTAMOUNT.TextFont.CharSet = 162;
                    REQUESTAMOUNT.Value = @"{#REQUESTAMOUNT#}";

                    NewField131371 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 138, 0, 152, 5, false);
                    NewField131371.Name = "NewField131371";
                    NewField131371.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField131371.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField131371.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField131371.MultiLine = EvetHayirEnum.ehEvet;
                    NewField131371.WordBreak = EvetHayirEnum.ehEvet;
                    NewField131371.TextFont.Size = 9;
                    NewField131371.TextFont.CharSet = 162;
                    NewField131371.Value = @"";

                    TECHNICALSPECIFICATIONNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 152, 0, 185, 5, false);
                    TECHNICALSPECIFICATIONNO.Name = "TECHNICALSPECIFICATIONNO";
                    TECHNICALSPECIFICATIONNO.DrawStyle = DrawStyleConstants.vbSolid;
                    TECHNICALSPECIFICATIONNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    TECHNICALSPECIFICATIONNO.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    TECHNICALSPECIFICATIONNO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    TECHNICALSPECIFICATIONNO.MultiLine = EvetHayirEnum.ehEvet;
                    TECHNICALSPECIFICATIONNO.WordBreak = EvetHayirEnum.ehEvet;
                    TECHNICALSPECIFICATIONNO.TextFont.Size = 9;
                    TECHNICALSPECIFICATIONNO.TextFont.CharSet = 162;
                    TECHNICALSPECIFICATIONNO.Value = @"{#TECHNICALSPECIFICATIONNO#}";

                    DETAILDESCRIPTION = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 185, 0, 209, 5, false);
                    DETAILDESCRIPTION.Name = "DETAILDESCRIPTION";
                    DETAILDESCRIPTION.DrawStyle = DrawStyleConstants.vbSolid;
                    DETAILDESCRIPTION.FieldType = ReportFieldTypeEnum.ftVariable;
                    DETAILDESCRIPTION.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    DETAILDESCRIPTION.MultiLine = EvetHayirEnum.ehEvet;
                    DETAILDESCRIPTION.WordBreak = EvetHayirEnum.ehEvet;
                    DETAILDESCRIPTION.TextFont.Size = 9;
                    DETAILDESCRIPTION.TextFont.CharSet = 162;
                    DETAILDESCRIPTION.Value = @"{#DETAILDESCRIPTION#}";

                    SPREFTOADMATTERS = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 209, 0, 239, 5, false);
                    SPREFTOADMATTERS.Name = "SPREFTOADMATTERS";
                    SPREFTOADMATTERS.DrawStyle = DrawStyleConstants.vbSolid;
                    SPREFTOADMATTERS.FieldType = ReportFieldTypeEnum.ftExpression;
                    SPREFTOADMATTERS.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    SPREFTOADMATTERS.MultiLine = EvetHayirEnum.ehEvet;
                    SPREFTOADMATTERS.WordBreak = EvetHayirEnum.ehEvet;
                    SPREFTOADMATTERS.TextFont.Size = 9;
                    SPREFTOADMATTERS.TextFont.CharSet = 162;
                    SPREFTOADMATTERS.Value = @"TTObjectClasses.Common.GetTextOfRTFString({#SPREFTOADMATTERS#})";

                    NewField171371 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 239, 0, 254, 5, false);
                    NewField171371.Name = "NewField171371";
                    NewField171371.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField171371.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField171371.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField171371.MultiLine = EvetHayirEnum.ehEvet;
                    NewField171371.WordBreak = EvetHayirEnum.ehEvet;
                    NewField171371.TextFont.Name = "Arial";
                    NewField171371.TextFont.Size = 9;
                    NewField171371.TextFont.Bold = true;
                    NewField171371.TextFont.CharSet = 162;
                    NewField171371.Value = @"";

                    NewField1173171 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 254, 0, 269, 5, false);
                    NewField1173171.Name = "NewField1173171";
                    NewField1173171.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1173171.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1173171.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1173171.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1173171.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1173171.TextFont.Name = "Arial";
                    NewField1173171.TextFont.Size = 9;
                    NewField1173171.TextFont.Bold = true;
                    NewField1173171.TextFont.CharSet = 162;
                    NewField1173171.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    DemandDetail.GetManagerialMatterReportQuery_Class dataset_GetManagerialMatterReportQuery = ParentGroup.rsGroup.GetCurrentRecord<DemandDetail.GetManagerialMatterReportQuery_Class>(0);
                    COUNTER.CalcValue = ParentGroup.GroupCounter.ToString();
                    ITEMNAME.CalcValue = (dataset_GetManagerialMatterReportQuery != null ? Globals.ToStringCore(dataset_GetManagerialMatterReportQuery.ItemName) : "");
                    NSN.CalcValue = (dataset_GetManagerialMatterReportQuery != null ? Globals.ToStringCore(dataset_GetManagerialMatterReportQuery.Nsn) : "");
                    TYPENAME.CalcValue = (dataset_GetManagerialMatterReportQuery != null ? Globals.ToStringCore(dataset_GetManagerialMatterReportQuery.Typename) : "");
                    REQUESTAMOUNT.CalcValue = (dataset_GetManagerialMatterReportQuery != null ? Globals.ToStringCore(dataset_GetManagerialMatterReportQuery.RequestAmount) : "");
                    NewField131371.CalcValue = NewField131371.Value;
                    TECHNICALSPECIFICATIONNO.CalcValue = (dataset_GetManagerialMatterReportQuery != null ? Globals.ToStringCore(dataset_GetManagerialMatterReportQuery.TechnicalSpecificationNo) : "");
                    DETAILDESCRIPTION.CalcValue = (dataset_GetManagerialMatterReportQuery != null ? Globals.ToStringCore(dataset_GetManagerialMatterReportQuery.DetailDescription) : "");
                    NewField171371.CalcValue = NewField171371.Value;
                    NewField1173171.CalcValue = NewField1173171.Value;
                    SPREFTOADMATTERS.CalcValue = TTObjectClasses.Common.GetTextOfRTFString((dataset_GetManagerialMatterReportQuery != null ? Globals.ToStringCore(dataset_GetManagerialMatterReportQuery.SpRefToAdMatters) : ""));
                    return new TTReportObject[] { COUNTER,ITEMNAME,NSN,TYPENAME,REQUESTAMOUNT,NewField131371,TECHNICALSPECIFICATIONNO,DETAILDESCRIPTION,NewField171371,NewField1173171,SPREFTOADMATTERS};
                }
            }

        }

        public MAINGroup MAIN;

        public partial class COMMISIONGroup : TTReportGroup
        {
            public ManagerialMatterReport MyParentReport
            {
                get { return (ManagerialMatterReport)ParentReport; }
            }

            new public COMMISIONGroupBody Body()
            {
                return (COMMISIONGroupBody)_body;
            }
            public TTReportField NAMESURNAME { get {return Body().NAMESURNAME;} }
            public TTReportField HOSPFUNC { get {return Body().HOSPFUNC;} }
            public TTReportField COMFUNC { get {return Body().COMFUNC;} }
            public TTReportField RANK { get {return Body().RANK;} }
            public COMMISIONGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public COMMISIONGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

             
            protected override TTReportNqlDataSet GetReportNqlDataSet()
            {
                TTBaseReportNqlData[] list = new TTBaseReportNqlData[1];
                list[0] = new TTReportNqlData<Demand.GetDemandTechCommissionQuery_Class>("GetDemandTechCommissionQuery", Demand.GetDemandTechCommissionQuery((string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
                return new TTReportNqlDataSet(ParentGroup, list);
            }

            private void onConstruct()
            {
                _header = null;
                _footer = null;
                _body = new COMMISIONGroupBody(this);
                DataSourceType = DataSourceTypeEnum.dstSelfRS;
            }

            public partial class COMMISIONGroupBody : TTReportSection
            {
                public ManagerialMatterReport MyParentReport
                {
                    get { return (ManagerialMatterReport)ParentReport; }
                }
                
                public TTReportField NAMESURNAME;
                public TTReportField HOSPFUNC;
                public TTReportField COMFUNC;
                public TTReportField RANK; 
                public COMMISIONGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 49;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 5;
                    RepeatWidth = 50;
                    
                    NAMESURNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 33, 45, 37, false);
                    NAMESURNAME.Name = "NAMESURNAME";
                    NAMESURNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    NAMESURNAME.CaseFormat = CaseFormatEnum.fcTitleCase;
                    NAMESURNAME.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NAMESURNAME.NoClip = EvetHayirEnum.ehEvet;
                    NAMESURNAME.TextFont.Name = "Arial";
                    NAMESURNAME.TextFont.CharSet = 162;
                    NAMESURNAME.Value = @"{#NAMESURNAME#}";

                    HOSPFUNC = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 38, 45, 42, false);
                    HOSPFUNC.Name = "HOSPFUNC";
                    HOSPFUNC.FieldType = ReportFieldTypeEnum.ftVariable;
                    HOSPFUNC.CaseFormat = CaseFormatEnum.fcTitleCase;
                    HOSPFUNC.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    HOSPFUNC.ObjectDefName = "UserTitleEnum";
                    HOSPFUNC.DataMember = "DISPLAYTEXT";
                    HOSPFUNC.TextFont.Name = "Arial";
                    HOSPFUNC.TextFont.CharSet = 162;
                    HOSPFUNC.Value = @"{#HOSPFUNC#}";

                    COMFUNC = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 23, 45, 27, false);
                    COMFUNC.Name = "COMFUNC";
                    COMFUNC.FieldType = ReportFieldTypeEnum.ftVariable;
                    COMFUNC.CaseFormat = CaseFormatEnum.fcUpperCase;
                    COMFUNC.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    COMFUNC.ObjectDefName = "CommisionMemberDutyEnum";
                    COMFUNC.DataMember = "DISPLAYTEXT";
                    COMFUNC.TextFont.Name = "Arial";
                    COMFUNC.TextFont.CharSet = 162;
                    COMFUNC.Value = @"{#COMFUNC#}";

                    RANK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 28, 45, 32, false);
                    RANK.Name = "RANK";
                    RANK.FieldType = ReportFieldTypeEnum.ftVariable;
                    RANK.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    RANK.NoClip = EvetHayirEnum.ehEvet;
                    RANK.TextFont.Name = "Arial";
                    RANK.TextFont.CharSet = 162;
                    RANK.Value = @"{#RANK#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    Demand.GetDemandTechCommissionQuery_Class dataset_GetDemandTechCommissionQuery = ParentGroup.rsGroup.GetCurrentRecord<Demand.GetDemandTechCommissionQuery_Class>(0);
                    NAMESURNAME.CalcValue = (dataset_GetDemandTechCommissionQuery != null ? Globals.ToStringCore(dataset_GetDemandTechCommissionQuery.Namesurname) : "");
                    HOSPFUNC.CalcValue = (dataset_GetDemandTechCommissionQuery != null ? Globals.ToStringCore(dataset_GetDemandTechCommissionQuery.Hospfunc) : "");
                    HOSPFUNC.PostFieldValueCalculation();
                    COMFUNC.CalcValue = (dataset_GetDemandTechCommissionQuery != null ? Globals.ToStringCore(dataset_GetDemandTechCommissionQuery.Comfunc) : "");
                    COMFUNC.PostFieldValueCalculation();
                    RANK.CalcValue = (dataset_GetDemandTechCommissionQuery != null ? Globals.ToStringCore(dataset_GetDemandTechCommissionQuery.Rank) : "");
                    return new TTReportObject[] { NAMESURNAME,HOSPFUNC,COMFUNC,RANK};
                }
            }

        }

        public COMMISIONGroup COMMISION;

        private ReportRuntimeParameters _runtimeParameters;
        public ReportRuntimeParameters RuntimeParameters
        {
            get { return _runtimeParameters; }
        }

        public ManagerialMatterReport()
        {
            PARTA = new PARTAGroup(this,"PARTA");
            MAIN = new MAINGroup(PARTA,"MAIN");
            COMMISION = new COMMISIONGroup(this,"COMMISION");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("TTOBJECTID", "", "İstek No", @"", true, true, false, new Guid("8c070a29-bd8b-41e9-a888-1108a97d2419"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("TTOBJECTID"))
                _runtimeParameters.TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(parameters["TTOBJECTID"]);
            Name = "MANAGERIALMATTERREPORT";
            Caption = "İdari Husus Raporu";
            FieldDefaults = SetFieldDefaultProperties();
            RTFDefaults = SetRTFDefaultProperties();
            HTMLDefaults = SetHTMLDefaultProperties();
            ShapeDefaults = SetShapeDefaultProperties();
            Orientation = OrientationEnum.oeLandscape;
            UserMarginLeft = 15;
            UserMarginTop = 15;
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