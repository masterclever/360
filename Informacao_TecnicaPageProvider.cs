using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Globalization;
using PROJETO;
using COMPONENTS;
using COMPONENTS.Data;
using COMPONENTS.Security;
using COMPONENTS.Configuration;
using System.IO;
using System.Web;
using System.Web.UI;
using PROJETO.DataProviders;
using PROJETO.DataPages;
using Telerik.Web.UI;


namespace PROJETO.DataProviders
{
	/// <summary>
	/// Classe de provider usada para a tabela auxiliar
	/// </summary>
	public class Informacao_TecnicaPageProvider : GeneralProvider
	{
		public Informacion_tecnica_Grid1GridDataProvider Informacion_tecnica_Grid1Provider;

		public Informacao_TecnicaPageProvider(IGeneralDataProvider Provider)
		{
			MainProvider = Provider;
			MainProvider.DataProvider = new _25246FASTRAX_TB_ASISTENCIADataProvider(MainProvider, MainProvider.TableName, MainProvider.DatabaseName, "PK_TB_ASISTENCIA", "Informacao_Tecnica");
			MainProvider.DataProvider.PageProvider = this;
			Informacion_tecnica_Grid1Provider = new Informacion_tecnica_Grid1GridDataProvider(this);
			Informacion_tecnica_Grid1Provider.SetRelationFields += new GeneralGridProvider.SetRelationFieldsEventHandler(Informacion_tecnica_Grid1Provider_SetRelationFields);
			Informacion_tecnica_Grid1Provider.SetRelationParameters += new GeneralGridProvider.SetRelationParametersEventHandler(Informacion_tecnica_Grid1Provider_SetRelationParameters);
		}


		private void Informacion_tecnica_Grid1Provider_SetRelationParameters(object sender)
		{
			try
			{
				if (MainProvider.DataProvider.Item == null)
				{
					MainProvider.DataProvider.Item = MainProvider.LoadItemFromControl(false);
				}
				Informacion_tecnica_Grid1Provider.DataProvider.Parameters["ASIS_ID"].Parameter.SetValue(MainProvider.DataProvider.Item["ASIS_ID"].Value);
			}
			catch (Exception)
			{
			}
		}

		private void Informacion_tecnica_Grid1Provider_SetRelationFields(object sender, GeneralDataProviderItem Item)
		{
			try
			{
				if (MainProvider.DataProvider.Item == null)
				{
					MainProvider.DataProvider.Item = MainProvider.LoadItemFromControl(false);
				}
				Item.SetFieldValue(Item["ASIS_ID"], MainProvider.DataProvider.Item["ASIS_ID"].Value);
				Informacion_tecnica_Grid1Provider.AliasVariables = new Dictionary<string, object>();
			}
			catch (Exception)
			{
			}
		}



		public override GeneralDataProviderItem GetDataProviderItem(GeneralDataProvider Provider)
		{
			if (Provider == MainProvider.DataProvider)
			{ 
				return new _25246FASTRAX_TB_ASISTENCIAItem(MainProvider.DatabaseName);
			}
			return null;
		}

		public override void FillAuxiliarTables()
		{
		}

		public override int GetMaxProcessLanc()
		{
			return 1;
		}
		
		public override void GetTableIdentity()
		{
			MainProvider.DataProvider.FindRecord("PK_TB_ASISTENCIA", false,new string[] { MainProvider.DataProvider.Dao.GetIdentity(MainProvider.TableName , "ASIS_ID") });
		}

		public override string CreateProcessBeforeInsert(string FieldName)
		{
			return "";
		}

		public override void CreateProcess(int Pos)
		{
			CreateProcess("",true, Pos);
		}

		public void ExecuteSingleProcess(string ProcessName)
        {
            CreateProcess(ProcessName, false);
            List<Process> ProcList = new List<Process>(Process.Values);
            if (ProcList.Count > 0)
                DataProcessEntry.ExecuteProcess(ProcList, MainProvider.DataProvider.Dao);
        }
		
		public void CreateProcess(string ProcessName, bool AllProcess)
		{
			CreateProcess(ProcessName, AllProcess, -1);
		}

		public void CreateProcess(string ProcessName, bool AllProcess, int Pos)
		{
			string RelationField = "";
			object ValueField = "";
			object RawValue = "";
			GeneralDataProviderItem Item;
			Process = new Dictionary<string, Process>();
			Process.Clear();
		}

		public override void CreateReverseProcess(int Pos , string SituationProcess)
		{
			string RelationField = "";
			object ValueField = "";
			object RawValue = "";
			GeneralDataProviderItem Item;
			ReverseProcess = new Dictionary<string, Process>();
			ReverseProcess.Clear();
			var situationP = new Dictionary<string, bool>();
		}

		public override void CreateEntries(EntryCommand EntryCommand)
		{   
			Entries = new Dictionary<string, Entry>();
			Entries.Clear();
			if (EntryCommand == EntryCommand.Insert || EntryCommand == EntryCommand.Update)
            {
			}				
			else if (EntryCommand == EntryCommand.Delete)
            {
            }
		}
		
		public override void CreateEntriesItems(Entry Entry,int vgNparc)
		{
			Entry.EntryItems.Clear(); 
			object ValueField="";
			switch (Entry.Title)
			{
				default:
					break;
			}
		}


		/// <summary>
		/// Valida se todos os campos foram preenchidos corretamente
		/// </summary>
		/// <param name="provider">Provider que vai ser usado para carregar os itens da p?gina</param>
		public override bool Validate(GeneralDataProviderItem ProviderItem)
		{
			return (ProviderItem.Errors.Count == 0);
		}
		


	}
	/// <summary>
	/// Classe de provider usada para acessar a tabela principal do grid
	/// </summary>
	public class Informacion_tecnica_Grid1GridDataProvider : GeneralGridProvider
	{
		public string INFTECField;
		public string OBSField;
		public string OBS2Field;
		public long LOJACORField;
		public long ASIS_IDField;
		public long ANOField;
		public long NOTASAIField;
		public long NOTAENTField;
		public long ORDNUMField;
		public DateTime FECHA_CIERREField;
		public DateTime DataKONField;
		public DateTime FECHA_PREVISTAField;
		public DateTime FECHA_VENTAField;
		public DateTime DataSITField;
		public DateTime FECHA_ENTRADAField;
		public long DIAS_RETORNOField;
		public long DIAS_PARADOField;
		public long CLI_CODFASTRAXField;
		public string NOMCLIField;
		public long PROD_CODFASTRAXField;
		public string NOMEField;
		public int QuantField;
		public string PROD_OSField;
		public double VALORField;
		public double COSTOField;
		public string MARCPROField;
		public string NOMMARCField;
		public int FORPROField;
		public string NOMFORField;
		public string SERIEField;
		public string StatusField;
		public string GARANTIAField;
		public string CONTATOField;
		public string INFORMEField;
		public string VENDEDORField;

		#region GeneralGridProvider Members

		public override int GetMaxProcessLanc()
		{
			return 1;
		}
		private _25246FASTRAX_TB_ASISTENCIADataProvider _DataProvider;
		
		public override GeneralDataProvider DataProvider
		{
			get
			{
				return _DataProvider;
			}
			set
			{
				_DataProvider = value as _25246FASTRAX_TB_ASISTENCIADataProvider;
			}
		}

		public Informacao_TecnicaPageProvider ParentPageProvider;
		
		public override string TableName { get { return "TB_ASISTENCIA"; } }

		public override string DatabaseName { get { return "25246FASTRAX"; } }

		public override string FormID { get { return "32499"; } }
		
		public override void SetOldParameters(GeneralDataProviderItem Item)
		{
		}

		/// <summary>
		/// Valida se todos os campos do GRID foram preenchidos corretamente
		/// </summary>
		/// <param name="provider">Provider que vai ser usado para carregar os itens da página</param>
		public override bool Validate(GeneralDataProviderItem ProviderItem)
		{
			return (ProviderItem.Errors.Count == 0);
		}		
		
		#endregion

		public Informacion_tecnica_Grid1GridDataProvider(Informacao_TecnicaPageProvider ParentProvider)
		{
			ParentPageProvider = ParentProvider;
			DataProvider = new _25246FASTRAX_TB_ASISTENCIADataProvider(this, TableName, DatabaseName, "PK_TB_ASISTENCIA", "Informacion_tecnica_Grid1");
			MainProvider = this;
			MainProvider.DataProvider.PageProvider = this;
			ParentPageProvider.MainProvider.DataProvider.Dao = MainProvider.DataProvider.Dao;
		}
		public _25246FASTRAX_TB_ASISTENCIAItem GetDataProviderItem()
		{
			return GetDataProviderItem(MainProvider.DataProvider) as _25246FASTRAX_TB_ASISTENCIAItem;
		}

		public override GeneralDataProviderItem GetDataProviderItem(GeneralDataProvider Provider)
		{
			if (Provider.Name == "Informacion_tecnica_Grid1")
			{
				return new _25246FASTRAX_TB_ASISTENCIAItem(DatabaseName);
			}
			return null;
		}

		public override void RefreshParentProvider(GeneralProvider ParentProvider)
		{
		ParentPageProvider = (Informacao_TecnicaPageProvider)ParentProvider;
		}

		public override void InitializeAlias(GeneralDataProviderItem Item)
		{
			if (AliasVariables == null)
			{
				AliasVariables = new Dictionary<string, object>();
			}
			INFTECField = Convert.ToString(Item["INFTEC"].GetValue(),CultureInfo.CurrentCulture);
			if (AliasVariables.ContainsKey("INFTECField"))
			{
				AliasVariables["INFTECField"] = INFTECField;
			}
			else
			{
				AliasVariables.Add("INFTECField" ,INFTECField);
			}
			OBSField = Convert.ToString(Item["OBS"].GetValue(),CultureInfo.CurrentCulture);
			if (AliasVariables.ContainsKey("OBSField"))
			{
				AliasVariables["OBSField"] = OBSField;
			}
			else
			{
				AliasVariables.Add("OBSField" ,OBSField);
			}
			OBS2Field = Convert.ToString(Item["OBS2"].GetValue(),CultureInfo.CurrentCulture);
			if (AliasVariables.ContainsKey("OBS2Field"))
			{
				AliasVariables["OBS2Field"] = OBS2Field;
			}
			else
			{
				AliasVariables.Add("OBS2Field" ,OBS2Field);
			}
			LOJACORField = Convert.ToInt64(Item["LOJACOR"].GetValue(),CultureInfo.CurrentCulture);
			if (AliasVariables.ContainsKey("LOJACORField"))
			{
				AliasVariables["LOJACORField"] = LOJACORField;
			}
			else
			{
				AliasVariables.Add("LOJACORField" ,LOJACORField);
			}
			ASIS_IDField = Convert.ToInt64(Item["ASIS_ID"].GetValue(),CultureInfo.CurrentCulture);
			if (AliasVariables.ContainsKey("ASIS_IDField"))
			{
				AliasVariables["ASIS_IDField"] = ASIS_IDField;
			}
			else
			{
				AliasVariables.Add("ASIS_IDField" ,ASIS_IDField);
			}
			ANOField = Convert.ToInt64(Item["ANO"].GetValue(),CultureInfo.CurrentCulture);
			if (AliasVariables.ContainsKey("ANOField"))
			{
				AliasVariables["ANOField"] = ANOField;
			}
			else
			{
				AliasVariables.Add("ANOField" ,ANOField);
			}
			NOTASAIField = Convert.ToInt64(Item["NOTASAI"].GetValue(),CultureInfo.CurrentCulture);
			if (AliasVariables.ContainsKey("NOTASAIField"))
			{
				AliasVariables["NOTASAIField"] = NOTASAIField;
			}
			else
			{
				AliasVariables.Add("NOTASAIField" ,NOTASAIField);
			}
			NOTAENTField = Convert.ToInt64(Item["NOTAENT"].GetValue(),CultureInfo.CurrentCulture);
			if (AliasVariables.ContainsKey("NOTAENTField"))
			{
				AliasVariables["NOTAENTField"] = NOTAENTField;
			}
			else
			{
				AliasVariables.Add("NOTAENTField" ,NOTAENTField);
			}
			ORDNUMField = Convert.ToInt64(Item["ORDNUM"].GetValue(),CultureInfo.CurrentCulture);
			if (AliasVariables.ContainsKey("ORDNUMField"))
			{
				AliasVariables["ORDNUMField"] = ORDNUMField;
			}
			else
			{
				AliasVariables.Add("ORDNUMField" ,ORDNUMField);
			}
			FECHA_CIERREField = Convert.ToDateTime(Item["FECHA_CIERRE"].GetValue(),CultureInfo.CurrentCulture);
			if (AliasVariables.ContainsKey("FECHA_CIERREField"))
			{
				AliasVariables["FECHA_CIERREField"] = FECHA_CIERREField;
			}
			else
			{
				AliasVariables.Add("FECHA_CIERREField" ,FECHA_CIERREField);
			}
			DataKONField = Convert.ToDateTime(Item["DataKON"].GetValue(),CultureInfo.CurrentCulture);
			if (AliasVariables.ContainsKey("DataKONField"))
			{
				AliasVariables["DataKONField"] = DataKONField;
			}
			else
			{
				AliasVariables.Add("DataKONField" ,DataKONField);
			}
			FECHA_PREVISTAField = Convert.ToDateTime(Item["FECHA_PREVISTA"].GetValue(),CultureInfo.CurrentCulture);
			if (AliasVariables.ContainsKey("FECHA_PREVISTAField"))
			{
				AliasVariables["FECHA_PREVISTAField"] = FECHA_PREVISTAField;
			}
			else
			{
				AliasVariables.Add("FECHA_PREVISTAField" ,FECHA_PREVISTAField);
			}
			FECHA_VENTAField = Convert.ToDateTime(Item["FECHA_VENTA"].GetValue(),CultureInfo.CurrentCulture);
			if (AliasVariables.ContainsKey("FECHA_VENTAField"))
			{
				AliasVariables["FECHA_VENTAField"] = FECHA_VENTAField;
			}
			else
			{
				AliasVariables.Add("FECHA_VENTAField" ,FECHA_VENTAField);
			}
			DataSITField = Convert.ToDateTime(Item["DataSIT"].GetValue(),CultureInfo.CurrentCulture);
			if (AliasVariables.ContainsKey("DataSITField"))
			{
				AliasVariables["DataSITField"] = DataSITField;
			}
			else
			{
				AliasVariables.Add("DataSITField" ,DataSITField);
			}
			FECHA_ENTRADAField = Convert.ToDateTime(Item["FECHA_ENTRADA"].GetValue(),CultureInfo.CurrentCulture);
			if (AliasVariables.ContainsKey("FECHA_ENTRADAField"))
			{
				AliasVariables["FECHA_ENTRADAField"] = FECHA_ENTRADAField;
			}
			else
			{
				AliasVariables.Add("FECHA_ENTRADAField" ,FECHA_ENTRADAField);
			}
			DIAS_RETORNOField = Convert.ToInt64(Item["DIAS_RETORNO"].GetValue(),CultureInfo.CurrentCulture);
			if (AliasVariables.ContainsKey("DIAS_RETORNOField"))
			{
				AliasVariables["DIAS_RETORNOField"] = DIAS_RETORNOField;
			}
			else
			{
				AliasVariables.Add("DIAS_RETORNOField" ,DIAS_RETORNOField);
			}
			DIAS_PARADOField = Convert.ToInt64(Item["DIAS_PARADO"].GetValue(),CultureInfo.CurrentCulture);
			if (AliasVariables.ContainsKey("DIAS_PARADOField"))
			{
				AliasVariables["DIAS_PARADOField"] = DIAS_PARADOField;
			}
			else
			{
				AliasVariables.Add("DIAS_PARADOField" ,DIAS_PARADOField);
			}
			CLI_CODFASTRAXField = Convert.ToInt64(Item["CLI_CODFASTRAX"].GetValue(),CultureInfo.CurrentCulture);
			if (AliasVariables.ContainsKey("CLI_CODFASTRAXField"))
			{
				AliasVariables["CLI_CODFASTRAXField"] = CLI_CODFASTRAXField;
			}
			else
			{
				AliasVariables.Add("CLI_CODFASTRAXField" ,CLI_CODFASTRAXField);
			}
			NOMCLIField = Convert.ToString(Item["NOMCLI"].GetValue(),CultureInfo.CurrentCulture);
			if (AliasVariables.ContainsKey("NOMCLIField"))
			{
				AliasVariables["NOMCLIField"] = NOMCLIField;
			}
			else
			{
				AliasVariables.Add("NOMCLIField" ,NOMCLIField);
			}
			PROD_CODFASTRAXField = Convert.ToInt64(Item["PROD_CODFASTRAX"].GetValue(),CultureInfo.CurrentCulture);
			if (AliasVariables.ContainsKey("PROD_CODFASTRAXField"))
			{
				AliasVariables["PROD_CODFASTRAXField"] = PROD_CODFASTRAXField;
			}
			else
			{
				AliasVariables.Add("PROD_CODFASTRAXField" ,PROD_CODFASTRAXField);
			}
			NOMEField = Convert.ToString(Item["NOME"].GetValue(),CultureInfo.CurrentCulture);
			if (AliasVariables.ContainsKey("NOMEField"))
			{
				AliasVariables["NOMEField"] = NOMEField;
			}
			else
			{
				AliasVariables.Add("NOMEField" ,NOMEField);
			}
			QuantField = Convert.ToInt32(Item["Quant"].GetValue(),CultureInfo.CurrentCulture);
			if (AliasVariables.ContainsKey("QuantField"))
			{
				AliasVariables["QuantField"] = QuantField;
			}
			else
			{
				AliasVariables.Add("QuantField" ,QuantField);
			}
			PROD_OSField = Convert.ToString(Item["PROD_OS"].GetValue(),CultureInfo.CurrentCulture);
			if (AliasVariables.ContainsKey("PROD_OSField"))
			{
				AliasVariables["PROD_OSField"] = PROD_OSField;
			}
			else
			{
				AliasVariables.Add("PROD_OSField" ,PROD_OSField);
			}
			try{VALORField = Convert.ToDouble(Item["VALOR"].GetValue().ToString().Replace(".", ",") ,CultureInfo.CurrentCulture);}catch (Exception){}
			if (AliasVariables.ContainsKey("VALORField"))
			{
				AliasVariables["VALORField"] = VALORField;
			}
			else
			{
				AliasVariables.Add("VALORField" ,VALORField);
			}
			try{COSTOField = Convert.ToDouble(Item["COSTO"].GetValue().ToString().Replace(".", ",") ,CultureInfo.CurrentCulture);}catch (Exception){}
			if (AliasVariables.ContainsKey("COSTOField"))
			{
				AliasVariables["COSTOField"] = COSTOField;
			}
			else
			{
				AliasVariables.Add("COSTOField" ,COSTOField);
			}
			MARCPROField = Convert.ToString(Item["MARCPRO"].GetValue(),CultureInfo.CurrentCulture);
			if (AliasVariables.ContainsKey("MARCPROField"))
			{
				AliasVariables["MARCPROField"] = MARCPROField;
			}
			else
			{
				AliasVariables.Add("MARCPROField" ,MARCPROField);
			}
			NOMMARCField = Convert.ToString(Item["NOMMARC"].GetValue(),CultureInfo.CurrentCulture);
			if (AliasVariables.ContainsKey("NOMMARCField"))
			{
				AliasVariables["NOMMARCField"] = NOMMARCField;
			}
			else
			{
				AliasVariables.Add("NOMMARCField" ,NOMMARCField);
			}
			FORPROField = Convert.ToInt32(Item["FORPRO"].GetValue(),CultureInfo.CurrentCulture);
			if (AliasVariables.ContainsKey("FORPROField"))
			{
				AliasVariables["FORPROField"] = FORPROField;
			}
			else
			{
				AliasVariables.Add("FORPROField" ,FORPROField);
			}
			NOMFORField = Convert.ToString(Item["NOMFOR"].GetValue(),CultureInfo.CurrentCulture);
			if (AliasVariables.ContainsKey("NOMFORField"))
			{
				AliasVariables["NOMFORField"] = NOMFORField;
			}
			else
			{
				AliasVariables.Add("NOMFORField" ,NOMFORField);
			}
			SERIEField = Convert.ToString(Item["SERIE"].GetValue(),CultureInfo.CurrentCulture);
			if (AliasVariables.ContainsKey("SERIEField"))
			{
				AliasVariables["SERIEField"] = SERIEField;
			}
			else
			{
				AliasVariables.Add("SERIEField" ,SERIEField);
			}
			StatusField = Convert.ToString(Item["Status"].GetValue(),CultureInfo.CurrentCulture);
			if (AliasVariables.ContainsKey("StatusField"))
			{
				AliasVariables["StatusField"] = StatusField;
			}
			else
			{
				AliasVariables.Add("StatusField" ,StatusField);
			}
			GARANTIAField = Convert.ToString(Item["GARANTIA"].GetValue(),CultureInfo.CurrentCulture);
			if (AliasVariables.ContainsKey("GARANTIAField"))
			{
				AliasVariables["GARANTIAField"] = GARANTIAField;
			}
			else
			{
				AliasVariables.Add("GARANTIAField" ,GARANTIAField);
			}
			CONTATOField = Convert.ToString(Item["CONTATO"].GetValue(),CultureInfo.CurrentCulture);
			if (AliasVariables.ContainsKey("CONTATOField"))
			{
				AliasVariables["CONTATOField"] = CONTATOField;
			}
			else
			{
				AliasVariables.Add("CONTATOField" ,CONTATOField);
			}
			INFORMEField = Convert.ToString(Item["INFORME"].GetValue(),CultureInfo.CurrentCulture);
			if (AliasVariables.ContainsKey("INFORMEField"))
			{
				AliasVariables["INFORMEField"] = INFORMEField;
			}
			else
			{
				AliasVariables.Add("INFORMEField" ,INFORMEField);
			}
			VENDEDORField = Convert.ToString(Item["VENDEDOR"].GetValue(),CultureInfo.CurrentCulture);
			if (AliasVariables.ContainsKey("VENDEDORField"))
			{
				AliasVariables["VENDEDORField"] = VENDEDORField;
			}
			else
			{
				AliasVariables.Add("VENDEDORField" ,VENDEDORField);
			}
			FillAuxiliarTables();
		}
		
		
		public override void GetTableIdentity()
		{
			MainProvider.DataProvider.FindRecord("PK_TB_ASISTENCIA", false,new string[] { MainProvider.DataProvider.Dao.GetIdentity(MainProvider.TableName , "ASIS_ID") });
		}

		public override void PositionParentsProvider()
        {
			ParentPageProvider.MainProvider.DataProvider.Dao = MainProvider.DataProvider.Dao;
            ParentPageProvider.MainProvider.DataProvider.SelectItem(ParentPageProvider.MainProvider.DataProvider.PageNumber, FormPositioningEnum.Current);
        }

		public override string CreateProcessBeforeInsert(string FieldName)
		{
			return "";
		}

		public override void CreateProcess(int Pos)
		{
			CreateProcess("",true, Pos);
		}

		public void CreateProcess(string ProcessName, bool AllProcess)
		{
			CreateProcess(ProcessName, AllProcess, -1);
		}

		public void CreateProcess(string ProcessName, bool AllProcess, int Pos)
		{
			string RelationField = "";
			object ValueField = "";
			object RawValue = "";
			GeneralDataProviderItem Item;
			Process = new Dictionary<string, Process>();
			Process.Clear();
			InitializeAlias(MainProvider.DataProvider.Item);
		}

		public override void CreateReverseProcess(int Pos, string SituationProcess)
		{
			CreateReverseProcess("", true, Pos, SituationProcess);
		}

		public void CreateReverseProcess(string ProcessName, bool AllProcess, int Pos, string SituationProcess)
		{
			string RelationField = "";
			object ValueField = "";
			object RawValue = "";
			GeneralDataProviderItem Item;
			ReverseProcess = new Dictionary<string, Process>();
			ReverseProcess.Clear();
			var situationP = new Dictionary<string, bool>();
		}

		public override void CreateEntries(EntryCommand EntryCommand)
		{   
			Entries = new Dictionary<string, Entry>();
			Entries.Clear();
			if (EntryCommand == EntryCommand.Insert || EntryCommand == EntryCommand.Update)
            {
			}				
			else if (EntryCommand == EntryCommand.Delete)
            {
            }
		}
		
		public override void CreateEntriesItems(Entry Entry,int vgNparc)
		{
			Entry.EntryItems.Clear(); 
			string ValueField="";
			switch (Entry.Title)
			{
				default:
					break;
			}
		}

}

}
