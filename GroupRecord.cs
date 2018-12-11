using System.Reflection;

namespace tom
{
    public class GroupRecord
    {
        public string GroupNumber { get; set; }
        public string LastName {get;set;}
        public string FirstName { get; set; }
        public string PaitentID { get; set; }
        public string Diagnosis { get; set; }
        public char Compound {get;set;}
        public string DrugName {get;set;}
        public string NDCNumber{get;set;}
        public string Pharmacy{get;set;}
        public int BinNumber {get;set;}
        public DateTime DateFilled {get;set;}
        public DateTime DateProcess {get;set;}
        public int Qty {get;set;}
        public int DS {get;set;}
        public int AWP {get;set;}
        public decimal Cost {get;set;}
        public decimal Fee {get;set;}
        public decimal SalesTax {get;set;}
        public decimal Copay {get;set;}
        public decmial UandC { get; set; }
        public decimal Due { get; set; }
        public decimal Savings {get;set;}
    }
    public GroupRecord(string groupNumber, string[] values){
        if(groupNumber.IsNullOrEmpty())
            return null;
        var retVal = new GroupRecord() {
            this.GroupNumber = groupNumber
        };
        values[0].ParseArrayToField<string>(retVal.LastName);
        values[1].ParseArrayToField<string>(retVal.LastName);
        values[2].ParseArrayToField<string>(retVal.PaitentID);
        values[3].ParseArrayToField<string>(retVal.Diagnosis);
        values[4].ParseArrayToField<string>(retVal.DrugName);
        values[5].ParseArrayToField<string>(retVal.NDCNumber);
        values[6].ParseArrayToField<string>(retVal.Pharmacy);
        values[7].ParseArrayToField<int>(retVal.BinNumber);
        values[8].ParseArrayToField<DateTime>(retVal.DateFilled);
        values[9].ParseArrayToField<DateTime>(retVal.DateProcess);
        values[10].ParseArrayToField<int>(retVal.Qty);
        values[11].ParseArrayToField<int>(retVal.DS);
        values[12].ParseArrayToField<decimal>(retVal.AWP);
        values[13].ParseArrayToField<decimal>(retVal.Cost);
        values[14].ParseArrayToField<decimal>(retVal.Fee);
        values[15].ParseArrayToField<decimal>(retVal.SalesTax);
        values[16].ParseArrayToField<decimal>(retVal.Copay);
        values[17].ParseArrayToField<decimal>(retVal.Due);
        values[18].ParseArrayToField<decimal>(retVal.UandC);
        values[19].ParseArrayToField<decimal>(retVal.Savings);

        return retVal;

    }
    private void ParseArrayToField<T>(this string value, T field){
        var converter = TypeDescriptor.GetConverter(typeof(T));
        if(converter != null){
            field = (T)converter.ConvertFromString(input);
        }
        else{
            field = default(T);
        }
    }
}
