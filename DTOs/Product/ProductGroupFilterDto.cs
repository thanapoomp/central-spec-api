namespace CentralSpecAPI.DTOs.Product
{
    public class ProductGroupFilterDto : PaginationDto
    {
        public string Name { get; set; }

        public int StatusId { get; set; }

        public string OrderingField { get; set; }

        public bool AscendingOrder { get; set; } = true;


    }
}