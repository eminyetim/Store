namespace Entities.RequestParameters
{
    public class ProductRequestParameters : RequestParameters // Bu sınıf product üzerinde arama yapmam için var.
    {

        public int? CategoryId{get ; set;}
        public int? MinPrice{get;set;} = 0;
        public int? MaxPrice{get;set;} = int.MaxValue;
        public bool IsValidPrice => MinPrice < MaxPrice;

        public int pageNumber {get ; set;}
        public int pageSize {get ; set;}

        //SearchTerm abstract classtan miras olarak alınıyor.

        public  ProductRequestParameters() : this(1,6) // This diğer constructer fonksiyonunu çağirir.
        {

        }    
        
        public ProductRequestParameters(int pageNumber, int pageSize)
        {
            this.pageNumber = pageNumber;
            this.pageSize = pageSize;
        }
    }
}