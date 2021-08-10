namespace CentralSpecAPI.DTOs.Product
{
    public class ProductFilterDto : PaginationDto
    {
        public string Name { get; set; }

        public int StatusId { get; set; }

        public int ProductGroupId { get; set; }
        public string OrderingField { get; set; }

        public bool AscendingOrder { get; set; } = true;
    }
}