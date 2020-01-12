using SQLite4Unity3d;
using System;
using System.Linq;
using Newtonsoft.Json;
using System.Collections.Generic;
using UnityEngine;

namespace SQLData
{
    public class ExampleData
    {
        [PrimaryKey, AutoIncrement]
        public int IdKey { get; set; }
        public string id { get; set; }

        public string customData { get; set; }

        public List<CustomDataClass> list;

        public void GetData()
        {
            list = JsonConvert.DeserializeObject<List<CustomDataClass>>(customData);
        }

        public void SetData()
        {

            customData = JsonConvert.SerializeObject(list);
        }

        public override string ToString()
        {



            return string.Format("[" +
                "ExampleData: " +
                "IdKey={0}, " +
                "id={1},  " +
                "customData={2},  " +
                "]",

                IdKey,
                id,
                customData
                );
        }

        public class CustomDataClass
        {

        }

    }
}
