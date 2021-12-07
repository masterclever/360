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
	public class Informe_de_Venta_por_LineaPageProvider : GeneralProvider
	{

		public Informe_de_Venta_por_LineaPageProvider(IGeneralDataProvider Provider)
		{
			MainProvider = Provider;
			MainProvider.DataProvider = new _25246FASTRAX_TB_PARAMETRODataProvider(MainProvider, MainProvider.TableName, MainProvider.DatabaseName, "", "Informe_de_Venta_por_Linea");
			MainProvider.DataProvider.PageProvider = this;
		}

		public override GeneralDataProviderItem GetDataProviderItem(GeneralDataProvider Provider)
		{
			if (Provider == MainProvider.DataProvider)
			{ 
				return new _25246FASTRAX_TB_PARAMETROItem(MainProvider.DatabaseName);
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


		/// <summary>
		/// Valida se todos os campos foram preenchidos corretamente
		/// </summary>
		/// <param name="provider">Provider que vai ser usado para carregar os itens da p?gina</param>
		public override bool Validate(GeneralDataProviderItem ProviderItem)
		{
			return (ProviderItem.Errors.Count == 0);
		}
		


	}

}
