namespace Rest_Api_request.Interfaces
{
    interface IProduct
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public int CategoryId { get; set; }
    }
}
