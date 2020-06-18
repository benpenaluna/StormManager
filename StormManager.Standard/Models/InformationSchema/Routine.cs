namespace StormManager.Standard.Models.InformationSchema
{
    public class Routine
    {
        public string TableName { get; set; }
        public string TransactionType { get; set; }
        public string StoredProcedureName { get; set; }
        public bool KeyInParameters { get; set; }
    }
}
