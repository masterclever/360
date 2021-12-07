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
	public class Clientes_SugeridoPageProvider : GeneralProvider
	{
		public Clientes_Sugeridos_Grid1GridDataProvider Clientes_Sugeridos_Grid1Provider;

		public Clientes_SugeridoPageProvider(IGeneralDataProvider Provider)
		{
			MainProvider = Provider;
			MainProvider.DataProvider = new _25246FASTRAX_VW_VENDAS_ULTCOMPDataProvider(MainProvider, MainProvider.TableName, MainProvider.DatabaseName, "", "Clientes_Sugerido");
			MainProvider.DataProvider.PageProvider = this;
			Clientes_Sugeridos_Grid1Provider = new Clientes_Sugeridos_Grid1GridDataProvider(this);
			Clientes_Sugeridos_Grid1Provider.SetRelationFields += new GeneralGridProvider.SetRelationFieldsEventHandler(Clientes_Sugeridos_Grid1Provider_SetRelationFields);
		}


		private void Clientes_Sugeridos_Grid1Provider_SetRelationFields(object sender, GeneralDataProviderItem Item)
		{
			try
			{
				if (MainProvider.DataProvider.Item == null)
				{
					MainProvider.DataProvider.Item = MainProvider.LoadItemFromControl(false);
				}
				Clientes_Sugeridos_Grid1Provider.AliasVariables = new Dictionary<string, object>();
			}
			catch (Exception)
			{
			}
		}



		public override GeneralDataProviderItem GetDataProviderItem(GeneralDataProvider Provider)
		{
			if (Provider == MainProvider.DataProvider)
			{ 
				return new _25246FASTRAX_VW_VENDAS_ULTCOMPItem(MainProvider.DatabaseName);
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
		
		public DataRow Grid1_GridColumn2_ComboBox_GetComboItem(string Value)
		{
			try
			{
				DataAccessObject Dao = Utility.GetDAO("25246FASTRAX");
				DataRow dr = Dao.RunSql(String.Format("SELECT TOP 1 " + "cast(" + Dao.PoeColAspas("CLI_CODFASTRAX") + " as varchar) " + " + '-' + " + Dao.PoeColAspas("CLI_NOME") +  " as DISPLAY_FIELD, " + Dao.PoeColAspas("CLI_CODFASTRAX") + " FROM  " + Dao.PoeColAspas("TB_CLIENTE") + " WHERE " + Dao.PoeColAspas("CLI_CODFASTRAX") + " = '{0}'", Value)).Tables[0].Rows[0];
				Dao.CloseConnection();
				Dao.Dispose();
				return dr;
			}
			catch
			{
				return null;
			}
		}
		
		public bool FillGrid1_GridColumn2_ComboBox(RadComboBox ComboBox, int NumberOfItems, string TextFilter, bool AllowFilter)
		{
			DataAccessObject Dao = Utility.GetDAO("25246FASTRAX");
			string DisplayFields = "cast(" + Dao.PoeColAspas("CLI_CODFASTRAX") + " as varchar) " + " + '-' + " + Dao.PoeColAspas("CLI_NOME");
			return Utility.FillComboBox(ComboBox, NumberOfItems, TextFilter, AllowFilter, 15, "TB_CLIENTE", DisplayFields, "CLI_CODFASTRAX", Dao, false, "", GComboBoxOnDemandStyle.Contains, "", false, "");
		}
		
		public DataRow Grid1_GridColumn3_ComboBox_GetComboItem(string Value)
		{
			try
			{
				DataAccessObject Dao = Utility.GetDAO("25246FASTRAX");
				DataRow dr = Dao.RunSql(String.Format("SELECT TOP 1 " + "cast(" + Dao.PoeColAspas("PROD_CODFASTRAX") + " as varchar) " + " + '-' + " + Dao.PoeColAspas("PROD_NOME") +  " as DISPLAY_FIELD, " + Dao.PoeColAspas("PROD_CODFASTRAX") + " FROM  " + Dao.PoeColAspas("TB_PRODUTO") + " WHERE " + Dao.PoeColAspas("PROD_CODFASTRAX") + " = '{0}'", Value)).Tables[0].Rows[0];
				Dao.CloseConnection();
				Dao.Dispose();
				return dr;
			}
			catch
			{
				return null;
			}
		}
		
		public bool FillGrid1_GridColumn3_ComboBox(RadComboBox ComboBox, int NumberOfItems, string TextFilter, bool AllowFilter)
		{
			DataAccessObject Dao = Utility.GetDAO("25246FASTRAX");
			string DisplayFields = "cast(" + Dao.PoeColAspas("PROD_CODFASTRAX") + " as varchar) " + " + '-' + " + Dao.PoeColAspas("PROD_NOME");
			return Utility.FillComboBox(ComboBox, NumberOfItems, TextFilter, AllowFilter, 15, "TB_PRODUTO", DisplayFields, "PROD_CODFASTRAX", Dao, false, "", GComboBoxOnDemandStyle.Contains, "", false, "");
		}


		
		public override string GetGridComboText(string GridColumnId, string FieldId)
		{
			DataTable dt;
			string Select = "";
			DataAccessObject Dao;
			string CboFilter = "";
			switch (GridColumnId)
			{
				case "Grid1_GridColumn2":
					Dao = Utility.GetDAO("25246FASTRAX");
					dt = Dao.RunSql(String.Format("SELECT " + "cast(" + Dao.PoeColAspas("CLI_CODFASTRAX") + " as varchar) " + " + '-' + " + Dao.PoeColAspas("CLI_NOME") + " FROM " + Dao.PoeColAspas("TB_CLIENTE") + " WHERE " + Dao.PoeColAspas("CLI_CODFASTRAX") + " = '{0}'", FieldId)).Tables[0];
					if (dt.Rows.Count > 0) return dt.Rows[0][0].ToString();
					return "";
				case "Grid1_GridColumn3":
					Dao = Utility.GetDAO("25246FASTRAX");
					dt = Dao.RunSql(String.Format("SELECT " + "cast(" + Dao.PoeColAspas("PROD_CODFASTRAX") + " as varchar) " + " + '-' + " + Dao.PoeColAspas("PROD_NOME") + " FROM " + Dao.PoeColAspas("TB_PRODUTO") + " WHERE " + Dao.PoeColAspas("PROD_CODFASTRAX") + " = '{0}'", FieldId)).Tables[0];
					if (dt.Rows.Count > 0) return dt.Rows[0][0].ToString();
					return "";
				default:
					return "";
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
	public class Clientes_Sugeridos_Grid1GridDataProvider : GeneralGridProvider
	{
		public DateTime ULT_COMPRAField;
		public long CLI_CODFASTRAXField;
		public long PROD_CODFASTRAXField;
		public double MEDIA_QTDField;
		public double MEDIA_VALORField;

		#region GeneralGridProvider Members

		public override int GetMaxProcessLanc()
		{
			return 1;
		}
		private _25246FASTRAX_VW_VENDAS_ULTCOMPDataProvider _DataProvider;
		
		public override GeneralDataProvider DataProvider
		{
			get
			{
				return _DataProvider;
			}
			set
			{
				_DataProvider = value as _25246FASTRAX_VW_VENDAS_ULTCOMPDataProvider;
			}
		}

		public Clientes_SugeridoPageProvider ParentPageProvider;
		
		public override string TableName { get { return "VW_VENDAS_ULTCOMP"; } }

		public override string DatabaseName { get { return "25246FASTRAX"; } }

		public override string FormID { get { return "32506"; } }
		
		public override void SetOldParameters(GeneralDataProviderItem Item)
		{
		}

		/// <summary>
		/// Valida se todos os campos do GRID foram preenchidos corretamente
		/// </summary>
		/// <param name="provider">Provider que vai ser usado para carregar os itens da página</param>
		public override bool Validate(GeneralDataProviderItem ProviderItem)
		{
			bool Accepted = false;
			try
			{
				Accepted =(ServerValidation.CheckNotEmpty(AliasVariables["ULT_COMPRAField"]));
			}
			catch (Exception)
			{
				Accepted = false;
			}
			if (!Accepted) { ProviderItem.Errors.Add("ServerValidationError:GridColumn1", "ULT_COMPRA não pode ser vazio!");}
			return (ProviderItem.Errors.Count == 0);
		}		
		
		#endregion

		public Clientes_Sugeridos_Grid1GridDataProvider(Clientes_SugeridoPageProvider ParentProvider)
		{
			ParentPageProvider = ParentProvider;
			DataProvider = new _25246FASTRAX_VW_VENDAS_ULTCOMPDataProvider(this, TableName, DatabaseName, "", "Clientes_Sugeridos_Grid1");
			MainProvider = this;
			MainProvider.DataProvider.PageProvider = this;
		}
		public _25246FASTRAX_VW_VENDAS_ULTCOMPItem GetDataProviderItem()
		{
			return GetDataProviderItem(MainProvider.DataProvider) as _25246FASTRAX_VW_VENDAS_ULTCOMPItem;
		}

		public override GeneralDataProviderItem GetDataProviderItem(GeneralDataProvider Provider)
		{
			if (Provider.Name == "Clientes_Sugeridos_Grid1")
			{
				return new _25246FASTRAX_VW_VENDAS_ULTCOMPItem(DatabaseName);
			}
			return null;
		}

		public override void RefreshParentProvider(GeneralProvider ParentProvider)
		{
		ParentPageProvider = (Clientes_SugeridoPageProvider)ParentProvider;
		}

		public override void InitializeAlias(GeneralDataProviderItem Item)
		{
			if (AliasVariables == null)
			{
				AliasVariables = new Dictionary<string, object>();
			}
			ULT_COMPRAField = Convert.ToDateTime(Item["ULT_COMPRA"].GetValue(),CultureInfo.CurrentCulture);
			if (AliasVariables.ContainsKey("ULT_COMPRAField"))
			{
				AliasVariables["ULT_COMPRAField"] = ULT_COMPRAField;
			}
			else
			{
				AliasVariables.Add("ULT_COMPRAField" ,ULT_COMPRAField);
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
			PROD_CODFASTRAXField = Convert.ToInt64(Item["PROD_CODFASTRAX"].GetValue(),CultureInfo.CurrentCulture);
			if (AliasVariables.ContainsKey("PROD_CODFASTRAXField"))
			{
				AliasVariables["PROD_CODFASTRAXField"] = PROD_CODFASTRAXField;
			}
			else
			{
				AliasVariables.Add("PROD_CODFASTRAXField" ,PROD_CODFASTRAXField);
			}
			try{MEDIA_QTDField = Convert.ToDouble(Item["MEDIA_QTD"].GetValue().ToString().Replace(".", ",") ,CultureInfo.CurrentCulture);}catch (Exception){}
			if (AliasVariables.ContainsKey("MEDIA_QTDField"))
			{
				AliasVariables["MEDIA_QTDField"] = MEDIA_QTDField;
			}
			else
			{
				AliasVariables.Add("MEDIA_QTDField" ,MEDIA_QTDField);
			}
			try{MEDIA_VALORField = Convert.ToDouble(Item["MEDIA_VALOR"].GetValue().ToString().Replace(".", ",") ,CultureInfo.CurrentCulture);}catch (Exception){}
			if (AliasVariables.ContainsKey("MEDIA_VALORField"))
			{
				AliasVariables["MEDIA_VALORField"] = MEDIA_VALORField;
			}
			else
			{
				AliasVariables.Add("MEDIA_VALORField" ,MEDIA_VALORField);
			}
			FillAuxiliarTables();
		}
		
		
		public override void GetTableIdentity()
		{
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
