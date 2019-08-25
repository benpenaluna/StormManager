using System;

namespace StormManager.Standard.Models.InformationSchema
{
    public class Routine
    {
        public string SPECIFIC_CATALOG { get; set; }
        public string SPECIFIC_SCHEMA { get; set; }
        public string SPECIFIC_NAME { get; set; }
        public string ROUTINE_CATALOG { get; set; }
        public string ROUTINE_SCHEMA { get; set; }
        public string ROUTINE_NAME { get; set; }
        public string ROUTINE_TYPE { get; set; }
        public string ROUTINE_BODY { get; set; }
        public string ROUTINE_DEFINITION { get; set; }
        public string IS_DETERMINISTIC { get; set; }
        public string SQL_DATA_ACCESS { get; set; }
        public string SCHEMA_LEVEL_ROUTINE { get; set; }
        public int MAX_DYNAMIC_RESULT_SETS { get; set; }
        public string IS_USER_DEFINED_CAST { get; set; }
        public string IS_IMPLICITLY_INVOCABLE { get; set; }
        public DateTime CREATED { get; set; }
        public DateTime LAST_ALTERED { get; set; }
    }
}
