using Rest_Api_request.Interfaces;

namespace Rest_Api_request.Main_Classes
{
    class Category : ICategory
    {
        public string Name { get; set; }
        public int Id { get; set; }
    }
}
