﻿namespace SignalR.DtoLayer.BasketDto
{
    public class ResultBasketListWithProductsDto
    {
        public int BasketID { get; set; }
        public decimal Price { get; set; }
        public int Count { get; set; }
        public decimal TotalPrice { get; set; }
        public int ProductID { get; set; }
        public int MenuTableID { get; set; }
        public string ProductName { get; set; }
    }
}
