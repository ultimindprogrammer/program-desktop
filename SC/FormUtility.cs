using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using SCLibrary;
using System;
using System.Data;
namespace SC
{
    public static class FormUtility
    {

        /// <summary>
        /// Buat Load dari database ke DataGrid yang dituju
        /// </summary>
        /// <param name="sqlCommand"></param>
        /// <param name="grid"></param>
        /// <param name="OnGridLoad"></param>
        public static void LoadDatabaseToGrid(string sqlCommand, GridControl grid, Action OnGridLoad)
        {
            GridView gridView = null;
            foreach (var v in grid.ViewCollection)
            {
                if (v is GridView)
                {
                    gridView = (GridView)v;
                    break;
                }
            }
            gridView.ShowLoadingPanel();
            DBSql.DoGetDataAsync(sqlCommand, delegate (DataSet dt)
            {
                grid.DataSource = dt;
                grid.DataMember = dt.Tables[0].TableName;
                gridView.OptionsView.ColumnAutoWidth = true;
                gridView.PopulateColumns();
                gridView.BestFitColumns(true);
                gridView.OptionsView.ColumnAutoWidth = false;
                gridView.HideLoadingPanel();
                OnGridLoad?.Invoke();
            });
        }
    }
}
