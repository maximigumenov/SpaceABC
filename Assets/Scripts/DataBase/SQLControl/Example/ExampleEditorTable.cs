using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SQLData
{
    public class ExampleEditorTable
    {
        private DataService dataService;

        public ExampleEditorTable(DataService dataService)
        {
            this.dataService = dataService;
        }


        public void SaveExampleData(ExampleData example)
        {
            example.SetData();
            dataService.AddObject<ExampleData>(example);
        }

        public ExampleData GetExampleData()
        {
            List<ExampleData> list = dataService._connection.Table<ExampleData>().Where(x => x.IdKey != 500).All();
            if (list.Count > 0)
            {
                list[0].GetData();
                return list[0];
            }
            return null;
        }

        public void UpdateExampleData(ExampleData example)
        {
            example.SetData();
            dataService.EditObject<ExampleData>(example);
        }
    }
}
